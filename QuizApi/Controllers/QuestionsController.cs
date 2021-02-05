using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos;
using QuizApi.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        QuestionService questionService;

        public QuestionsController()
        {
            this.questionService = new QuestionService();
        }

        [HttpGet]
        public List<QuestionDto> Get()
        {
            return questionService.FindAll();
        }

        [HttpGet("{id}")]
        public QuestionDto Get(int id)
        {
            return questionService.Find(id);
        }

        [HttpPost]
        public QuestionDto Post([FromBody] CreateQuestionDto createDto)
        {
            //return questionService.PostQuestion(createDto);
            return null;
        }

        [HttpPut("{id}")]
        public QuestionDto Put(int id, [FromBody] CreateQuestionDto createDto)
        {
            return questionService.UpdateQuestion(id, createDto);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return questionService.Delete(id);
        }
    }
}
