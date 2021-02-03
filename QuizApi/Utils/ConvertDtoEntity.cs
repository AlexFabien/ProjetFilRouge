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
        public static List<ActeurHasQuestion> ConvertListActeurHasQuestionDtoToListActeurHasQuestion(ICollection<ActeurHasQuestionDto> acteurHasQuestion)
        {
            List<ActeurHasQuestion> listActeurHasQuestion = null;
            if (acteurHasQuestion != null)
            {
                listActeurHasQuestion = new List<ActeurHasQuestion>();
                foreach (ActeurHasQuestionDto acteurHasQuestionDto in acteurHasQuestion)
                {
                    listActeurHasQuestion.Add(acteurHasQuestionDto);
                }
            }
            return listActeurHasQuestion;
        }

        internal static ICollection<ActeurHasQuestionDto> ConvertListActeurHasQuestionToListActeurHasQuestionDto(ICollection<ActeurHasQuestion> acteurHasQuestionDto)
        {
            List<ActeurHasQuestionDto> listActeurHasQuestion = null;
            if (acteurHasQuestionDto != null)
            {
                listActeurHasQuestion = new List<ActeurHasQuestionDto>();
                foreach (ActeurHasQuestion acteurHasQuestion in acteurHasQuestionDto)
                {
                    listActeurHasQuestion.Add(acteurHasQuestion);
                }
            }
            return listActeurHasQuestion;
        }
    }
}
