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

        public QuestionService(QuestionRepository repository, VentillationRepository ventillationRepository)
        {
            this.repository = repository;
            this.ventillationRepository = ventillationRepository;
        }

        public QuestionDto Ajouter(QuestionDto obj)
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
                    taux = (ventilations[i].Valeur == null) ? 0 : (Convert.ToDouble(ventilations[i].Valeur)/100);
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
                        if ((listQuestionsDuNiveau==null) || (listQuestionsDuNiveau.Count() != nbQuestionsDuNiveau))
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

        internal QuestionSuivanteDto TrouverQuestionParQuizEtQuestion(int idQuiz, int numeroQuestion)
        {
            return this.repository.FindQuestionByQuizAndNumeroQuestion(idQuiz, numeroQuestion);
        }
    }
}
