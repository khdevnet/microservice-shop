using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Warehouse.Products.WebApi.Application;

namespace Warehouse.Products.WebApi.Controllers
{
    [Route("api/settings")]
    public class SettingsController : Controller
    {
        private readonly IOptions<DatabaseConnectionSettings> connection;

        public SettingsController(IOptions<DatabaseConnectionSettings> connection)
        {
            this.connection = connection;
        }

        // GET api/values1
        [HttpGet]
        public string Get()
        {
            return this.connection.Value.ShopDbContext;
        }

    }
}
