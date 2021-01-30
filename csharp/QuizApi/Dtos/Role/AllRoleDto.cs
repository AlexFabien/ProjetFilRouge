using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos.Role
{
    //INFO : C'est mieux de faire des sous dossiers s'il y a plusieurs DTO par Entite
    public class AllRoleDto
    {
        public AllRoleDto(string nom, int? idRole = null)
        {
            Nom = nom;
            IdRole = idRole;
        }

        public int? IdRole { get; set; }
        public string Nom { get; set; }
    }
}
