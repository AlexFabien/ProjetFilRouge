using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace QuizApi.Repositories
{
    public class VentillationRepository : IRepository<Ventillation>
    {
        private QuizContext context;

        private bool disposedValue;

        public VentillationRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Ventillation obj = FindById(id);
            if (obj != null)
            {
                context.Ventillation.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"VentillationRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Ventillation> FindAll()
        {
            return context.Ventillation;
        }

        public Ventillation FindById(int id)
        {
            Ventillation obj = context.Ventillation.Find(id);
            if (obj == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"VentillationRepository.FindById : l'élément {id} n'a pas été trouvé ");
            return obj;
        }

        public Ventillation Insert(Ventillation obj)
        {
            context.Ventillation.Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        internal List<Ventillation> retourneVentillation(int idNiveau)
        {
            return context.Ventillation.Where(v => v.IdNiveauQuiz == idNiveau).ToList();
        }

        public void Update(Ventillation obj)
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
        // ~VentillationRepository()
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
