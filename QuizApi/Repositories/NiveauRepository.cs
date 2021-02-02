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
    public class NiveauRepository : AbstractRepository<Niveau>
    {
        private QueryBuilder queryBuilder;
        public NiveauRepository(QueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public override Niveau Create(Niveau obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> roleDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idniveau" 
                    && pr.Name != "Question" 
                    && pr.Name != "Quiz" 
                    && pr.Name != "VentillationIdNiveauQuestionNavigation" 
                    && pr.Name != "VentillationIdNiveauQuizNavigation")
                {
                    roleDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
                .Insert("niveau")
                .Values(roleDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long niveauId = cmd.LastInsertedId;
            obj.IdNiveau = (int)niveauId;
            connectionSql.Close();
            return obj;
        }

        //FIXIT : trouver une autre facon de recupere l'id car c'est pas generique
        public override int Delete(int id)
        {
            OpenConnection();
            //TODO : c'est pas bien ca
            string request = queryBuilder.Delete("niveau", id).Replace("id", "id_niveau");
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Niveau Find(int id)
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("niveau")
                .Where("id_niveau", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Niveau niveau = new Niveau();
            while (rdr.Read())
            {
                niveau.IdNiveau = rdr.GetInt32(0);
                niveau.Libelle = rdr.GetString(1);
            }
            CloseConnection(rdr);
            return niveau;
        }

        public override List<Niveau> FindAll()
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("niveau")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Niveau> niveaux = new List<Niveau>();

            while (rdr.Read())
            {
                Niveau niveau = new Niveau();
                niveau.IdNiveau = rdr.GetInt32(0);
                niveau.Libelle = rdr.GetString(1);
                niveaux.Add(niveau);
            }
            CloseConnection(rdr);
            return niveaux;
        }

        public override Niveau Update(int id, Niveau obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> niveauDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idniveau"
                    && pr.Name != "Question"
                    && pr.Name != "Quiz"
                    && pr.Name != "VentillationIdNiveauQuestionNavigation"
                    && pr.Name != "VentillationIdNiveauQuizNavigation"
                    && pr.Name != "Acteur"
                    && pr.GetValue(obj) != null)
                {
                    niveauDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
              .Update("niveau")
              .Set(niveauDictionnary)
              .Where("id_niveau", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}
