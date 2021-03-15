using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuestionAvecReponseDto
    {
        public QuestionAvecReponseDto()
        {
            Reponses = new HashSet<ReponseDto>();
        }

        public QuestionAvecReponseDto(int idQuestion, int? numero, string libelle, string explicationReponse, 
            int? idNiveau, int? idTypeQuestion, int? idQuiz, int? idTechnologie)
        {
            IdQuestion = idQuestion;
            Numero = numero;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
        }

        public QuestionAvecReponseDto(int idQuestion, int? numero, string libelle, string explicationReponse, int? idNiveau, 
            int? idTypeQuestion, int? idQuiz, int? idTechnologie, ICollection<ReponseDto> reponses) : 
            this(idQuestion, numero, libelle, explicationReponse, idNiveau, idTypeQuestion, idQuiz, idTechnologie)
        {
            Reponses = reponses;
        }

        public int IdQuestion { get; set; }
        public int ?Numero { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }
        public int? IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }
        public virtual ICollection<ReponseDto> Reponses { get; set; }

        /// <summary>
        /// Fonction qui transforme une question(DTO) en question(Models) automatiquement
        /// </summary>
        /// <param name="questionDto"></param>
        public static implicit operator Question(QuestionAvecReponseDto questionDto)
        {
            return new Question(
                questionDto.IdQuestion,
                questionDto.Numero,
                questionDto.Libelle,
                questionDto.ExplicationReponse,
                questionDto.IdNiveau,
                questionDto.IdTypeQuestion,
                questionDto.IdQuiz,
                questionDto.IdTechnologie,
                ConvertDtoEntity.ConvertListReponseDtoToListReponse(questionDto.Reponses)
                );
        }
    }
}
