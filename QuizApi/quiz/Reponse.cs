using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Reponse
    {
        public int IdReponse { get; set; }
        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
        public int? IdQuestion { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
    }
}
