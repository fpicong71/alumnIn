using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebFormacion.Data;
using WebFormacion.Models;

namespace WebFormacion.Controllers
{
    public class EntidadesController : Controller
    {
        private readonly WebContext _context;

        public EntidadesController(WebContext context)
        {
            _context = context;
        }

        // GET: Entidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntidadFormacion.ToListAsync());
        }

        // GET: Entidades/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.EntidadFormacion
                .Include(ce=>ce.CursoEntidades)
                   .ThenInclude(c=>c.Curso)
                   .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EntidadID == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // GET: Entidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadID,RazonSocial,Direccion,CodigoPostal")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidad);
        }

        // GET: Entidades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.EntidadFormacion.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return View(entidad);
        }

        // POST: Entidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EntidadID,RazonSocial,Direccion,CodigoPostal")] Entidad entidad)
        {
            if (id != entidad.EntidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadExists(entidad.EntidadID))
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
            return View(entidad);
        }

        // GET: Entidades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.EntidadFormacion
                .FirstOrDefaultAsync(m => m.EntidadID == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // POST: Entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var entidad = await _context.EntidadFormacion.FindAsync(id);
            _context.EntidadFormacion.Remove(entidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadExists(string id)
        {
            return _context.EntidadFormacion.Any(e => e.EntidadID == id);
        }
    }
}
