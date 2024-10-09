using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_b1_individueel.Data;
using _2024_b1_individueel.Models;

namespace _2024_b1_individueel.Controllers
{
    public class FlagDecksController : Controller
    {
        private readonly GuessTheFlagDatabaseContext _context;

        public FlagDecksController(GuessTheFlagDatabaseContext context)
        {
            _context = context;
        }

        // GET: FlagDecks
        public async Task<IActionResult> Index()
        {
            return View(await _context.FlagDeckSet.ToListAsync());
        }

        // GET: FlagDecks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flagDeck = await _context.FlagDeckSet
                .FirstOrDefaultAsync(m => m.Identifier == id);
            if (flagDeck == null)
            {
                return NotFound();
            }

            return View(flagDeck);
        }

        // GET: FlagDecks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlagDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Identifier")] FlagDeck flagDeck)
        {
            if (ModelState.IsValid)
            {
                flagDeck.Identifier = Guid.NewGuid();
                _context.Add(flagDeck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flagDeck);
        }

        // GET: FlagDecks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flagDeck = await _context.FlagDeckSet.FindAsync(id);
            if (flagDeck == null)
            {
                return NotFound();
            }
            return View(flagDeck);
        }

        // POST: FlagDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Identifier")] FlagDeck flagDeck)
        {
            if (id != flagDeck.Identifier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flagDeck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlagDeckExists(flagDeck.Identifier))
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
            return View(flagDeck);
        }

        // GET: FlagDecks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flagDeck = await _context.FlagDeckSet
                .FirstOrDefaultAsync(m => m.Identifier == id);
            if (flagDeck == null)
            {
                return NotFound();
            }

            return View(flagDeck);
        }

        // POST: FlagDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var flagDeck = await _context.FlagDeckSet.FindAsync(id);
            if (flagDeck != null)
            {
                _context.FlagDeckSet.Remove(flagDeck);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlagDeckExists(Guid id)
        {
            return _context.FlagDeckSet.Any(e => e.Identifier == id);
        }
    }
}
