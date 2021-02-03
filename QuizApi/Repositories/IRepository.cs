using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Méthode qui retourne la liste de toutes les T(DTO)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll();

        /// <summary>
        /// Méthode qui retourne la T(DTO) qui a pour id : {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(int id);

        /// <summary>
        /// Méthode qui ajoute une T à la base de données
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Insert(T obj);

        /// <summary>
        /// Méthode qui supprime la T qui a pour id : {id} de la base de données
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id);

        /// <summary>
        /// Méthode qui modifie une T
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Update(T obj);

        public void Save();
    }

}
