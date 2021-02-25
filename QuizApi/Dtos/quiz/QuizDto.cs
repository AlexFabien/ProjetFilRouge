using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuizDto
    {
        public QuizDto()
        {
        }

        public QuizDto(int idQuiz, string libelle, int? idTechnologie, int? idNiveau)
        {
            IdQuiz = idQuiz;
            Libelle = libelle;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
        }

        public int IdQuiz { get; set; }
        public string Libelle { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }
        public int? NbQuestions { get; set; }

        /// <summary>
        /// Fonction qui transforme une quiz(DTO) en quiz(Models) automatiquement
        /// </summary>
        /// <param name="quizDto"></param>
        public static implicit operator Quiz(QuizDto quizDto)
        {
            return new Quiz(
                quizDto.IdQuiz,
                quizDto.Libelle,
                quizDto.IdTechnologie,
                quizDto.IdNiveau
                );
        }
    }
}
