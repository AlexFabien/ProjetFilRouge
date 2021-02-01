using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Acteur
    {
        public Acteur()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
            ActeurHasQuiz = new HashSet<ActeurHasQuiz>();
        }

        public int IdActeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
        public virtual ICollection<ActeurHasQuiz> ActeurHasQuiz { get; set; }
    }
}
