using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos.Reponse
{
    public class AfterCreateReponseDto
    {
        public AfterCreateReponseDto()
        {
        }

        public AfterCreateReponseDto(string libelle, bool isCreated, int idReponse, byte? reponseCorrecte, int? idQuestion)
        {
            Libelle = libelle;
            IsCreated = isCreated;
            IdReponse = idReponse;
            ReponseCorrecte = reponseCorrecte;
            IdQuestion = idQuestion;
        }

        public int IdReponse { get; set; }
        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
        public int? IdQuestion { get; set; }
        public bool IsCreated { get; set; }

        
    }
}
