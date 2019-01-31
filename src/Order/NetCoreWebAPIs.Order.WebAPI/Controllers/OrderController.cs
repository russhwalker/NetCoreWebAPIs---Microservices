using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using NetCoreWebAPIs.Order.WebAPI.Data;

namespace NetCoreWebAPIs.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{customerId}")]
        public ActionResult<IEnumerable<Core.Models.Order>> Get(int customerId)
        {
            return orderRepository.GetOrders(customerId);
        }

        [HttpPost]
        public ActionResult<Core.Models.Order> Post([FromBody]Core.Models.Order order)
        {
            if (order.OrderId == 0)
            {
                orderRepository.InsertOrder(order);
            }
            else
            {
                orderRepository.UpdateOrder(order);
            }
            return order;
        }
    }
}