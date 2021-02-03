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
    public class RoleService
    {
        private RoleRepository roleRepository;

        public RoleService()
        {
            this.roleRepository = new RoleRepository(new QueryBuilder());
        }

        internal List<RoleDto> FindAll()
        {
            List<Role> role = roleRepository.FindAll();
            List<RoleDto> allRoleDtos = new List<RoleDto>();
            role.ForEach(r => { allRoleDtos.Add(ConvertEntityToDto(r)); });
            return allRoleDtos;
        }

        internal RoleDto Find(int id)
        {
            Role role = roleRepository.Find(id);
            RoleDto allRoleDto = ConvertEntityToDto(role);
            return allRoleDto;
        }

        internal RoleDto PostRole(CreateRoleDto roleDto)
        {
            Role role = ConvertDtoToEntity(roleDto);
            Role roleConverted = roleRepository.Create(role);
            return ConvertEntityToDto(roleConverted);
        }

        internal RoleDto UpdateRole(int id, CreateRoleDto newRoleDto)
        {
            Role role = ConvertDtoToEntity(newRoleDto);
            Role newRole = roleRepository.Update(id, role);
            return ConvertEntityToDto(newRole);
        }
        internal int Delete(int id)
        {
            return roleRepository.Delete(id);
        }

        private Role ConvertDtoToEntity(RoleDto roleDto)
        {
            Role roleConverted = new Role();
            roleConverted.Nom = roleDto.Nom;
            return roleConverted;
        }
        private Role ConvertDtoToEntity(CreateRoleDto roleDto)
        {
            Role roleConverted = new Role();
            roleConverted.Nom = roleDto.Nom;
            return roleConverted;
        }

        private RoleDto ConvertEntityToDto(Role role)
        {
            return new RoleDto(role.Nom, role.IdRole);
        }
    }
}
