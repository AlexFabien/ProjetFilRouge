using QuizApi.Dtos;
using QuizApi.Utils;
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

        public Repondu(string libelle)
        {
            Libelle = libelle;
        }

        public Repondu(int idEtatReponse, string libelle, ICollection<ActeurHasQuestion> acteurHasQuestion)
        {
            IdEtatReponse = idEtatReponse;
            Libelle = libelle;
            ActeurHasQuestion = acteurHasQuestion;
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }

        /// <summary>
        /// Fonction qui transforme une repondu(Models) en repondu(DTO) automatiquement
        /// </summary>
        /// <param name="repondu"></param>
        public static implicit operator ReponduDto(Repondu repondu)
        {
            return new ReponduDto(
                repondu.IdEtatReponse,
                repondu.Libelle,
                ConvertDtoEntity.ConvertListActeurHasQuestionToListActeurHasQuestionDto(repondu.ActeurHasQuestion)
                );
        }
    }
}
