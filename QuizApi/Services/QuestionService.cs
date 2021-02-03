using QuizApi.Dtos.Niveau;
using QuizApi.Dtos.Role;
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
            question.ForEach(q => { questionsDtos.Add(ConvertEntityToDto(q)); });
            return questionsDtos;
        }

        internal QuestionDto Find(int id)
        {
            Question question = questionRepository.Find(id);
            QuestionDto niveauDto = ConvertEntityToDto(question);
            return niveauDto;
        }

        internal QuestionDto PostNiveau(CreateQuestionDto dto)
        {
            Question question = ConvertDtoToEntity(dto);
            Question qConverted = questionRepository.Create(question);
            return ConvertEntityToDto(qConverted);
        }

        internal QuestionDto UpdateQuestion(int id, CreateQuestionDto newDto)
        {
            Question question = ConvertDtoToEntity(newDto);
            Question newQuestion = questionRepository.Update(id, question);
            return ConvertEntityToDto(newQuestion);
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

        private QuestionDto ConvertEntityToDto(Question question)
        {
            return new QuestionDto(question.IdQuestion, question.Libelle, question.ExplicationReponse, question.IdNiveau, question.IdTypeQuestion);
        }
    }
}
