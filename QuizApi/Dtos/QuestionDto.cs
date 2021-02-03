using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestionDto>();
            Reponse = new HashSet<ReponseDto>();
        }

        public int IdQuestion { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }

        public virtual NiveauDto IdNiveauNavigation { get; set; }
        public virtual TypeQuestionDto IdTypeQuestionNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestionDto> ActeurHasQuestion { get; set; }
        public virtual ICollection<ReponseDto> Reponse { get; set; }
    }
}
