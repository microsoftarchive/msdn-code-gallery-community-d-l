// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.Repositories;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockOrderRepository : IOrderRepository
    {
        public Func<string, ShoppingCart, Address, Address, PaymentMethod, Task<Order>> CreateBasicOrderAsyncDelegate { get; set; }
        public Func<string, ShoppingCart, Address, Address, PaymentMethod, ShippingMethod, Task<Order>> CreateOrderAsyncDelegate { get; set; }

        public Task CreateBasicOrderAsync(string userId, ShoppingCart shoppingCart, Address shippingAddress, Address billingAddress, PaymentMethod paymentMethod)
        {
            return CreateBasicOrderAsyncDelegate(userId, shoppingCart, shippingAddress, billingAddress, paymentMethod);
        }

        public Task<Order> CreateOrderAsync(string userId, ShoppingCart shoppingCart, Address shippingAddress, Address billingAddress, PaymentMethod paymentMethod, ShippingMethod shippingMethod)
        {
            return CreateOrderAsyncDelegate(userId, shoppingCart, shippingAddress, billingAddress, paymentMethod, shippingMethod);
        }

        public Order CurrentOrder { get; set; }
    }
}
