using QuizApi.quiz;
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

        public ReponduDto( string libelle, int idEtatReponse)
        {
           
            Libelle = libelle;
            IdEtatReponse = idEtatReponse;
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }




        /// <summary>
        /// Fonction qui transforme une parametrage(DTO) en parametrage(Models) automatiquement
        /// </summary>
        /// <param name="reponduDto"></param>
        public static implicit operator Repondu(ReponduDto reponduDto)
        {
            return new Repondu(
                reponduDto.Libelle,
                reponduDto.IdEtatReponse
                );
        }

    }
}
