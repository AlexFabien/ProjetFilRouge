using QuizApi.Dtos.Role;
using QuizApi.Entities;
using QuizApi.Repositories;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    public class RoleService
    {
        private RoleRepository roleRepository;

        public RoleService()
        {
            this.roleRepository = new RoleRepository(new QueryBuilder());
        }

        internal List<AllRoleDto> FindAll()
        {
            List<RoleEntity> roleEntities = roleRepository.FindAll();
            List<AllRoleDto> allRoleDtos = new List<AllRoleDto>();
            roleEntities.ForEach(roleEntity => { allRoleDtos.Add(ConvertEntityToDto(roleEntity)); });
            return allRoleDtos;
        }

        internal AllRoleDto Find(int id)
        {
            RoleEntity roleEntity = roleRepository.Find(id);
            AllRoleDto allRoleDto = ConvertEntityToDto(roleEntity);
            return allRoleDto;
        }

        private AllRoleDto ConvertEntityToDto(RoleEntity roleEntity)
        {
            return new AllRoleDto(roleEntity.Nom, roleEntity.IdRole);
        }
    }
}
