using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuestionSuivanteDto
    {
        public QuestionSuivanteDto()
        {
            Reponse = new HashSet<ReponseQuestionSuivanteDto>();
        }

        public QuestionSuivanteDto(int idQuestion, int? numero, string libelle) : this()
        {
            IdQuestion = idQuestion;
            Numero = numero;
            Libelle = libelle;
        }

        public QuestionSuivanteDto(int idQuestion, int? numero, string libelle,
            ICollection<ReponseQuestionSuivanteDto> reponse) : this(idQuestion, numero, libelle)
        {
            Reponse = reponse;
        }

        public int IdQuestion { get; set; }
        public int ?Numero { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<ReponseQuestionSuivanteDto> Reponse { get; set; }
    }
}
