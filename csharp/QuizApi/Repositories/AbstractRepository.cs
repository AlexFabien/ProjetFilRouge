using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace QuizApi.Repositories
{
    public abstract class AbstractRepository<T>    
    {
        public MySqlConnection connectionSql = Utils.ConnectionSql.GetConnection();

        /// <summary>
        /// Ajoute un objet
        /// </summary>
        /// <param name="obj">Objet a ajouter</param>
        /// <returns>Retourne le nouvel objet</returns>
        public abstract T Create(T obj);

        /// <summary>
        /// Supprime un objet
        /// </summary>
        /// <param name="id">id de l'objet a supprimer</param>
        /// <returns>1 si reussi sinon 0</returns>
        public abstract int Delete(int id);

        /// <summary>
        /// Recupere un objet
        /// </summary>
        /// <param name="id"> id de l'objet</param>
        /// <returns>Retourne un objet</returns>
        public abstract T Find(int id);

        /// <summary>
        /// Recupere tous les objets
        /// </summary>
        /// <returns>List<T></returns>
        public abstract List<T> FindAll();

        /// <summary>
        /// Modifie un objet
        /// </summary>
        /// <param name="id">id de l'objet a modifier</param>
        /// <param name="obj">Nouvel objet</param>
        /// <returns></returns>
        public abstract T Update(int id, T obj);

        public void OpenConnection ()
        {
            Console.WriteLine("Connecting to MySQL...");
            connectionSql.Open();       
        }
        
        public void CloseConnection (MySqlDataReader reader)
        {
            Console.WriteLine("Close MySQL...");
            reader.Close();
            connectionSql.Close();       
        }
    }
}
