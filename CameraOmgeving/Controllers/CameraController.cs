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
    public class CameraController : Controller
    {
        private readonly AppDbContext _context;

        public CameraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Camera
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.cameras.Include(c => c.Location);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Camera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cameras == null)
            {
                return NotFound();
            }

            var camera = await _context.cameras
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.id == id);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        // GET: Camera/Create
        public IActionResult Create()
        {
            ViewData["locationID"] = new SelectList(_context.locations, "id", "name");
            return View();
        }

        // POST: Camera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type,name,Description,locationID,Contents,Image")] Camera camera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationID"] = new SelectList(_context.locations, "id", "name", camera.locationID);
            return View(camera);
        }

        // GET: Camera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cameras == null)
            {
                return NotFound();
            }

            var camera = await _context.cameras.FindAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            ViewData["locationID"] = new SelectList(_context.locations, "id", "name", camera.locationID);
            return View(camera);
        }

        // POST: Camera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type,name,Description,locationID,Contents,Image")] Camera camera)
        {
            if (id != camera.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraExists(camera.id))
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
            ViewData["locationID"] = new SelectList(_context.locations, "id", "name", camera.locationID);
            return View(camera);
        }

        // GET: Camera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cameras == null)
            {
                return NotFound();
            }

            var camera = await _context.cameras
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.id == id);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        // POST: Camera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cameras == null)
            {
                return Problem("Entity set 'AppDbContext.cameras'  is null.");
            }
            var camera = await _context.cameras.FindAsync(id);
            if (camera != null)
            {
                _context.cameras.Remove(camera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CameraExists(int id)
        {
          return _context.cameras.Any(e => e.id == id);
        }


    }
}
