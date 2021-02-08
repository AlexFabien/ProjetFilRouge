using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuestionDto
    {
        public QuestionDto()
        {
        }

        public QuestionDto(int idQuestion, string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion)
        {
            IdQuestion = idQuestion;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
        }

        public int IdQuestion { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }

        /// <summary>
        /// Fonction qui transforme une question(DTO) en question(Models) automatiquement
        /// </summary>
        /// <param name="questionDto"></param>
        public static implicit operator Question(QuestionDto questionDto)
        {
            return new Question(
                questionDto.IdQuestion,
                questionDto.Libelle,
                questionDto.ExplicationReponse,
                questionDto.IdNiveau,
                questionDto.IdTypeQuestion
                );
        }
    }
}
