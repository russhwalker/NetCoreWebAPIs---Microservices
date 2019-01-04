using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return customerService.GetCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return customerService.GetCustomer(id);
        }

        [HttpPost]
        public Customer Post([FromBody] Customer customer)
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
