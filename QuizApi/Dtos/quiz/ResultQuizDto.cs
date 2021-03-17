using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class ResultQuizDto
    {
        public ResultQuizDto()
        {
            Reponses = new HashSet<ResultReponseCandidatDto>();
        }

        public ResultQuizDto(string libelle, int? idTechnologie, int? idNiveau, int? nbQuestions) : this()
        {
            Libelle = libelle;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            NbQuestions = nbQuestions;
        }

        public ResultQuizDto(string libelle, int? idTechnologie, int? idNiveau, int? nbQuestions, 
            ICollection<ResultReponseCandidatDto> reponses) : this(libelle, idTechnologie, idNiveau, nbQuestions)
        {
            Reponses = reponses;
        }

        public string Libelle { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }
        public int? NbQuestions { get; set; }
        public virtual ICollection<ResultReponseCandidatDto> Reponses { get; set; }
    }
}
