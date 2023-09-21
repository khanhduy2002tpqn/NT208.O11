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
    public class RepoesController : Controller
    {
        private readonly ShoeStoreProjectContext _context;

        public RepoesController(ShoeStoreProjectContext context)
        {
            _context = context;
        }

        // GET: Repoes
        public async Task<IActionResult> Index()
        {
              return _context.Repo != null ? 
                          View(await _context.Repo.ToListAsync()) :
                          Problem("Entity set 'ShoeStoreProjectContext.Repo'  is null.");
        }

        // GET: Repoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Repo == null)
            {
                return NotFound();
            }

            var repo = await _context.Repo
                .FirstOrDefaultAsync(m => m.RepoID == id);
            if (repo == null)
            {
                return NotFound();
            }

            return View(repo);
        }

        // GET: Repoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepoID,RepoName,Address")] Repo repo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repo);
        }

        // GET: Repoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Repo == null)
            {
                return NotFound();
            }

            var repo = await _context.Repo.FindAsync(id);
            if (repo == null)
            {
                return NotFound();
            }
            return View(repo);
        }

        // POST: Repoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepoID,RepoName,Address")] Repo repo)
        {
            if (id != repo.RepoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepoExists(repo.RepoID))
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
            return View(repo);
        }

        // GET: Repoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Repo == null)
            {
                return NotFound();
            }

            var repo = await _context.Repo
                .FirstOrDefaultAsync(m => m.RepoID == id);
            if (repo == null)
            {
                return NotFound();
            }

            return View(repo);
        }

        // POST: Repoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Repo == null)
            {
                return Problem("Entity set 'ShoeStoreProjectContext.Repo'  is null.");
            }
            var repo = await _context.Repo.FindAsync(id);
            if (repo != null)
            {
                _context.Repo.Remove(repo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepoExists(int id)
        {
          return (_context.Repo?.Any(e => e.RepoID == id)).GetValueOrDefault();
        }
    }
}
