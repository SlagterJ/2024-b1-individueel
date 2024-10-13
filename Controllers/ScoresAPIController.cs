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

[Route("api/Scores")]
[ApiController]
public class ScoresAPIController(GuessTheFlagDatabaseContext context) : ControllerBase
{
    // GET: api/ScoresAPI
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Score>>> GetScoreSet()
    {
        return await context.ScoreSet.ToListAsync();
    }

    // GET: api/ScoresAPI/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Score>> GetScore(Guid id)
    {
        var score = await context.ScoreSet.FindAsync(id);

        if (score == null)
        {
            return NotFound();
        }

        return score;
    }

    // PUT: api/ScoresAPI/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutScore(Guid id, Score score)
    {
        if (id != score.Identifier)
        {
            return BadRequest();
        }

        context.Entry(score).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ScoreExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/ScoresAPI
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Score>> PostScore(Score score)
    {
        context.ScoreSet.Add(score);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetScore", new { id = score.Identifier }, score);
    }

    // DELETE: api/ScoresAPI/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScore(Guid id)
    {
        var score = await context.ScoreSet.FindAsync(id);
        if (score == null)
        {
            return NotFound();
        }

        context.ScoreSet.Remove(score);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ScoreExists(Guid id)
    {
        return context.ScoreSet.Any(e => e.Identifier == id);
    }
}
