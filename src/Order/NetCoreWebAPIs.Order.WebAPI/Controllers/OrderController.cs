using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
namespace NetCoreWebAPIs.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("{customerId}")]
        public ActionResult<IEnumerable<Core.Models.Order>> Get(int customerId)
        {
            return Data.DataStore.Orders
                .Where(o => o.CustomerId == customerId)
                .ToList();
        }

        [HttpPost]
        public ActionResult<Core.Models.Order> Post([FromBody]Core.Models.Order order)
        {
            Data.DataStore.Orders.Add(order);
            return order;
        }
    }
}