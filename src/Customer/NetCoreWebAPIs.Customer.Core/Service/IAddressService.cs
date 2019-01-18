using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Service
{
    public interface IAddressService
    {
        NetCoreWebAPIs.Core.Models.Address GetAddress(int addressId);
        List<NetCoreWebAPIs.Core.Models.Address> GetAddresses();
        NetCoreWebAPIs.Core.Models.Address SaveAddress(NetCoreWebAPIs.Core.Models.Address address);
        bool DeleteAddress(int addressId);
    }
}