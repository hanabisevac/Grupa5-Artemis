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
    public class FotografijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotografijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fotografija
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fotografija.Include(f => f.atrakcija).Include(f => f.korisnik);
            var niz =  await applicationDbContext.ToListAsync();
            
            return View(niz);
        }

        // GET: Fotografija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografija = await _context.Fotografija
                .Include(f => f.atrakcija)
                .Include(f => f.korisnik)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fotografija == null)
            {
                return NotFound();
            }

            return View(fotografija);
        }

        // GET: Fotografija/Create
        public IActionResult Create()
        {
            ViewData["atrakcijaID"] = new SelectList(_context.Atrakcija, "ID", "ID");
            ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID");
            return View();
        }

        // POST: Fotografija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,putanja,korisnikID,atrakcijaID,verifikovano")] Fotografija fotografija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotografija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["atrakcijaID"] = new SelectList(_context.Atrakcija, "ID", "naziv", fotografija.atrakcijaID);
            //ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID", fotografija.korisnikID);
            return View(fotografija);
        }

        // GET: Fotografija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografija = await _context.Fotografija.FindAsync(id);
            if (fotografija == null)
            {
                return NotFound();
            }
            ViewData["atrakcijaID"] = new SelectList(_context.Atrakcija, "ID", "naziv", fotografija.atrakcijaID);
            //ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID", fotografija.korisnikID);
            return View(fotografija);
        }

        // POST: Fotografija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,putanja,korisnikID,atrakcijaID,verifikovano")] Fotografija fotografija)
        {
            if (id != fotografija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotografija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografijaExists(fotografija.ID))
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
            ViewData["atrakcijaID"] = new SelectList(_context.Atrakcija, "ID", "ID", fotografija.atrakcijaID);
            //ViewData["korisnikID"] = new SelectList(_context.Korisnik, "ID", "ID", fotografija.korisnikID);
            return View(fotografija);
        }

        // GET: Fotografija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografija = await _context.Fotografija
                .Include(f => f.atrakcija)
                //.Include(f => f.korisnik)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fotografija == null)
            {
                return NotFound();
            }

            return View(fotografija);
        }

        // POST: Fotografija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotografija = await _context.Fotografija.FindAsync(id);
            _context.Fotografija.Remove(fotografija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografijaExists(int id)
        {
            return _context.Fotografija.Any(e => e.ID == id);
        }
    }
}
