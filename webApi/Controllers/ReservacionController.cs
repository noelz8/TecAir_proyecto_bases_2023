using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetReservaciones()
        {
            var reservaciones = await _context.Reservaciones.ToListAsync();

            return Ok(reservaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacion>> GetAsync(int id)
        {
            var reservacion = await _context.Reservaciones.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return reservacion;
        }

        [HttpPost]
        public async Task<ActionResult<Reservacion>> Post([FromBody] Reservacion reservacion)
        {
            reservacion.CalcularPrecioDerivado();

            await _context.AddAsync(reservacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservaciones), new { id = reservacion.ReservacionID }, reservacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reservacion>> Put(int id, [FromBody] Reservacion reservacion)
        {
            reservacion.CalcularPrecioDerivado();

            var existingReserva = await _context.Reservaciones.FindAsync(id);

            if (existingReserva == null)
            {
                return NotFound();
            }

            _context.Update(reservacion);
            await _context.SaveChangesAsync();

            return Ok(reservacion);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reservacion = await _context.Reservaciones.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            _context.Remove(reservacion);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("reservaciones/clientes/{idCliente}")]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetByClienteId(int idCliente)
        {
            var reservaciones = await _context.Reservaciones.Where(r => r.ClienteID == idCliente).ToListAsync();

            return Ok(reservaciones);
        }

        
        [HttpGet("reservaciones/fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetByFecha(DateTime fecha)
        {
            var reservaciones = await _context.Reservaciones.Where(r => r.Fecha == fecha).ToListAsync();

            return Ok(reservaciones);
        }
    }
}