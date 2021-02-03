using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class AllTechnologieDto
    {
        public int? IdTechnologie { get; set; }
        public string Libelle { get; set; }
       

        public AllTechnologieDto(string libelle, int? idTechnologie)
        {
            Libelle = libelle;
            IdTechnologie = idTechnologie;
        }
    }
}
