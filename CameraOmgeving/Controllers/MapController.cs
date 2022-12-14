using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CameraOmgeving.Data;
using CameraOmgeving.Models;

namespace CameraOmgeving.Controllers
{
    public class MapController : Controller
    {
        private readonly AppDbContext _context;

        public MapController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Map
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Maps.Include(m => m.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Map/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maps == null)
            {
                return NotFound();
            }

            var map = await _context.Maps
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // GET: Map/Create
        public IActionResult Create()
        {
            ViewData["userID"] = new SelectList(_context.Users, "id", "name");
            return View();
        }

        // POST: Map/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,LocationID,userID")] Map map)
        {
            if (ModelState.IsValid)
            {
                _context.Add(map);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userID"] = new SelectList(_context.Users, "id", "name", map.userID);
            return View(map);
        }

        // GET: Map/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maps == null)
            {
                return NotFound();
            }

            var map = await _context.Maps.FindAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            ViewData["userID"] = new SelectList(_context.Users, "id", "name", map.userID);
            return View(map);
        }

        // POST: Map/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,LocationID,userID")] Map map)
        {
            if (id != map.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(map);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapExists(map.id))
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
            ViewData["userID"] = new SelectList(_context.Users, "id", "name", map.userID);
            return View(map);
        }

        // GET: Map/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maps == null)
            {
                return NotFound();
            }

            var map = await _context.Maps
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // POST: Map/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maps == null)
            {
                return Problem("Entity set 'AppDbContext.Maps'  is null.");
            }
            var map = await _context.Maps.FindAsync(id);
            if (map != null)
            {
                _context.Maps.Remove(map);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapExists(int id)
        {
          return _context.Maps.Any(e => e.id == id);
        }
    }
}
