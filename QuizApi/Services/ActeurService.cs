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
    public class ActeurService : IService<ActeurDto>
    {
        private IRepository<Acteur> repository;

        public ActeurService(IRepository<Acteur> repository)
        {
            this.repository = repository;
        }

        public void Ajouter(ActeurDto obj)
        {
            this.repository.Insert(obj);
        }

        public void Modifier(ActeurDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public ActeurDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<ActeurDto> TrouverTout()
        {
            List<ActeurDto> acteursDto = new List<ActeurDto>();
            //this.repository.FindAll().ToList().ForEach(p => acteursDto.Add(new ActeurDto(p.IdActeur)));
            return acteursDto;
        }
    }
}
