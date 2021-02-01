using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ActeurHasQuestion
    {
        public int IdActeur { get; set; }
        public int IdQuestion { get; set; }
        public string Commentaire { get; set; }
        public int? IdEtatReponse { get; set; }
        public int? IdReponseCandidat { get; set; }

        public virtual Acteur IdActeurNavigation { get; set; }
        public virtual Repondu IdEtatReponseNavigation { get; set; }
        public virtual Question IdQuestionNavigation { get; set; }
        public virtual ReponseCandidat IdReponseCandidatNavigation { get; set; }
    }
}
