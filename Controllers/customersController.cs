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
        [HttpGet()]
        [Route("/")]

        public async Task<ActionResult> Getcustomer()
        {
          if (_context.history == null)
          {
              return NotFound();
          }
            //var queryText = from m in _context.history
            //                select m;
            var queryText = from m in _context.customer
                            select m;
            return Ok(await queryText.ToListAsync());
        }

        
    }
}
