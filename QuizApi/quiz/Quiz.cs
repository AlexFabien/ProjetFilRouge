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

        public int IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Technologie IdTechnologieNavigation { get; set; }
        public virtual ICollection<ActeurHasQuiz> ActeurHasQuiz { get; set; }
    }
}
