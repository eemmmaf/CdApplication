using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CdApplication.Data;
using CdApplication.Models;

namespace CdApplication.Controllers
{
    public class CdsController : Controller
    {
        private readonly CdContext _context;

        public CdsController(CdContext context)
        {
            _context = context;
        }

        // GET: Cds
        public async Task<IActionResult> Index(string searchString)
        {

            //Sökning
            ViewData["CurrentFilter"] = searchString;

            //Hämtar CD och inkluderar artist 
            var cds = from s in _context.Cd
                      .Include(s => s.Artist)
                      select s;

            //Kontroll att inte sökningen är tom
            if (!String.IsNullOrEmpty(searchString))
            {
                //Hämtar album som innehåller artistens namn
                cds = cds.Where(s => s.Title.Contains(searchString));

                //Returnerar albumet
                return View(cds);
            }

            var cdContext = _context.Cd.Include(c => c.Artist);
            return View(await cdContext.ToListAsync());
        }

        // GET: Cds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cd == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // GET: Cds/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Set<Artist>(), "ArtistId", "Name");
            return View();
        }

        // POST: Cds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ArtistId,CreatedDate")] Cd cd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Set<Artist>(), "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // GET: Cds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cd == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Set<Artist>(), "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // POST: Cds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ArtistId,CreatedDate")] Cd cd)
        {
            if (id != cd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CdExists(cd.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Set<Artist>(), "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // GET: Cds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cd == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // POST: Cds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cd == null)
            {
                return Problem("Entity set 'CdContext.Cd'  is null.");
            }
            var cd = await _context.Cd.FindAsync(id);
            if (cd != null)
            {
                _context.Cd.Remove(cd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CdExists(int id)
        {
          return (_context.Cd?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
