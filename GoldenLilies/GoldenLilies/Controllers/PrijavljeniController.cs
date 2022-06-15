using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoldenLilies.Data;
using GoldenLilies.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoldenLilies.Controllers
{
    public class PrijavljeniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrijavljeniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prijavljeni
        [Authorize(Roles ="Vodic")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prijavljeni.Include(p => p.korisnik).Include(p => p.tura);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prijavljeni/Details/5
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavljeni = await _context.Prijavljeni
                .Include(p => p.korisnik)
                .Include(p => p.tura)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prijavljeni == null)
            {
                return NotFound();
            }

            return View(prijavljeni);
        }

        // GET: Prijavljeni/Create
        [Authorize(Roles = "Vodic")]
        public IActionResult Create()
        {
            ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID");
            ViewData["turaID"] = new SelectList(_context.Tura, "ID", "ID");
            return View();
        }

        // POST: Prijavljeni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Create([Bind("ID,korisnikID,turaID")] Prijavljeni prijavljeni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prijavljeni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID", prijavljeni.korisnikID);
            ViewData["turaID"] = new SelectList(_context.Tura, "ID", "ID", prijavljeni.turaID);
            return View(prijavljeni);
        }

        // GET: Prijavljeni/Edit/5
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavljeni = await _context.Prijavljeni.FindAsync(id);
            if (prijavljeni == null)
            {
                return NotFound();
            }
            ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID", prijavljeni.korisnikID);
            ViewData["turaID"] = new SelectList(_context.Tura, "ID", "ID", prijavljeni.turaID);
            return View(prijavljeni);
        }

        // POST: Prijavljeni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,korisnikID,turaID")] Prijavljeni prijavljeni)
        {
            if (id != prijavljeni.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prijavljeni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrijavljeniExists(prijavljeni.ID))
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
            ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID", prijavljeni.korisnikID);
            ViewData["turaID"] = new SelectList(_context.Tura, "ID", "ID", prijavljeni.turaID);
            return View(prijavljeni);
        }

        // GET: Prijavljeni/Delete/5
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavljeni = await _context.Prijavljeni
                .Include(p => p.korisnik)
                .Include(p => p.tura)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prijavljeni == null)
            {
                return NotFound();
            }

            return View(prijavljeni);
        }

        // POST: Prijavljeni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prijavljeni = await _context.Prijavljeni.FindAsync(id);
            _context.Prijavljeni.Remove(prijavljeni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrijavljeniExists(int id)
        {
            return _context.Prijavljeni.Any(e => e.ID == id);
        }
    }
}
