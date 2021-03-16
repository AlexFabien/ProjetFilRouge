using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApi.Dtos
{
    public class CreatedActeurHasQuestionDto
    {
        public CreatedActeurHasQuestionDto()
        {
            ReponsesCandidat = new HashSet<CreatedReponseCandidatDto>();
        }
        public CreatedActeurHasQuestionDto(string commentaire, int? idEtatReponse) : this()
        {
            Commentaire = commentaire;
            IdEtatReponse = idEtatReponse;
        }

        public string Commentaire { get; set; }
        public int? IdEtatReponse { get; set; }
        public virtual ICollection<CreatedReponseCandidatDto> ReponsesCandidat { get; set; }

    }
}
