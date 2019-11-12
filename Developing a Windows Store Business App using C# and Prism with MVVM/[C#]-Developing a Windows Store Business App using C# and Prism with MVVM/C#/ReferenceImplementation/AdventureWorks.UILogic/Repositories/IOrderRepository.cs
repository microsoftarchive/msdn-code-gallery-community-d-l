// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;

namespace AdventureWorks.UILogic.Repositories
{
    public interface IOrderRepository
    {
        Task CreateBasicOrderAsync(string userId, ShoppingCart shoppingCart, Address shippingAddress,
                                          Address billingAddress, PaymentMethod paymentMethod);

        Task<Order> CreateOrderAsync(string userId, ShoppingCart shoppingCart, Address shippingAddress,
                                     Address billingAddress, PaymentMethod paymentMethod, ShippingMethod shippingMethod);

        Order CurrentOrder { get; }
    }
}
