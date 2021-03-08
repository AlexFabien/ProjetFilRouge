using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class GetAllQuizDto
    {
        public GetAllQuizDto()
        {
        }

        public GetAllQuizDto(int idQuiz, string libelle, int? nbQuestions, NiveauDto niveau, TechnologieDto technologie)
        {
            IdQuiz = idQuiz;
            Libelle = libelle;
            NbQuestions = nbQuestions;
            Niveau = niveau;
            Technologie = technologie;
        }

        public int IdQuiz { get; set; }
        public string Libelle { get; set; }
        public int? NbQuestions { get; set; }
        public virtual NiveauDto Niveau { get; set; }
        public virtual TechnologieDto Technologie { get; set; }

    }
}
