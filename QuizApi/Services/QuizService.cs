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
        public QuizService(QuizRepository repository, QuestionService questionService)
        {
            this.repository = repository;
            this.questionService = questionService;
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
                        // Ajouter les questions au quiz
                        foreach (Question q in listQuestion)
                        {
                            q.IdQuiz = leQuiz.IdQuiz;
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

        internal IEnumerable<Acteur2Dto> TrouverTousLesUtilisateursDuQuiz(int id)
        {
            IEnumerable<Acteur> listActeur = this.repository?.TrouverTousLesUtilisateursDuQuiz(id);
            if (listActeur == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"QuizService.TrouverTousLesUtilisateursDuQuiz : Pas d'utilisateurs trouvés pour le quiz n° {id}.");
            return ConvertDtoEntity.ConvertListActeurToListActeur2Dto(listActeur?.ToList());
        }

        internal object AjouterCandidats(int id)
        {
            throw new NotImplementedException();
        }
    }
}
