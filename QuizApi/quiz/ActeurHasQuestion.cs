using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class ActeurHasQuestion
    {
        public ActeurHasQuestion()
        {
            ReponseCandidat = new HashSet<ReponseCandidat>();
        }

        public ActeurHasQuestion(int idActeur, int idQuestion, string commentaire, int? idEtatReponse) : this()
        {
            IdActeur = idActeur;
            IdQuestion = idQuestion;
            Commentaire = commentaire;
            IdEtatReponse = idEtatReponse;
        }

        public int IdActeur { get; set; }
        public int IdQuestion { get; set; }
        public string Commentaire { get; set; }
        public int? IdEtatReponse { get; set; }

        public virtual Acteur IdActeurNavigation { get; set; }
        public virtual Repondu IdEtatReponseNavigation { get; set; }
        public virtual Question IdQuestionNavigation { get; set; }
        public virtual ICollection<ReponseCandidat> ReponseCandidat { get; set; }


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
                acteurHasQuestion.IdEtatReponse
                );
        }
    }
}
