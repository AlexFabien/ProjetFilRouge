using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class TechnologieDto
    {
        public TechnologieDto()
        {
            Quiz = new HashSet<QuizDto>();
        }

        public int IdTechnologie { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<QuizDto> Quiz { get; set; }
    }
}
