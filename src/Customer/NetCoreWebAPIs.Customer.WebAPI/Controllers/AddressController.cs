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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NetCoreWebAPIs.Core.Models.Address>> Get()
        {
            return addressService.GetAddresses();
        }

        [HttpGet("{id}")]
        public ActionResult<NetCoreWebAPIs.Core.Models.Address> Get(int id)
        {
            return addressService.GetAddress(id);
        }

        [HttpPost]
        public NetCoreWebAPIs.Core.Models.Address Post([FromBody] NetCoreWebAPIs.Core.Models.Address customer)
        {
            return addressService.SaveAddress(customer);
        }
    }
}
