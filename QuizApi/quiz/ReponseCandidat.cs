using QuizApi.Dtos;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ReponseCandidat
    {
        public ReponseCandidat()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public ReponseCandidat(string libelle, int? idReponseCandidat= null)
        {
            IdReponseCandidat = idReponseCandidat;
            Libelle = libelle;
        }

        public int? IdReponseCandidat { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }

        /// <summary>
        /// Fonction qui transforme une ReponseCandidat(Models) en ReponseCandidat(DTO) automatiquement
        /// </summary>
        /// <param name="rc"></param>
        public static implicit operator ReponseCandidatDto(ReponseCandidat rc)
        {
            return new ReponseCandidatDto(rc.Libelle, rc.IdReponseCandidat);
        }
    }
}
