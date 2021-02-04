using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApi.Dtos
{
   // public partial class Parametrage
    public class ActeurDto
    {
        public ActeurDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestionDto>();
            ActeurHasQuiz = new HashSet<ActeurHasQuizDto>();
        }

        public ActeurDto(int idActeur, string nom, string prenom, string email, string password,
            int? idRole, RoleDto idRoleNavigation, 
            ICollection<ActeurHasQuestionDto> acteurHasQuestion, ICollection<ActeurHasQuizDto> acteurHasQuiz)
        {
            IdActeur = idActeur;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            IdRole = idRole;
            IdRoleNavigation = idRoleNavigation;
            ActeurHasQuestion = acteurHasQuestion;
            ActeurHasQuiz = acteurHasQuiz;
        }

        public int IdActeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdRole { get; set; }

        public virtual RoleDto IdRoleNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestionDto> ActeurHasQuestion { get; set; }
        public virtual ICollection<ActeurHasQuizDto> ActeurHasQuiz { get; set; }

        /// <summary>
        /// Fonction qui transforme une Acteur(DTO) en Acteur(Models) automatiquement
        /// </summary>
        /// <param name="acteurDto"></param>
        public static implicit operator Acteur(ActeurDto acteurDto)
        {
            return new Acteur(
                acteurDto.IdActeur,
                acteurDto.Nom,
                acteurDto.Prenom,
                acteurDto.Email,
                acteurDto.Password,
                acteurDto.IdRole,
                acteurDto.IdRoleNavigation,
                ConvertDtoEntity.ConvertListActeurHasQuestionDtoToListActeurHasQuestion(acteurDto.ActeurHasQuestion),
                ConvertDtoEntity.ConvertListActeurHasQuizDtoToListActeurHasQuiz(acteurDto.ActeurHasQuiz)
                );
        }

    }
}
