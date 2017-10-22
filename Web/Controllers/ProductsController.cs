using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repositories;
using System.Linq;
using Shop.Data.Models;

namespace Shop.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.Get().ToList();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.Get(id);
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            productRepository.Add(product);
        }

        // PUT api/products
        [HttpPut]
        public void Put([FromBody]Product product)
        {
            productRepository.Edit(product);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}