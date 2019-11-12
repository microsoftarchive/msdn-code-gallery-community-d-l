// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;

namespace AdventureWorks.UILogic.Repositories
{
    public interface ICheckoutDataRepository
    {
        Task<Address> GetShippingAddressAsync(string id);
        Task<Address> GetBillingAddressAsync(string id);
        Task<PaymentMethod> GetPaymentMethodAsync(string id);

        Task<Address> GetDefaultShippingAddressAsync();
        Task<Address> GetDefaultBillingAddressAsync();
        Task<PaymentMethod> GetDefaultPaymentMethodAsync();

        Task<IReadOnlyCollection<Address>> GetAllShippingAddressesAsync();
        Task<IReadOnlyCollection<Address>> GetAllBillingAddressesAsync();
        Task<IReadOnlyCollection<PaymentMethod>> GetAllPaymentMethodsAsync();

        Task SaveShippingAddressAsync(Address address);
        Task SaveBillingAddressAsync(Address address);
        Task SavePaymentMethodAsync(PaymentMethod paymentMethod);

        Task SetDefaultShippingAddressAsync(string addressId);
        Task SetDefaultBillingAddressAsync(string addressId);
        Task SetDefaultPaymentMethodAsync(string paymentMethodId);

        Task RemoveDefaultShippingAddressAsync();
        Task RemoveDefaultBillingAddressAsync();
        Task RemoveDefaultPaymentMethodAsync();
    }
}