using QuizApi.Dtos;
using System;
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

        /// <summary>
        /// Fonction qui transforme une reponse(Models) en reponse(DTO) automatiquement
        /// </summary>
        /// <param name="reponse"></param>
        public static implicit operator ReponseDto(Reponse reponse)
        {
            return new ReponseDto(
                reponse.IdReponse,
                reponse.Libelle,
                reponse.ReponseCorrecte,
                reponse.IdQuestion,
                reponse.IdQuestionNavigation
                );
        }
    }
}
