using QuizApi.Dtos;
using QuizApi.Repositories;
using QuizApi.Utils;
using QuizApi.quiz;
using System;
using System.Linq;
using System.Collections.Generic;

namespace QuizApi.Services
{
    public class QuizService : IService<QuizDto>
    {
        private QuizRepository repository;
        public QuizService(QuizRepository repository)
        {
            this.repository = repository;
        }

        public QuizDto Ajouter(QuizDto obj)
        {
            //using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // retourner une liste de question (type_question, niveau, nbQuestions)
                    IEnumerable<Question> listQuestion = null;
                    if ((obj.IdTechnologie != null) && (obj.IdNiveau != null) && (obj.NbQuestions != null))
                        listQuestion = this.repository.retourneListQuestion((int)obj.IdTechnologie, (int)obj.IdNiveau, (int)obj.NbQuestions);
                    // prendre en compte la répartition des questions en fonction du niveau du quiz
                    // Gérer si la répartition n'existe pas.
                    // Prendre en compte le nombre de question max en Bdd
                    // Gérer s'il ne reste pas assez de question.
                    
                    // Créer le quiz en Bdd dans un premier temps, afin de récupérer la pk
                    Quiz leQuiz = this.repository.Insert(obj);
                    // Ajouter le créateur du quiz
                    leQuiz.ActeurHasQuiz.Add(
                        new ActeurHasQuiz(1, leQuiz.IdQuiz)
                    );
                    // Ajouter les questions au quiz
                    foreach (Question q in listQuestion)
                    {
                        q.IdQuiz = leQuiz.IdQuiz;
                        leQuiz.Question.Add(q);
                    }
                    // Mettre à jout leQuiz en Bdd avec les nouvelles modifications
                    this.repository.Update(leQuiz);
                    return leQuiz;

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
    }
}
