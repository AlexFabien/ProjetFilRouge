using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class AfterCreateTechnologieDto
    {
        public int? IdTechnologie { get; set; }
        public string Libelle { get; set; }
        public bool IsCreated { get; set; }
        public AfterCreateTechnologieDto()
        {
        }


        public AfterCreateTechnologieDto( string libelle, bool isCreated, int? idTechnologie = null)
        {
            IdTechnologie = idTechnologie;
            Libelle = libelle;
            IsCreated = isCreated;
        }
    }
}
