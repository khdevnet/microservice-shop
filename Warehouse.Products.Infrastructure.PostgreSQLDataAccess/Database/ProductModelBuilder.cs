using Microsoft.EntityFrameworkCore;
using Warehouse.Products.Domain.Entities;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Database
{
    public static class ProductModelBuilder
    {
        public static void BuildProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product");

            modelBuilder.Entity<Product>()
                .Property(product => product.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(b => b.Sku)
                .HasColumnName("sku")
                .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Sku)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("price")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Count)
                .HasColumnName("count")
                .IsRequired();
        }
    }
}