using System;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Products.Domain.Extensibility.Repositories;
using Warehouse.Products.Domain.Entities;

namespace Warehouse.Products.WebApi.Controllers
{
    [Route("api/products")]
    public class ProductsController : CrudController<Product, Guid>
    {
        public ProductsController(ICrudRepository<Product, Guid> crudRepository) : base(crudRepository)
        {
        }
    }
}