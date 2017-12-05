using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop.Application;

namespace Shop.Controllers
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
