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
    public class IspitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IspitsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ispits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ispit.Include(i => i.Nastavnik).Include(i => i.Predmet).Include(i => i.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ispits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ispit = await _context.Ispit
                .Include(i => i.Nastavnik)
                .Include(i => i.Predmet)
                .Include(i => i.Student)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ispit == null)
            {
                return NotFound();
            }

            return View(ispit);
        }

        // GET: Ispits/Create
        public IActionResult Create()
        {
            ViewData["nastavnikID"] = new SelectList(_context.Nastavnik, "ID", "Ime");
            ViewData["PredmetID"] = new SelectList(_context.Predmet, "ID", "naziv");
            ViewData["StudentId"] = new SelectList(_context.Student, "ID", "Ime");
            return View();
        }

        // POST: Ispits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StudentId,PredmetID,Datum_ispita,nastavnikID,ocjena")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ispit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["nastavnikID"] = new SelectList(_context.Nastavnik, "ID", "Ime", ispit.nastavnikID);
            ViewData["PredmetID"] = new SelectList(_context.Predmet, "ID", "ID", ispit.PredmetID);
            ViewData["StudentId"] = new SelectList(_context.Student, "ID", "Ime", ispit.StudentId);
            return View(ispit);
        }

        // GET: Ispits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ispit = await _context.Ispit.SingleOrDefaultAsync(m => m.ID == id);
            if (ispit == null)
            {
                return NotFound();
            }
            ViewData["nastavnikID"] = new SelectList(_context.Nastavnik, "ID", "Ime", ispit.nastavnikID);
            ViewData["PredmetID"] = new SelectList(_context.Predmet, "ID", "naziv", ispit.PredmetID);
            ViewData["StudentId"] = new SelectList(_context.Student, "ID", "Ime", ispit.StudentId);
            return View(ispit);
        }

        // POST: Ispits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudentId,PredmetID,Datum_ispita,nastavnikID,ocjena")] Ispit ispit)
        {
            if (id != ispit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ispit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IspitExists(ispit.ID))
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
            ViewData["nastavnikID"] = new SelectList(_context.Nastavnik, "ID", "Ime", ispit.nastavnikID);
            ViewData["PredmetID"] = new SelectList(_context.Predmet, "ID", "naziv", ispit.PredmetID);
            ViewData["StudentId"] = new SelectList(_context.Student, "ID", "Ime", ispit.StudentId);
            return View(ispit);
        }

        // GET: Ispits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ispit = await _context.Ispit
                .Include(i => i.Nastavnik)
                .Include(i => i.Predmet)
                .Include(i => i.Student)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ispit == null)
            {
                return NotFound();
            }

            return View(ispit);
        }

        // POST: Ispits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ispit = await _context.Ispit.SingleOrDefaultAsync(m => m.ID == id);
            _context.Ispit.Remove(ispit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IspitExists(int id)
        {
            return _context.Ispit.Any(e => e.ID == id);
        }
    }
}
