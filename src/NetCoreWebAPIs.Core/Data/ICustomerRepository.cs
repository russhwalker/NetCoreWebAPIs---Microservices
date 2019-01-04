using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core.Data
{
    public interface ICustomerRepository
    {
        Customer Get(int customerId);
        List<Customer> Get();
        Customer Save(Customer customer);
        bool Delete(int customerId);
    }
}