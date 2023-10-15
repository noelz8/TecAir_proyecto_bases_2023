using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Controllers
{

    [Route("reservaciones")] // ruta del controlador para ser usado en EndPoint
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
            var reservas = await _context.Reservaciones.ToListAsync();

            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacion>> GetAsync(int id)
        {
            var reserva = await _context.Reservaciones.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        [HttpPost]
        public async Task<ActionResult<Reservacion>> Post([FromBody] Reservacion reserva)
        {
            reserva.CalcularPrecioDerivado();

            await _context.AddAsync(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservaciones), new { id = reserva.ReservacionID }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reservacion>> Put(int id, [FromBody] Reservacion reserva)
        {
            reserva.CalcularPrecioDerivado();

            var existingReserva = await _context.Reservaciones.FindAsync(id);

            if (existingReserva == null)
            {
                return NotFound();
            }

            _context.Update(reserva);
            await _context.SaveChangesAsync();

            return Ok(reserva);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reserva = await _context.Reservaciones.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Remove(reserva);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("api/reservas/cliente/{idCliente}")]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetByClienteId(int idCliente)
        {
            var reservas = await _context.Reservaciones.Where(r => r.ClienteID == idCliente).ToListAsync();

            return Ok(reservas);
        }

        [HttpGet("api/reservas/fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetByFecha(DateTime fecha)
        {
            var reservas = await _context.Reservaciones.Where(r => r.Fecha == fecha).ToListAsync();

            return Ok(reservas);
        }
    }
}