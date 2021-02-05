using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ReponseCandidat
    {
        public ReponseCandidat()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public ReponseCandidat(int idReponseCandidat, string libelle, ICollection<ActeurHasQuestion> acteurHasQuestion)
        {
            IdReponseCandidat = idReponseCandidat;
            Libelle = libelle;
            ActeurHasQuestion = acteurHasQuestion;
        }

        public int IdReponseCandidat { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }

        /// <summary>
        /// Fonction qui transforme une reponseCandidat(Models) en reponseCandidat(DTO) automatiquement
        /// </summary>
        /// <param name="reponseCandidat"></param>
        public static implicit operator ReponseCandidatDto(ReponseCandidat reponseCandidat)
        {
            return new ReponseCandidatDto(
                reponseCandidat.IdReponseCandidat,
                reponseCandidat.Libelle,
                ConvertDtoEntity.ConvertListActeurHasQuestionToListActeurHasQuestionDto(reponseCandidat.ActeurHasQuestion)
                );
        }
    }
}
