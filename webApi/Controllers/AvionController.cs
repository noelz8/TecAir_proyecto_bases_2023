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
    public class AvionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Avion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avion>>> GetAvions()
        {
            return await _context.Avions.ToListAsync();
        }

        // GET: api/Avion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avion>> GetAvion(int id)
        {
            var avion = await _context.Avions.FindAsync(id);

            if (avion == null)
            {
                return NotFound();
            }

            return avion;
        }

        // PUT: api/Avion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvion(int id, Avion avion)
        {
            if (id != avion.Avionid)
            {
                return BadRequest();
            }

            _context.Entry(avion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvionExists(id))
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
        [HttpPost("creaAvion")]
        public async Task<ActionResult<Avion>> PostAviont([FromBody] Avion avion)
        {
            if (avion == null)
            {
                return BadRequest("El objeto Avion no puede ser nulo.");
            }

            // Realiza validaciones adicionales si es necesario

            _context.Avions.Add(avion);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAvion", new { id = avion.Avionid }, avion);
            }
            catch (DbUpdateException)
            {
                if (AvionExists(avion.Avionid))
                {
                    return Conflict("Ya existe un avión con el mismo ID.");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Avion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avion>> PostAvion(Avion avion)
        {
            _context.Avions.Add(avion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AvionExists(avion.Avionid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAvion", new { id = avion.Avionid }, avion);
        }

        // DELETE: api/Avion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvion(int id)
        {
            var avion = await _context.Avions.FindAsync(id);
            if (avion == null)
            {
                return NotFound();
            }

            _context.Avions.Remove(avion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvionExists(int id)
        {
            return _context.Avions.Any(e => e.Avionid == id);
        }
    }
}
