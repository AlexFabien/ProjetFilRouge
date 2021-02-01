using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class CreateTechnologieDto
    {
        public string Libelle { get; set; }
        public CreateTechnologieDto()
        {
        }

        public CreateTechnologieDto(string libelle)
        {
            Libelle = libelle;
        }

        
    }
}
