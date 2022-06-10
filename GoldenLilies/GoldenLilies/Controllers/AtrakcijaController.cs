using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoldenLilies.Data;
using GoldenLilies.Models;

namespace GoldenLilies.Controllers
{
    public class AtrakcijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtrakcijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atrakcija
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Atrakcija.Include(a => a.lokacija).Include(a => a.vrstaAtrakcije);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Atrakcija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atrakcija = await _context.Atrakcija
                .Include(a => a.lokacija)
                .Include(a => a.vrstaAtrakcije)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atrakcija == null)
            {
                return NotFound();
            }

            return View(atrakcija);
        }

        // GET: Atrakcija/Create
        public IActionResult Create()
        {
            ViewData["lokacijaID"] = new SelectList(_context.Lokacija, "ID", "ID");
            ViewData["vrstaAtrakcijeID"] = new SelectList(_context.VrstaAtrakcije, "ID", "ID");
            return View();
        }

        // POST: Atrakcija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,naziv,lokacijaID,vrstaAtrakcijeID,informacije,radnoVrijeme")] Atrakcija atrakcija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atrakcija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["lokacijaID"] = new SelectList(_context.Lokacija, "ID", "ID", atrakcija.lokacijaID);
            ViewData["vrstaAtrakcijeID"] = new SelectList(_context.VrstaAtrakcije, "ID", "ID", atrakcija.vrstaAtrakcijeID);
            return View(atrakcija);
        }

        // GET: Atrakcija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atrakcija = await _context.Atrakcija.FindAsync(id);
            if (atrakcija == null)
            {
                return NotFound();
            }
            ViewData["lokacijaID"] = new SelectList(_context.Lokacija, "ID", "ID", atrakcija.lokacijaID);
            ViewData["vrstaAtrakcijeID"] = new SelectList(_context.VrstaAtrakcije, "ID", "ID", atrakcija.vrstaAtrakcijeID);
            return View(atrakcija);
        }

        // POST: Atrakcija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,naziv,lokacijaID,vrstaAtrakcijeID,informacije,radnoVrijeme")] Atrakcija atrakcija)
        {
            if (id != atrakcija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atrakcija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtrakcijaExists(atrakcija.ID))
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
            ViewData["lokacijaID"] = new SelectList(_context.Lokacija, "ID", "ID", atrakcija.lokacijaID);
            ViewData["vrstaAtrakcijeID"] = new SelectList(_context.VrstaAtrakcije, "ID", "ID", atrakcija.vrstaAtrakcijeID);
            return View(atrakcija);
        }

        // GET: Atrakcija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atrakcija = await _context.Atrakcija
                .Include(a => a.lokacija)
                .Include(a => a.vrstaAtrakcije)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atrakcija == null)
            {
                return NotFound();
            }

            return View(atrakcija);
        }

        // POST: Atrakcija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atrakcija = await _context.Atrakcija.FindAsync(id);
            _context.Atrakcija.Remove(atrakcija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtrakcijaExists(int id)
        {
            return _context.Atrakcija.Any(e => e.ID == id);
        }
    }
}
