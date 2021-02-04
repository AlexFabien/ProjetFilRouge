using QuizApi.quiz;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class ReponseDto
    {
        public ReponseDto(int idReponse, string libelle, byte? reponseCorrecte, int? idQuestion, QuestionDto idQuestionNavigation)
        {
            IdReponse = idReponse;
            Libelle = libelle;
            ReponseCorrecte = reponseCorrecte;
            IdQuestion = idQuestion;
            IdQuestionNavigation = idQuestionNavigation;
        }

        public int IdReponse { get; set; }
        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
        public int? IdQuestion { get; set; }

        public virtual QuestionDto IdQuestionNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une reponse(DTO) en reponse(Models) automatiquement
        /// </summary>
        /// <param name="reponseDto"></param>
        public static implicit operator Reponse(ReponseDto reponseDto)
        {
            return new Reponse(
                reponseDto.IdReponse,
                reponseDto.Libelle,
                reponseDto.ReponseCorrecte,
                reponseDto.IdQuestion
                );
        }
    }
}
