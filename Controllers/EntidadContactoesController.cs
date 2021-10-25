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
    public class EntidadContactoesController : Controller
    {
        private readonly WebContext _context;

        public EntidadContactoesController(WebContext context)
        {
            _context = context;
        }

        // GET: EntidadContactoes
        public async Task<IActionResult> Index()
        {
            var webContext = _context.EntidadContacto.Include(e => e.Contacto).Include(e => e.Entidad);
            return View(await webContext.ToListAsync());
        }

        // GET: EntidadContactoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadContacto = await _context.EntidadContacto
                .Include(e => e.Contacto)
                .Include(e => e.Entidad)
                .FirstOrDefaultAsync(m => m.EntidadID == id);
            if (entidadContacto == null)
            {
                return NotFound();
            }

            return View(entidadContacto);
        }

        // GET: EntidadContactoes/Create
        public IActionResult Create()
        {
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID");
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID");
            return View();
        }

        // POST: EntidadContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadID,ContactoID")] EntidadContacto entidadContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidadContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID", entidadContacto.ContactoID);
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID", entidadContacto.EntidadID);
            return View(entidadContacto);
        }

        // GET: EntidadContactoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadContacto = await _context.EntidadContacto.FindAsync(id);
            if (entidadContacto == null)
            {
                return NotFound();
            }
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID", entidadContacto.ContactoID);
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID", entidadContacto.EntidadID);
            return View(entidadContacto);
        }

        // POST: EntidadContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EntidadID,ContactoID")] EntidadContacto entidadContacto)
        {
            if (id != entidadContacto.EntidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidadContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadContactoExists(entidadContacto.EntidadID))
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
            ViewData["ContactoID"] = new SelectList(_context.Contacto, "ContactoID", "ContactoID", entidadContacto.ContactoID);
            ViewData["EntidadID"] = new SelectList(_context.EntidadFormacion, "EntidadID", "EntidadID", entidadContacto.EntidadID);
            return View(entidadContacto);
        }

        // GET: EntidadContactoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadContacto = await _context.EntidadContacto
                .Include(e => e.Contacto)
                .Include(e => e.Entidad)
                .FirstOrDefaultAsync(m => m.EntidadID == id);
            if (entidadContacto == null)
            {
                return NotFound();
            }

            return View(entidadContacto);
        }

        // POST: EntidadContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var entidadContacto = await _context.EntidadContacto.FindAsync(id);
            _context.EntidadContacto.Remove(entidadContacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadContactoExists(string id)
        {
            return _context.EntidadContacto.Any(e => e.EntidadID == id);
        }
    }
}
