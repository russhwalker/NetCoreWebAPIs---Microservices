using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BusinessContext businessContext;

        public CustomerRepository(BusinessContext businessContext)
        {
            this.businessContext = businessContext;
        }

        public List<Customer> GetCustomers()
        {
            return businessContext.Customers.ToList();
        }
    }
}