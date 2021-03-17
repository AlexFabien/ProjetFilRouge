using MySql.Data.MySqlClient;
using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace QuizApi.Repositories
{
    public class ActeurHasQuestionRepository : IRepository<ActeurHasQuestion>
    {
        private QuizContext context;

        private bool disposedValue;

        public ActeurHasQuestionRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            ActeurHasQuestion obj = FindById(id);
            if (obj != null)
            {
                context.ActeurHasQuestion.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"ActeurHasQuestionRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<ActeurHasQuestion> FindAll()
        {
            return context.ActeurHasQuestion;
        }

        public ActeurHasQuestion FindById(int id)
        {
            ActeurHasQuestion obj = context.ActeurHasQuestion.Find();
            if (obj == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"ActeurHasQuestionRepository.FindById : l'élément {id} n'a pas été trouvé ");
            return obj;
        }

        public ActeurHasQuestion Insert(ActeurHasQuestion obj)
        {
            context.ActeurHasQuestion.Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(ActeurHasQuestion obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        internal ActeurHasQuestion ReponseQuestionAvecEtat(int idQuestion, int idCandidat)
        {
            return context.ActeurHasQuestion
                .Where(a => a.IdQuestion == idQuestion)
                .Where(a => a.IdActeur == idCandidat)
                .Include(a => a.ReponseCandidat)
                .SingleOrDefault();
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
        // ~ActeurHasQuestionRepository()
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
