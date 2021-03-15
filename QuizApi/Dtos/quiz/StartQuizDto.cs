using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class StartQuizDto
    {
        public StartQuizDto()
        {
        }

        public StartQuizDto(string libelle, int? idTechnologie, int? idNiveau, int? nbQuestions, Acteur2Dto candidat)
        {
            Libelle = libelle;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            NbQuestions = nbQuestions;
            Candidat = candidat;
        }

        public string Libelle { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }
        public int? NbQuestions { get; set; }
        public Acteur2Dto Candidat { get; set; }
    }
}
