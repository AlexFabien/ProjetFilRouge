using QuizApi.Dtos;
using QuizApi.Repositories;
using QuizApi.Utils;
using QuizApi.quiz;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace QuizApi.Services
{
    public class QuizService : IService<QuizDto>
    {
        private QuizRepository repository;
        private QuestionService questionService;
        private IService<ActeurDto> acteurService;
        public QuizService(QuizRepository repository, QuestionService questionService, IService<ActeurDto> acteurService)
        {
            this.repository = repository;
            this.questionService = questionService;
            this.acteurService = acteurService;
        }

        public QuizDto Ajouter(QuizDto obj)
        {
            return null;
        }
        public QuizDto CreerQuiz(CreatedQuizDto obj)
        {
            //using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Quiz leQuiz = null;
                    //TODO : vérifier le role du créateur
                    // retourner une liste de question (type_question, niveau, nbQuestions)
                    IEnumerable <Question> listQuestion = null;
                    if ((obj.IdTechnologie != null) && (obj.IdNiveau != null) && (obj.NbQuestions != null))
                        listQuestion = this.questionService.retourneListQuestion((int)obj.IdTechnologie, (int)obj.IdNiveau, (int)obj.NbQuestions);
                    
                    if (listQuestion?.Count() == obj.NbQuestions)
                    {
                        // Créer le quiz en Bdd dans un premier temps, afin de récupérer la pk
                        leQuiz = this.repository.Insert(obj);
                        // Ajouter le créateur du quiz
                        leQuiz.ActeurHasQuiz.Add(
                            new ActeurHasQuiz(obj.IdCreateur, leQuiz.IdQuiz)
                        );
                        int i = 0;
                        //TODO Ajouter de l'aléatoire dans la sélection des questions (actuellement dans l'ordre de la ventillation)
                        // Ajouter les questions au quiz
                        foreach (Question q in listQuestion)
                        {
                            i++;
                            q.IdQuiz = leQuiz.IdQuiz;
                            q.Numero = i;
                            leQuiz.Question.Add(q);
                        }
                        // Mettre à jout leQuiz en Bdd avec les nouvelles modifications
                        this.repository.Update(leQuiz);
                    }
                    if (leQuiz == null)
                        throw new RessourceException(StatusCodes.Status500InternalServerError, "QuizService.Ajouter : Erreur lors de la création du quiz !");
                    QuizDto leQuizDto = leQuiz;
                    leQuizDto.NbQuestions = obj.NbQuestions;
                    return leQuizDto;

                    //Without this line, no changes will get applied to the database
                    //transaction.Commit();
                }
                catch (Exception ex)
                {
                    //There is no need to call transaction.Rollback() here as the transaction object
                    //will go out of scope and disposing will roll back automatically
                    throw ex;
                }
            }
        }

        internal StartQuizDto StartQuiz(int idQuiz, int idCandidate)
        {
            //TODO Vérifier que le candidat est positionné sur le quiz
            Quiz quiz = this.repository.FindById(idQuiz);
            Acteur candidat = this.acteurService.TrouverParId(idCandidate);
            int nbQuestions = this.questionService.NbQuestionsDuQuiz(idQuiz);
            StartQuizDto startQuizDto = new StartQuizDto(quiz.Libelle, quiz.IdTechnologie, quiz.IdNiveau, nbQuestions, candidat);
            return startQuizDto;
        }

        public ReponseBody AjouterCandidats(int id, List<ActeurIdCandidat> listCandidats)
        {
            try
            {
                Quiz leQuiz = this.repository.FindById(id);
                //TODO : vérifier le role des candidats
                // Ajouter les candidats au quiz
                listCandidats.ForEach(a =>
                leQuiz.ActeurHasQuiz.Add(
                    new ActeurHasQuiz(a.IdCandidat, leQuiz.IdQuiz)
                ));
                this.repository.Update(leQuiz);
                return new ReponseBody(true, "Les candidats ont été ajoutés au quiz.");
            }
            catch (Exception)
            {
                return new ReponseBody(false, "Les candidats n'ont pas été ajoutés au quiz.");
            }
        }

        public void Modifier(QuizDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public QuizDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<QuizDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListQuizToListQuizDto(this.repository?.FindAll()?.ToList());
        }

        public IEnumerable<GetAllQuizDto> TrouverToutAvecNiveauTechno()
        {
            return ConvertDtoEntity.ConvertListQuizToListGetAllQuizDto(this.repository?.FindAllWithLevelTechno()?.ToList());
        }

        internal IEnumerable<Acteur2Dto> TrouverTousLesUtilisateursDuQuiz(int id)
        {
            IEnumerable<Acteur> listActeur = this.repository?.TrouverTousLesUtilisateursDuQuiz(id);
            if (listActeur == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"QuizService.TrouverTousLesUtilisateursDuQuiz : Pas d'utilisateurs trouvés pour le quiz n° {id}.");
            return ConvertDtoEntity.ConvertListActeurToListActeur2Dto(listActeur?.ToList());
        }
    }
}
