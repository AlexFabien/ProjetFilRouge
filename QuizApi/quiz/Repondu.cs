using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Repondu
    {
       
        public Repondu()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public Repondu(string libelle, int idEtatReponse)
        {
            Libelle = libelle;
            IdEtatReponse = idEtatReponse;
        }

        public string Libelle { get; set; }
        public int IdEtatReponse { get; set; }
        

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
        /// <summary>
        /// Fonction qui transforme une Parametrage(Models) en Parametrage(DTO) automatiquement
        /// </summary>
        /// <param name="repondu"></param>
        public static implicit operator ReponduDto(Repondu repondu)
        {
            return new ReponduDto(
                repondu.Libelle,
                repondu.IdEtatReponse
                );
        }
    }
}
