using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Ventillation
    {
        public Ventillation(int idNiveauQuiz, int idNiveauQuestion, int? valeur)
        {
            IdNiveauQuiz = idNiveauQuiz;
            IdNiveauQuestion = idNiveauQuestion;
            Valeur = valeur;
        }

        public Ventillation(int idNiveauQuiz, int idNiveauQuestion, int? valeur, Niveau idNiveauQuestionNavigation,
            Niveau idNiveauQuizNavigation)
        {
            IdNiveauQuiz = idNiveauQuiz;
            IdNiveauQuestion = idNiveauQuestion;
            Valeur = valeur;
            IdNiveauQuestionNavigation = idNiveauQuestionNavigation;
            IdNiveauQuizNavigation = idNiveauQuizNavigation;
        }

        public int IdNiveauQuiz { get; set; }
        public int IdNiveauQuestion { get; set; }
        public int? Valeur { get; set; }

        public virtual Niveau IdNiveauQuestionNavigation { get; set; }
        public virtual Niveau IdNiveauQuizNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une ventillation(Models) en ventillation(DTO) automatiquement
        /// </summary>
        /// <param name="ventillation"></param>
        public static implicit operator VentillationDto(Ventillation ventillation)
        {
            return new VentillationDto(
                ventillation.IdNiveauQuiz,
                ventillation.IdNiveauQuestion,
                ventillation.Valeur
                );
        }
    }
}
