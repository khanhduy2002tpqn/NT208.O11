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
    public class ProductRepoesController : Controller
    {
        private readonly ShoeStoreProjectContext _context;

        public ProductRepoesController(ShoeStoreProjectContext context)
        {
            _context = context;
        }

        // GET: ProductRepoes
        public async Task<IActionResult> Index()
        {
            var shoeStoreProjectContext = _context.ProductRepo.Include(p => p.Cart).Include(p => p.Repo).Include(p => p.Source);
            return View(await shoeStoreProjectContext.ToListAsync());
        }

        // GET: ProductRepoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductRepo == null)
            {
                return NotFound();
            }

            var productRepo = await _context.ProductRepo
                .Include(p => p.Cart)
                .Include(p => p.Repo)
                .Include(p => p.Source)
                .FirstOrDefaultAsync(m => m.RepoProductID == id);
            if (productRepo == null)
            {
                return NotFound();
            }

            return View(productRepo);
        }

        // GET: ProductRepoes/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "PID", "PID");
            ViewData["RepoID"] = new SelectList(_context.Repo, "RepoID", "RepoID");
            ViewData["SourceID"] = new SelectList(_context.Source, "SourceID", "SourceID");
            return View();
        }

        // POST: ProductRepoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepoProductID,RepoID,ProductName,ProductID,SourceID,Quantity")] ProductRepo productRepo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productRepo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "PID", "PID", productRepo.ProductID);
            ViewData["RepoID"] = new SelectList(_context.Repo, "RepoID", "RepoID", productRepo.RepoID);
            ViewData["SourceID"] = new SelectList(_context.Source, "SourceID", "SourceID", productRepo.SourceID);
            return View(productRepo);
        }

        // GET: ProductRepoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductRepo == null)
            {
                return NotFound();
            }

            var productRepo = await _context.ProductRepo.FindAsync(id);
            if (productRepo == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "PID", "PID", productRepo.ProductID);
            ViewData["RepoID"] = new SelectList(_context.Repo, "RepoID", "RepoID", productRepo.RepoID);
            ViewData["SourceID"] = new SelectList(_context.Source, "SourceID", "SourceID", productRepo.SourceID);
            return View(productRepo);
        }

        // POST: ProductRepoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("RepoProductID,RepoID,ProductName,ProductID,SourceID,Quantity")] ProductRepo productRepo)
        {
            if (id != productRepo.RepoProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productRepo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductRepoExists(productRepo.RepoProductID))
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
            ViewData["ProductID"] = new SelectList(_context.Product, "PID", "PID", productRepo.ProductID);
            ViewData["RepoID"] = new SelectList(_context.Repo, "RepoID", "RepoID", productRepo.RepoID);
            ViewData["SourceID"] = new SelectList(_context.Source, "SourceID", "SourceID", productRepo.SourceID);
            return View(productRepo);
        }

        // GET: ProductRepoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductRepo == null)
            {
                return NotFound();
            }

            var productRepo = await _context.ProductRepo
                .Include(p => p.Cart)
                .Include(p => p.Repo)
                .Include(p => p.Source)
                .FirstOrDefaultAsync(m => m.RepoProductID == id);
            if (productRepo == null)
            {
                return NotFound();
            }

            return View(productRepo);
        }

        // POST: ProductRepoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ProductRepo == null)
            {
                return Problem("Entity set 'ShoeStoreProjectContext.ProductRepo'  is null.");
            }
            var productRepo = await _context.ProductRepo.FindAsync(id);
            if (productRepo != null)
            {
                _context.ProductRepo.Remove(productRepo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductRepoExists(int? id)
        {
          return (_context.ProductRepo?.Any(e => e.RepoProductID == id)).GetValueOrDefault();
        }
    }
}
