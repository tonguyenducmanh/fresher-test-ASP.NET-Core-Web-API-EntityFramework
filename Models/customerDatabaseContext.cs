using Microsoft.EntityFrameworkCore;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    public class customerDatabaseContext : DbContext
    {
        public customerDatabaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<filter>()
                .HasOne(b => b.filterContent)
                .WithOne(i => i.filter)
                .HasForeignKey<filterContent>(b => b.filterId);
        }


        public DbSet<customer> customer { get; set; }
        public DbSet<history> history { get; set; }
        public DbSet<the> the { get; set; }
        public DbSet<loaitiemnang> loaitiemnang { get; set; }
        public DbSet<filter> filter { get; set; }
        public DbSet<filterContent> filterContent { get; set; }
    }
}
