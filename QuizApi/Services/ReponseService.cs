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
    public class ReponseService : IService<ReponseDto>
    {
        private IRepository<Reponse> repository;

        public ReponseService(IRepository<Reponse> repository)
        {
            this.repository = repository;
        }

        public void Ajouter(ReponseDto obj)
        {
            this.repository.Insert(obj);
        }

        public void Modifier(ReponseDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public ReponseDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<ReponseDto> TrouverTout()
        {

            List<ReponseDto> reponsesDto = new List<ReponseDto>();
            //this.repository.FindAll().ToList().ForEach(p => reponsesDto.Add(new ReponseDto(p.IdReponse)));
            return reponsesDto;
        }
    }
}

