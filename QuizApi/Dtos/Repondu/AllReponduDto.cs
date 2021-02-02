using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos.Repondu
{
    public class AllReponduDto
    {
        public AllReponduDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public AllReponduDto(string libelle, int idEtatReponse)
        {
            Libelle = libelle;
            IdEtatReponse = idEtatReponse;
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
    }
    
}
