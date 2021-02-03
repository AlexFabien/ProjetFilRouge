using QuizApi.Dtos;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ActeurHasQuestion
    {
        public ActeurHasQuestion(int idActeur, int idQuestion, string commentaire, 
            int? idEtatReponse, int? idReponseCandidat, Acteur idActeurNavigation,
            Repondu idEtatReponseNavigation, Question idQuestionNavigation, ReponseCandidat idReponseCandidatNavigation)
        {
            IdActeur = idActeur;
            IdQuestion = idQuestion;
            Commentaire = commentaire;
            IdEtatReponse = idEtatReponse;
            IdReponseCandidat = idReponseCandidat;
            IdActeurNavigation = idActeurNavigation;
            IdEtatReponseNavigation = idEtatReponseNavigation;
            IdQuestionNavigation = idQuestionNavigation;
            IdReponseCandidatNavigation = idReponseCandidatNavigation;
        }

        public int IdActeur { get; set; }
        public int IdQuestion { get; set; }
        public string Commentaire { get; set; }
        public int? IdEtatReponse { get; set; }
        public int? IdReponseCandidat { get; set; }

        public virtual Acteur IdActeurNavigation { get; set; }
        public virtual Repondu IdEtatReponseNavigation { get; set; }
        public virtual Question IdQuestionNavigation { get; set; }
        public virtual ReponseCandidat IdReponseCandidatNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une acteurHasQuestion(Models) en acteurHasQuestion(DTO) automatiquement
        /// </summary>
        /// <param name="acteurHasQuestion"></param>
        public static implicit operator ActeurHasQuestionDto(ActeurHasQuestion acteurHasQuestion)
        {
            return new ActeurHasQuestionDto(
                acteurHasQuestion.IdActeur,
                acteurHasQuestion.IdQuestion,
                acteurHasQuestion.Commentaire,
                acteurHasQuestion.IdEtatReponse,
                acteurHasQuestion.IdReponseCandidat,
                acteurHasQuestion.IdActeurNavigation,
                acteurHasQuestion.IdEtatReponseNavigation,
                acteurHasQuestion.IdQuestionNavigation,
                acteurHasQuestion.IdReponseCandidatNavigation
                );
        }
    }
}
