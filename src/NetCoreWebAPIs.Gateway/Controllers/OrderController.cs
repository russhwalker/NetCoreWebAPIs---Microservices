using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly Core.APICaller caller;

        public OrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
            caller = new Core.APICaller();
        }

        [HttpGet("{customerId}")]
        public IEnumerable<Core.Models.Order> Get(int customerId)
        {
            return caller.GetAsync<IEnumerable<Core.Models.Order>>($"{configuration["ApiUrls:Order"]}/{customerId}").Result;
        }

        [HttpPost]
        public Core.Models.Order Post([FromBody] Core.Models.Order order)
        {
            return caller.PostAsync<Core.Models.Order>(configuration["ApiUrls:Order"], order).Result;
        }
    }
}