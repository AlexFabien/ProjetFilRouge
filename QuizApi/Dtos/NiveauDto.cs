using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class NiveauDto
    {
        public NiveauDto() { }

        public NiveauDto(string libelle, int? idNiveau = null)
        {
            IdNiveau = idNiveau;
            Libelle = libelle;
        }

        public int? IdNiveau { get; set; }
        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme un Niveau(DTO) en Niveau(Models) automatiquement
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator quiz.Niveau(NiveauDto dto)
        {
            return new quiz.Niveau(dto.Libelle, dto.IdNiveau);
        }
    }
}
