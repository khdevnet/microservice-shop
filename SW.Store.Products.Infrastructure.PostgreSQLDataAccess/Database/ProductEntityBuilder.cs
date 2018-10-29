using Microsoft.EntityFrameworkCore;
using SW.Store.Products.Domain.Entities;

namespace SW.Store.Products.Infrastructure.PostgreSQLDataAccess.Database
{
    public static class ProductEntityBuilder
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
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("price")
                .IsRequired();
        }
    }
}