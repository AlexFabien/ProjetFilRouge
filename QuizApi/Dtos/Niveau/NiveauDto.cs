using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos.Niveau
{
    public class NiveauDto
    {
        public NiveauDto() { }

        public NiveauDto(int idNiveau, string libelle)
        {
            IdNiveau = idNiveau;
            Libelle = libelle;
        }

        public int IdNiveau { get; set; }
        public string Libelle { get; set; }
    }
}
