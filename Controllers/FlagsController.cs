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
    public class FlagsController : Controller
    {
        private readonly GuessTheFlagDatabaseContext _context;

        public FlagsController(GuessTheFlagDatabaseContext context)
        {
            _context = context;
        }

        // GET: Flags
        public async Task<IActionResult> Index()
        {
            return View(await _context.FlagSet.ToListAsync());
        }

        // GET: Flags/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flag = await _context.FlagSet
                .FirstOrDefaultAsync(m => m.Identifier == id);
            if (flag == null)
            {
                return NotFound();
            }

            return View(flag);
        }

        // GET: Flags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryCode,CorrectAnswers,Identifier")] Flag flag)
        {
            if (ModelState.IsValid)
            {
                flag.Identifier = Guid.NewGuid();
                _context.Add(flag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flag);
        }

        // GET: Flags/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flag = await _context.FlagSet.FindAsync(id);
            if (flag == null)
            {
                return NotFound();
            }
            return View(flag);
        }

        // POST: Flags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CountryCode,CorrectAnswers,Identifier")] Flag flag)
        {
            if (id != flag.Identifier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlagExists(flag.Identifier))
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
            return View(flag);
        }

        // GET: Flags/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flag = await _context.FlagSet
                .FirstOrDefaultAsync(m => m.Identifier == id);
            if (flag == null)
            {
                return NotFound();
            }

            return View(flag);
        }

        // POST: Flags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var flag = await _context.FlagSet.FindAsync(id);
            if (flag != null)
            {
                _context.FlagSet.Remove(flag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlagExists(Guid id)
        {
            return _context.FlagSet.Any(e => e.Identifier == id);
        }
    }
}
