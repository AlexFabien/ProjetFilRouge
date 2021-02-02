using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos.Repondu;
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
    public class RepondusController : ControllerBase
    {
        
        ReponduService reponduService;

        public RepondusController()
        {
            this.reponduService = new ReponduService();
        }

        // GET: api/<RepondusController>
        [HttpGet]

        public List<AllReponduDto> Get()
        {
            return reponduService.FindAll();
        }

        // GET api/<RepondusController>/5
        [HttpGet("{id}")]

        public AllReponduDto Get(int id)
        {
            return reponduService.Find(id);
        }
        // POST api/<RepondusController>
        [HttpPost]
        public AfterCreateReponduDto Post([FromBody] CreateReponduDto reponduEntity)
        {
            return reponduService.PostReponduEntity(reponduEntity);
        }

        // PUT api/<RepondusController>/5
        [HttpPut("{id}")]
        public AfterCreateReponduDto Put(int id, [FromBody] CreateReponduDto reponduEntity)
        {
            return reponduService.PutReponduEntity(id, reponduEntity);
        }

        // DELETE api/<RepondusController>/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return reponduService.Delete(id);
        }




    }

    

        
 }

