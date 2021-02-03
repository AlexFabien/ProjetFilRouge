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
    public class ReponseRepository: AbstractRepository<Reponse>
    {
        //private QueryBuilder queryBuilder;
        private quizContext context;
        public ReponseRepository (/*QueryBuilder queryBuilder,*/ quizContext context)
        {
            //this.queryBuilder = queryBuilder;
            this.context = context;
        }

        public override Reponse Create(Reponse obj)
        {
            this.context.Add(obj);
            return obj;
           // OpenConnection();
           // Dictionary<string, dynamic> reponseDictionnary = new Dictionary<string, dynamic>();

           // foreach (PropertyInfo pr in obj.GetType().GetProperties())
           // {
           //     if (pr.Name.ToLower() != "idreponse")
           //     {
           //         reponseDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
           //     }
           // }
           // string request = queryBuilder
           //     .Insert("reponse")
           //     .Values(reponseDictionnary);
           //// request= "INSERT INTO reponse(libelle,reponse_correcte) VALUES ('methode de get','0')";
           // MySqlCommand cmd = new MySqlCommand(request, connectionSql);
           // Console.WriteLine(request);
           // cmd.ExecuteNonQuery();
           // long reponseId = cmd.LastInsertedId;

           // obj.IdReponse = (int)reponseId;

           // connectionSql.Close();
           // return obj;
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Reponse Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Reponse> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Reponse Update(int id, Reponse obj)
        {
            throw new NotImplementedException();
        }

        //FIXIT : trouver une autre facon de recupere l'id car c'est pas generique
        //public override int Delete(int id)
        //{
        //    OpenConnection();
        //    //TODO : c'est pas bien ca
        //    string request = queryBuilder.Delete("reponse", id).Replace("id", "id_reponse");
        //    MySqlCommand cmd = new MySqlCommand(request, connectionSql);
        //    int result = cmd.ExecuteNonQuery();
        //    connectionSql.Close();
        //    return result;
        //}

        //public override Reponse Find(int id)
        //{
        //    OpenConnection();
        //    string request = queryBuilder
        //        .Select()
        //        .From("reponse")
        //        .Where("id_reponse", id, "=")
        //        .Get();
        //    MySqlCommand cmd = new MySqlCommand(request, connectionSql);
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    Reponse reponseEntity = new Reponse();
        //    while (rdr.Read())
        //    {
        //        reponseEntity.IdReponse = rdr.GetInt32(0);
        //        reponseEntity.Libelle = rdr.GetString(1);
        //        reponseEntity.ReponseCorrecte = rdr.GetByte(2);
        //        reponseEntity.IdQuestion = rdr.GetInt32(3);

        //    }
        //    CloseConnection(rdr);
        //    return reponseEntity;
        //}

        //public override List<Reponse> FindAll()
        //{
        //    OpenConnection();
        //    string request = queryBuilder
        //        .Select()
        //        .From("reponse")
        //        .Get();
        //    MySqlCommand cmd = new MySqlCommand(request, connectionSql);
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    List<Reponse> reponseEntities = new List<Reponse>();

        //    while (rdr.Read())
        //    {
        //        Reponse reponseEntity = new Reponse();
        //        reponseEntity.IdReponse = rdr.GetInt32(0);
        //        reponseEntity.Libelle = rdr.GetString(1);
        //        reponseEntity.ReponseCorrecte = rdr.GetByte(2);
        //        reponseEntity.IdQuestion = rdr.GetInt32(3);

        //        reponseEntities.Add(reponseEntity);
        //    }
        //    CloseConnection(rdr);
        //    return reponseEntities;
        //}

        //public override Reponse Update(int id, Reponse obj)
        //{
        //    OpenConnection();
        //    Dictionary<string, dynamic> reponseDictionnary = new Dictionary<string, dynamic>();

        //    foreach (PropertyInfo pr in obj.GetType().GetProperties())
        //    {
        //        if (pr.Name.ToLower() != "idReponse" && pr.GetValue(obj) != null)
        //        {
        //            reponseDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
        //        }
        //    }
        //    string request = queryBuilder
        //      .Update("reponse")
        //      .Set(reponseDictionnary)
        //      .Where("idReponse", id).Get();

        //    MySqlCommand cmd = new MySqlCommand(request, connectionSql);
        //    cmd.ExecuteNonQuery();
        //    connectionSql.Close();
        //    return Find(id);
        //}
    }
}

