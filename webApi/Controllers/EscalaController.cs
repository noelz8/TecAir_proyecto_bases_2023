using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscalaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EscalaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Escala
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escala>>> GetEscalas()
        {
            return await _context.Escalas.ToListAsync();
        }

        // GET: api/Escala/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escala>> GetEscala(string id)
        {
            var escala = await _context.Escalas.FindAsync(id);

            if (escala == null)
            {
                return NotFound();
            }

            return escala;
        }

        // PUT: api/Escala/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscala(string id, Escala escala)
        {
            if (id != escala.Codigoaeropuertoescala)
            {
                return BadRequest();
            }

            _context.Entry(escala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscalaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Escala
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Escala>> PostEscala(Escala escala)
        {
            _context.Escalas.Add(escala);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EscalaExists(escala.Codigoaeropuertoescala))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEscala", new { id = escala.Codigoaeropuertoescala }, escala);
        }

        // DELETE: api/Escala/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscala(string id)
        {
            var escala = await _context.Escalas.FindAsync(id);
            if (escala == null)
            {
                return NotFound();
            }

            _context.Escalas.Remove(escala);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EscalaExists(string id)
        {
            return _context.Escalas.Any(e => e.Codigoaeropuertoescala == id);
        }
    }
}
