using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Service
{
    public interface ICustomerService
    {
        NetCoreWebAPIs.Core.Models.Customer GetCustomer(int customerId);
        List<NetCoreWebAPIs.Core.Models.Customer> GetCustomers();
        NetCoreWebAPIs.Core.Models.Customer SaveCustomer(NetCoreWebAPIs.Core.Models.Customer customer);
        bool DeleteCustomer(int customerId);
    }
}