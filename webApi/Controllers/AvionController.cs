using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace webApi.AvionController;


[Route("api/[controller]")]
[ApiController]
public class AvionController : Controller
{
    // Inyecta el contexto de la base de datos
    private readonly ApplicationDbContext context;

    // El constructor inicializa el contexto de la base de datos
    public AvionController(ApplicationDbContext context)
    {
        this.context = context;
    }

    // Devuelve una lista de todos los aviones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Avion>>> Get()
    {
        return await context.Aviones.ToListAsync();
    }

    // Devuelve un avión específico por su ID
    // Obtener un cliente específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCliente(int id)
    {
        var avion = await context.Aviones.FindAsync(id);
        if (avion == null)
        {
            return NotFound();
            }

        return Ok(avion);
    }

    // Crea un nuevo avión
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Avion avion)
    {
        context.Aviones.Add(avion);
        await context.SaveChangesAsync();

        return CreatedAtAction("Get", new { id = avion.AvionId }, avion);
    }
   
    // Actualiza un avión existente
    [HttpPut("{id}")]
    public async Task<ActionResult<Avion>> Update(int id, Avion avion)
    {
        avion.AvionId = id;
        context.Aviones.Update(avion);
        await context.SaveChangesAsync();

        return avion;
    }

    // Elimina un avión
         // Eliminar un cliente
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAvion(int id)
    {
        var avion = await context.Aviones.FindAsync(id);
        if (avion == null)
        {
            return NotFound();
            }

        context.Aviones.Remove(avion);
        await context.SaveChangesAsync();

        return NoContent();
    }
}