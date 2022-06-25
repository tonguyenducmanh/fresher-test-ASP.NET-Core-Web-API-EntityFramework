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
    [Route("/")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly customerDatabaseContext _context;

        public customersController(customerDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        [Route("/")]
        public async Task<ActionResult<IEnumerable<customer>>> Getcustomer()
        {
          if (_context.customer == null)
          {
              return NotFound();
          }
            return await _context.customer.ToListAsync();
        }

        
    }
}
