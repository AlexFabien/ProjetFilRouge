using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public partial class ActeurHasQuizDto
    {
        public int IdActeur { get; set; }
        public int IdQuiz { get; set; }

        public virtual ActeurDto IdActeurNavigation { get; set; }
        public virtual QuizDto IdQuizNavigation { get; set; }
    }
}
