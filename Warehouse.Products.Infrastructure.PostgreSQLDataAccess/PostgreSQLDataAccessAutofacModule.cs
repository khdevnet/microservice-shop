using Autofac;
using System;
using Warehouse.Products.Domain.Entities;
using Warehouse.Products.Domain.Extensibility.Repositories;
using Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Repositories;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess
{
    public class PostgreSQLDataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CrudRepository<Product, Guid>>().As<ICrudRepository<Product, Guid>>();
            builder.RegisterType<CrudRepository<Category, Guid>>().As<ICrudRepository<Category, Guid>>();
        }
    }
}