using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class cursoController : Controller
    {
        private readonly WebApplication1Context _context;

        public cursoController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: curso
        public async Task<IActionResult> Index()
        {
              return _context.curso != null ? 
                          View(await _context.curso.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.curso'  is null.");
        }

        // GET: curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.curso == null)
            {
                return NotFound();
            }

            var curso = await _context.curso
                .FirstOrDefaultAsync(m => m.cursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: curso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cursoId,nome,depid")] curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.curso == null)
            {
                return NotFound();
            }

            var curso = await _context.curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cursoId,nome,depid")] curso curso)
        {
            if (id != curso.cursoId)
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
                    if (!cursoExists(curso.cursoId))
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
            return View(curso);
        }

        // GET: curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.curso == null)
            {
                return NotFound();
            }

            var curso = await _context.curso
                .FirstOrDefaultAsync(m => m.cursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.curso == null)
            {
                return Problem("Entity set 'WebApplication1Context.curso'  is null.");
            }
            var curso = await _context.curso.FindAsync(id);
            if (curso != null)
            {
                _context.curso.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cursoExists(int id)
        {
          return (_context.curso?.Any(e => e.cursoId == id)).GetValueOrDefault();
        }
    }
}
