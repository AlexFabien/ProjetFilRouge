using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System.Collections.Generic;
using System.Linq;

namespace QuizApi.Services
{
    public class RoleService : IService<RoleDto>
    {
        private IRepository<Role> repository;

        public RoleService(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        public void Ajouter(RoleDto obj)
        {
            this.repository.Insert(obj);
        }

        public void Modifier(RoleDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public RoleDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<RoleDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListRoleToListRoleDto(this.repository.FindAll().ToList());
        }
    }
}
