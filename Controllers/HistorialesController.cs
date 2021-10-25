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
    public class HistorialesController : Controller
    {
        private readonly WebContext _context;

        public HistorialesController(WebContext context)
        {
            _context = context;
        }

        // GET: Historiales
        public async Task<IActionResult> Index()
        {
            var webContext = _context.Historial.Include(h => h.Alumno).Include(h => h.Contacto).Include(h => h.Curso);
            return View(await webContext.ToListAsync());
        }

        // GET: Historiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .Include(h => h.Alumno)
                .Include(h => h.Contacto)
                .Include(h => h.Curso)
                .FirstOrDefaultAsync(m => m.HistorialID == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // GET: Historiales/Create
        public IActionResult Create()
        {
            ViewData["AlumnoID"] = new SelectList(_context.Alumno, "AlumnoID", "AlumnoID");
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID");
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso");
            return View();
        }

        // POST: Historiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistorialID,AlumnoID,ContactoID,CursoID,Fecha,Medio,Mensaje")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumno, "AlumnoID", "AlumnoID", historial.AlumnoID);
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID", historial.ContactoID);
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", historial.CursoID);
            return View(historial);
        }

        // GET: Historiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }
            ViewData["AlumnoID"] = new SelectList(_context.Alumno, "AlumnoID", "AlumnoID", historial.AlumnoID);
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID", historial.ContactoID);
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", historial.CursoID);
            return View(historial);
        }

        // POST: Historiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistorialID,AlumnoID,ContactoID,CursoID,Fecha,Medio,Mensaje")] Historial historial)
        {
            if (id != historial.HistorialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialExists(historial.HistorialID))
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
            ViewData["AlumnoID"] = new SelectList(_context.Alumno, "AlumnoID", "AlumnoID", historial.AlumnoID);
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID", historial.ContactoID);
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", historial.CursoID);
            return View(historial);
        }

        // GET: Historiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .Include(h => h.Alumno)
                .Include(h => h.Contacto)
                .Include(h => h.Curso)
                .FirstOrDefaultAsync(m => m.HistorialID == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // POST: Historiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historial = await _context.Historial.FindAsync(id);
            _context.Historial.Remove(historial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialExists(int id)
        {
            return _context.Historial.Any(e => e.HistorialID == id);
        }
    }
}
