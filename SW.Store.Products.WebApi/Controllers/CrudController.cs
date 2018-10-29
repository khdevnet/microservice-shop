using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SW.Store.Products.Domain.Extensibility.Repositories;

namespace SW.Store.Products.WebApi.Controllers
{
    public class CrudController<TEntity, TId> : Controller where TEntity : class
    {
        private readonly ICrudRepository<TEntity, TId> crudRepository;

        public CrudController(ICrudRepository<TEntity, TId> crudRepository)
        {
            this.crudRepository = crudRepository;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return crudRepository.Get().ToList();
        }

        [HttpGet("{id}")]
        public TEntity Get(TId id)
        {
            return crudRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]TEntity entity)
        {
            crudRepository.Add(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(TId id)
        {
            crudRepository.Delete(id);
        }
    }
}