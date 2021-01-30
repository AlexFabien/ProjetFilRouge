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
            IdRole = idRole;
        }

        public int? IdRole { get; set; }
        public string Nom { get; set; }
    }
}
