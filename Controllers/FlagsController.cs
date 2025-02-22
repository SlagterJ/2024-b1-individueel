﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2024_b1_individueel.Data;
using _2024_b1_individueel.Models;
using _2024_b1_individueel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Controllers;

public class FlagsController(GuessTheFlagDatabaseContext context) : Controller
{
    // GET: Flags
    public async Task<IActionResult> Index() => View(await context.FlagSet.ToListAsync());

    // GET: Flags/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var flag = await context.FlagSet.FirstOrDefaultAsync(m => m.Identifier == id);
        if (flag == null)
            return NotFound();

        return View(flag);
    }

    // GET: Flags/Create
    public IActionResult Create()
    {
        var flagDecks = context.FlagDeckSet.ToList();
        var flagCreateEditViewModel = new FlagCreateEditViewModel()
        {
            FlagDecks = context
                .FlagDeckSet.Select(flagDeck => new SelectListItem
                {
                    Value = flagDeck.Identifier.ToString(),
                    Text = flagDeck.Name,
                })
                .ToList(),
        };
        return View(flagCreateEditViewModel);
    }

    // POST: Flags/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("CountryCode,CorrectAnswer,FlagDeckIdentifier,Identifier")]
            FlagCreateEditViewModel flagCreateEditViewModel
    )
    {
        if (ModelState.IsValid)
        {
            var flagDeck = await context.FlagDeckSet.FirstOrDefaultAsync(
                (flagDeck) => flagDeck.Identifier == flagCreateEditViewModel.FlagDeckIdentifier
            );

            if (flagDeck == null)
                return NotFound();

            var flag = new Flag()
            {
                CountryCode = flagCreateEditViewModel.CountryCode!,
                CorrectAnswer = flagCreateEditViewModel.CorrectAnswer!,
                FlagDeckIdentifier = flagDeck.Identifier,
                FlagDeck = flagDeck,
            };
            context.Add(flag);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(flagCreateEditViewModel);
    }

    // GET: Flags/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var flag = await context.FlagSet.FindAsync(id);
        if (flag == null)
            return NotFound();

        return View(flag);
    }

    // POST: Flags/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("CountryCode,CorrectAnswers,Identifier")] Flag flag
    )
    {
        if (id != flag.Identifier)
            return NotFound();

        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        try
        {
            context.Update(flag);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FlagExists(flag.Identifier))
                return NotFound();
            else
                throw;
        }

        return View(flag);
    }

    // GET: Flags/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var flag = await context.FlagSet.FirstOrDefaultAsync(m => m.Identifier == id);
        if (flag == null)
            return NotFound();

        return View(flag);
    }

    // POST: Flags/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var flag = await context.FlagSet.FindAsync(id);
        if (flag != null)
            context.FlagSet.Remove(flag);

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FlagExists(int id) => context.FlagSet.Any(e => e.Identifier == id);
}
