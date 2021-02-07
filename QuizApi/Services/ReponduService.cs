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
    public class ReponduService : IService<ReponduDto>
    {
        private IRepository<Repondu> repository;

        public ReponduService(IRepository<Repondu> repository)
        {
            this.repository = repository;
        }

        public ReponduDto Ajouter(ReponduDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(ReponduDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public ReponduDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<ReponduDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListReponduToListReponduDto(this.repository?.FindAll()?.ToList());
        }
    }
}

