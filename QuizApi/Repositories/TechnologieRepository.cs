using MySql.Data.MySqlClient;
using QuizApi.Entities;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuizApi.Repositories
{
    public class TechnologieRepository: AbstractRepository<TechnologieEntity>
    {
        private QueryBuilder _queryBuilder;

        public TechnologieRepository ( QueryBuilder queryBuilder)
        {
             this._queryBuilder = queryBuilder;
             
        }

        public override TechnologieEntity Create(TechnologieEntity obj)
        {
           
            this.OpenConnection();
            Dictionary<string, dynamic> technologieEntityDictionnary  = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id_technologie")
                {
                    technologieEntityDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("technologie")
                .Values(technologieEntityDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            Console.WriteLine(request);
            cmd.ExecuteNonQuery();
            long technologieEntityId   = cmd.LastInsertedId;
            obj.Id_Technologie = (int) technologieEntityId;
            connectionSql.Close();
            return obj;
        }

        

        public override int Delete(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("technologie",id).Replace("id", "id_technologie");
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override TechnologieEntity Find(int idTechnologie)
        {
            OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("technologie")
                .Where("id_technologie", idTechnologie, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            TechnologieEntity technologieEntity = new TechnologieEntity();
            while (rdr.Read())
            {
                technologieEntity.Id_Technologie = rdr.GetInt32(0);
                technologieEntity.Libelle= rdr.GetString(1);
            }
            CloseConnection(rdr);
            return technologieEntity;
        }

        

        public override List<TechnologieEntity> FindAll()
        {
            OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("technologie")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<TechnologieEntity> technologieEntities = new List<TechnologieEntity>();

            while (rdr.Read())
            {
                TechnologieEntity technologieEntity = new TechnologieEntity();
                technologieEntity.Id_Technologie = rdr.GetInt32(0);
                technologieEntity.Libelle = rdr.GetString(1);
                technologieEntities.Add(technologieEntity);
            }
            CloseConnection(rdr);
            return technologieEntities;
        }

        public override TechnologieEntity Update(int idTechnologie, TechnologieEntity obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> technologieEntityDictionnary  = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id_technologie" && pr.GetValue(obj) != null)
                {
                    technologieEntityDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("technologie")
              .Set(technologieEntityDictionnary)
              .Where("id_technologie", idTechnologie).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(idTechnologie);
        }

        
    }
}
