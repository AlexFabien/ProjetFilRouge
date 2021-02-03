using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi .Dtos
{
    public class TechnologieDto
    {
        public TechnologieDto() { }

        public TechnologieDto(string libelle, int? idTechnologie = null)
        {
            Libelle = libelle;
            IdTechnologie  = idTechnologie;
        }
        public int? IdTechnologie { get; set; }
        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme une parametrage(DTO) en parametrage(Models) automatiquement
        /// </summary>
        /// <param name="technologieDto"></param>
        public static implicit operator Technologie(TechnologieDto technologieDto)
        {
            return new Technologie(
                technologieDto.Libelle,
                technologieDto.IdTechnologie
                );
        }

    }
}
