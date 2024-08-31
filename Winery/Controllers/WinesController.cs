using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Winery.Data;
using Winery.Models;

namespace Winery.Controllers
{
    public class WinesController : Controller
    {
        private readonly WineryContext _context;

        public WinesController(WineryContext context)
        {
            _context = context;
        }

        // GET: Wines
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Wine
                                            orderby m.Type
                                            select m.Type;
            var movies = from m in _context.Wine
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Type == movieGenre);
            }

            var movieGenreVM = new winess
            {
                WinGen = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Wineis = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Wines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wine == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine
                .FirstOrDefaultAsync(m => m.WineId == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // GET: Wines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WineId,Name,Type,Brand,Country,Region,Vintage,WineSize,Stock,WinePrice")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wine);
        }

        // GET: Wines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wine == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.FindAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WineId,Name,Type,Brand,Country,Region,Vintage,WineSize,Stock,WinePrice")] Wine wine)
        {
            if (id != wine.WineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineExists(wine.WineId))
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
            return View(wine);
        }

        // GET: Wines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wine == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine
                .FirstOrDefaultAsync(m => m.WineId == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wine == null)
            {
                return Problem("Entity set 'WineryContext.Wine'  is null.");
            }
            var wine = await _context.Wine.FindAsync(id);
            if (wine != null)
            {
                _context.Wine.Remove(wine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineExists(int id)
        {
          return (_context.Wine?.Any(e => e.WineId == id)).GetValueOrDefault();
        }
    }
}
