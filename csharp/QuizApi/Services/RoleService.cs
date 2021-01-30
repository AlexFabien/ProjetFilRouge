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

        internal List<RoleDto> FindAll()
        {
            List<RoleEntity> roleEntities = roleRepository.FindAll();
            List<RoleDto> allRoleDtos = new List<RoleDto>();
            roleEntities.ForEach(roleEntity => { allRoleDtos.Add(ConvertEntityToDto(roleEntity)); });
            return allRoleDtos;
        }

        internal RoleDto Find(int id)
        {
            RoleEntity roleEntity = roleRepository.Find(id);
            RoleDto allRoleDto = ConvertEntityToDto(roleEntity);
            return allRoleDto;
        }

        internal RoleDto PostRole(RoleDto roleDto)
        {
            RoleEntity roleEntity = ConvertDtoToEntity(roleDto);
            RoleEntity roleEntityConverted = roleRepository.Create(roleEntity);
            return ConvertEntityToDto(roleEntityConverted);
        }

        private RoleEntity ConvertDtoToEntity(RoleDto roleDto)
        {
            return new RoleEntity(roleDto.Nom);
        }

        private RoleDto ConvertEntityToDto(RoleEntity roleEntity)
        {
            return new RoleDto(roleEntity.Nom, roleEntity.Id_Role);
        }
    }
}
