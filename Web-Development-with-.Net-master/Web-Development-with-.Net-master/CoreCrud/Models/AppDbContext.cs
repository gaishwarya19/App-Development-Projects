using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
         public DbSet<Athlete> Athlete { get; set; }
         public DbSet<Country> Country { get; set; }
    }
}