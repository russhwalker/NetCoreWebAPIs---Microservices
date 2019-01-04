using NetCoreWebAPIs.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomer(int customerId)
        {
            return customerRepository.Get(customerId);
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.Get();
        }

        public Customer SaveCustomer(Customer customer)
        {
            return customerRepository.Save(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return customerRepository.Delete(customerId);
        }
    }
}