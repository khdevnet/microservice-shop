using Microsoft.EntityFrameworkCore;
using Warehouse.Products.Domain.Entities;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Database
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.BuildProduct();
        }
    }
}