using Autofac;
using System;
using SW.Store.Products.Domain.Entities;
using SW.Store.Products.Domain.Extensibility.Repositories;
using SW.Store.Products.Infrastructure.PostgreSQLDataAccess.Repositories;

namespace SW.Store.Products.Infrastructure.PostgreSQLDataAccess
{
    public class PostgreSQLDataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CrudRepository<Product, int>>().As<ICrudRepository<Product, int>>();
        }
    }
}