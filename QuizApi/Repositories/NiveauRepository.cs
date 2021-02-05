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
    public class NiveauRepository : IRepository<Niveau>
    {
        private QuizContext context;
        private bool disposedValue;

        public NiveauRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Niveau obj = FindById(id);
            if (obj != null)
            {
                context.Niveau.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"NiveauRepository.Delete : l'élément {id} n'a pas été trouvé ");

        }

       
        public IEnumerable<Niveau> FindAll()
        {
            return context.Niveau;
        }

        public Niveau FindById(int id)
        {
            return context.Niveau.Find(id);
        }

        public void Insert(Niveau obj)
        {
            context.Niveau.Add(obj);
            Save();
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new RessourceException(StatusCodes.Status400BadRequest, $"NiveauRepository.Save : \n\tdoublon sur enregistrement \n\tou tentative de mise à jour d'un enregistrement inexistant.");
            }
        }

        public void Update(Niveau obj)
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
