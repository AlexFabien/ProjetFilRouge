using QuizApi.quiz;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class CreatedReponseDto
    {
        public CreatedReponseDto()
        {
        }

        public CreatedReponseDto(string libelle, byte? reponseCorrecte)
        {
            Libelle = libelle;
            ReponseCorrecte = reponseCorrecte;
        }

        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }

        /// <summary>
        /// Fonction qui transforme une reponse(DTO) en reponse(Models) automatiquement
        /// </summary>
        /// <param name="reponseDto"></param>
        public static implicit operator Reponse(CreatedReponseDto reponseDto)
        {
            return new Reponse(
                0,
                reponseDto.Libelle,
                reponseDto.ReponseCorrecte,
                null
                );
        }
    }
}
