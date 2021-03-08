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
    public class ConnectActeurDto
    {
        public ConnectActeurDto()
        {
        }

        public ConnectActeurDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Fonction qui transforme une Acteur(DTO) en Acteur(Models) automatiquement
        /// </summary>
        /// <param name="acteurDto"></param>
        public static implicit operator Acteur(ConnectActeurDto dto)
        {
            return new Acteur(null, null, dto.Email, dto.Password);
        }

    }
}
