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
            List<ActeurDto> ConvertListActeurDtoToListActeur()
            {
                List<ActeurDto> listActeurDto = null;
                if (role.Acteur != null)
                {
                    listActeurDto = new List<ActeurDto>();
                    foreach (Acteur acteur in role.Acteur)
                    {
                        listActeurDto.Add(acteur);
                    }
                }
                return listActeurDto;
            }

            return new RoleDto(
                role.IdRole,
                role.Nom,
                ConvertListActeurDtoToListActeur()
                );
        }
    }
}
