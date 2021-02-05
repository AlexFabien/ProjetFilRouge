using QuizApi.quiz;
using QuizApi.Utils;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class ReponseCandidatDto
    {
        public ReponseCandidatDto()
        {
        }

        public ReponseCandidatDto(int idReponseCandidat, string libelle)
        {
            IdReponseCandidat = idReponseCandidat;
            Libelle = libelle;
        }

        public int IdReponseCandidat { get; set; }
        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme une reponseCandidat(DTO) en reponseCandidat(Models) automatiquement
        /// </summary>
        /// <param name="reponseCandidat"></param>
        public static implicit operator ReponseCandidat(ReponseCandidatDto reponseCandidat)
        {
            return new ReponseCandidat(
                reponseCandidat.IdReponseCandidat,
                reponseCandidat.Libelle
                );
        }
    }
}
