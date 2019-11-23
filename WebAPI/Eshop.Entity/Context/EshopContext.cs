using Eshop.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Entity.Context
{
    public class EshopContext : DbContext
    {
        public DbSet<AnimalCategory> AnimalCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public EshopContext(DbContextOptions<EshopContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalCategory>()
                .HasMany(x => x.Products)
                .WithOne();

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Orders);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.AnimalCategory)
                .WithMany(x => x.Products);
        }
    }
}
