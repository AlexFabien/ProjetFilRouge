using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Role
    {
        public Role()
        {
            Acteur = new HashSet<Acteur>();
        }

        public Role(string nom, int? id = null)
        {
            Nom = nom;
            IdRole = id;
        }

        public int? IdRole { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Acteur> Acteur { get; set; }

        /// <summary>
        /// Fonction qui transforme une Parametrage(Models) en Parametrage(DTO) automatiquement
        /// </summary>
        /// <param name="parametrage"></param>
        public static implicit operator RoleDto(Role role)
        {
            return new RoleDto(role.Nom, role.IdRole);
        }
    }
}
