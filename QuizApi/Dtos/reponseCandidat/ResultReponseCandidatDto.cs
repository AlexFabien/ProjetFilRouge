using QuizApi.quiz;
using QuizApi.Utils;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class ResultReponseCandidatDto
    {
        public ResultReponseCandidatDto()
        {
        }

        public ResultReponseCandidatDto(string libelle, int? total)
        {
            Libelle = libelle;
            Total = total;
        }

        public string Libelle { get; set; }
        public int? Total { get; set; }
    }
}
