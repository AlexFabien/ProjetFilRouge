using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Technologie
    {
        public Technologie()
        {
            Quiz = new HashSet<Quiz>();
        }

        public int IdTechnologie { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
