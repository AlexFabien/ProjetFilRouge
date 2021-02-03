using QuizApi.quiz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApi.Dtos
{
   // public partial class Parametrage
    public class ParametrageDto
    {
        public ParametrageDto() { }

        public ParametrageDto(string valeur, int? idParametrage = null)
        {
            Valeur = valeur;
            IdParametrage = idParametrage;
        }
        public int? IdParametrage { get; set; }
        public string Valeur { get; set; }

        /// <summary>
        /// Fonction qui transforme une parametrage(DTO) en parametrage(Models) automatiquement
        /// </summary>
        /// <param name="parametrageDto"></param>
        public static implicit operator Parametrage(ParametrageDto parametrageDto)
        {
            return new Parametrage(
                parametrageDto.Valeur,
                parametrageDto.IdParametrage
                );
        }

    }
}
