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
    public class TypeQuestionRepository : IRepository<TypeQuestion>
    {
        private QuizContext context;

        private bool disposedValue;

        public TypeQuestionRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            TypeQuestion obj = FindById(id);
            if (obj != null)
            {
                context.TypeQuestion.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"TypeQuestionRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<TypeQuestion> FindAll()
        {
            return context.TypeQuestion;
        }

        public TypeQuestion FindById(int id)
        {
            TypeQuestion obj = context.TypeQuestion.Find(id);
            if (obj == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"TypeQuestionRepository.FindById : l'élément {id} n'a pas été trouvé ");
            return obj;
        }

        public TypeQuestion Insert(TypeQuestion obj)
        {
            context.TypeQuestion.Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(TypeQuestion obj)
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
        // ~TypeQuestionRepository()
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
