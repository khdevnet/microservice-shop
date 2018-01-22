using System.Collections.Generic;
using Warehouse.Products.Domain.Entities;

namespace Warehouse.Products.Domain.Extensibility.Repositories
{
    public interface ICategoryRepository
    {
        Category Get(int id);

        IEnumerable<Category> Get();

        Category Add(Category product);

        int Delete(int id);
    }
}