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
    public class ReservacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetReservacions()
        {
            return await _context.Reservacions.ToListAsync();
        }

        // GET: api/Reservacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacion>> GetReservacion(int id)
        {
            var reservacion = await _context.Reservacions.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return reservacion;
        }

        // PUT: api/Reservacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacion(int id, Reservacion reservacion)
        {
            if (id != reservacion.Reservacionid)
            {
                return BadRequest();
            }

            _context.Entry(reservacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionExists(id))
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

        // POST: api/Reservacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservacion>> PostReservacion(Reservacion reservacion)
        {
            _context.Reservacions.Add(reservacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservacionExists(reservacion.Reservacionid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReservacion", new { id = reservacion.Reservacionid }, reservacion);
        }

        // DELETE: api/Reservacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            _context.Reservacions.Remove(reservacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservacionExists(int id)
        {
            return _context.Reservacions.Any(e => e.Reservacionid == id);
        }
    }
}
