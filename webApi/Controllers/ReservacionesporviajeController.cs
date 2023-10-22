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
    public class ReservacionesporviajeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservacionesporviajeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservacionesporviaje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacionesporviaje>>> GetReservacionesporviajes()
        {
            return await _context.Reservacionesporviajes.ToListAsync();
        }

        // GET: api/Reservacionesporviaje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacionesporviaje>> GetReservacionesporviaje(int id)
        {
            var reservacionesporviaje = await _context.Reservacionesporviajes.FindAsync(id);

            if (reservacionesporviaje == null)
            {
                return NotFound();
            }

            return reservacionesporviaje;
        }

        // PUT: api/Reservacionesporviaje/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacionesporviaje(int id, Reservacionesporviaje reservacionesporviaje)
        {
            if (id != reservacionesporviaje.Viajeid)
            {
                return BadRequest();
            }

            _context.Entry(reservacionesporviaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionesporviajeExists(id))
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

        // POST: api/Reservacionesporviaje
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservacionesporviaje>> PostReservacionesporviaje(Reservacionesporviaje reservacionesporviaje)
        {
            _context.Reservacionesporviajes.Add(reservacionesporviaje);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservacionesporviajeExists(reservacionesporviaje.Viajeid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReservacionesporviaje", new { id = reservacionesporviaje.Viajeid }, reservacionesporviaje);
        }

        // DELETE: api/Reservacionesporviaje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacionesporviaje(int id)
        {
            var reservacionesporviaje = await _context.Reservacionesporviajes.FindAsync(id);
            if (reservacionesporviaje == null)
            {
                return NotFound();
            }

            _context.Reservacionesporviajes.Remove(reservacionesporviaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservacionesporviajeExists(int id)
        {
            return _context.Reservacionesporviajes.Any(e => e.Viajeid == id);
        }
    }
}
