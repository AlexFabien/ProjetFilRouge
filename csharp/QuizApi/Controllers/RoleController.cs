using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos.Role;
using QuizApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleService roleService;

        public RoleController()
        {
            this.roleService = new RoleService();
        }

        [HttpGet]
        public List<RoleDto> Get()
        {
            return roleService.FindAll();
        }

        [HttpGet("{id}")]
        public RoleDto Get(int id)
        {
            return roleService.Find(id);
        }

        [HttpPost]
        public RoleDto Post([FromBody] RoleDto roleDto)
        {
            return roleService.PostRole(roleDto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
