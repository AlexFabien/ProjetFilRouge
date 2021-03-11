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
    public class TypeQuestionService : IService<TypeQuestionDto>
    {
        private IRepository<TypeQuestion> repository;

        public TypeQuestionService(IRepository<TypeQuestion> repository)
        {
            this.repository = repository;
        }

        public TypeQuestionDto Ajouter(TypeQuestionDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(TypeQuestionDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public TypeQuestionDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<TypeQuestionDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListTypeQuestionToListTypeQuestionDto(this.repository?.FindAll()?.ToList());
        }
    }
}
