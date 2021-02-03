using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class ReponduDto
    {
        public ReponduDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestionDto>();
        }

        public int IdEtatReponse { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<ActeurHasQuestionDto> ActeurHasQuestion { get; set; }
    }
}
