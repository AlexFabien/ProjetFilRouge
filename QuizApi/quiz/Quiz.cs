using QuizApi.Dtos;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Quiz
    {
        public Quiz()
        {
            ActeurHasQuiz = new HashSet<ActeurHasQuiz>();
            Question = new HashSet<Question>();
        }

        public Quiz(int idQuiz, int? idTechnologie, int? idNiveau):this()
        {
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
        }

        public Quiz(int idQuiz, int? idTechnologie, int? idNiveau, Niveau idNiveauNavigation, Technologie idTechnologieNavigation): this()
        {
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            IdNiveauNavigation = idNiveauNavigation;
            IdTechnologieNavigation = idTechnologieNavigation;
        }

        public int IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Technologie IdTechnologieNavigation { get; set; }
        public virtual ICollection<ActeurHasQuiz> ActeurHasQuiz { get; set; }
        public virtual ICollection<Question> Question { get; set; }

        /// <summary>
        /// Fonction qui transforme une quiz(Models) en quiz(DTO) automatiquement
        /// </summary>
        /// <param name="quiz"></param>
        public static implicit operator QuizDto(Quiz quiz)
        {
            return new QuizDto(
                quiz.IdQuiz,
                quiz.IdTechnologie,
                quiz.IdNiveau
                );
        }
    }
}
