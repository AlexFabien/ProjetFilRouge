using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Technologie
    {
        public Technologie()
        {
            Quiz = new HashSet<Quiz>();
        }
        public Technologie(string libelle, int? idTechnologie = null)
        {
            Libelle = libelle;
            IdTechnologie = idTechnologie;
        }

        public int? IdTechnologie { get; set; }
        public string Libelle { get; set; }
        /// <summary>
        /// Fonction qui transforme une Parametrage(Models) en Parametrage(DTO) automatiquement
        /// </summary>
        /// <param name="parametrage"></param>
        public static implicit operator TechnologieDto(Technologie technologie)
        {
            return new TechnologieDto(
                technologie.Libelle,
                technologie.IdTechnologie
                );
        }
        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
