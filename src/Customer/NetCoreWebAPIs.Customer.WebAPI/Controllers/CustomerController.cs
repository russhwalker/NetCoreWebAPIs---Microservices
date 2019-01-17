using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPIs.Customer.Core.Service;

namespace NetCoreWebAPIs.Customer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public ActionResult<NetCoreWebAPIs.Core.Responses.CustomersResponse> Get()
        {
            var customers = customerService.GetCustomers();
            return new NetCoreWebAPIs.Core.Responses.CustomersResponse
            {
                Customers = customers
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Core.Data.Customer> Get(int id)
        {
            return customerService.GetCustomer(id);
        }

        [HttpPost]
        public NetCoreWebAPIs.Core.Models.Customer Post([FromBody] NetCoreWebAPIs.Core.Models.Customer customer)
        {
            return customerService.SaveCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerService.DeleteCustomer(id);
        }
    }
}
