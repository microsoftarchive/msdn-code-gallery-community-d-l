// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.Services;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockAddressService : IAddressService
    {
        public MockAddressService()
        {
            Addresses = new List<Address>();
        }

        public List<Address> Addresses { get; set; }
        
        public void SaveEntity(Address address)
        {
            Addresses.Add(address);
        }

        public Task<IReadOnlyCollection<Address>> GetAddressesAsync()
        {
            return Task.FromResult<IReadOnlyCollection<Address>>(Addresses);
        }

        public Task SaveAddressAsync(Address address)
        {
            var matchingAddress = Addresses.FirstOrDefault(a => a.Id == address.Id && a.AddressType == address.AddressType);
            if (matchingAddress != null)
            {
                Addresses.Remove(matchingAddress);
            }
            Addresses.Add(address);
            return Task.Delay(0);
        }

        public Task SetDefault(string defaultAddressId, AddressType addressType)
        {
            var matchingAddress = Addresses.FirstOrDefault(a => a.Id == defaultAddressId && a.AddressType == addressType);
            matchingAddress.IsDefault = true;
            return Task.Delay(0);
        }
    }
}
