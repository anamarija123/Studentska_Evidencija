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
    public class NastavniksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NastavniksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Nastavniks
        public async Task<IActionResult> Index(string trazi)
        {
            var nastavnici = from n in _context.Nastavnik
                           select n;
            //Provjeri je li traži postavljen
            if (!String.IsNullOrEmpty(trazi))
            {
                nastavnici = nastavnici.Where(n => n.Ime.Contains(trazi) || n.Prezime.Contains(trazi));
            }
            return View(nastavnici.ToList());
        }

        // GET: Nastavniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nastavnik = await _context.Nastavnik
                .SingleOrDefaultAsync(m => m.ID == id);
            if (nastavnik == null)
            {
                return NotFound();
            }

            return View(nastavnik);
        }

        // GET: Nastavniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nastavniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,DatumZaposlenja")] Nastavnik nastavnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nastavnik);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nastavnik);
        }

        // GET: Nastavniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nastavnik = await _context.Nastavnik.SingleOrDefaultAsync(m => m.ID == id);
            if (nastavnik == null)
            {
                return NotFound();
            }
            return View(nastavnik);
        }

        // POST: Nastavniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,DatumZaposlenja")] Nastavnik nastavnik)
        {
            if (id != nastavnik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nastavnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NastavnikExists(nastavnik.ID))
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
            return View(nastavnik);
        }

        // GET: Nastavniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nastavnik = await _context.Nastavnik
                .SingleOrDefaultAsync(m => m.ID == id);
            if (nastavnik == null)
            {
                return NotFound();
            }

            return View(nastavnik);
        }

        // POST: Nastavniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nastavnik = await _context.Nastavnik.SingleOrDefaultAsync(m => m.ID == id);
            _context.Nastavnik.Remove(nastavnik);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NastavnikExists(int id)
        {
            return _context.Nastavnik.Any(e => e.ID == id);
        }
    }
}
