using NetCoreWebAPIs.Core.Models;
using NetCoreWebAPIs.Customer.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Customer.Core.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public NetCoreWebAPIs.Core.Models.Address GetAddress(int addressId)
        {
            var address = addressRepository.Get(addressId);
            return new NetCoreWebAPIs.Core.Models.Address
            {
                AddressId = address.AddressId,
                CustomerId = address.CustomerId,
                Street = address.Street,
                City = address.City,
                State = address.State,
                Zip = address.Zip
            };
        }

        public List<NetCoreWebAPIs.Core.Models.Address> GetAddresses()
        {
            return addressRepository.Get()
                .Select(a => new NetCoreWebAPIs.Core.Models.Address
                {
                    AddressId = a.AddressId,
                    CustomerId = a.CustomerId,
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    Zip = a.Zip
                }).ToList();
        }

        public NetCoreWebAPIs.Core.Models.Address SaveAddress(NetCoreWebAPIs.Core.Models.Address address)
        {
            //TODO fix this manual mess.
            var entity = new Data.Address
            {
                AddressId = address.AddressId,
                CustomerId = address.CustomerId,
                Street = address.Street,
                City = address.City,
                State = address.State,
                Zip = address.Zip
            };
            addressRepository.Save(entity);
            address.AddressId = entity.AddressId;
            return address;
        }

        public bool DeleteAddress(int addressId)
        {
            return addressRepository.Delete(addressId);
        }
    }
}