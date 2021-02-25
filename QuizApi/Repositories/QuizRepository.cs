using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace QuizApi.Repositories
{
    public class QuizRepository : IRepository<Quiz>
    {
        private QuizContext context;

        private bool disposedValue;

        public QuizRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Quiz obj = FindById(id);
            if (obj != null)
            {
                context.Quiz.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"QuizRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Quiz> FindAll()
        {
            return context.Quiz;
        }

        public Quiz FindById(int id)
        {
            Quiz obj = context.Quiz.Find(id);
            if (obj == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"QuizRepository.FindById : l'élément {id} n'a pas été trouvé ");
            return obj;
        }

        public Quiz Insert(Quiz obj)
        {
            context.Quiz.Add(obj);
            Save();
            return obj;
        }

        internal IEnumerable<Acteur> TrouverTousLesUtilisateursDuQuiz(int id)
        {
            return context.Quiz.Where(q => q.IdQuiz == id)?
                .Include(q => q.ActeurHasQuiz)
                .ThenInclude(a => a.IdActeurNavigation)
                .Select(q => q.ActeurHasQuiz.Where(a => a.IdActeurNavigation.IdRole == 3).Select(a => a.IdActeurNavigation))
                .FirstOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Quiz obj)
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
        // ~QuizRepository()
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
