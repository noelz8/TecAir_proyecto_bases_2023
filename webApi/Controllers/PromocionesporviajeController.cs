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
    public class PromocionesporviajeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PromocionesporviajeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Promocionesporviaje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promocionesporviaje>>> GetPromocionesporviajes()
        {
            return await _context.Promocionesporviajes.ToListAsync();
        }

        // GET: api/Promocionesporviaje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promocionesporviaje>> GetPromocionesporviaje(int id)
        {
            var promocionesporviaje = await _context.Promocionesporviajes.FindAsync(id);

            if (promocionesporviaje == null)
            {
                return NotFound();
            }

            return promocionesporviaje;
        }

        // PUT: api/Promocionesporviaje/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromocionesporviaje(int id, Promocionesporviaje promocionesporviaje)
        {
            if (id != promocionesporviaje.Viajeid)
            {
                return BadRequest();
            }

            _context.Entry(promocionesporviaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionesporviajeExists(id))
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

        // POST: api/Promocionesporviaje
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Promocionesporviaje>> PostPromocionesporviaje(Promocionesporviaje promocionesporviaje)
        {
            _context.Promocionesporviajes.Add(promocionesporviaje);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromocionesporviajeExists(promocionesporviaje.Viajeid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPromocionesporviaje", new { id = promocionesporviaje.Viajeid }, promocionesporviaje);
        }

        // DELETE: api/Promocionesporviaje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocionesporviaje(int id)
        {
            var promocionesporviaje = await _context.Promocionesporviajes.FindAsync(id);
            if (promocionesporviaje == null)
            {
                return NotFound();
            }

            _context.Promocionesporviajes.Remove(promocionesporviaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromocionesporviajeExists(int id)
        {
            return _context.Promocionesporviajes.Any(e => e.Viajeid == id);
        }
    }
}
