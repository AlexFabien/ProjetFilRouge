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
    public class QuestionRepository : AbstractRepository<Question>
    {
        private QueryBuilder queryBuilder;
        public QuestionRepository(QueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public override Question Create(Question obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> questionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id_quetion" 
                    && pr.Name != "Question" 
                    && pr.Name != "fk_Questions_Niveau1_idx"
                    && pr.Name != "fk_Questions_TypeQuestion1_idx")
                {
                    questionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
                .Insert("question")
                .Values(questionDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long questionId = cmd.LastInsertedId;
            obj.IdQuestion = (int)questionId;
            connectionSql.Close();
            return obj;
        }

        //FIXIT : trouver une autre facon de recupere l'id car c'est pas generique
        public override int Delete(int id)
        {
            OpenConnection();
            //TODO : c'est pas bien ca
            string request = queryBuilder.Delete("question", id).Replace("id", "id_question");
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Question Find(int id)
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("question")
                .Where("id_question", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Question question = new Question();
            while (rdr.Read())
            {
                question.IdQuestion = rdr.GetInt32(0);
                question.Libelle = rdr.GetString(1);
                question.ExplicationReponse = rdr.GetString(2);
                question.IdNiveau = rdr.GetInt32(3);
                question.IdTypeQuestion = rdr.GetInt32(4);
            }
            CloseConnection(rdr);
            return question;
        }

        public override List<Question> FindAll()
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("question")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Question> questions = new List<Question>();

            while (rdr.Read())
            {
                Question question = new Question();
                question.IdNiveau = rdr.GetInt32(0);
                question.Libelle = rdr.GetString(1);
                questions.Add(question);
            }
            CloseConnection(rdr);
            return questions;
        }

        public override Question Update(int id, Question obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> questionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id_quetion"
                    && pr.Name != "Question"
                    && pr.Name != "fk_Questions_Niveau1_idx"
                    && pr.Name != "fk_Questions_TypeQuestion1_idx"
                    && pr.GetValue(obj) != null)
                {
                    questionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
              .Update("question")
              .Set(questionDictionnary)
              .Where("id_quetion", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}
