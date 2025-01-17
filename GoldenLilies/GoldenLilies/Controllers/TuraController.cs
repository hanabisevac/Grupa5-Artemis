﻿using System;
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
    [Authorize]
    public class TuraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TuraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tura
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tura.ToListAsync());
        }

        // GET: Tura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tura = await _context.Tura
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tura == null)
            {
                return NotFound();
            }

            return View(tura);
        }

        // GET: Tura/Create
        [Authorize(Roles ="Vodic")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Vodic")]
        public async Task<IActionResult> Create([Bind("ID,vodicID,vrijeme,informacije")] Tura tura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tura);
        }

        // GET: Tura/Edit/5
        [Authorize(Roles ="Vodic")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tura = await _context.Tura.FindAsync(id);
            if (tura == null)
            {
                return NotFound();
            }
            return View(tura);
        }

        // POST: Tura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,vodicID,vrijeme,informacije")] Tura tura)
        {
            if (id != tura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuraExists(tura.ID))
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
            return View(tura);
        }

        // GET: Tura/Delete/5
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tura = await _context.Tura
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tura == null)
            {
                return NotFound();
            }

            return View(tura);
        }

        // POST: Tura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vodic")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tura = await _context.Tura.FindAsync(id);
            _context.Tura.Remove(tura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuraExists(int id)
        {
            return _context.Tura.Any(e => e.ID == id);
        }

        public async Task<IActionResult> TureAtrakcije(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Console.WriteLine("tu sam" + id);
            var veza =  _context.AtrakcijeTure.Where( m => m.atrakcijaID == id).Include(t=> t.tura);
            if (veza == null)
            {
                return NotFound();
            }

            var lista = veza.ToList();
            List<Tura> ture = new List<Tura>();
            for (int i = 0; i < lista.Count; i++) {
                ture.Add(lista.ElementAt(i).tura);
            }
            return View(ture);
        }

        public async Task<IActionResult> TureZaPrijavljene(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ture = _context.Tura.Where(m => m.ID == id);
            //.FirstOrDefaultAsync(m => m.ID == id);
            if (ture == null)
            {
                return NotFound();
            }

            return View(ture.ToListAsync());
        }


    }
}
