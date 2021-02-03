using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class AfterCreateReponduDto 
    {
        public AfterCreateReponduDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public AfterCreateReponduDto(string libelle, bool isCreated, int idEtatReponse)
        {
            Libelle = libelle;
            IsCreated = isCreated;
            IdEtatReponse = idEtatReponse;
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }
        public bool IsCreated { get; set; }

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
    }
}
