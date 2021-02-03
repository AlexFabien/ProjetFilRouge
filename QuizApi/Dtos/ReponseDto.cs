using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class ReponseDto
    {
        public int IdReponse { get; set; }
        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
        public int? IdQuestion { get; set; }

        public virtual QuestionDto IdQuestionNavigation { get; set; }
    }
}
