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

public class ScoresController(GuessTheFlagDatabaseContext context) : Controller
{
    // GET: Scores
    public async Task<IActionResult> Index()
    {
        return View(await context.ScoreSet.ToListAsync());
    }

    // GET: Scores/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var score = await context.ScoreSet.FirstOrDefaultAsync(m => m.Identifier == id);
        if (score == null)
        {
            return NotFound();
        }

        return View(score);
    }

    // GET: Scores/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Scores/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("AchievedBy,AchievedScore,Identifier")] Score score
    )
    {
        if (ModelState.IsValid)
        {
            score.Identifier = Guid.NewGuid();
            context.Add(score);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(score);
    }

    // GET: Scores/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var score = await context.ScoreSet.FindAsync(id);
        if (score == null)
        {
            return NotFound();
        }
        return View(score);
    }

    // POST: Scores/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        Guid id,
        [Bind("AchievedBy,AchievedScore,Identifier")] Score score
    )
    {
        if (id != score.Identifier)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(score);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(score.Identifier))
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
        return View(score);
    }

    // GET: Scores/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var score = await context.ScoreSet.FirstOrDefaultAsync(m => m.Identifier == id);
        if (score == null)
        {
            return NotFound();
        }

        return View(score);
    }

    // POST: Scores/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var score = await context.ScoreSet.FindAsync(id);
        if (score != null)
        {
            context.ScoreSet.Remove(score);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ScoreExists(Guid id)
    {
        return context.ScoreSet.Any(e => e.Identifier == id);
    }
}
