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
    public class OrigenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrigenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Origen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Origen>>> GetOrigens()
        {
            return await _context.Origens.ToListAsync();
        }

        // GET: api/Origen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Origen>> GetOrigen(string id)
        {
            var origen = await _context.Origens.FindAsync(id);

            if (origen == null)
            {
                return NotFound();
            }

            return origen;
        }

        // PUT: api/Origen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigen(string id, Origen origen)
        {
            if (id != origen.Codigoaeropuertoorigen)
            {
                return BadRequest();
            }

            _context.Entry(origen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigenExists(id))
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

        // POST: api/Origen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Origen>> PostOrigen(Origen origen)
        {
            _context.Origens.Add(origen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrigenExists(origen.Codigoaeropuertoorigen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrigen", new { id = origen.Codigoaeropuertoorigen }, origen);
        }

        // DELETE: api/Origen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigen(string id)
        {
            var origen = await _context.Origens.FindAsync(id);
            if (origen == null)
            {
                return NotFound();
            }

            _context.Origens.Remove(origen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrigenExists(string id)
        {
            return _context.Origens.Any(e => e.Codigoaeropuertoorigen == id);
        }
    }
}
