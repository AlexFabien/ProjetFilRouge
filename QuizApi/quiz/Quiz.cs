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
            Question = new HashSet<Question>();
        }

        public Quiz(int idQuiz, string libelle, int? idTechnologie, int? idNiveau) : this ()
        {
            IdQuiz = idQuiz;
            Libelle = libelle;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
        }

        public int IdQuiz { get; set; }
        public string Libelle { get; set; }
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
                quiz.Libelle,
                quiz.IdTechnologie,
                quiz.IdNiveau
                );
        }
    }
}
