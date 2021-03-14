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
    public class NiveauxController : ControllerBase
    {
        private IService<NiveauDto> service;

        public NiveauxController(IService<NiveauDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(this.service.TrouverTout());
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

        [HttpGet("{id}")]
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
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NiveauDto createDto)
        {
            try
            {
                this.service.Ajouter(createDto);
                return Ok(createDto);
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

        [HttpPut()]
        public IActionResult Update([FromBody] NiveauDto dto)
        {
            try
            {
                this.service.Modifier(dto);
                return Ok(dto);
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

        [HttpDelete("{id}")]
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
    }
}
