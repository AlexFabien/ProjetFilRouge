using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Dtos
{
    public class NiveauDto
    {
        public NiveauDto()
        {
            Question = new HashSet<QuestionDto>();
            Quiz = new HashSet<QuizDto>();
            VentillationIdNiveauQuestionNavigation = new HashSet<VentillationDto>();
            VentillationIdNiveauQuizNavigation = new HashSet<VentillationDto>();
        }

        public NiveauDto(int idNiveau, string libelle, ICollection<QuestionDto> question, ICollection<QuizDto> quiz,
            ICollection<VentillationDto> ventillationIdNiveauQuestionNavigation,
            ICollection<VentillationDto> ventillationIdNiveauQuizNavigation)
        {
            IdNiveau = idNiveau;
            Libelle = libelle;
            Question = question;
            Quiz = quiz;
            VentillationIdNiveauQuestionNavigation = ventillationIdNiveauQuestionNavigation;
            VentillationIdNiveauQuizNavigation = ventillationIdNiveauQuizNavigation;
        }

        public int IdNiveau { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<QuestionDto> Question { get; set; }
        public virtual ICollection<QuizDto> Quiz { get; set; }
        public virtual ICollection<VentillationDto> VentillationIdNiveauQuestionNavigation { get; set; }
        public virtual ICollection<VentillationDto> VentillationIdNiveauQuizNavigation { get; set; }

        /// <summary>
        /// Fonction qui transforme une niveau(DTO) en niveau(Models) automatiquement
        /// </summary>
        /// <param name="niveauDto"></param>
        public static implicit operator Niveau(NiveauDto niveauDto)
        {
            return new Niveau(
                niveauDto.IdNiveau,
                niveauDto.Libelle,
                ConvertDtoEntity.ConvertListQuestionDtoToListQuestion(niveauDto.Question),
                ConvertDtoEntity.ConvertListQuizDtoToListQuiz(niveauDto.Quiz),
                ConvertDtoEntity.ConvertListVentillationDtoToListVentillation(niveauDto.VentillationIdNiveauQuestionNavigation),
                ConvertDtoEntity.ConvertListVentillationDtoToListVentillation(niveauDto.VentillationIdNiveauQuizNavigation)
                ) ;
        }
    }
}
