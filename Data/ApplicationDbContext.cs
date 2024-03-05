using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Itemss { get; set; }
    }
}
