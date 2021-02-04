using QuizApi.quiz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApi.Dtos
{
    public class ActeurHasQuestionDto
    {
        public ActeurHasQuestionDto(int idActeur, int idQuestion, string commentaire, 
                int? idEtatReponse, int? idReponseCandidat, ActeurDto idActeurNavigation, 
                ReponduDto idEtatReponseNavigation, QuestionDto idQuestionNavigation, 
                ReponseCandidatDto idReponseCandidatNavigation)
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

        public virtual ActeurDto IdActeurNavigation { get; set; }
        public virtual ReponduDto IdEtatReponseNavigation { get; set; }
        public virtual QuestionDto IdQuestionNavigation { get; set; }
        public virtual ReponseCandidatDto IdReponseCandidatNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une acteurHasQuestion(DTO) en acteurHasQuestion(Models) automatiquement
        /// </summary>
        /// <param name="acteurHasQuestion"></param>
        public static implicit operator ActeurHasQuestion(ActeurHasQuestionDto acteurHasQuestionDto)
        {
            return new ActeurHasQuestion(
                acteurHasQuestionDto.IdActeur,
                acteurHasQuestionDto.IdQuestion,
                acteurHasQuestionDto.Commentaire,
                acteurHasQuestionDto.IdEtatReponse,
                acteurHasQuestionDto.IdReponseCandidat,
                acteurHasQuestionDto.IdActeurNavigation,
                acteurHasQuestionDto.IdEtatReponseNavigation,
                acteurHasQuestionDto.IdQuestionNavigation,
                acteurHasQuestionDto.IdReponseCandidatNavigation
                );
        }
    }
}
