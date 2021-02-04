using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class AllReponseDto
    {
        public AllReponseDto()
        {
        }

        public AllReponseDto(string libelle, int idReponse, byte? reponseCorrecte,int? idQuestion)
        {
            Libelle = libelle;
            IdReponse = idReponse;
            ReponseCorrecte = reponseCorrecte;
            IdQuestion = idQuestion;
        }

        public int IdReponse { get; set; }
        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
        public int? IdQuestion { get; set; }

        
    }
}
