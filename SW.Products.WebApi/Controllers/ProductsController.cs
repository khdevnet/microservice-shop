using Microsoft.AspNetCore.Mvc;
using SW.Store.Products.Domain.Entities;
using SW.Store.Products.Domain.Extensibility.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SW.Store.Products.WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : CrudController<Product, int>
    {
        public ProductsController(ICrudRepository<Product, int> crudRepository) : base(crudRepository)
        {
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<ProductModel> GetAll()
        {
            return base.Get().Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Url = $"{Request.Scheme }://{Request.Host}/{Request.PathBase}img/{p.Id}.jpg"
            });
        }
    }
}