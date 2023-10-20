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
    public class MaletumController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaletumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Maletum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maletum>>> GetMaleta()
        {
            return await _context.Maleta.ToListAsync();
        }

        // GET: api/Maletum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maletum>> GetMaletum(int id)
        {
            var maletum = await _context.Maleta.FindAsync(id);

            if (maletum == null)
            {
                return NotFound();
            }

            return maletum;
        }

        // PUT: api/Maletum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaletum(int id, Maletum maletum)
        {
            if (id != maletum.Numero)
            {
                return BadRequest();
            }

            _context.Entry(maletum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaletumExists(id))
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

        // POST: api/Maletum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maletum>> PostMaletum(Maletum maletum)
        {
            _context.Maleta.Add(maletum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaletumExists(maletum.Numero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaletum", new { id = maletum.Numero }, maletum);
        }

        // DELETE: api/Maletum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaletum(int id)
        {
            var maletum = await _context.Maleta.FindAsync(id);
            if (maletum == null)
            {
                return NotFound();
            }

            _context.Maleta.Remove(maletum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaletumExists(int id)
        {
            return _context.Maleta.Any(e => e.Numero == id);
        }
    }
}
