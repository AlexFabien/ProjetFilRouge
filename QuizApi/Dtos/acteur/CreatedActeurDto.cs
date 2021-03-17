﻿using QuizApi.quiz;
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
    public class CreatedActeurDto
    {
        public CreatedActeurDto()
        {
        }

        public CreatedActeurDto( string nom, string prenom, string email, string password, int idRole)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            IdRole = idRole;
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdRole { get; set; }

        /// <summary>
        /// Fonction qui transforme une Acteur(DTO) en Acteur(Models) automatiquement
        /// </summary>
        /// <param name="acteurDto"></param>
        public static implicit operator Acteur(CreatedActeurDto createdActeurDto)
        {
            return new Acteur(
                0,
                createdActeurDto.Nom,
                createdActeurDto.Prenom,
                createdActeurDto.Email,
                null,
                createdActeurDto.IdRole
                );
        }

    }
}
