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
    public class RoleRepository : AbstractRepository<RoleEntity>
    {
        private QueryBuilder queryBuilder;
        public RoleRepository(QueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public override RoleEntity Create(RoleEntity obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> roleDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id_role")
                {
                    roleDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
                .Insert("role")
                .Values(roleDictionnary);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long roleId = cmd.LastInsertedId;
            obj.Id_Role = (int)roleId;
            connectionSql.Close();
            return obj;
        }

        //FIXIT : trouver une autre facon de recupere l'id car c'est pas generique
        public override int Delete(int id)
        {
            OpenConnection();
            //TODO : c'est pas bien ca
            string request = queryBuilder.Delete("role", id).Replace("id", "id_role");
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override RoleEntity Find(int id)
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("role")
                .Where("id_role", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            RoleEntity roleEntity = new RoleEntity();
            while (rdr.Read())
            {
                roleEntity.Id_Role = rdr.GetInt32(0);
                roleEntity.Nom = rdr.GetString(1);
            }
            CloseConnection(rdr);
            return roleEntity;
        }

        public override List<RoleEntity> FindAll()
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("role")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<RoleEntity> roleEntities = new List<RoleEntity>();

            while (rdr.Read())
            {
                RoleEntity roleEntity = new RoleEntity();
                roleEntity.Id_Role = rdr.GetInt32(0);
                roleEntity.Nom = rdr.GetString(1);
                roleEntities.Add(roleEntity);
            }
            CloseConnection(rdr);
            return roleEntities;
        }

        public override RoleEntity Update(int id, RoleEntity obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> roleDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "id_role" && pr.GetValue(obj) != null)
                {
                    roleDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = queryBuilder
              .Update("role")
              .Set(roleDictionnary)
              .Where("id_role", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}
