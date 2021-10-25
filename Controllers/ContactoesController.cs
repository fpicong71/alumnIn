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
    public class ContactoesController : Controller
    {
        private readonly WebContext _context;

        public ContactoesController(WebContext context)
        {
            _context = context;
        }

        // GET: Contactoes
        public async Task<IActionResult> Index()
        {
            var contactoContext = _context.Contacto.Include(h => h.EntidadContactos).ThenInclude(h=>h.Entidad);
            return View(await _context.Contacto.ToListAsync());
        }

        // GET: Contactoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactoContext = await _context.Contacto.Include(h => h.EntidadContactos).ThenInclude(h => h.Entidad)
                .FirstOrDefaultAsync(m => m.ContactoID == id);

            if (contactoContext == null)
            {
                return NotFound();
            }

            return View(contactoContext);
        }

        // GET: Contactoes/Create
        public IActionResult Create()
        {
            ViewData["ContactoID"] = new SelectList(_context.EntidadContacto, "EntidadID", "ContactoID");
            return View();
        }

        // POST: Contactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactoID,Nombre,Apellido1,Apellido2,Puesto")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {

                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactoID"] = new SelectList(_context.EntidadContacto, "EntidadID", "ContactoID");
            return View(contacto);
        }

        // GET: Contactoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = await _context.Contacto.FirstOrDefaultAsync(m => m.ContactoID == id);

            //var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            ViewData["ContactoID"] = new SelectList(_context.EntidadContacto, "EntidadID", "ContactoID");
            return View(contacto);
        }

        // POST: Contactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContactoID,Nombre,Apellido1,Apellido2,Puesto")] Contacto contacto)
        {
            if (id != contacto.ContactoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.ContactoID))
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
            ViewData["ContactoID"] = new SelectList(_context.EntidadContacto, "EntidadID", "ContactoID");
            return View(contacto);
        }

        // GET: Contactoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.Include(h=>h.EntidadContactos).ThenInclude(h=>h.Entidad)
                .FirstOrDefaultAsync(m => m.ContactoID == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(string id)
        {
            return _context.Contacto.Any(e => e.ContactoID == id);
        }
    }
}
