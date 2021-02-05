using QuizApi.quiz;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public partial class ActeurHasQuizDto
    {
        public ActeurHasQuizDto(int idActeur, int idQuiz)
        {
            IdActeur = idActeur;
            IdQuiz = idQuiz;
        }

        public int IdActeur { get; set; }
        public int IdQuiz { get; set; }

        /// <summary>
        /// Fonction qui transforme une acteurHasQuiz(DTO) en acteurHasQuiz(Models) automatiquement
        /// </summary>
        /// <param name="acteurHasQuizDto"></param>
        public static implicit operator ActeurHasQuiz(ActeurHasQuizDto acteurHasQuizDto)
        {
            return new ActeurHasQuiz(
                acteurHasQuizDto.IdActeur,
                acteurHasQuizDto.IdQuiz
                );
        }
    }
}
