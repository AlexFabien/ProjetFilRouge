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
    public class TechnologiesController : ControllerBase
    {
        TechnologieService technologieService;

        public TechnologiesController()
        {
            this.technologieService = new TechnologieService();
        }

            // GET: api/<TechnologiesController>
            [HttpGet]

        public List<AllTechnologieDto> Get()
        {
            return technologieService.FindAll();
        }

        // GET api/<TechnologiesController>/5
        [HttpGet("{id}")]

        public AllTechnologieDto Get(int idTechnologie )
        {
            return technologieService.Find(idTechnologie);
        }
        // POST api/<TechnologiesController>
        [HttpPost]
        public AfterCreateTechnologieDto Post([FromBody] CreateTechnologieDto technologieEntity)
        {
            return technologieService.PostTechnologieEntity(technologieEntity);
        }

        // PUT api/<TechnologiesController>/5
        [HttpPut("{id}")]
        public AfterCreateTechnologieDto Put(int id, [FromBody] CreateTechnologieDto technologieEntity)
        {
            return technologieService.PutTechnologeEntity(id, technologieEntity);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public long Delete(int id )
        {
            return technologieService.Delete(id);
        }

        
        
        
     }
 
 }

