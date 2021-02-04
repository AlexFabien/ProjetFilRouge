using QuizApi.Dtos;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.quiz
{
    public partial class TypeQuestion
    {
        public TypeQuestion()
        {
            Question = new HashSet<Question>();
        }

        public TypeQuestion(int idTypeQuestion, string libelle, ICollection<Question> question)
        {
            IdTypeQuestion = idTypeQuestion;
            Libelle = libelle;
            Question = question;
        }

        public int IdTypeQuestion { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Question> Question { get; set; }

        /// <summary>
        /// Fonction qui transforme une typeQuestion(Models) en typeQuestion(DTO) automatiquement
        /// </summary>
        /// <param name="typeQuestion"></param>
        public static implicit operator TypeQuestionDto(TypeQuestion typeQuestion)
        {
            return new TypeQuestionDto(
                typeQuestion.IdTypeQuestion,
                typeQuestion.Libelle,
                ConvertDtoEntity.ConvertListQuestionToListQuestionDto(typeQuestion.Question)
                );
        }
    }
}
