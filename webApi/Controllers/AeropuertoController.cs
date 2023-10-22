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
    public class AeropuertoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AeropuertoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Aeropuerto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeropuerto>>> GetAeropuertos()
        {
            return await _context.Aeropuertos.ToListAsync();
        }

        // GET: api/Aeropuerto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeropuerto>> GetAeropuerto(string id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);

            if (aeropuerto == null)
            {
                return NotFound();
            }

            return aeropuerto;
        }

        // PUT: api/Aeropuerto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeropuerto(string id, Aeropuerto aeropuerto)
        {
            if (id != aeropuerto.Codigoaeropuerto)
            {
                return BadRequest();
            }

            _context.Entry(aeropuerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeropuertoExists(id))
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

        // POST: api/Aeropuerto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeropuerto>> PostAeropuerto(Aeropuerto aeropuerto)
        {
            _context.Aeropuertos.Add(aeropuerto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeropuertoExists(aeropuerto.Codigoaeropuerto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeropuerto", new { id = aeropuerto.Codigoaeropuerto }, aeropuerto);
        }

        // DELETE: api/Aeropuerto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeropuerto(string id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
            {
                return NotFound();
            }

            _context.Aeropuertos.Remove(aeropuerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeropuertoExists(string id)
        {
            return _context.Aeropuertos.Any(e => e.Codigoaeropuerto == id);
        }
    }
}
