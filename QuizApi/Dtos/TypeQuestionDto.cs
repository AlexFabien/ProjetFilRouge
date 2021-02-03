using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class TypeQuestionDto
    {
        public TypeQuestionDto()
        {
            Question = new HashSet<QuestionDto>();
        }

        public int IdTypeQuestion { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<QuestionDto> Question { get; set; }
    }
}
