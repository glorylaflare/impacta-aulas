using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteWebApp.Data;
using TesteWebApp.Models;

namespace TesteWebApp.Controllers
{
    public class EspecilidadesController : Controller
    {
        private readonly TesteWebAppContext _context;

        public EspecilidadesController(TesteWebAppContext context)
        {
            _context = context;
        }

        // GET: Especilidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especilidade.ToListAsync());
        }

        // GET: Especilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especilidade = await _context.Especilidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especilidade == null)
            {
                return NotFound();
            }

            return View(especilidade);
        }

        // GET: Especilidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo")] Especilidade especilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especilidade);
        }

        // GET: Especilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especilidade = await _context.Especilidade.FindAsync(id);
            if (especilidade == null)
            {
                return NotFound();
            }
            return View(especilidade);
        }

        // POST: Especilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo")] Especilidade especilidade)
        {
            if (id != especilidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecilidadeExists(especilidade.Id))
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
            return View(especilidade);
        }

        // GET: Especilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especilidade = await _context.Especilidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especilidade == null)
            {
                return NotFound();
            }

            return View(especilidade);
        }

        // POST: Especilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especilidade = await _context.Especilidade.FindAsync(id);
            if (especilidade != null)
            {
                _context.Especilidade.Remove(especilidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecilidadeExists(int id)
        {
            return _context.Especilidade.Any(e => e.Id == id);
        }
    }
}
