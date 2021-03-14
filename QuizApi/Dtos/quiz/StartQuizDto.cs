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

        public StartQuizDto(string libelle, int? idTechnologie, int? idNiveau, Acteur2Dto candidat)
        {
            Libelle = libelle;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            Candidat = candidat;
        }

        public string Libelle { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }
        public Acteur2Dto Candidat { get; set; }
    }
}
