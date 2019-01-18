using NetCoreWebAPIs.Customer.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public NetCoreWebAPIs.Core.Models.Customer GetCustomer(int customerId)
        {
            var customer = customerRepository.Get(customerId);
            return new NetCoreWebAPIs.Core.Models.Customer
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName
            };
        }

        public List<NetCoreWebAPIs.Core.Models.Customer> GetCustomers()
        {
            return customerRepository.Get()
                .Select(c => new NetCoreWebAPIs.Core.Models.Customer
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName
                }).ToList();
        }

        public NetCoreWebAPIs.Core.Models.Customer SaveCustomer(NetCoreWebAPIs.Core.Models.Customer customer)
        {
            //TODO fix this manual mess.
            var entity = new Data.Customer
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                UpdateDate = DateTime.Now
            };
            customerRepository.Save(entity);
            customer.CustomerId = entity.CustomerId;
            return customer;
        }

        public bool DeleteCustomer(int customerId)
        {
            return customerRepository.Delete(customerId);
        }
    }
}