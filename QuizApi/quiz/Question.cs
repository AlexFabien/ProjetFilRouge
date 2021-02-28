﻿using QuizApi.Dtos;
using QuizApi.Utils;
using System;
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

        public Question(int idQuestion, int? numero, string libelle, string explicationReponse, 
            int? idNiveau, int? idTypeQuestion, int? idQuiz, int? idTechnologie) : this()
        {
            IdQuestion = idQuestion;
            Numero = numero;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
        }

        public int IdQuestion { get; set; }
        public int? Numero { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }
        public int? IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Quiz IdQuizNavigation { get; set; }
        public virtual Technologie IdTechnologieNavigation { get; set; }
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
                question.Numero,
                question.Libelle,
                question.ExplicationReponse,
                question.IdNiveau,
                question.IdTypeQuestion,
                question.IdQuiz,
                question.IdTechnologie
                );
        }
    }
}
