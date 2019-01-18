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
        public IEnumerable<Core.Models.Customer> Get()
        {
            return caller.GetAsync<IEnumerable<Core.Models.Customer>>(configuration["ApiUrls:Customer"]).Result;
        }

        [HttpGet]
        [Route("GetDetails/{id}")]
        public Core.Models.Customer GetDetails(int id)
        {
            var customer = caller.GetAsync<Core.Models.Customer>($"{configuration["ApiUrls:Customer"]}/{id}").Result;
            var orders = caller.GetAsync<IEnumerable<Core.Models.Order>>($"{configuration["ApiUrls:Orders"]}/{id}").Result;
            return customer;
        }

        [HttpPost]
        public Core.Models.Customer Post([FromBody] Core.Models.Customer customer)
        {
            return caller.PostAsync<Core.Models.Customer>(configuration["ApiUrls:Customer"], customer).Result;
        }
    }
}