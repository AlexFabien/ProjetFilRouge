using Microsoft.AspNetCore.Http;
using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApi.Services
{
    public class QuestionService : IService<QuestionDto>
    {
        private QuestionRepository repository;
        private VentillationRepository ventillationRepository;
        private ActeurHasQuestionRepository acteurHasQuestionRepository;

        public QuestionService(QuestionRepository repository, VentillationRepository ventillationRepository, ActeurHasQuestionRepository acteurHasQuestionRepository)
        {
            this.repository = repository;
            this.ventillationRepository = ventillationRepository;
            this.acteurHasQuestionRepository = acteurHasQuestionRepository;
        }

        public QuestionDto Ajouter(QuestionDto obj)
        {
            return this.repository.Insert(obj);
        }

        public QuestionAvecReponseDto Ajouter(CreatedQuestionDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(QuestionDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public QuestionDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<QuestionDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListQuestionToListQuestionDto(this.repository?.FindAll()?.ToList());
        }

        public int NbQuestionsDuQuiz(int idQuiz)
        {
            return this.repository.NbQuestionsDuQuiz(idQuiz);
        }

        internal IEnumerable<Question> retourneListQuestion(int idTechnologie, int idNiveau, int nbQuestions)
        {
            IEnumerable<Question> listQuestions = null;
            // prendre en compte la répartition des questions en fonction du niveau du quiz
            List<Ventillation> ventilations = this.ventillationRepository.retourneVentillation(idNiveau);

            // Gérer si la répartition n'existe pas.
            if (ventilations?.Count > 0)
            {
                int totalQuestions = 0;
                double taux;
                int nbQuestionsDuNiveau;
                for (int i = 0; i < ventilations.Count; i++)
                {
                    taux = (ventilations[i].Valeur == null) ? 0 : (Convert.ToDouble(ventilations[i].Valeur) / 100);
                    // On arrondi à l'inférieur ici ...
                    nbQuestionsDuNiveau = Convert.ToInt32(Math.Floor(taux * nbQuestions));
                    totalQuestions += nbQuestionsDuNiveau;

                    if ((i == ventilations.Count - 1) && (totalQuestions != nbQuestions))
                    {
                        // ... et au dernier tour de boucle, on récupère le reste des questions.
                        nbQuestionsDuNiveau += (nbQuestions - totalQuestions);
                    }

                    if (nbQuestionsDuNiveau > 0)
                    {
                        IEnumerable<Question> listQuestionsDuNiveau = this.repository.retourneListQuestion(idTechnologie, ventilations[i].IdNiveauQuestion, nbQuestionsDuNiveau);
                        // Gérer s'il ne reste pas assez de question.
                        if ((listQuestionsDuNiveau == null) || (listQuestionsDuNiveau.Count() != nbQuestionsDuNiveau))
                        {
                            throw new RessourceException(StatusCodes.Status500InternalServerError, $"QuestionService.retourneListQuestion : Pas assez de questions de la technologie n° {idTechnologie} " +
                                                                                                    $"et du niveau {ventilations[i].IdNiveauQuestion} !");
                        }
                        if (listQuestions == null)
                            listQuestions = listQuestionsDuNiveau;
                        else listQuestions = listQuestions.Concat(listQuestionsDuNiveau);
                    }
                }
            }
            return listQuestions;
        }

        public ReponseBody AjouterReponsesCandidat(int idQuestion, int idCandidat, CreatedActeurHasQuestionDto createdActeurHasQuestionDto)
        {
            try
            {
                Question laQuestion = this.repository.FindById(idQuestion);
                if (laQuestion == null)
                    throw new RessourceException(StatusCodes.Status404NotFound, $"QuestionService.AjouterReponsesCandidat : la question n° {idQuestion} n'a pas été trouvé ");
                // Ajouter les réponses à la question
                //laQuestion.ActeurHasQuestion.Add(createdActeurHasQuestionDto);
                laQuestion.ActeurHasQuestion.Add(
                    new ActeurHasQuestion(idCandidat,
                                            idQuestion,
                                            createdActeurHasQuestionDto.Commentaire,
                                            createdActeurHasQuestionDto.IdEtatReponse,
                                            ConvertDtoEntity.ConvertListCreatedReponseCandidatDtoToListReponseCandidat(createdActeurHasQuestionDto.ReponsesCandidat))
                );
                this.repository.Update(laQuestion);
                return new ReponseBody(true, "La réponse a été enregistré.");
            }
            catch (Exception e)
            {
                return new ReponseBody(false, "La réponse n'a pas été enregistré.");
            }
        }

        internal ICollection<ResultReponseCandidatDto> RetourneResultatQuiz(int idQuiz, int idCandidat)
        {
            ResultReponseCandidatDto resultOK = new ResultReponseCandidatDto("Réponse OK", 0);
            ResultReponseCandidatDto resultPasse = new ResultReponseCandidatDto("Réponse Passe", 0);
            ResultReponseCandidatDto resultKO = new ResultReponseCandidatDto("Réponse KO", 0);
            List<Question> listQuestion = this.repository.retourneListQuestion(idQuiz)?.ToList();
            listQuestion.ForEach(q =>
                {
                    ActeurHasQuestion acteurHasQuestion = this.acteurHasQuestionRepository.ReponseQuestionAvecEtat(q.IdQuestion, idCandidat);
                    if (acteurHasQuestion == null)
                        throw new RessourceException(StatusCodes.Status404NotFound, $"QuestionService.RetourneResultatQuiz : Pas de réponse trouvé pour la question n° {q.IdQuestion} du candidat n° {idCandidat}.");
                    if (acteurHasQuestion.IdEtatReponse == 1) // En Attente de traitement
                    {
                        // On va vérifier si la réponse est correcte
                        if (q.IdTypeQuestion == 1) // Choix unique
                        {
                            if (q.Reponse.Where(r => r.ReponseCorrecte == 1).First().IdReponse == Convert.ToInt32(acteurHasQuestion.ReponseCandidat.First().Libelle))
                                acteurHasQuestion.IdEtatReponse = 3; // Réponse correcte
                            else acteurHasQuestion.IdEtatReponse = 4; // Reponse incorrecte
                            // TODO : MAJ en Bdd
                        }
                        else if (q.IdTypeQuestion == 2) // Choix multiple
                        {
                            bool result = false;
                            List<Reponse> listRepOK = q.Reponse.Where(r => r.ReponseCorrecte == 1).ToList();
                            // On parcourt la réponse correcte
                            for (int i = 0; i < listRepOK.Count; i++)
                            {
                                result = false;
                                // On compare avec les réponses du candidat
                                acteurHasQuestion.ReponseCandidat.ToList().ForEach(r =>
                                {
                                    if (Convert.ToInt32(r.Libelle) == listRepOK[i].IdReponse)
                                    {
                                        result = true;
                                    }
                                });
                                if (!result) // Si pas retrouvé, la réponse du candidat est KO
                                    break;
                            }
                            if (result)
                                acteurHasQuestion.IdEtatReponse = 3; // Réponse correcte
                            else acteurHasQuestion.IdEtatReponse = 4; // Reponse incorrecte
                            // TODO : MAJ en Bdd
                        }
                    }
                    _ = (acteurHasQuestion.IdEtatReponse == 2) ? resultPasse.Total++ :
                                                                (acteurHasQuestion.IdEtatReponse == 3) ? resultOK.Total++ : resultKO.Total++;

                    //switch (acteurHasQuestion.IdEtatReponse)
                    //{
                    //    case 2:
                    //        resultPasse.Total++;
                    //        break;
                    //    case 3:
                    //        resultOK.Total++;
                    //        break;
                    //    case 4:
                    //        resultKO.Total++;
                    //        break;

                    //    default:
                    //        break;
                    //}
                });
            List<ResultReponseCandidatDto> toto = new List<ResultReponseCandidatDto>
            {
                resultOK,
                resultKO,
                resultPasse
            };
            return toto;
        }

        internal QuestionSuivanteDto TrouverQuestionParQuizEtQuestion(int idQuiz, int numeroQuestion)
        {
            return this.repository.FindQuestionByQuizAndNumeroQuestion(idQuiz, numeroQuestion);
        }
    }
}
