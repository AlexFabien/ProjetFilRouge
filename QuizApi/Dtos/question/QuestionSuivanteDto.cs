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
            Reponses = new HashSet<ReponseQuestionSuivanteDto>();
        }

        public QuestionSuivanteDto(int idQuestion, int? numero, string libelle, int? idTypeQuestion) : this()
        {
            IdQuestion = idQuestion;
            Numero = numero;
            Libelle = libelle;
            IdTypeQuestion = idTypeQuestion;
        }

        public QuestionSuivanteDto(int idQuestion, int? numero, string libelle, int? idTypeQuestion,
            ICollection<ReponseQuestionSuivanteDto> reponses) : this(idQuestion, numero, libelle, idTypeQuestion)
        {
            Reponses = reponses;
        }

        public int IdQuestion { get; set; }
        public int ?Numero { get; set; }
        public string Libelle { get; set; }
        public int? IdTypeQuestion { get; set; }
        public virtual ICollection<ReponseQuestionSuivanteDto> Reponses { get; set; }
    }
}
