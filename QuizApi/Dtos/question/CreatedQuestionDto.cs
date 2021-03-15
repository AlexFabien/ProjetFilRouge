using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class CreatedQuestionDto
    {
        public CreatedQuestionDto()
        {
            Reponses = new HashSet<CreatedReponseDto>();
        }

        public CreatedQuestionDto(string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion, int? idTechnologie) : this()
        {
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
            IdTechnologie = idTechnologie;
        }

        public CreatedQuestionDto(string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion,  
            int? idTechnologie, ICollection<CreatedReponseDto> reponses) : this(libelle, explicationReponse, idNiveau, idTypeQuestion, idTechnologie)
        {
            Reponses = reponses;
        }

        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }
        public int? IdTechnologie { get; set; }
        public virtual ICollection<CreatedReponseDto> Reponses { get; set; }

        /// <summary>
        /// Fonction qui transforme une CreatedQuestion(DTO) en question(Models) automatiquement
        /// </summary>
        /// <param name="questionDto"></param>
        public static implicit operator Question(CreatedQuestionDto questionDto)
        {
            return new Question(
                0,
                null,
                questionDto.Libelle,
                questionDto.ExplicationReponse,
                questionDto.IdNiveau,
                questionDto.IdTypeQuestion,
                null,
                questionDto.IdTechnologie,
                ConvertDtoEntity.ConvertListCreatedReponseDtoToListReponse(questionDto.Reponses)
                );
        }
    }
}
