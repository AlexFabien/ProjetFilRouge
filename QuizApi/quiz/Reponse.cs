﻿using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class Reponse
    {
        public Reponse()
        {
        }

        public Reponse(string libelle, byte? reponseCorrecte)
        {
            Libelle = libelle;
            ReponseCorrecte = reponseCorrecte;
        }

        public Reponse(int idReponse,string libelle, byte? reponseCorrecte,int?idQuestion)
        {
            IdReponse = idReponse;
            Libelle = libelle;
            ReponseCorrecte = reponseCorrecte;
            IdQuestion = idQuestion;
        }

        public int IdReponse { get; set; }
        public string Libelle { get; set; }
        public byte? ReponseCorrecte { get; set; }
        public int? IdQuestion { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
    }
}
