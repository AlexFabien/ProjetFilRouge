using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Services;

namespace QuizApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class _ParametragesController : ControllerBase
    {
        private readonly QuizContext _context;

        ParametrageService parametrageService;

        public _ParametragesController()
        {
            //this.parametrageService = new ParametrageService();
            _context = new QuizContext();
        }

        // GET: api/Parametrages
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<ParametrageDTO>>> GetParametrage()
        //{
        //    return Ok(await parametrageService.FindAllAsync());
        //}

        public async Task<ActionResult<IEnumerable<Parametrage>>> GetParametrage()
        {
            return await _context.Parametrage.ToListAsync();
        }


        // GET: api/Parametrages/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ParametrageDTO>> GetParametrage(int id)
        //{
        //    var parametrage = await _context.Parametrage.FindAsync(id);

        //    if (parametrage == null)
        //    {
        //        return NotFound();
        //    }

        //    return parametrage;
        //}

        //    // PUT: api/Parametrages/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutParametrage(int id, ParametrageDTO parametrage)
        //    {
        //        if (id != parametrage.IdParametrage)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(parametrage).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ParametrageExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Parametrages
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPost]
        //    public async Task<ActionResult<ParametrageDTO>> PostParametrage(ParametrageDTO parametrage)
        //    {
        //        _context.Parametrage.Add(parametrage);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetParametrage", new { id = parametrage.IdParametrage }, parametrage);
        //    }

        //    // DELETE: api/Parametrages/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<ParametrageDTO>> DeleteParametrage(int id)
        //    {
        //        var parametrage = await _context.Parametrage.FindAsync(id);
        //        if (parametrage == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Parametrage.Remove(parametrage);
        //        await _context.SaveChangesAsync();

        //        return parametrage;
        //    }

        //    private bool ParametrageExists(int id)
        //    {
        //        return _context.Parametrage.Any(e => e.IdParametrage == id);
        //    }
    }
}
