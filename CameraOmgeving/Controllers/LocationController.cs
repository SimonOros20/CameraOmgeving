using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CameraOmgeving.Data;
using CameraOmgeving.Models;
using NuGet.ProjectModel;
using Microsoft.CodeAnalysis;
using Location = CameraOmgeving.Models.Location;

namespace CameraOmgeving.Controllers
{
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;

        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Location    
        public async Task<IActionResult> Index(int? LocationID)
        {
            var appDbContext = _context.locations.Include(l => l.Map)
                                                 .Include(C => C.Cameras);
            return View(await appDbContext.ToListAsync());
        }
            
        // GET: Location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.locations == null)
            {
                return NotFound();
            }

            var location = await _context.locations
                .Include(l => l.Map)
                .Include(C => C.Cameras)
                .FirstOrDefaultAsync(m => m.id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            ViewData["mapId"] = new SelectList(_context.Maps, "id", "Name");
            ViewData["cameraID"] = new SelectList(_context.cameras, "id", "Name");
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,cameraID,mapId")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["mapId"] = new SelectList(_context.Maps, "id", "Name", location.mapId);
            ViewData["cameraID"] = new SelectList(_context.cameras, "id", "Name", location.Cameras);
            return View(location);
        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.locations == null)
            {
                return NotFound();
            }

            var location = await _context.locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["mapId"] = new SelectList(_context.Maps, "id", "Name", location.mapId);
            ViewData["CameraID"] = new SelectList(_context.cameras, "id", "Name", location.Cameras);
            return View(location);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,cameraID,mapId")] Location location)
        {
            if (id != location.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.id))
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
            ViewData["mapId"] = new SelectList(_context.Maps, "id", "Name", location.mapId);
            ViewData["cameraID"] = new SelectList(_context.cameras, "id", "Name", location.Cameras);
            return View(location);

        }

        // GET: Location/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.locations == null)
            {
                return NotFound();
            }

            var location = await _context.locations
                .Include(l => l.Map)
                .Include( C=> C.Cameras)
                .FirstOrDefaultAsync(m => m.id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.locations == null)
            {
                return Problem("Entity set 'AppDbContext.locations'  is null.");
            }
            var location = await _context.locations.FindAsync(id);
            if (location != null)
            {
                _context.locations.Remove(location);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
          return _context.locations.Any(e => e.id == id);
        }
    }
}
