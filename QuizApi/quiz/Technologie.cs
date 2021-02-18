using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Technologie
    {
        public Technologie()
        {
            Question = new HashSet<Question>();
            Quiz = new HashSet<Quiz>();
        }
        public Technologie(string libelle, int? idTechnologie = null)
        {
            Libelle = libelle;
            IdTechnologie = idTechnologie;
        }

        public int? IdTechnologie { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Quiz> Quiz { get; set; }

        /// <summary>
        /// Fonction qui transforme une technologie(Models) en technologie(DTO) automatiquement
        /// </summary>
        /// <param name="technologie"></param>
        public static implicit operator TechnologieDto(Technologie technologie)
        {
            return new TechnologieDto(
                technologie.Libelle,
                technologie.IdTechnologie
                );
        }
    }
}
