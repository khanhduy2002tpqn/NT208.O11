using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeStoreProject.Data;
using ShoeStoreProject.Models;

namespace ShoeStoreProject.Controllers
{
    public class SourcesController : Controller
    {
        private readonly ShoeStoreProjectContext _context;

        public SourcesController(ShoeStoreProjectContext context)
        {
            _context = context;
        }

        // GET: Sources
        public async Task<IActionResult> Index()
        {
              return _context.Source != null ? 
                          View(await _context.Source.ToListAsync()) :
                          Problem("Entity set 'ShoeStoreProjectContext.Source'  is null.");
        }

        // GET: Sources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Source == null)
            {
                return NotFound();
            }

            var source = await _context.Source
                .FirstOrDefaultAsync(m => m.SourceID == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }

        // GET: Sources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SourceID,SourceName,Address,PhoneNumber,Email")] Source source)
        {
            if (ModelState.IsValid)
            {
                _context.Add(source);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(source);
        }

        // GET: Sources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Source == null)
            {
                return NotFound();
            }

            var source = await _context.Source.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }
            return View(source);
        }

        // POST: Sources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SourceID,SourceName,Address,PhoneNumber,Email")] Source source)
        {
            if (id != source.SourceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(source);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourceExists(source.SourceID))
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
            return View(source);
        }

        // GET: Sources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Source == null)
            {
                return NotFound();
            }

            var source = await _context.Source
                .FirstOrDefaultAsync(m => m.SourceID == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }

        // POST: Sources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Source == null)
            {
                return Problem("Entity set 'ShoeStoreProjectContext.Source'  is null.");
            }
            var source = await _context.Source.FindAsync(id);
            if (source != null)
            {
                _context.Source.Remove(source);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SourceExists(int id)
        {
          return (_context.Source?.Any(e => e.SourceID == id)).GetValueOrDefault();
        }
    }
}
