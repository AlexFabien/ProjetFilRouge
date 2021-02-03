using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos.Reponse
{
    public class CreateReponseDto
    {
        public CreateReponseDto()
        {
        }

        public CreateReponseDto(string libelle, byte? reponseCorrecte)
        {
            Libelle = libelle;
            ReponseCorrecte = reponseCorrecte;
        }

        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
       

       
    }
}
