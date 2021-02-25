using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class CreatedQuizDto
    {
        public CreatedQuizDto()
        {
        }

        public CreatedQuizDto(int idCreateur, string libelle, int? idTechnologie, int? idNiveau, int? nbQuestions)
        {
            IdCreateur = idCreateur;
            Libelle = libelle;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            NbQuestions = nbQuestions;
        }

        public int IdCreateur { get; set; }
        public string Libelle { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }
        public int? NbQuestions { get; set; }

        /// <summary>
        /// Fonction qui transforme une quiz(DTO) en quiz(Models) automatiquement
        /// </summary>
        /// <param name="quizDto"></param>
        public static implicit operator Quiz(CreatedQuizDto createdQuizDto)
        {
            return new Quiz(
                0,
                createdQuizDto.Libelle,
                createdQuizDto.IdTechnologie,
                createdQuizDto.IdNiveau
                );
        }
    }
}
