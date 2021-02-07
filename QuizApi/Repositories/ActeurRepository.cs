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
    public class ActeurRepository : IRepository<Acteur>
    {
        private QuizContext context;

        private bool disposedValue;

        public ActeurRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Acteur obj = FindById(id);
            if (obj != null)
            {
                context.Acteur.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"ActeurRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Acteur> FindAll()
        {
            return context.Acteur;
        }

        public Acteur FindById(int id)
        {
            Acteur obj = context.Acteur.Find(id);
            if (obj == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"ActeurRepository.FindById : l'élément {id} n'a pas été trouvé ");
            return obj;
        }

        public Acteur Insert(Acteur obj)
        {
            context.Acteur.Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Acteur obj)
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
        // ~ActeurRepository()
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
