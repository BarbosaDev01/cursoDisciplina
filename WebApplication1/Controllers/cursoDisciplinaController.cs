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
    public class cursoDisciplinaController : Controller
    {
        private readonly WebApplication1Context _context;

        public cursoDisciplinaController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: cursoDisciplina
        public async Task<IActionResult> Index()
        {
            var webApplication1Context = _context.cursoDisciplina.Include(c => c.curso).Include(c => c.disciplina);
            return View(await webApplication1Context.ToListAsync());
        }

        // GET: cursoDisciplina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cursoDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.cursoDisciplina
                .Include(c => c.curso)
                .Include(c => c.disciplina)
                .FirstOrDefaultAsync(m => m.cursoDisciplinaID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // GET: cursoDisciplina/Create
        public IActionResult Create()
        {
            ViewData["cursoID"] = new SelectList(_context.curso, "cursoId", "nome");
            ViewData["disciplinaID"] = new SelectList(_context.disciplina, "disciplinaId", "nome");
            return View();
        }

        // POST: cursoDisciplina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cursoDisciplinaID,cursoID,disciplinaID")] cursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursoID"] = new SelectList(_context.curso, "cursoId", "nome", cursoDisciplina.cursoID);
            ViewData["disciplinaID"] = new SelectList(_context.disciplina, "disciplinaId", "nome", cursoDisciplina.disciplinaID);
            return View(cursoDisciplina);
        }

        // GET: cursoDisciplina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cursoDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.cursoDisciplina.FindAsync(id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["cursoID"] = new SelectList(_context.curso, "cursoId", "nome", cursoDisciplina.cursoID);
            ViewData["disciplinaID"] = new SelectList(_context.disciplina, "disciplinaId", "nome", cursoDisciplina.disciplinaID);
            return View(cursoDisciplina);
        }

        // POST: cursoDisciplina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cursoDisciplinaID,cursoID,disciplinaID")] cursoDisciplina cursoDisciplina)
        {
            if (id != cursoDisciplina.cursoDisciplinaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cursoDisciplinaExists(cursoDisciplina.cursoDisciplinaID))
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
            ViewData["cursoID"] = new SelectList(_context.curso, "cursoId", "nome", cursoDisciplina.cursoID);
            ViewData["disciplinaID"] = new SelectList(_context.disciplina, "disciplinaId", "nome", cursoDisciplina.disciplinaID);
            return View(cursoDisciplina);
        }

        // GET: cursoDisciplina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cursoDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.cursoDisciplina
                .Include(c => c.curso)
                .Include(c => c.disciplina)
                .FirstOrDefaultAsync(m => m.cursoDisciplinaID == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // POST: cursoDisciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cursoDisciplina == null)
            {
                return Problem("Entity set 'WebApplication1Context.cursoDisciplina'  is null.");
            }
            var cursoDisciplina = await _context.cursoDisciplina.FindAsync(id);
            if (cursoDisciplina != null)
            {
                _context.cursoDisciplina.Remove(cursoDisciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cursoDisciplinaExists(int id)
        {
          return (_context.cursoDisciplina?.Any(e => e.cursoDisciplinaID == id)).GetValueOrDefault();
        }
    }
}
