using Microsoft.EntityFrameworkCore;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    public class customerDatabaseContext : DbContext
    {
        public customerDatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<customer> customer { get; set; }
        public DbSet<history> history { get; set; }
        public DbSet<the> the { get; set; }
        public DbSet<loaitiemnang> loaitiemnang { get; set; }
    }
}
