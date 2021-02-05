using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    public class QuestionService
    {
        private QuestionRepository questionRepository;

        public QuestionService()
        {
            this.questionRepository = new QuestionRepository(new QueryBuilder());
        }

        internal List<QuestionDto> FindAll()
        {
            List<Question> question = questionRepository.FindAll();
            List<QuestionDto> questionsDtos = new List<QuestionDto>();
            question.ForEach(q => { questionsDtos.Add(q); });
            return questionsDtos;
        }

        internal QuestionDto Find(int id)
        {
            Question question = questionRepository.Find(id);
            return question;
        }

        internal QuestionDto PostNiveau(CreateQuestionDto dto)
        {
            Question question = ConvertDtoToEntity(dto);
            Question qConverted = questionRepository.Create(question);
            return qConverted;
        }

        internal QuestionDto UpdateQuestion(int id, CreateQuestionDto newDto)
        {
            Question question = ConvertDtoToEntity(newDto);
            Question newQuestion = questionRepository.Update(id, question);
            return newQuestion;
        }
        internal int Delete(int id)
        {
            return questionRepository.Delete(id);
        }

        private Question ConvertDtoToEntity(CreateQuestionDto dto)
        {
            Question qConverted = new Question();
            qConverted.Libelle = dto.Libelle;
            qConverted.ExplicationReponse = dto.ExplicationReponse;
            return qConverted;
        }
    }
}
