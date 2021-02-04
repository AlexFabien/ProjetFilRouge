using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            ActeurHasQuestion = new HashSet<ActeurHasQuestionDto>();
            Reponse = new HashSet<ReponseDto>();
        }

        public QuestionDto(int idQuestion, string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion,
            NiveauDto idNiveauNavigation, TypeQuestionDto idTypeQuestionNavigation,
            ICollection<ActeurHasQuestionDto> acteurHasQuestion, ICollection<ReponseDto> reponse)
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

        public virtual NiveauDto IdNiveauNavigation { get; set; }
        public virtual TypeQuestionDto IdTypeQuestionNavigation { get; set; }
        public virtual ICollection<ActeurHasQuestionDto> ActeurHasQuestion { get; set; }
        public virtual ICollection<ReponseDto> Reponse { get; set; }

        /// <summary>
        /// Fonction qui transforme une question(DTO) en question(Models) automatiquement
        /// </summary>
        /// <param name="questionDto"></param>
        public static implicit operator Question(QuestionDto questionDto)
        {
            return new Question(
                questionDto.IdQuestion,
                questionDto.Libelle,
                questionDto.ExplicationReponse,
                questionDto.IdNiveau,
                questionDto.IdTypeQuestion,
                questionDto.IdNiveauNavigation,
                questionDto.IdTypeQuestionNavigation,
                ConvertDtoEntity.ConvertListActeurHasQuestionDtoToListActeurHasQuestion(questionDto.ActeurHasQuestion),
                ConvertDtoEntity.ConvertListReponseDtoToListReponse(questionDto.Reponse)
                );
        }
    }
}
