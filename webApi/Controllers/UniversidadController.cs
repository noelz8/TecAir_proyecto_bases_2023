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
    public class UniversidadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UniversidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Universidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetUniversidades()
        {
            return await _context.Universidades.ToListAsync();
        }

        // GET: api/Universidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(string id)
        {
            var universidad = await _context.Universidades.FindAsync(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Universidad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(string id, Universidad universidad)
        {
            if (id != universidad.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(universidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversidadExists(id))
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

        // POST: api/Universidad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            _context.Universidades.Add(universidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniversidadExists(universidad.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUniversidad", new { id = universidad.Nombre }, universidad);
        }

        // DELETE: api/Universidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversidad(string id)
        {
            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }

            _context.Universidades.Remove(universidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversidadExists(string id)
        {
            return _context.Universidades.Any(e => e.Nombre == id);
        }
    }
}
