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
    public class ParametrageRepository : IRepository<Parametrage>
    {
        private QuizContext context;

        private bool disposedValue;

        public ParametrageRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Parametrage obj = FindById(id);
            if (obj != null)
            {
                context.Parametrage.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"ParametrageRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Parametrage> FindAll()
        {
            return context.Parametrage;
        }

        public Parametrage FindById(int id)
        {
            return context.Parametrage.Find(id);
        }

        public void Insert(Parametrage obj)
        {
            context.Parametrage.Add(obj);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Parametrage obj)
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
