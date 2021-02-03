using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class CreateNiveauDto
    {
        public CreateNiveauDto(){}

        public CreateNiveauDto(string libelle)
        {
            Libelle = libelle;
        }

        public string Libelle { get; set; }
    }
}
