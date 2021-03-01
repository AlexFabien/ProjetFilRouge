using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ReponseCandidat
    {
        public ReponseCandidat(int idReponseCandidat, string libelle, int? idActeur, int? idQuestion)
        {
            IdReponseCandidat = idReponseCandidat;
            Libelle = libelle;
            IdActeur = idActeur;
            IdQuestion = idQuestion;
        }

        public int IdReponseCandidat { get; set; }
        public string Libelle { get; set; }
        public int? IdActeur { get; set; }
        public int? IdQuestion { get; set; }

        public virtual ActeurHasQuestion Id { get; set; }

        //TODO : si l'objet en parapetre est null, on a un NullReferenceException
        /// <summary>
        /// Fonction qui transforme une reponseCandidat(Models) en reponseCandidat(DTO) automatiquement
        /// </summary>
        /// <param name="reponseCandidat"></param>
        public static implicit operator ReponseCandidatDto(ReponseCandidat reponseCandidat)
        {
            return new ReponseCandidatDto(
                reponseCandidat.IdReponseCandidat,
                reponseCandidat.Libelle
                );
        }
    }
}
