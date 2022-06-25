using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fresher_test_ASP.NET_Core_Web_API.Models;

namespace fresher_test_ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sachsController : ControllerBase
    {
        private readonly SachContext _context;

        public sachsController(SachContext context)
        {
            _context = context;
        }

        // GET: api/sachs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sach>>> Getsach()
        {
          if (_context.sach == null)
          {
              return NotFound();
          }
            return await _context.sach.ToListAsync();
        }

        // GET: api/sachs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sach>> Getsach(int id)
        {
          if (_context.sach == null)
          {
              return NotFound();
          }
            var sach = await _context.sach.FindAsync(id);

            if (sach == null)
            {
                return NotFound();
            }

            return sach;
        }

        // PUT: api/sachs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsach(int id, sach sach)
        {
            if (id != sach.Id)
            {
                return BadRequest();
            }

            _context.Entry(sach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sachExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/sachs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<sach>> Postsach(sach sach)
        {
          if (_context.sach == null)
          {
              return Problem("Entity set 'SachContext.sach'  is null.");
          }
            _context.sach.Add(sach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsach", new { id = sach.Id }, sach);
        }

        // DELETE: api/sachs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesach(int id)
        {
            if (_context.sach == null)
            {
                return NotFound();
            }
            var sach = await _context.sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }

            _context.sach.Remove(sach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool sachExists(int id)
        {
            return (_context.sach?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
