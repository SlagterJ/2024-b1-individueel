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
    public ActionResult<FlagDeck> GetFlagDeck(Guid id)
    {
        var flagDeck = context
            .FlagDeckSet.Include((model) => model.Flags)
            .FirstOrDefault((model) => model.Identifier == id);

        if (flagDeck == null)
            return NotFound();

        return flagDeck;
    }

    // PUT: api/FlagDecksAPI/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFlagDeck(Guid id, FlagDeck flagDeck)
    {
        if (id != flagDeck.Identifier)
            return BadRequest();

        context.Entry(flagDeck).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FlagDeckExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/FlagDecksAPI
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<FlagDeck>> PostFlagDeck(FlagDeck flagDeck)
    {
        context.FlagDeckSet.Add(flagDeck);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetFlagDeck", new { id = flagDeck.Identifier }, flagDeck);
    }

    // DELETE: api/FlagDecksAPI/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlagDeck(Guid id)
    {
        var flagDeck = await context.FlagDeckSet.FindAsync(id);
        if (flagDeck == null)
            return NotFound();

        context.FlagDeckSet.Remove(flagDeck);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool FlagDeckExists(Guid id) => context.FlagDeckSet.Any(e => e.Identifier == id);
}
