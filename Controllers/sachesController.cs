using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fresher_test_ASP.NET_Core_Web_API.Models;

namespace fresher_test_ASP.NET_Core_Web_API.Controllers
{
    public class sachesController : Controller
    {
        private readonly SachContext _context;

        public sachesController(SachContext context)
        {
            _context = context;
        }

        // GET: saches
        public async Task<IActionResult> Index()
        {
              return _context.sach != null ? 
                          View(await _context.sach.ToListAsync()) :
                          Problem("Entity set 'SachContext.sach'  is null.");
        }

        // GET: saches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sach == null)
            {
                return NotFound();
            }

            var sach = await _context.sach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: saches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenSach,TacGia")] sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sach);
        }

        // GET: saches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sach == null)
            {
                return NotFound();
            }

            var sach = await _context.sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }

        // POST: saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenSach,TacGia")] sach sach)
        {
            if (id != sach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sachExists(sach.Id))
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
            return View(sach);
        }

        // GET: saches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sach == null)
            {
                return NotFound();
            }

            var sach = await _context.sach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sach == null)
            {
                return Problem("Entity set 'SachContext.sach'  is null.");
            }
            var sach = await _context.sach.FindAsync(id);
            if (sach != null)
            {
                _context.sach.Remove(sach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sachExists(int id)
        {
          return (_context.sach?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
