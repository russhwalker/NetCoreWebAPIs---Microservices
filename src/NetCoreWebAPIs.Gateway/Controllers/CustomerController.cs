using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreWebAPIs.Core.Responses;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly Core.APICaller caller;

        public CustomerController(IConfiguration configuration)
        {
            this.configuration = configuration;
            caller = new Core.APICaller();
        }

        [HttpGet]
        public ActionResult<CustomersResponse> Get()
        {
            return caller.GetAsync<CustomersResponse>(configuration["ApiUrls:Customer"]).Result;
        }

        [HttpPost]
        public Core.Models.Customer Post([FromBody] Core.Models.Customer customer)
        {
            var asdf = caller.PostAsync<Core.Models.Customer>(configuration["ApiUrls:Customer"], customer).Result;
            return caller.PostAsync<Core.Models.Customer>(configuration["ApiUrls:Customer"], customer).Result;
        }
    }
}