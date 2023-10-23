using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cosa.Data;
using Cosa.Models;

namespace Cosa.Controllers
{
    [Route("api/[controller]")]
    public class RusuariosController : Controller
    {
        private readonly UsuariosDbContext _context;

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Nombre,Apellido,Apellido2,Email,Telefono,Password,Universidad,Carnet,Rol")] Rusuario rusuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rusuario);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario != null && usuario.Password == password)
            {
                // The user is logged in.
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // The user is not logged in.
                ModelState.AddModelError("", "Correo o contraseña incorrectas.");
                return View();
            }
        }



        public RusuariosController(UsuariosDbContext context)
        {
            _context = context;
        }

        // GET: Rusuarios
        public async Task<IActionResult> Index()
        {
            return _context.Usuarios != null ?
                        View(await _context.Usuarios.ToListAsync()) :
                        Problem("Entity set 'UsuariosDbContext.Usuarios'  is null.");
        }

        // GET: Rusuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var rusuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rusuario == null)
            {
                return NotFound();
            }

            return View(rusuario);
        }

        // GET: Rusuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rusuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Apellido2,Email,Telefono,Password,Universidad,Carnet,Rol")] Rusuario rusuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rusuario);
        }

        // GET: Rusuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var rusuario = await _context.Usuarios.FindAsync(id);
            if (rusuario == null)
            {
                return NotFound();
            }
            return View(rusuario);
        }

        // POST: Rusuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Apellido2,Email,Telefono,Password,Universidad,Carnet,Rol")] Rusuario rusuario)
        {
            if (id != rusuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rusuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RusuarioExists(rusuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rusuario);
        }

        // GET: Rusuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var rusuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rusuario == null)
            {
                return NotFound();
            }

            return View(rusuario);
        }

        // POST: Rusuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'UsuariosDbContext.Usuarios'  is null.");
            }
            var rusuario = await _context.Usuarios.FindAsync(id);
            if (rusuario != null)
            {
                _context.Usuarios.Remove(rusuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RusuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
