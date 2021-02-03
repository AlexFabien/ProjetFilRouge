using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuizDto
    {
        public QuizDto()
        {
            ActeurHasQuiz = new HashSet<ActeurHasQuizDto>();
        }

        public int IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }

        public virtual NiveauDto IdNiveauNavigation { get; set; }
        public virtual TechnologieDto IdTechnologieNavigation { get; set; }
        public virtual ICollection<ActeurHasQuizDto> ActeurHasQuiz { get; set; }
    }
}
