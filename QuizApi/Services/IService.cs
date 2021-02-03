using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    interface IService<T>
    {
        /// <summary>
        /// Méthode qui retourne la liste de toutes les T(DTO)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> TrouverTout();

        /// <summary>
        /// Méthode qui retourne la T(DTO) qui a pour id : {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T TrouverParId(int id);

        /// <summary>
        /// Méthode qui ajoute une T à la base de données
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Ajouter(T obj);

        /// <summary>
        /// Méthode qui supprime la T qui a pour id : {id} de la base de données
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Supprimer(int id);

        /// <summary>
        /// Méthode qui modifie une obj
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Modifier(T obj);
    }

}
