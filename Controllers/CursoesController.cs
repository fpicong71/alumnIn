using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebFormacion.Data;
using WebFormacion.Models;
using WebFormacion.Models.WebViewModels;

namespace WebFormacion.Controllers
{
    public class CursoesController : Controller
    {
        private readonly WebContext _context;

        public CursoesController(WebContext context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Index()
        {


            var cursoContext = _context.Curso
                .Include(c => c.CursoEntidades)
                .ThenInclude(e=>e.Entidad)
                .AsNoTracking();
            return View(await cursoContext.ToListAsync());

            //return View(await _context.Curso.ToListAsync());
        }

        // GET: Cursoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var curso = await _context.Curso
            //    .FirstOrDefaultAsync(m => m.CursoID == id);

            var cursoContext = await _context.Curso
               .Include(ce => ce.CursoEntidades)
                  .ThenInclude(e => e.Entidad)
                  .AsNoTracking()
               .FirstOrDefaultAsync(m => m.CursoID == id);

            if (cursoContext == null)
            {
                return NotFound();
            }

            return View(cursoContext);
        }

        // GET: Cursoes/Create
        public IActionResult Create()
        {
            var curso = new Curso();
            curso.CursoEntidades = new List<CursoEntidad>();
            LlenarCursoData(curso);
            return View();

        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoID,NombreCurso,DescripcionCurso")] Curso curso, string[] selectedEntidad)
        {
            if (selectedEntidad != null)
            {
                curso.CursoEntidades = new List<CursoEntidad>();
                foreach (var entidad in selectedEntidad)
                {
                    var entidadToAdd = new CursoEntidad { CursoID = curso.CursoID, EntidadID = entidad };
                    curso.CursoEntidades.Add(entidadToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            LlenarCursoData(curso);
            return View(curso);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(curso);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            ////LlenarEntidadDropDownList(curso.CursoEntidades);
            //ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", curso.CursoID);

            //return View(curso);
        }

        // GET: Cursoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var curso = await _context.Curso.FindAsync(id);
            //Cambiado
            //var cursoContext = await _context.Curso.FindAsync(id);
            var cursoContext = await _context.Curso
            .Include(ce => ce.CursoEntidades)
            .ThenInclude(e => e.Entidad)
            .AsNoTracking().FirstOrDefaultAsync(m => m.CursoID == id);
            //Fin Cambiado
            if (cursoContext == null)
            {
                return NotFound();
            }

            //LlenarEntidad(cursoContext.CursoID);
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", cursoContext.CursoID);
            
            return View(cursoContext);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string id, [Bind("CursoID,NombreCurso,DescripcionCurso")] Curso curso)
        {
            if (id != curso.CursoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoID))
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
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "NombreCurso", curso.CursoID);
            return View(curso);
        }


        //METODO AÑADIDO
        private void LlenarCursoData(Curso curso)
        {
            var todasEntidades = _context.EntidadFormacion;
            var entidadCurso = new HashSet<string>(curso.CursoEntidades.Select(c => c.CursoID));
            var viewModel = new List<AsignacionEntidadData>();
            foreach (var entidad in todasEntidades)
            {
                viewModel.Add(new AsignacionEntidadData
                {
                    EntidadID = entidad.EntidadID,
                    RazonSocial = entidad.RazonSocial,
                    Asignado = entidadCurso.Contains(curso.CursoID)
                });
            }
            ViewData["Entidades"] = viewModel;
        }
        //METODO AÑADIDO
        //private void LlenarEntidad(object entidadSelect = null)
        //{
        //    var entidadQuery = from e in _context.EntidadFormacion
        //                       orderby e.RazonSocial
        //                       select e;
        //    ViewBag.EntidadID = new SelectList(entidadQuery.AsNoTracking(), "EntidadID", "RazonSocial", entidadSelect);

        //}

        // GET: Cursoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso
             .Include(ce => ce.CursoEntidades)
                .ThenInclude(e => e.Entidad)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CursoID == id);

            //var curso = await _context.Curso
            //    .FirstOrDefaultAsync(m => m.CursoID == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CursoExists(string id)
        {
            return _context.Curso.Any(e => e.CursoID == id);
        }
    }
}
