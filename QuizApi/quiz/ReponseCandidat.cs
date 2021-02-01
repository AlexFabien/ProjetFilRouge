using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ReponseCandidat
    {
        public ReponseCandidat()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public int IdReponseCandidat { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
    }
}
