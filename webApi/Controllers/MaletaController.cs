using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaletaController : Controller
        {
            private readonly ApplicationDbContext _context;

            public MaletaController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Maleta>>> GetMaletas()
            {
                var maletas = await _context.Maletas.ToListAsync();

                return Ok(maletas);
            }

            [HttpGet("maletas/{id}")]
            public async Task<ActionResult<Maleta>> GetMaleta(int id)
            {
                var maleta = await _context.Maletas.Where(m => m.NumeroMaleta == id).FirstOrDefaultAsync();

                if (maleta == null)
                {
                    return NotFound();
                }

                return Ok(maleta);
            }

            [HttpPost]
            public ActionResult<Maleta> CreateMaleta(Maleta maleta)
            {
                _context.Maletas.Add(maleta);
                _context.SaveChangesAsync();

                return CreatedAtAction("GetMaleta", new { id = maleta.NumeroMaleta }, maleta);
            }

            [HttpPut("maletas/{id}")]
            public async Task<ActionResult<Maleta>> UpdateMaleta(int id, Maleta maleta)
            {
                // Busca la maleta actual por su ID
                var maletaActual = await _context.Maletas.FindAsync(id);

                if (maletaActual == null)
                {
                    return NotFound();
                }

                // Actualiza las propiedades de la maleta actual con los valores de la nueva maleta
                maletaActual.NumeroMaleta = maleta.NumeroMaleta;
                maletaActual.Dueno = maleta.Dueno;
                maletaActual.Color = maleta.Color;
                maletaActual.Precio = maleta.Precio;
                maletaActual.Peso = maleta.Peso;

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                return Ok(maletaActual);
            }


            [HttpDelete("maletas/{id}")]
            public async Task<IActionResult> DeleteMaleta(int id)
            {
                // Busca la maleta actual por su ID
                var maleta = await _context.Maletas.FindAsync(id);

                if (maleta == null)
                {
                    return NotFound();
                }

                _context.Maletas.Remove(maleta);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

}