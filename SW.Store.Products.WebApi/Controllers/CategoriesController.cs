using Microsoft.AspNetCore.Mvc;
using Warehouse.Products.Domain.Extensibility.Repositories;
using Warehouse.Products.Domain.Entities;
using System;

namespace Warehouse.Products.WebApi.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : CrudController<Product, Guid>
    {
        public CategoriesController(ICrudRepository<Product, Guid> crudRepository) : base(crudRepository)
        {
        }
    }
}