using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Niveau
    {
        public Niveau()
        {
            Question = new HashSet<Question>();
            Quiz = new HashSet<Quiz>();
            VentillationIdNiveauQuestionNavigation = new HashSet<Ventillation>();
            VentillationIdNiveauQuizNavigation = new HashSet<Ventillation>();
        }

        public Niveau(int idNiveau, string libelle):this()
        {
            IdNiveau = idNiveau;
            Libelle = libelle;
        }

        public Niveau(int idNiveau, string libelle, ICollection<Question> question, ICollection<Quiz> quiz,
            ICollection<Ventillation> ventillationIdNiveauQuestionNavigation,
            ICollection<Ventillation> ventillationIdNiveauQuizNavigation)
        {
            IdNiveau = idNiveau;
            Libelle = libelle;
            Question = question;
            Quiz = quiz;
            VentillationIdNiveauQuestionNavigation = ventillationIdNiveauQuestionNavigation;
            VentillationIdNiveauQuizNavigation = ventillationIdNiveauQuizNavigation;
        }

        public int IdNiveau { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Quiz> Quiz { get; set; }
        public virtual ICollection<Ventillation> VentillationIdNiveauQuestionNavigation { get; set; }
        public virtual ICollection<Ventillation> VentillationIdNiveauQuizNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une niveau(Models) en niveau(DTO) automatiquement
        /// </summary>
        /// <param name="niveau"></param>
        public static implicit operator NiveauDto(Niveau niveau)
        {
            return new NiveauDto(
                niveau.IdNiveau,
                niveau.Libelle
                );
        }
    }
}
