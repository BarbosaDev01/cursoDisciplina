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
    public class disciplinaController : Controller
    {
        private readonly WebApplication1Context _context;

        public disciplinaController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: disciplina
        public async Task<IActionResult> Index()
        {
              return _context.disciplina != null ? 
                          View(await _context.disciplina.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.disciplina'  is null.");
        }

        // GET: disciplina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.disciplina
                .FirstOrDefaultAsync(m => m.disciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: disciplina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: disciplina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("disciplinaId,nome")] disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        // GET: disciplina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.disciplina.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        // POST: disciplina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("disciplinaId,nome")] disciplina disciplina)
        {
            if (id != disciplina.disciplinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!disciplinaExists(disciplina.disciplinaId))
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
            return View(disciplina);
        }

        // GET: disciplina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.disciplina
                .FirstOrDefaultAsync(m => m.disciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.disciplina == null)
            {
                return Problem("Entity set 'WebApplication1Context.disciplina'  is null.");
            }
            var disciplina = await _context.disciplina.FindAsync(id);
            if (disciplina != null)
            {
                _context.disciplina.Remove(disciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool disciplinaExists(int id)
        {
          return (_context.disciplina?.Any(e => e.disciplinaId == id)).GetValueOrDefault();
        }
    }
}
