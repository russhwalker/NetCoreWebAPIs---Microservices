using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core.Service
{
    public interface ICustomerService
    {
        Data.Customer GetCustomer(int customerId);
        List<Data.Customer> GetCustomers();
        Data.Customer SaveCustomer(Data.Customer customer);
        bool DeleteCustomer(int customerId);
    }
}