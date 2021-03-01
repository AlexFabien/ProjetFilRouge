using QuizApi.quiz;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class ReponseQuestionSuivanteDto
    {
       
        public ReponseQuestionSuivanteDto(int idReponse, string libelle)
        {
            IdReponse = idReponse;
            Libelle = libelle;
        }

        public int IdReponse { get; set; }
        public string Libelle { get; set; }
    }
}
