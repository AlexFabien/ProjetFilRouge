using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class VentillationDto
    {
        public int IdNiveauQuiz { get; set; }
        public int IdNiveauQuestion { get; set; }
        public int? Valeur { get; set; }

        public virtual NiveauDto IdNiveauQuestionNavigation { get; set; }
        public virtual NiveauDto IdNiveauQuizNavigation { get; set; }
    }
}
