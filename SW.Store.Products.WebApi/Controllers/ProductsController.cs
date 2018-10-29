using System;
using Microsoft.AspNetCore.Mvc;
using SW.Store.Products.Domain.Extensibility.Repositories;
using SW.Store.Products.Domain.Entities;

namespace SW.Store.Products.WebApi.Controllers
{
    [Route("api/products")]
    public class ProductsController : CrudController<Product, int>
    {
        public ProductsController(ICrudRepository<Product, int> crudRepository) : base(crudRepository)
        {
        }
    }
}