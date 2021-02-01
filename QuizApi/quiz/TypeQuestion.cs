using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class TypeQuestion
    {
        public TypeQuestion()
        {
            Question = new HashSet<Question>();
        }

        public int IdTypeQuestion { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
