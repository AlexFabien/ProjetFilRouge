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
    public class QuestionService : IService<QuestionDto>
    {
        private IRepository<Question> repository;

        public QuestionService(IRepository<Question> repository)
        {
            this.repository = repository;
        }

        public QuestionDto Ajouter(QuestionDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(QuestionDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public QuestionDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<QuestionDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListQuestionToListQuestionDto(this.repository?.FindAll()?.ToList());
        }
    }
}
