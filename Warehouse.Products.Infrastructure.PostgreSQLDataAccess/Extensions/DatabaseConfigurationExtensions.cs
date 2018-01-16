using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ShopDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Transient);
        }

        public static void ApplyDbMigrations(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ShopDbContext context = serviceScope.ServiceProvider.GetRequiredService<ShopDbContext>();
                context.Database.Migrate();
            }
        }
    }
}