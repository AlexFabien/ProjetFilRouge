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
    public class RoleRepository : AbstractRepository<Role>
    {
        private QueryBuilder queryBuilder;
        public RoleRepository(QueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public override Role Create(Role obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> roleDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idrole" && pr.Name != "Acteur")
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
            obj.IdRole = (int)roleId;
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

        public override Role Find(int id)
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("role")
                .Where("id_role", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Role role = new Role();
            while (rdr.Read())
            {
                role.IdRole = rdr.GetInt32(0);
                role.Nom = rdr.GetString(1);
            }
            CloseConnection(rdr);
            return role;
        }

        public override List<Role> FindAll()
        {
            OpenConnection();
            string request = queryBuilder
                .Select()
                .From("role")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Role> roles = new List<Role>();

            while (rdr.Read())
            {
                Role role = new Role();
                role.IdRole = rdr.GetInt32(0);
                role.Nom = rdr.GetString(1);
                roles.Add(role);
            }
            CloseConnection(rdr);
            return roles;
        }

        public override Role Update(int id, Role obj)
        {
            OpenConnection();
            Dictionary<string, dynamic> roleDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idrole" && pr.Name != "Acteur" && pr.GetValue(obj) != null)
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
