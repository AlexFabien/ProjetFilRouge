using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Repondu
    {
        public Repondu()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public Repondu(string libelle)
        {
            Libelle = libelle;
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
    }
}
