using Core.Entities;
using Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts {
    public class StoreDbContext : DbContext {
        public DbSet<Collection> Collections { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProducts> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public StoreDbContext() {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectionMap).Assembly);
        }
    }
}
