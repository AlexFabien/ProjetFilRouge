using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Role
    {
        public Role()
        {
            Acteur = new HashSet<Acteur>();
        }

        public int IdRole { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Acteur> Acteur { get; set; }
    }
}
