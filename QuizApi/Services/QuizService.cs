using QuizApi.Dtos;
using QuizApi.Repositories;
using QuizApi.Utils;
using QuizApi.quiz;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QuizApi.Services
{
    public class QuizService : IService<QuizDto>
    {
        private IRepository<Quiz> repository;

        public QuizService(IRepository<Quiz> repository)
        {
            this.repository = repository;
        }

        public QuizDto Ajouter(QuizDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(QuizDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public QuizDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<QuizDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListQuizToListQuizDto(this.repository?.FindAll()?.ToList());
        }
    }
}
