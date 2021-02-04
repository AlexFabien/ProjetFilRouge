using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ActeurHasQuiz
    {
        public ActeurHasQuiz(int idActeur, int idQuiz, Acteur idActeurNavigation, Quiz idQuizNavigation)
        {
            IdActeur = idActeur;
            IdQuiz = idQuiz;
            IdActeurNavigation = idActeurNavigation;
            IdQuizNavigation = idQuizNavigation;
        }

        public int IdActeur { get; set; }
        public int IdQuiz { get; set; }

        public virtual Acteur IdActeurNavigation { get; set; }
        public virtual Quiz IdQuizNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une acteurHasQuiz(Models) en acteurHasQuiz(DTO) automatiquement
        /// </summary>
        /// <param name="acteurHasQuiz"></param>
        public static implicit operator ActeurHasQuizDto(ActeurHasQuiz acteurHasQuiz)
        {
            return new ActeurHasQuizDto(
                acteurHasQuiz.IdActeur,
                acteurHasQuiz.IdQuiz,
                acteurHasQuiz.IdActeurNavigation,
                acteurHasQuiz.IdQuizNavigation
                );
        }
    }
}
