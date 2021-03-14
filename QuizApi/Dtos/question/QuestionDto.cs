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

        public QuestionDto(int idQuestion, int? numero, string libelle, string explicationReponse, 
            int? idNiveau, int? idTypeQuestion, int? idQuiz, int? idTechnologie)
        {
            IdQuestion = idQuestion;
            Numero = numero;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
        }

        public int IdQuestion { get; set; }
        public int ?Numero { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }
        public int? IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }

        /// <summary>
        /// Fonction qui transforme une question(DTO) en question(Models) automatiquement
        /// </summary>
        /// <param name="questionDto"></param>
        public static implicit operator Question(QuestionDto questionDto)
        {
            return new Question(
                questionDto.IdQuestion,
                questionDto.Numero,
                questionDto.Libelle,
                questionDto.ExplicationReponse,
                questionDto.IdNiveau,
                questionDto.IdTypeQuestion,
                questionDto.IdQuiz,
                questionDto.IdTechnologie
                );
        }
    }
}
