using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class NiveauDto
    {
        public NiveauDto()
        {
        }

        public NiveauDto(int idNiveau, string libelle)
        {
            IdNiveau = idNiveau;
            Libelle = libelle;
        }

        public int IdNiveau { get; set; }
        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme une niveau(DTO) en niveau(Models) automatiquement
        /// </summary>
        /// <param name="niveauDto"></param>
        public static implicit operator Niveau(NiveauDto niveauDto)
        {
            return new Niveau(
                niveauDto.IdNiveau,
                niveauDto.Libelle
                ) ;
        }
    }
}
