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

[Route("api/Flags")]
[ApiController]
public class FlagsAPIController(GuessTheFlagDatabaseContext context) : ControllerBase
{
    // GET: api/FlagsAPI
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flag>>> GetFlagSet() =>
        await context.FlagSet.ToListAsync();

    // GET: api/FlagsAPI/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Flag>> GetFlag(int id)
    {
        var flag = await context.FlagSet.FindAsync(id);

        if (flag == null)
            return NotFound();

        return flag;
    }

    // PUT: api/FlagsAPI/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFlag(int id, Flag flag)
    {
        if (id != flag.Identifier)
            return BadRequest();

        context.Entry(flag).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FlagExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/FlagsAPI
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Flag>> PostFlag(Flag flag)
    {
        context.FlagSet.Add(flag);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetFlag", new { id = flag.Identifier }, flag);
    }

    // DELETE: api/FlagsAPI/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlag(int id)
    {
        var flag = await context.FlagSet.FindAsync(id);
        if (flag == null)
            return NotFound();

        context.FlagSet.Remove(flag);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool FlagExists(int id) => context.FlagSet.Any(e => e.Identifier == id);
}
