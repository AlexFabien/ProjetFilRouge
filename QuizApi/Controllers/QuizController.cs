using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos;
using QuizApi.Services;
using QuizApi.Utils;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private QuizService service;
        private QuestionService questionService;

        public QuizController(QuizService service, QuestionService questionService)
        {
            this.service = service;
            this.questionService = questionService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(this.service.TrouverToutAvecNiveauTechno());
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FindById(int id)
        {
            try
            {
                return Ok(this.service.TrouverParId(id));
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}/candidates")]
        public IActionResult FindAllCandidatesByQuiz(int id)
        {
            try
            {
                return Ok(this.service.TrouverTousLesUtilisateursDuQuiz(id));
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{idQuiz}/candidates/{idCandidate}")]
        public IActionResult FindAllCandidatesByQuiz(int idQuiz, int idCandidate)
        {
            try
            {
                //TODO Ajouter n° de la question en cours
                return Ok(this.service.StartQuiz(idQuiz, idCandidate));
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{idQuiz}/questions/{numQuestion}")]
        public IActionResult FindNextQuestion(int idQuiz, int numQuestion)
        {
            try
            {
                return Ok(this.questionService.TrouverQuestionParQuizEtQuestion(idQuiz, numQuestion));
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.service.Supprimer(id);
                return Ok();
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] CreatedQuizDto createdQuizDto)
        {
            try
            {
                QuizDto unQuiz = this.service.CreerQuiz(createdQuizDto);
#warning Retourner un code 201
                return Ok(unQuiz);
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("{id}/candidates")]
        public IActionResult InsertCandidatesByQuiz(int id, [FromBody] List<ActeurIdCandidat> listCandidats)
        {
            try
            {
                return Ok(this.service.AjouterCandidats(id, listCandidats));
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody] QuizDto quizDto)
        {
            try
            {
                this.service.Modifier(quizDto);
                return Ok(quizDto);
            }
            catch (RessourceException e)
            {
                if (e.Statut == 404)
                    return NotFound(e.Message);
                else
                {
                    return BadRequest(e.Message);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }

}
