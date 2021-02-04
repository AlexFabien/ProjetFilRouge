using QuizApi.Dtos;
using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Utils
{
    static class ConvertDtoEntity
    {
        public static List<ActeurHasQuestion> ConvertListActeurHasQuestionDtoToListActeurHasQuestion(ICollection<ActeurHasQuestionDto> collectionActeurHasQuestionDto)
        {
            List<ActeurHasQuestion> listActeurHasQuestion = null;
            if (collectionActeurHasQuestionDto != null)
            {
                listActeurHasQuestion = new List<ActeurHasQuestion>();
                foreach (ActeurHasQuestionDto acteurHasQuestionDto in collectionActeurHasQuestionDto)
                {
                    listActeurHasQuestion.Add(acteurHasQuestionDto);
                }
            }
            return listActeurHasQuestion;
        }

        internal static ICollection<ActeurHasQuestionDto> ConvertListActeurHasQuestionToListActeurHasQuestionDto(ICollection<ActeurHasQuestion> collectionActeurHasQuestion)
        {
            List<ActeurHasQuestionDto> listActeurHasQuestionDto = null;
            if (collectionActeurHasQuestion != null)
            {
                listActeurHasQuestionDto = new List<ActeurHasQuestionDto>();
                foreach (ActeurHasQuestion acteurHasQuestion in collectionActeurHasQuestion)
                {
                    listActeurHasQuestionDto.Add(acteurHasQuestion);
                }
            }
            return listActeurHasQuestionDto;
        }

        public static List<ActeurHasQuiz> ConvertListActeurHasQuizDtoToListActeurHasQuiz(ICollection<ActeurHasQuizDto> collectionActeurHasQuizDto)
        {
            List<ActeurHasQuiz> listActeurHasQuiz = null;
            if (collectionActeurHasQuizDto != null)
            {
                listActeurHasQuiz = new List<ActeurHasQuiz>();
                foreach (ActeurHasQuizDto acteurHasQuizDto in collectionActeurHasQuizDto)
                {
                    listActeurHasQuiz.Add(acteurHasQuizDto);
                }
            }
            return listActeurHasQuiz;
        }

        internal static ICollection<ActeurHasQuizDto> ConvertListActeurHasQuizToListActeurHasQuizDto(ICollection<ActeurHasQuiz> collectionActeurHasQuiz)
        {
            List<ActeurHasQuizDto> listActeurHasQuizDto = null;
            if (collectionActeurHasQuiz != null)
            {
                listActeurHasQuizDto = new List<ActeurHasQuizDto>();
                foreach (ActeurHasQuiz acteurHasQuiz in collectionActeurHasQuiz)
                {
                    listActeurHasQuizDto.Add(acteurHasQuiz);
                }
            }
            return listActeurHasQuizDto;
        }

        public static List<Question> ConvertListQuestionDtoToListQuestion(ICollection<QuestionDto> collectionQuestionDto)
        {
            List<Question> listQuestion = null;
            if (collectionQuestionDto != null)
            {
                listQuestion = new List<Question>();
                foreach (QuestionDto questionDto in collectionQuestionDto)
                {
                    listQuestion.Add(questionDto);
                }
            }
            return listQuestion;
        }

        internal static ICollection<QuestionDto> ConvertListQuestionToListQuestionDto(ICollection<Question> collectionQuestion)
        {
            List<QuestionDto> listQuestionDto = null;
            if (collectionQuestion != null)
            {
                listQuestionDto = new List<QuestionDto>();
                foreach (Question question in collectionQuestion)
                {
                    listQuestionDto.Add(question);
                }
            }
            return listQuestionDto;
        }

        public static List<Quiz> ConvertListQuizDtoToListQuiz(ICollection<QuizDto> collectionQuizDto)
        {
            List<Quiz> listQuiz = null;
            if (collectionQuizDto != null)
            {
                listQuiz = new List<Quiz>();
                foreach (QuizDto quizDto in collectionQuizDto)
                {
                    listQuiz.Add(quizDto);
                }
            }
            return listQuiz;
        }

        internal static ICollection<QuizDto> ConvertListQuizToListQuizDto(ICollection<Quiz> collectionQuiz)
        {
            List<QuizDto> listQuizDto = null;
            if (collectionQuiz != null)
            {
                listQuizDto = new List<QuizDto>();
                foreach (Quiz quiz in collectionQuiz)
                {
                    listQuizDto.Add(quiz);
                }
            }
            return listQuizDto;
        }

        public static List<Ventillation> ConvertListVentillationDtoToListVentillation(ICollection<VentillationDto> collectionVentillationDto)
        {
            List<Ventillation> listVentillation = null;
            if (collectionVentillationDto != null)
            {
                listVentillation = new List<Ventillation>();
                foreach (VentillationDto ventillationDto in collectionVentillationDto)
                {
                    listVentillation.Add(ventillationDto);
                }
            }
            return listVentillation;
        }

        internal static ICollection<VentillationDto> ConvertListVentillationToListVentillationDto(ICollection<Ventillation> collectionVentillation)
        {
            List<VentillationDto> listVentillationDto = null;
            if (collectionVentillation != null)
            {
                listVentillationDto = new List<VentillationDto>();
                foreach (Ventillation ventillation in collectionVentillation)
                {
                    listVentillationDto.Add(ventillation);
                }
            }
            return listVentillationDto;
        }

        public static List<Reponse> ConvertListReponseDtoToListReponse(ICollection<ReponseDto> collectionReponseDto)
        {
            List<Reponse> listReponse = null;
            if (collectionReponseDto != null)
            {
                listReponse = new List<Reponse>();
                foreach (ReponseDto reponseDto in collectionReponseDto)
                {
                    listReponse.Add(reponseDto);
                }
            }
            return listReponse;
        }

        internal static ICollection<ReponseDto> ConvertListReponseToListReponseDto(ICollection<Reponse> collectionReponse)
        {
            List<ReponseDto> listReponseDto = null;
            if (collectionReponse != null)
            {
                listReponseDto = new List<ReponseDto>();
                foreach (Reponse reponse in collectionReponse)
                {
                    listReponseDto.Add(reponse);
                }
            }
            return listReponseDto;
        }
    }
}
