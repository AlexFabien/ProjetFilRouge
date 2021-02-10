using QuizApi.Dtos;
using QuizApi.Utils;
using System;
﻿using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Question
    {
        public Question()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestion>();
            Reponse = new HashSet<Reponse>();
        }

        public Question(int idQuestion, string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion, int? idQuiz)
        {
            IdQuestion = idQuestion;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
            IdQuiz = idQuiz;
        }

        public Question(int idQuestion, string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion,
            Niveau idNiveauNavigation, TypeQuestion idTypeQuestionNavigation,
            ICollection<ActeurHasQuestion> acteurHasQuestion, ICollection<Reponse> reponse)
        {
            IdQuestion = idQuestion;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
            IdNiveauNavigation = idNiveauNavigation;
            IdTypeQuestionNavigation = idTypeQuestionNavigation;
            ActeurHasQuestion = acteurHasQuestion;
            Reponse = reponse;
        }

        public int IdQuestion { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }
        public int? IdQuiz { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Quiz IdQuizNavigation { get; set; }
        public virtual TypeQuestion IdTypeQuestionNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestion> ActeurHasQuestion { get; set; }
        public virtual ICollection<Reponse> Reponse { get; set; }

        /// <summary>
        /// Fonction qui transforme une question(Models) en question(DTO) automatiquement
        /// </summary>
        /// <param name="question"></param>
        public static implicit operator QuestionDto(Question question)
        {
            return new QuestionDto(
                question.IdQuestion,
                question.Libelle,
                question.ExplicationReponse,
                question.IdNiveau,
                question.IdTypeQuestion,
                question.IdQuiz
                );
        }
    }
}
