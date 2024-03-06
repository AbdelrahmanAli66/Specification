using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Itemss { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed stores and items
            modelBuilder.Entity<Store>().HasData(SeedData.GetStores());
            modelBuilder.Entity<Item>().HasData(SeedData.GetItems());
        }
    }
}
