using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos.Niveau;
using QuizApi.Dtos.Role;
using QuizApi.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NiveauxController : ControllerBase
    {
        NiveauService niveauService;

        public NiveauxController()
        {
            this.niveauService = new NiveauService();
        }

        [HttpGet]
        public List<NiveauDto> Get()
        {
            return niveauService.FindAll();
        }

        [HttpGet("{id}")]
        public NiveauDto Get(int id)
        {
            return niveauService.Find(id);
        }

        [HttpPost]
        public NiveauDto Post([FromBody] CreateNiveauDto createDto)
        {
            return niveauService.PostNiveau(createDto);
        }

        [HttpPut("{id}")]
        public NiveauDto Put(int id, [FromBody] CreateNiveauDto createDto)
        {
            return niveauService.UpdateNiveau(id, createDto);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return niveauService.Delete(id);
        }
    }
}
