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
    public class TechnologieService : IService<TechnologieDto>
    {
        private IRepository<Technologie> repository;

        public TechnologieService(IRepository<Technologie> repository)
        {
            this.repository = repository;
        }

        public void Ajouter(TechnologieDto obj)
        {
            this.repository.Insert(obj);
        }

        public void Modifier(TechnologieDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public TechnologieDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<TechnologieDto> TrouverTout()
        {
            List<TechnologieDto> technologieDto = new List<TechnologieDto>();
            this.repository.FindAll().ToList().ForEach(p => technologieDto.Add(new TechnologieDto(p.Libelle, p.IdTechnologie)));
            return technologieDto;
        }
    }
}
