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
    public class departamentoesController : Controller
    {
        private readonly WebApplication1Context _context;

        public departamentoesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: departamentoes
        public async Task<IActionResult> Index()
        {
              return _context.departamento != null ? 
                          View(await _context.departamento.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.departamento'  is null.");
        }

        // GET: departamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.depid == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: departamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("depid,depnome,instid")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // GET: departamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: departamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("depid,depnome,instid")] departamento departamento)
        {
            if (id != departamento.depid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departamentoExists(departamento.depid))
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
            return View(departamento);
        }

        // GET: departamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.depid == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departamento == null)
            {
                return Problem("Entity set 'WebApplication1Context.departamento'  is null.");
            }
            var departamento = await _context.departamento.FindAsync(id);
            if (departamento != null)
            {
                _context.departamento.Remove(departamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departamentoExists(int id)
        {
          return (_context.departamento?.Any(e => e.depid == id)).GetValueOrDefault();
        }
    }
}
