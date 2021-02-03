using QuizApi.quiz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApi.Dtos
{
    public class ActeurHasQuestionDto
    {
        public int IdActeur { get; set; }
        public int IdQuestion { get; set; }
        public string Commentaire { get; set; }
        public int? IdEtatReponse { get; set; }
        public int? IdReponseCandidat { get; set; }

        public virtual ActeurDto IdActeurNavigation { get; set; }
        public virtual ReponduDto IdEtatReponseNavigation { get; set; }
        public virtual Question IdQuestionNavigation { get; set; }
        public virtual ReponseCandidatDto IdReponseCandidatNavigation { get; set; }
    }
}
