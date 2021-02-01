using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Niveau
    {
        public Niveau()
        {
            Question = new HashSet<Question>();
            Quiz = new HashSet<Quiz>();
            VentillationIdNiveauQuestionNavigation = new HashSet<Ventillation>();
            VentillationIdNiveauQuizNavigation = new HashSet<Ventillation>();
        }

        public int IdNiveau { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Quiz> Quiz { get; set; }
        public virtual ICollection<Ventillation> VentillationIdNiveauQuestionNavigation { get; set; }
        public virtual ICollection<Ventillation> VentillationIdNiveauQuizNavigation { get; set; }
    }
}
