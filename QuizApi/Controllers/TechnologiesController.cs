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
    public class TechnologiesController : ControllerBase
    {
        private IService<TechnologieDto> service;

        public TechnologiesController(IService<TechnologieDto> service)
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

        //[HttpPost]
        //[Route("")]
        //public IActionResult Insert([FromBody] ParametrageDto parametrageDto)
        //{
        //    try
        //    {
        //        this.service.Ajouter(parametrageDto);
        //        return Ok(parametrageDto);
        //    }
        //    catch (RessourceException e)
        //    {
        //        if (e.Statut == 404)
        //            return NotFound(e.Message);
        //        else
        //        {
        //            return BadRequest(e.Message);
        //        }
        //    }
        //}

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody] TechnologieDto technologieDto)
        {
            try
            {
                this.service.Modifier(technologieDto);
                return Ok(technologieDto);
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

