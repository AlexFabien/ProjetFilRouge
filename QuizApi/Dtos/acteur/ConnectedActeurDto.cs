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
    public class ConnectedActeurDto
    {
        public ConnectedActeurDto()
        {
        }

        public ConnectedActeurDto(string nom, string prenom, string email, string password, string? token = "")
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Password = password;
            Token = token;
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }

        /// <summary>
        /// Fonction qui transforme une Acteur(DTO) en Acteur(Models) automatiquement
        /// </summary>
        /// <param name="acteurDto"></param>
        public static implicit operator Acteur(ConnectedActeurDto dto)
        {
            return new Acteur(null, null, dto.Email, dto.Password);
        }

    }
}
