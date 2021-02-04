using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

namespace QuizApi.Dtos
{
    public class QuizDto
    {
        public QuizDto()
        {
            ActeurHasQuiz = new HashSet<ActeurHasQuizDto>();
        }

        public QuizDto(int idQuiz, int? idTechnologie, int? idNiveau, NiveauDto idNiveauNavigation,
            TechnologieDto idTechnologieNavigation, ICollection<ActeurHasQuizDto> acteurHasQuiz)
        {
            IdQuiz = idQuiz;
            IdTechnologie = idTechnologie;
            IdNiveau = idNiveau;
            IdNiveauNavigation = idNiveauNavigation;
            IdTechnologieNavigation = idTechnologieNavigation;
            ActeurHasQuiz = acteurHasQuiz;
        }

        public int IdQuiz { get; set; }
        public int? IdTechnologie { get; set; }
        public int? IdNiveau { get; set; }

        public virtual NiveauDto IdNiveauNavigation { get; set; }
        public virtual TechnologieDto IdTechnologieNavigation { get; set; }
        public virtual ICollection<ActeurHasQuizDto> ActeurHasQuiz { get; set; }

        /// <summary>
        /// Fonction qui transforme une quiz(DTO) en quiz(Models) automatiquement
        /// </summary>
        /// <param name="quizDto"></param>
        public static implicit operator Quiz(QuizDto quizDto)
        {
            return new Quiz(
                quizDto.IdQuiz,
                quizDto.IdTechnologie,
                quizDto.IdNiveau,
                quizDto.IdNiveauNavigation,
                quizDto.IdTechnologieNavigation,
                ConvertDtoEntity.ConvertListActeurHasQuizDtoToListActeurHasQuiz(quizDto.ActeurHasQuiz)
                );
        }
    }
}
