using Microsoft.EntityFrameworkCore;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    public class SachContext: DbContext
    {
        public SachContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<sach> sach { get; set; }
    }
}
