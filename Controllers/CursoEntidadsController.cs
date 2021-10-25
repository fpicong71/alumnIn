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
    public class CursoEntidadsController : Controller
    {
        private readonly WebContext _context;

        public CursoEntidadsController(WebContext context)
        {
            _context = context;
        }

        // GET: CursoEntidads
        public async Task<IActionResult> Index()
        {
            var webContext = _context.CursoEntidad.Include(c => c.Curso).Include(c => c.Entidad);
            return View(await webContext.ToListAsync());
        }

        // GET: CursoEntidads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoEntidad = await _context.CursoEntidad
                .Include(c => c.Curso)
                .Include(c => c.Entidad)
                .FirstOrDefaultAsync(m => m.EntidadID == id);
            if (cursoEntidad == null)
            {
                return NotFound();
            }

            return View(cursoEntidad);
        }

        // GET: CursoEntidads/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso");
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID");
            return View();
        }

        // POST: CursoEntidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadID,CursoID")] CursoEntidad cursoEntidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoEntidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", cursoEntidad.CursoID);
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID", cursoEntidad.EntidadID);
            return View(cursoEntidad);
        }

        // GET: CursoEntidads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoEntidad = await _context.CursoEntidad.FindAsync(id);
            if (cursoEntidad == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", cursoEntidad.CursoID);
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID", cursoEntidad.EntidadID);
            return View(cursoEntidad);
        }

        // POST: CursoEntidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EntidadID,CursoID")] CursoEntidad cursoEntidad)
        {
            if (id != cursoEntidad.EntidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoEntidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoEntidadExists(cursoEntidad.EntidadID))
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
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", cursoEntidad.CursoID);
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID", cursoEntidad.EntidadID);
            return View(cursoEntidad);
        }

        // GET: CursoEntidads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoEntidad = await _context.CursoEntidad
                .Include(c => c.Curso)
                .Include(c => c.Entidad)
                .FirstOrDefaultAsync(m => m.EntidadID == id);
            if (cursoEntidad == null)
            {
                return NotFound();
            }

            return View(cursoEntidad);
        }

        // POST: CursoEntidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cursoEntidad = await _context.CursoEntidad.FindAsync(id);
            _context.CursoEntidad.Remove(cursoEntidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoEntidadExists(string id)
        {
            return _context.CursoEntidad.Any(e => e.EntidadID == id);
        }
    }
}
