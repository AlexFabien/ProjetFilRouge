using QuizApi.quiz;
using QuizApi.Utils;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class RoleDto
    {
        public RoleDto(){}

        public RoleDto(int idRole, string nom)
        {
            IdRole = idRole;
            Nom = nom;
        }

        public int IdRole { get; set; }
        public string Nom { get; set; }

        /// <summary>
        /// Fonction qui transforme une role(DTO) en role(Models) automatiquement
        /// </summary>
        /// <param name="roleDto"></param>
        public static implicit operator Role(RoleDto roleDto)
        {
            return new Role(
                roleDto.IdRole,
                roleDto.Nom
                );
        }
    }
}
