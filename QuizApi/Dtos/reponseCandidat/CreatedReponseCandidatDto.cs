using QuizApi.quiz;
using QuizApi.Utils;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class CreatedReponseCandidatDto
    {
        public CreatedReponseCandidatDto()
        {
        }

        public CreatedReponseCandidatDto(string libelle)
        {
            Libelle = libelle;
        }

        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme une reponseCandidat(DTO) en reponseCandidat(Models) automatiquement
        /// </summary>
        /// <param name="reponseCandidat"></param>
        public static implicit operator ReponseCandidat(CreatedReponseCandidatDto reponseCandidat)
        {
            return new ReponseCandidat(
                0,
                reponseCandidat.Libelle,
                null,
                null
                );
        }
    }
}
