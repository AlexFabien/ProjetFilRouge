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
    public class ReponduRepository : AbstractRepository<Repondu>
    {
        private QueryBuilder queryBuilder;
        public ReponduRepository(QueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public override Repondu Create(Repondu obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> reponduDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idEtatReponse")
                {
                    reponduDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
                .Insert("repondu")
                .Values(reponduDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            Console.WriteLine(request);
            cmd.ExecuteNonQuery();
            long etat_reponseId = cmd.LastInsertedId;
            obj.IdEtatReponse = (int)etat_reponseId;
            connectionSql.Close();
            return obj;
        }

        //FIXIT : trouver une autre facon de recupere l'id car c'est pas generique
        public override int Delete(int id)
        {
            OpenConnection();
            //TODO : c'est pas bien ca
            string request = queryBuilder.Delete("repondu", id).Replace("id", "idEtatReponse");
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Repondu Find(int id)
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("repondu")
                .Where("idEtatReponse", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Repondu reponduEntity = new Repondu();
            while (rdr.Read())
            {
                reponduEntity.IdEtatReponse = rdr.GetInt32(0);
                reponduEntity.Libelle = rdr.GetString(1);
            }
            CloseConnection(rdr);
            return reponduEntity;
        }

        public override List<Repondu> FindAll()
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("repondu")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Repondu> reponduEntities = new List<Repondu>();

            while (rdr.Read())
            {
                Repondu reponduEntity = new Repondu();
                reponduEntity.IdEtatReponse = rdr.GetInt32(0);
                reponduEntity.Libelle = rdr.GetString(1);
                reponduEntities.Add(reponduEntity);
            }
            CloseConnection(rdr);
            return reponduEntities;
        }

        public override Repondu Update(int id, Repondu obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> reponduDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idEtatReponse" && pr.GetValue(obj) != null)
                {
                    reponduDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
              .Update("repondu")
              .Set(reponduDictionnary)
              .Where("idEtatReponse", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}

