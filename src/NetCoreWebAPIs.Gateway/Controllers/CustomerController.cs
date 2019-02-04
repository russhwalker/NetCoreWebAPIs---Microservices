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
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly Core.APICaller caller;

        public CustomerController(IConfiguration configuration)
        {
            this.configuration = configuration;
            caller = new Core.APICaller();
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Core.Models.Customer> Get()
        {
            return caller.GetAsync<IEnumerable<Core.Models.Customer>>(configuration["ApiUrls:Customer"]).Result;
        }

        [HttpGet]
        [Route("GetDetails/{id}")]
        public Core.Models.Customer GetDetails(int id)
        {
            var customerTask = caller.GetAsync<Core.Models.Customer>($"{configuration["ApiUrls:Customer"]}/{id}");
            var ordersTask = caller.GetAsync<IEnumerable<Core.Models.Order>>($"{configuration["ApiUrls:Order"]}/{id}");
            Task.WaitAll(new Task[] { customerTask, ordersTask });
            var customer = customerTask.Result;
            customer.Orders = ordersTask.Result.ToList();
            return customerTask.Result;
        }

        [HttpPost]
        public Core.Models.Customer Post([FromBody] Core.Models.Customer customer)
        {
            return caller.PostAsync<Core.Models.Customer>(configuration["ApiUrls:Customer"], customer).Result;
        }
    }
}