using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos.Role
{
    //INFO : le sous-dossier c'est pour classer les DTO par entity
    public class RoleDto
    {
        public RoleDto(){}

        public RoleDto(string nom, int? idRole = null)
        {
            Nom = nom;
            IdRole = idRole;
        }

        public int? IdRole { get; set; }
        public string Nom { get; set; }
    }
}
