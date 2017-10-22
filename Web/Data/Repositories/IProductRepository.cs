using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public interface IProductRepository
    {
        Product Get(int id);

        IEnumerable<Product> Get();

        Product Add(Product product);

        Product Edit(Product product);

        int Delete(int id);
    }
}