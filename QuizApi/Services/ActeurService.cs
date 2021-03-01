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

        public ActeurDto Ajouter(ActeurDto obj)
        {
            return null;
            //return this.repository.Insert(obj);
        }

        public ActeurDto CreerActeur(CreatedActeurDto createdActeurDto)
        {
            ActeurDto acteurDto = new ActeurDto(
                0,
                createdActeurDto.Nom,
                createdActeurDto.Prenom,
                createdActeurDto.Email,
                createdActeurDto.Password,
                1 //FIXIT : devrait fonctionner sans idRole
                );
            return this.repository.Insert(acteurDto);        
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
    }
}
