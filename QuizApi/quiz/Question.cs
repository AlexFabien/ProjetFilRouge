using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Question
    {
        public Question()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
            Reponse = new HashSet<Reponse>();
        }

        public int IdQuestion { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual TypeQuestion IdTypeQuestionNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
        public virtual ICollection<Reponse> Reponse { get; set; }
    }
}
