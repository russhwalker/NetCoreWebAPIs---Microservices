using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Order.WebAPI.Data
{
    public interface IOrderRepository
    {
        List<Core.Models.Order> GetOrders(int customerId);
        void InsertOrder(Core.Models.Order order);
    }
}