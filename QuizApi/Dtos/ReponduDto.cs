using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class ReponduDto
    {
        public ReponduDto()
        {
        }

        public ReponduDto(int idEtatReponse, string libelle)
        {
            IdEtatReponse = idEtatReponse;
            Libelle = libelle;
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme une repondu(DTO) en repondu(Models) automatiquement
        /// </summary>
        /// <param name="reponduDto"></param>
        public static implicit operator Repondu(ReponduDto reponduDto)
        {
            return new Repondu(
                reponduDto.IdEtatReponse,
                reponduDto.Libelle
                );
        }
    }
}
