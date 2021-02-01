using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Ventillation
    {
        public int IdNiveauQuiz { get; set; }
        public int IdNiveauQuestion { get; set; }
        public int? Valeur { get; set; }

        public virtual Niveau IdNiveauQuestionNavigation { get; set; }
        public virtual Niveau IdNiveauQuizNavigation { get; set; }
    }
}
