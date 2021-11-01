using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudUsuarios.Data;
using crudUsuarios.Models;

namespace crudUsuarios.Controllers
{
    public class SEG_UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SEG_UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SEG_Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.SEG_Usuarios.ToListAsync());
        }

        // GET: SEG_Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sEG_Usuarios = await _context.SEG_Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sEG_Usuarios == null)
            {
                return NotFound();
            }

            return View(sEG_Usuarios);
        }

        // GET: SEG_Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SEG_Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usuario,Email,FechaAltaModificacion")] SEG_Usuarios sEG_Usuarios)
        {
            var usuario = await _context.SEG_Usuarios.FirstOrDefaultAsync(i => i.Usuario == sEG_Usuarios.Usuario);
            
            if (usuario != null) //Si el nombre de usuario del usuario a ingresar ya existe => error
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(sEG_Usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(sEG_Usuarios);
        }

        // GET: SEG_Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sEG_Usuarios = await _context.SEG_Usuarios.FindAsync(id);
            if (sEG_Usuarios == null)
            {
                return NotFound();
            }
            return View(sEG_Usuarios);
        }

        // POST: SEG_Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usuario,Email,FechaAltaModificacion")] SEG_Usuarios sEG_Usuarios)
        {
            if (id != sEG_Usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sEG_Usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SEG_UsuariosExists(sEG_Usuarios.Id))
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
            return View(sEG_Usuarios);
        }

        // GET: SEG_Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sEG_Usuarios = await _context.SEG_Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sEG_Usuarios == null)
            {
                return NotFound();
            }

            return View(sEG_Usuarios);
        }

        // POST: SEG_Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sEG_Usuarios = await _context.SEG_Usuarios.FindAsync(id);
            _context.SEG_Usuarios.Remove(sEG_Usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SEG_UsuariosExists(int id)
        {
            return _context.SEG_Usuarios.Any(e => e.Id == id);
        }
    }
}
