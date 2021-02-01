using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Entities
{
    public class TechnologieEntity
    {
        public int?Id_Technologie { get; set; }
        public string Libelle { get; set; }
        
        public TechnologieEntity() { }

        public TechnologieEntity(string libelle, int? idTechnologie=null)
        {
            Id_Technologie = idTechnologie;
            Libelle = libelle;
        }
    }
}
