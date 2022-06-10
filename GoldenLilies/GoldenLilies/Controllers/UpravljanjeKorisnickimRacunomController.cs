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
    public class UpravljanjeKorisnickimRacunomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpravljanjeKorisnickimRacunomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UpravljanjeKorisnickimRacunom
        public async Task<IActionResult> Index()
        {
            return View(await _context.Korisnik.ToListAsync());
        }

        // GET: UpravljanjeKorisnickimRacunom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // GET: UpravljanjeKorisnickimRacunom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UpravljanjeKorisnickimRacunom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ime,prezime,email,password,adresaID,telefon,aspNetUsersID")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korisnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korisnik);
        }

        // GET: UpravljanjeKorisnickimRacunom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            return View(korisnik);
        }

        // POST: UpravljanjeKorisnickimRacunom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ime,prezime,email,password,adresaID,telefon,aspNetUsersID")] Korisnik korisnik)
        {
            if (id != korisnik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(korisnik.ID))
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
            return View(korisnik);
        }

        // GET: UpravljanjeKorisnickimRacunom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: UpravljanjeKorisnickimRacunom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisnik.Any(e => e.ID == id);
        }
    }
}
