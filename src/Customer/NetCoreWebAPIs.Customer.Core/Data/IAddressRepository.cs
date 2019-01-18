using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Data
{
    public interface IAddressRepository
    {
        Address Get(int addressId);
        List<Address> Get();
        Address Save(Address address);
        bool Delete(int addressId);
    }
}