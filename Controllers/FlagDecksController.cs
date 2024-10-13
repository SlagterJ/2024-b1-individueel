using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2024_b1_individueel.Data;
using _2024_b1_individueel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Controllers;

public class FlagDecksController(GuessTheFlagDatabaseContext context) : Controller
{
    // GET: FlagDecks
    public async Task<IActionResult> Index() => View(await context.FlagDeckSet.ToListAsync());

    public async Task<IActionResult> Choose() => View(await context.FlagDeckSet.ToListAsync());

    // GET: FlagDecks/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
            return NotFound();

        var flagDeck = await context.FlagDeckSet.FirstOrDefaultAsync(m => m.Identifier == id);
        if (flagDeck == null)
            return NotFound();

        return View(flagDeck);
    }

    // GET: FlagDecks/Create
    public IActionResult Create() => View();

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
            context.Add(flagDeck);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(flagDeck);
    }

    // GET: FlagDecks/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
            return NotFound();

        var flagDeck = await context.FlagDeckSet.FindAsync(id);
        if (flagDeck == null)
            return NotFound();

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
            return NotFound();

        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        try
        {
            context.Update(flagDeck);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FlagDeckExists(flagDeck.Identifier))
                return NotFound();
            else
                throw;
        }

        return View(flagDeck);
    }

    // GET: FlagDecks/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
            return NotFound();

        var flagDeck = await context.FlagDeckSet.FirstOrDefaultAsync(m => m.Identifier == id);
        if (flagDeck == null)
            return NotFound();

        return View(flagDeck);
    }

    // POST: FlagDecks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var flagDeck = await context.FlagDeckSet.FindAsync(id);
        if (flagDeck != null)
            context.FlagDeckSet.Remove(flagDeck);

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FlagDeckExists(Guid id) => context.FlagDeckSet.Any(e => e.Identifier == id);
}
