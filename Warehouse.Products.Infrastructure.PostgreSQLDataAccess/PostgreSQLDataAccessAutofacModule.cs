using Autofac;
using Warehouse.Products.Domain.Extensibility.Repositories;
using Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Repositories;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess
{
    public class PostgreSQLDataAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
        }
    }
}