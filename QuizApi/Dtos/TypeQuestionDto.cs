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
        }

        public TypeQuestionDto(int idTypeQuestion, string libelle)
        {
            IdTypeQuestion = idTypeQuestion;
            Libelle = libelle;
        }

        public int IdTypeQuestion { get; set; }
        public string Libelle { get; set; }

        /// <summary>
        /// Fonction qui transforme une typeQuestion(DTO) en typeQuestion(Models) automatiquement
        /// </summary>
        /// <param name="typeQuestionDto"></param>
        public static implicit operator TypeQuestion(TypeQuestionDto typeQuestionDto)
        {
            return new TypeQuestion(
                typeQuestionDto.IdTypeQuestion,
                typeQuestionDto.Libelle
                );
        }
    }
}
