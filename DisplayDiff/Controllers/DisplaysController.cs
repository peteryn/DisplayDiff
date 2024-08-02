using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DisplayDiff.Data;
using DisplayDiff.Models;

namespace DisplayDiff.Controllers
{
    public class DisplaysController : Controller
    {
        private readonly DisplayDiffContext _context;

        public DisplaysController(DisplayDiffContext context)
        {
            _context = context;
        }

        // GET: Displays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Display.ToListAsync());
        }

        // GET: Displays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Display
                .FirstOrDefaultAsync(m => m.Id == id);
            if (display == null)
            {
                return NotFound();
            }

            return View(display);
        }

        // GET: Displays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Displays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Company,VerticalResolution,HorizontalResolution,AdaptiveSync,PanelType,DiagonalLength,RefreshRate,FullSpecsURL")] Display display)
        {
            if (ModelState.IsValid)
            {
                _context.Add(display);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(display);
        }

        // GET: Displays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Display.FindAsync(id);
            if (display == null)
            {
                return NotFound();
            }
            return View(display);
        }

        // POST: Displays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Company,VerticalResolution,HorizontalResolution,AdaptiveSync,PanelType,DiagonalLength,RefreshRate,FullSpecsURL")] Display display)
        {
            if (id != display.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(display);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisplayExists(display.Id))
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
            return View(display);
        }

        // GET: Displays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Display
                .FirstOrDefaultAsync(m => m.Id == id);
            if (display == null)
            {
                return NotFound();
            }

            return View(display);
        }

        // POST: Displays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var display = await _context.Display.FindAsync(id);
            if (display != null)
            {
                _context.Display.Remove(display);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisplayExists(int id)
        {
            return _context.Display.Any(e => e.Id == id);
        }
    }
}
