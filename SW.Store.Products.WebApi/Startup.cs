using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Warehouse.Products.Infrastructure.PostgreSQLDataAccess;
using Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Database;
using Warehouse.Products.WebApi.Configurations;

namespace Warehouse.Products.WebApi
{
    public class Startup
    {
        private const string CorsPolicyName = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString(nameof(ProductDbContext));
            services.AddDbContext(connectionString);

            services.AddCors(options =>
            {
                options.AddPolicy(
                    CorsPolicyName,
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddOptions();

            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<PostgreSQLDataAccessAutofacModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.ApplyDbMigrations();
            app.UseCors(CorsPolicyName);
            app.UseMvc();
        }
    }
}