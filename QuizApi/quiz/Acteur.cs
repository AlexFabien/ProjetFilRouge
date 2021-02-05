using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Acteur
    {
        public Acteur()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
            ActeurHasQuiz = new HashSet<ActeurHasQuiz>();
        }

        public Acteur(int idActeur, string nom, string prenom, string email, string password, int? idRole):this()
        {
            IdActeur = idActeur;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            IdRole = idRole;
        }

        public Acteur(int idActeur, string nom, string prenom, string email, string password,
                int? idRole, Role idRoleNavigation,
                ICollection<ActeurHasQuestion> acteurHasQuestion, ICollection<ActeurHasQuiz> acteurHasQuiz)
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

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
        public virtual ICollection<ActeurHasQuiz> ActeurHasQuiz { get; set; }

        /// <summary>
        /// Fonction qui transforme une Acteur(Models) en Acteur(DTO) automatiquement
        /// </summary>
        /// <param name="acteur"></param>
        public static implicit operator ActeurDto(Acteur acteur)
        {
            return new ActeurDto(
                acteur.IdActeur,
                acteur.Nom,
                acteur.Prenom,
                acteur.Email,
                acteur.Password,
                acteur.IdRole
                );
        }
    }
}
