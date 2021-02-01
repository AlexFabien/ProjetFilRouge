using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ActeurHasQuiz
    {
        public int IdActeur { get; set; }
        public int IdQuiz { get; set; }

        public virtual Acteur IdActeurNavigation { get; set; }
        public virtual Quiz IdQuizNavigation { get; set; }
    }
}
