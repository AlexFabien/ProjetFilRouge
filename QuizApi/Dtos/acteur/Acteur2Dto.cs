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
    public class Acteur2Dto
    {
        public Acteur2Dto()
        {
        }

        public Acteur2Dto(int idActeur, string nom, string prenom, string email, int? idRole)
        {
            IdActeur = idActeur;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            IdRole = idRole;
        }

        public int IdActeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int? IdRole { get; set; }

        /// <summary>
        /// Fonction qui transforme une Acteur(DTO) en Acteur(Models) automatiquement
        /// </summary>
        /// <param name="acteurDto"></param>
        public static implicit operator Acteur(Acteur2Dto acteurDto)
        {
            return new Acteur(
                acteurDto.IdActeur,
                acteurDto.Nom,
                acteurDto.Prenom,
                acteurDto.Email,
                string.Empty,
                acteurDto.IdRole
                );
        }

    }
}
