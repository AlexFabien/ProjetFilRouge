﻿using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos;
using QuizApi.Services;
using QuizApi.Utils;
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

        private IService<ReponduDto> service;

        public RepondusController(IService<ReponduDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
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
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] ReponduDto reponduDto)
        {
            try
            {
                this.service.Ajouter(reponduDto);
                return Ok(reponduDto);
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
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody] ReponduDto reponduDto)
        {
            try
            {
                this.service.Modifier(reponduDto);
                return Ok(reponduDto);
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
        }



    }




}

