using Microsoft.EntityFrameworkCore;
using Warehouse.Products.Domain.Models;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("product");

            modelBuilder.Entity<Product>()
                .Property(product => product.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Product>()
                .Property(attachment => attachment.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .HasColumnName("price")
                .IsRequired();
        }

        public DbSet<Product> Products { get; set; }
    }
}