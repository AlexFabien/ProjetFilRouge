using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizApi.Dtos;
using QuizApi.Services;
using QuizApi.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActeursController : ControllerBase
    {
        //private IService<ActeurDto> service;
        private ActeurService service;

        public ActeursController(ActeurService service)
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

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody] ActeurDto acteurDto)
        {
            try
            {
                this.service.Modifier(acteurDto);
                return Ok(acteurDto);
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] ConnectActeurDto connectActeurDto)
        {
            try
            {
                ConnectedActeurDto connectedActeurDto = this.service.Connecter(connectActeurDto);
                return Ok(connectedActeurDto);
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
        [Route("register")]
        [AllowAnonymous]
        //public IActionResult Insert([FromBody] ActeurDto acteurDto)       
        public IActionResult Register([FromBody] CreatedActeurDto createdActeurDto)
        {
            try
            {
                ActeurDto acteurDto = this.transformCreatedActeurDtoToActeurDto(createdActeurDto);
                return Ok(this.service.Ajouter(acteurDto));
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

        private ActeurDto transformCreatedActeurDtoToActeurDto(CreatedActeurDto createdActeurDto) {
            return new ActeurDto(
            0,
            createdActeurDto.Nom,
            createdActeurDto.Prenom,
            createdActeurDto.Email,
            createdActeurDto.Password,
            1 //FIXIT : devrait fonctionner sans idRole
            );
        }
    }

}
