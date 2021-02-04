using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Quiz
    {
        public Quiz()
        {
            ActeurHasQuiz = new HashSet<ActeurHasQuiz>();
        }

        public Quiz(int idQuiz, int? idTechnologie, int? idNiveau, Niveau idNiveauNavigation,
            Technologie idTechnologieNavigation, ICollection<ActeurHasQuiz> acteurHasQuiz)
        {
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            IdNiveauNavigation = idNiveauNavigation;
            IdTechnologieNavigation = idTechnologieNavigation;
            ActeurHasQuiz = acteurHasQuiz;
        }

        public int IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Technologie IdTechnologieNavigation { get; set; }
        public virtual ICollection<ActeurHasQuiz> ActeurHasQuiz { get; set; }

        /// <summary>
        /// Fonction qui transforme une quiz(Models) en quiz(DTO) automatiquement
        /// </summary>
        /// <param name="quiz"></param>
        public static implicit operator QuizDto(Quiz quiz)
        {
            return new QuizDto(
                quiz.IdQuiz,
                quiz.IdTechnologie,
                quiz.IdNiveau,
                quiz.IdNiveauNavigation,
                quiz.IdTechnologieNavigation,
                ConvertDtoEntity.ConvertListActeurHasQuizToListActeurHasQuizDto(quiz.ActeurHasQuiz)
                );
        }
    }
}
