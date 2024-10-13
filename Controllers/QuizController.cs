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

public class QuizController(GuessTheFlagDatabaseContext context) : Controller
{
    // this is, for some reason, required
    [Route("quiz/{identifier?}")]
    public async Task<IActionResult> Index(Guid? identifier)
    {
        if (identifier == null)
            return View("Index");

        var flagDeck = await context.FlagDeckSet.FirstOrDefaultAsync(model =>
            model.Identifier == identifier
        );
        if (flagDeck == null)
            return NotFound();

        return View("Index", flagDeck.Shuffle());
    }
}
