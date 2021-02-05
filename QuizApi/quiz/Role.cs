using QuizApi.Dtos;
using QuizApi.Utils;
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

        public Role(int idRole, string nom, ICollection<Acteur> acteur)
        {
            IdRole = idRole;
            Nom = nom;
            Acteur = acteur;
        }

        public int IdRole { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Acteur> Acteur { get; set; }

        /// <summary>
        /// Fonction qui transforme une role(Models) en role(DTO) automatiquement
        /// </summary>
        /// <param name="role"></param>
        public static implicit operator RoleDto(Role role)
        {
            return new RoleDto(
                role.IdRole,
                role.Nom,
                ConvertDtoEntity.ConvertListActeurToListActeurDto(role.Acteur)
                );
        }
    }
}
