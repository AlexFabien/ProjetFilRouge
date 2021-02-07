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
    public class ParametrageService : IService<ParametrageDto>
    {
        private IRepository<Parametrage> repository;

        public ParametrageService(IRepository<Parametrage> repository)
        {
            this.repository = repository;
        }

        public ParametrageDto Ajouter(ParametrageDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(ParametrageDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public ParametrageDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<ParametrageDto> TrouverTout()
        {
            List<ParametrageDto> parametragesDto = new List<ParametrageDto>();
            this.repository.FindAll().ToList().ForEach(p => parametragesDto.Add(new ParametrageDto(p.Valeur, p.IdParametrage)));
            return parametragesDto;
        }
    }
}
