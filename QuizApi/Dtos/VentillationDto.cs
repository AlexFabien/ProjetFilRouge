using QuizApi.quiz;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class VentillationDto
    {
        public VentillationDto(int idNiveauQuiz, int idNiveauQuestion, int? valeur)
        {
            IdNiveauQuiz = idNiveauQuiz;
            IdNiveauQuestion = idNiveauQuestion;
            Valeur = valeur;
        }

        public int IdNiveauQuiz { get; set; }
        public int IdNiveauQuestion { get; set; }
        public int? Valeur { get; set; }

        /// <summary>
        /// Fonction qui transforme une ventillation(DTO) en ventillation(Models) automatiquement
        /// </summary>
        /// <param name="ventillationDto"></param>
        public static implicit operator Ventillation(VentillationDto ventillationDto)
        {
            return new Ventillation(
                ventillationDto.IdNiveauQuiz,
                ventillationDto.IdNiveauQuestion,
                ventillationDto.Valeur
                );
        }
    }
}
