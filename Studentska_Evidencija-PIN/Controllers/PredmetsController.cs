using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studentska_Evidencija_PIN.Data;
using Studentska_Evidencija_PIN.Models;
using Microsoft.AspNetCore.Authorization;

namespace Studentska_Evidencija_PIN.Controllers
{
    [Authorize]
    public class PredmetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PredmetsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Predmets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Predmet.Include(p => p.smjer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Predmets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet
                .Include(p => p.smjer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // GET: Predmets/Create
        public IActionResult Create()
        {
            ViewData["smjerId"] = new SelectList(_context.Smjer, "ID", "Naziv");
            return View();
        }

        // POST: Predmets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,naziv,smjerId")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predmet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["smjerId"] = new SelectList(_context.Smjer, "ID", "Naziv", predmet.smjerId);
            return View(predmet);
        }

        // GET: Predmets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet.SingleOrDefaultAsync(m => m.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }
            ViewData["smjerId"] = new SelectList(_context.Smjer, "ID", "Naziv", predmet.smjerId);
            return View(predmet);
        }

        // POST: Predmets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,naziv,smjerId")] Predmet predmet)
        {
            if (id != predmet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredmetExists(predmet.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["smjerId"] = new SelectList(_context.Smjer, "ID", "Naziv", predmet.smjerId);
            return View(predmet);
        }

        // GET: Predmets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet
                .Include(p => p.smjer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // POST: Predmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predmet = await _context.Predmet.SingleOrDefaultAsync(m => m.ID == id);
            _context.Predmet.Remove(predmet);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PredmetExists(int id)
        {
            return _context.Predmet.Any(e => e.ID == id);
        }
    }
}
