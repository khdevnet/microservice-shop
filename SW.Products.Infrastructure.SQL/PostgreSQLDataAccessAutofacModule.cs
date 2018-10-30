using Autofac;
using System;
using SW.Products.Domain.Entities;
using SW.Products.Domain.Extensibility.Repositories;
using SW.Products.Infrastructure.PostgreSQLDataAccess.Repositories;

namespace SW.Products.Infrastructure.PostgreSQLDataAccess
{
    public class PostgreSQLDataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CrudRepository<Product, int>>().As<ICrudRepository<Product, int>>();
        }
    }
}