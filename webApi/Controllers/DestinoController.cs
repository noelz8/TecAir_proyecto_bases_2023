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
    public class DestinoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DestinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Destino
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destino>>> GetDestinos()
        {
            return await _context.Destinos.ToListAsync();
        }

        // GET: api/Destino/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destino>> GetDestino(string id)
        {
            var destino = await _context.Destinos.FindAsync(id);

            if (destino == null)
            {
                return NotFound();
            }

            return destino;
        }

        // PUT: api/Destino/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestino(string id, Destino destino)
        {
            if (id != destino.Codigoaeropuertodestino)
            {
                return BadRequest();
            }

            _context.Entry(destino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoExists(id))
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

        // POST: api/Destino
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destino>> PostDestino(Destino destino)
        {
            _context.Destinos.Add(destino);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DestinoExists(destino.Codigoaeropuertodestino))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDestino", new { id = destino.Codigoaeropuertodestino }, destino);
        }

        // DELETE: api/Destino/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestino(string id)
        {
            var destino = await _context.Destinos.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }

            _context.Destinos.Remove(destino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoExists(string id)
        {
            return _context.Destinos.Any(e => e.Codigoaeropuertodestino == id);
        }
    }
}
