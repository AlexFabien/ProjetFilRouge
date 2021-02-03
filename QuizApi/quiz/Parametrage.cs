using QuizApi.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.quiz
{
    public partial class Parametrage
    {
        public Parametrage() { }
        public Parametrage(string valeur, int? idParametrage = null)
        {
            Valeur = valeur;
            IdParametrage = idParametrage;
        }

        public int? IdParametrage { get; set; }
        public string Valeur { get; set; }

        /// <summary>
        /// Fonction qui transforme une Parametrage(Models) en Parametrage(DTO) automatiquement
        /// </summary>
        /// <param name="parametrage"></param>
        public static implicit operator ParametrageDto(Parametrage parametrage)
        {
            return new ParametrageDto(
                parametrage.Valeur,
                parametrage.IdParametrage
                );
        }

    }
}
