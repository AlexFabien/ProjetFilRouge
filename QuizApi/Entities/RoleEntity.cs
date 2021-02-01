using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Entities
{
    public class RoleEntity
    {
        public RoleEntity() { }
        public RoleEntity(string nom, int? idRole = null)
        {
            Nom = nom;
            Id_Role = idRole;
        }

        public int? Id_Role { get; set; }
        public string Nom { get; set; }
    }
}
