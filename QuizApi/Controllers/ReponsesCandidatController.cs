using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos.ReponseCandidat;
using QuizApi.Dtos.Role;
using QuizApi.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReponsesCandidatController : ControllerBase
    {
        ReponseCandidatService reponsesCandidatService;

        public ReponsesCandidatController()
        {
            this.reponsesCandidatService = new ReponseCandidatService();
        }

        [HttpGet]
        public List<ReponseCandidatDto> Get()
        {
            return reponsesCandidatService.FindAll();
        }

        [HttpGet("{id}")]
        public ReponseCandidatDto Get(int id)
        {
            return reponsesCandidatService.Find(id);
        }

        [HttpPost]
        public ReponseCandidatDto Post([FromBody] CreateReponseCandidatDto createDto)
        {
            return reponsesCandidatService.PostRole(createDto);
        }

        [HttpPut("{id}")]
        public ReponseCandidatDto Put(int id, [FromBody] CreateReponseCandidatDto createDto)
        {
            return reponsesCandidatService.UpdateRole(id, createDto);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return reponsesCandidatService.Delete(id);
        }
    }
}
