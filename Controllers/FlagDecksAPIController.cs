using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2024_b1_individueel.Data;
using _2024_b1_individueel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Controllers;

[Route("api/FlagDecks")]
[ApiController]
public class FlagDecksAPIController(GuessTheFlagDatabaseContext context) : ControllerBase
{
    // GET: api/FlagDecksAPI
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlagDeck>>> GetFlagDeckSet() =>
        await context.FlagDeckSet.ToListAsync();

    // GET: api/FlagDecksAPI/5
    [HttpGet("{id}")]
    public ActionResult<FlagDeck> GetFlagDeck(int id)
    {
        var flagDeck = context
            .FlagDeckSet.Include((model) => model.Flags)
            .FirstOrDefault((model) => model.Identifier == id);

        if (flagDeck == null)
            return NotFound();

        return flagDeck;
    }

    public readonly struct ScorePost
    {
        public string AchievedByName { get; init; }
        public int ScoreNumber { get; init; }
    }

    [HttpPost("{identifier}")]
    public ActionResult<Score> PostScore(int identifier, ScorePost scorePost)
    {
        var flagDeck = context
            .FlagDeckSet.Include((model) => model.Flags)
            .FirstOrDefault((model) => model.Identifier == identifier);

        if (flagDeck == null)
            return NotFound();

        var score = new Score()
        {
            AchievedBy = scorePost.AchievedByName != "" ? scorePost.AchievedByName : "Anoniem",
            AchievedScore = scorePost.ScoreNumber,
            FlagDeck = flagDeck,
        };

        context.ScoreSet.Add(score);
        context.SaveChanges();

        return score;
    }

    private bool FlagDeckExists(int id) => context.FlagDeckSet.Any(e => e.Identifier == id);
}
