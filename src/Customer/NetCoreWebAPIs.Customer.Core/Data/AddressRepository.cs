using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BusinessContext db;

        public AddressRepository(BusinessContext businessContext)
        {
            this.db = businessContext;
        }

        public Address Get(int addressId)
        {
            return db.Addresses.SingleOrDefault(c => c.AddressId == addressId);
        }

        public List<Address> Get()
        {
            return db.Addresses.ToList();
        }

        public Address Save(Address address)
        {
            if (address.AddressId == 0)
            {
                db.Addresses.Add(address);
            }
            else
            {
                db.Addresses.Attach(address);
                db.Entry(address).State = EntityState.Modified;
            }
            db.SaveChanges();
            return address;
        }

        public bool Delete(int addressId)
        {
            var address = db.Addresses.Single(c => c.AddressId == addressId);
            db.Addresses.Remove(address);
            return db.SaveChanges() > 0;
        }
    }
}