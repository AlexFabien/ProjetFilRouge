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
        //private IRepository<Acteur> repository;
        private ActeurRepository repository;

        //public ActeurService(IRepository<Acteur> repository)
        public ActeurService(ActeurRepository repository)
        {
            this.repository = repository;
        }

        public ActeurDto Ajouter(ActeurDto obj)
        {
            return this.repository.Insert(obj);
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
            return ConvertDtoEntity.ConvertListActeurToListActeurDto(this.repository?.FindAll()?.ToList());
        }

        public ConnectedActeurDto Connecter(ConnectActeurDto connectActeurDto)
        {
            return this.repository.Authenticate(connectActeurDto);
        }
    }
}
