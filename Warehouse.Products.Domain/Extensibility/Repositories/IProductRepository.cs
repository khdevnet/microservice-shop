using System.Collections.Generic;
using Warehouse.Products.Domain.Models;

namespace Warehouse.Products.Domain.Extensibility.Repositories
{
    public interface IProductRepository
    {
        Product Get(int id);

        IEnumerable<Product> Get();

        Product Add(Product product);

        int Delete(int id);
    }
}