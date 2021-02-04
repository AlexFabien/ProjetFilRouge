using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos;
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
    public class ReponsesController : ControllerBase
    {
        
        ReponseService reponseService;

        public ReponsesController(ReponseService reponseService)
        {
            this.reponseService = reponseService;
        }

        // GET: api/<ReponsesController>
        [HttpGet]

        public List<AllReponseDto> Get()
        {
            return this.reponseService.FindAll();
        }

        // GET api/<ReponsesController>/5
        [HttpGet("{id}")]

        public AllReponseDto Get(int id)
        {
            return reponseService.Find(id);
        }
        // POST api/<ReponsesController>
        [HttpPost]
        public AfterCreateReponseDto Post([FromBody] CreateReponseDto reponseEntity)
        {
            return reponseService.PostReponseEntity(reponseEntity);
        }

        // PUT api/<ReponsesController>/5
        [HttpPut("{id}")]
        public AfterCreateReponseDto Put(int id, [FromBody] CreateReponseDto reponseEntity)
        {
            return reponseService.PutReponseEntity(id, reponseEntity);
        }

        // DELETE api/<ReponsesController>/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return reponseService.Delete(id);
        }
    }
}
