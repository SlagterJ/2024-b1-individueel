using _2024_b1_individueel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Controllers;

public class QuizController(GuessTheFlagDatabaseContext context) : Controller
{
    public IActionResult Index() => View();

    // this is, for some reason, required
    [Route("quiz/{identifier?}")]
    public async Task<IActionResult> Quiz(Guid? identifier)
    {
        if (identifier == null)
            return View("Index");

        var flagDeck = await context.FlagDeckSet.FirstOrDefaultAsync(model =>
            model.Identifier == identifier
        );
        if (flagDeck == null)
            return NotFound();

        return View("Quiz", flagDeck.Shuffle());
    }
}
