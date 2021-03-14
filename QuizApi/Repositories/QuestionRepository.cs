using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApi.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private QuizContext context;
        private bool disposedValue;

        public QuestionRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Question obj = FindById(id);
            if (obj != null)
            {
                context.Question.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"QuestionRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Question> FindAll()
        {
            return context.Question;
        }

        public Question FindById(int id)
        {
            return context.Question.Find(id);
        }

        public Question Insert(Question obj)
        {
            context.Question.Add(obj);
            Save();
            return obj;
        }

        internal IEnumerable<Question> retourneListQuestion(int idTechnologie, int idNiveau, int nbQuestions)
        {
            return context.Question.Where(q => q.IdTechnologie == idTechnologie && q.IdNiveau == idNiveau && q.IdQuiz == null).Take(nbQuestions);
        }

        internal Question FindQuestionByQuizAndNumeroQuestion(int idQuiz, int numeroQuestion)
        {
            try
            {
                Question question = context.Question
                    .Where(q => q.IdQuiz == idQuiz)
                    .Where(q => q.Numero == numeroQuestion)
                    .Include(q => q.Reponse)
                    .First();
                if (question?.Reponse.Count() == 0)
                    throw new RessourceException(StatusCodes.Status404NotFound, $"QuestionRepository.FindQuestionByQuizAndNumeroQuestion : " +
                    $"les réponses pour la question n° {numeroQuestion} du quiz n° {idQuiz} n'ont pas été trouvées.");
                return question;
            }
            catch(RessourceException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new RessourceException(StatusCodes.Status404NotFound, $"QuestionRepository.FindQuestionByQuizAndNumeroQuestion : " +
                    $"la question n° {numeroQuestion} du quiz n° {idQuiz} n'a pas été trouvée.");
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new RessourceException(StatusCodes.Status400BadRequest, $"QuestionRepository.Save : \n\tdoublon sur enregistrement \n\tou tentative de mise à jour d'un enregistrement inexistant.");
            }
        }

        public void Update(Question obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    context.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~ParametrageRepository()
        // {
        //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
