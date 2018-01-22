using System.Collections.Generic;
using System.Linq;
using Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Database;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Repositories
{
    internal class CrudRepository<TEntity> where TEntity : class
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

        public int Delete(int id)
        {
            context.Remove(Get(id));
            return context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}