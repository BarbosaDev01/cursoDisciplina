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
    public class instituicaosController : Controller
    {
        private readonly WebApplication1Context _context;

        public instituicaosController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: instituicaos
        public async Task<IActionResult> Index()
        {
              return _context.instituicao != null ? 
                          View(await _context.instituicao.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.instituicao'  is null.");
        }

        // GET: instituicaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.instituicao == null)
            {
                return NotFound();
            }

            var instituicao = await _context.instituicao
                .FirstOrDefaultAsync(m => m.instid == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // GET: instituicaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: instituicaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("instid,instnome,insendereco")] instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: instituicaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.instituicao == null)
            {
                return NotFound();
            }

            var instituicao = await _context.instituicao.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // POST: instituicaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("instid,instnome,insendereco")] instituicao instituicao)
        {
            if (id != instituicao.instid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!instituicaoExists(instituicao.instid))
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
            return View(instituicao);
        }

        // GET: instituicaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.instituicao == null)
            {
                return NotFound();
            }

            var instituicao = await _context.instituicao
                .FirstOrDefaultAsync(m => m.instid == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // POST: instituicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.instituicao == null)
            {
                return Problem("Entity set 'WebApplication1Context.instituicao'  is null.");
            }
            var instituicao = await _context.instituicao.FindAsync(id);
            if (instituicao != null)
            {
                _context.instituicao.Remove(instituicao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool instituicaoExists(int id)
        {
          return (_context.instituicao?.Any(e => e.instid == id)).GetValueOrDefault();
        }
    }
}
