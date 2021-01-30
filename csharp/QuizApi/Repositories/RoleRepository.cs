using MySql.Data.MySqlClient;
using QuizApi.Entities;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
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
                roleEntity.IdRole = rdr.GetInt32(0);
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
                roleEntity.IdRole = rdr.GetInt32(0);
                roleEntity.Nom = rdr.GetString(1);
                roleEntities.Add(roleEntity);
            }
            CloseConnection(rdr);
            return roleEntities;
        }

        public override RoleEntity Update(int id, RoleEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
