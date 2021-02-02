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
    public class ReponseCandidatRepository : AbstractRepository<ReponseCandidat>
    {
        private QueryBuilder queryBuilder;
        public ReponseCandidatRepository(QueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public override ReponseCandidat Create(ReponseCandidat obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> reponseCandidatDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idreponsecandidat" && pr.Name != "ActeurHasQuestion")
                {
                    reponseCandidatDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
                .Insert("reponse_candidat")
                .Values(reponseCandidatDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long rcId = cmd.LastInsertedId;
            obj.IdReponseCandidat = (int)rcId;
            connectionSql.Close();
            return obj;
        }

        //FIXIT : trouver une autre facon de recupere l'id car c'est pas generique
        public override int Delete(int id)
        {
            OpenConnection();
            //TODO : c'est pas bien ca
            string request = queryBuilder.Delete("reponse_candidat", id).Replace(" id", " id_reponse_candidat");
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override ReponseCandidat Find(int id)
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("reponse_candidat")
                .Where("id_reponse_candidat", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            ReponseCandidat rc = new ReponseCandidat();
            while (rdr.Read())
            {
                rc.IdReponseCandidat = rdr.GetInt32(0);
                rc.Libelle = rdr.GetString(1);
            }
            CloseConnection(rdr);
            return rc;
        }

        public override List<ReponseCandidat> FindAll()
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("reponse_candidat")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<ReponseCandidat> rcList = new List<ReponseCandidat>();

            while (rdr.Read())
            {
                ReponseCandidat rc = new ReponseCandidat();
                rc.IdReponseCandidat = rdr.GetInt32(0);
                rc.Libelle = rdr.GetString(1);
                rcList.Add(rc);
            }
            CloseConnection(rdr);
            return rcList;
        }

        public override ReponseCandidat Update(int id, ReponseCandidat obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> rcDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idreponsecandidat" && pr.Name != "ActeurHasQuestion" && pr.GetValue(obj) != null)
                {
                    rcDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
              .Update("reponse_candidat")
              .Set(rcDictionnary)
              .Where("id_reponse_candidat", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}
