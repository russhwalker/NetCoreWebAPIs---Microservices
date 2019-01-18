using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebAPIs.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("{customerId}")]
        public ActionResult<IEnumerable<Core.Models.Order>> Get(int customerId)
        {
            return new List<Core.Models.Order>
            {
                new Core.Models.Order
                {
                    OrderId = 1,
                    CustomerId = customerId,
                    TotalPrice = 25.55M
                }
            };
        }
    }
}