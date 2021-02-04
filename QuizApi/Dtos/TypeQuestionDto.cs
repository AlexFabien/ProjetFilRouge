using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class TypeQuestionDto
    {
        public TypeQuestionDto()
        {
            Question = new HashSet<QuestionDto>();
        }

        public TypeQuestionDto(int idTypeQuestion, string libelle, ICollection<QuestionDto> question)
        {
            IdTypeQuestion = idTypeQuestion;
            Libelle = libelle;
            Question = question;
        }

        public int IdTypeQuestion { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<QuestionDto> Question { get; set; }

        /// <summary>
        /// Fonction qui transforme une typeQuestion(DTO) en typeQuestion(Models) automatiquement
        /// </summary>
        /// <param name="typeQuestionDto"></param>
        public static implicit operator TypeQuestion(TypeQuestionDto typeQuestionDto)
        {
            return new TypeQuestion(
                typeQuestionDto.IdTypeQuestion,
                typeQuestionDto.Libelle,
                ConvertDtoEntity.ConvertListQuestionDtoToListQuestion(typeQuestionDto.Question)
                );
        }
    }
}
