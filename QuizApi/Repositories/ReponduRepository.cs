using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuizApi.Repositories
{
    public class ReponduRepository : IRepository<Repondu>
    {
        private QuizContext context;

        private bool disposedValue;

        public ReponduRepository (QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Repondu obj = FindById(id);
            if (obj != null)
            {
                context.Repondu.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"ReponduRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Repondu> FindAll()
        {
            return context.Repondu;
        }

        public Repondu FindById(int id)
        {
            return context.Repondu.Find(id);
        }

        public Repondu Insert(Repondu obj)
        {
            context.Repondu.Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Repondu obj)
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

