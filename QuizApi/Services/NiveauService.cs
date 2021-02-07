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
    public class NiveauService : IService<NiveauDto>
    {
        private IRepository<Niveau> repository;

        public NiveauService(IRepository<Niveau> repository)
        {
            this.repository = repository;
        }

        public NiveauDto Ajouter(NiveauDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(NiveauDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public NiveauDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<NiveauDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListNiveauToListNiveauDto(this.repository?.FindAll()?.ToList());
        }
    }
}
