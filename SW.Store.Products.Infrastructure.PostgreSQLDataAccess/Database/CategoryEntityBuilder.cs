using Microsoft.EntityFrameworkCore;
using Warehouse.Products.Domain.Entities;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Database
{
    public static class CategoryEntityBuilder
    {
        public static void BuildCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("category");

            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Category>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Category>()
                .Property(c => c.ParentId)
                .HasColumnName("parentId")
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasOne(p => p.Parent)
                .WithMany(b => b.SubCategeris)
                .HasForeignKey(p => p.ParentId);

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasColumnName("description")
                .IsRequired();
        }
    }
}