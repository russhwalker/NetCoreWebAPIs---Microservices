using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BusinessContext db;

        public CustomerRepository(BusinessContext businessContext)
        {
            this.db = businessContext;
        }

        public Customer Get(int customerId)
        {
            return db.Customers.SingleOrDefault(c => c.CustomerId == customerId);
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Save(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                db.Customers.Attach(customer);
                db.Entry(customer).State = EntityState.Modified;
            }
            db.SaveChanges();
            return customer;
        }

        public bool Delete(int customerId)
        {
            var customer = db.Customers.Single(c => c.CustomerId == customerId);
            db.Customers.Remove(customer);
            return db.SaveChanges() > 0;
        }
    }
}