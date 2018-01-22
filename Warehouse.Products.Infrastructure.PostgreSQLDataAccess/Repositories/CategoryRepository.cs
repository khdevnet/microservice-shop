using Warehouse.Products.Domain.Entities;
using Warehouse.Products.Domain.Extensibility.Repositories;
using Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Database;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Repositories
{
    internal class CategoryRepository : CrudRepository<Category>, ICategoryRepository
    {
        internal CategoryRepository(ProductDbContext context) : base(context)
        {
        }
    }
}