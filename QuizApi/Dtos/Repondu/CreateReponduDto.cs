using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class CreateReponduDto 
    {
        public CreateReponduDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
        }

        public string Libelle { get; set; }

        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
    }
}
