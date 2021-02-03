using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuizApi.Repositories
{
    public class TechnologieRepository: IRepository<Technologie>
    {
        private QuizContext context;

        private bool disposedValue;

        public TechnologieRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Technologie obj = FindById(id);
            if (obj != null)
            {
                context.Technologie.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"TechnologieRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Technologie> FindAll()
        {
            return context.Technologie;
        }

        public Technologie FindById(int id)
        {
            return context.Technologie.Find(id);
        }

        public void Insert(Technologie obj)
        {
            context.Technologie.Add(obj);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Technologie obj)
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
