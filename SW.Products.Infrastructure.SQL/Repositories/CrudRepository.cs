using System.Collections.Generic;
using System.Linq;
using SW.Products.Domain.Extensibility.Repositories;
using SW.Products.Infrastructure.PostgreSQLDataAccess.Database;

namespace SW.Products.Infrastructure.PostgreSQLDataAccess.Repositories
{
    internal class CrudRepository<TEntity, TId> : ICrudRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly ProductDbContext context;

        public CrudRepository(ProductDbContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public TId Delete(TId id)
        {
            context.Remove(Get(id));
            context.SaveChanges();
            return id;
        }

        public TEntity Get(TId id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}