// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.Services;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace AdventureWorks.UILogic.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;
        private readonly IShippingMethodService _shippingMethodService;
        private readonly ISessionStateService _sessionStateService;
        private Order _currentOrder;
        private const string OrderKey = "CurrentOrderKey";

        public OrderRepository(IOrderService orderService, IAccountService accountService, IShippingMethodService shippingMethodService, ISessionStateService sessionStateService)
        {
            _orderService = orderService;
            _accountService = accountService;
            _shippingMethodService = shippingMethodService;
            _sessionStateService = sessionStateService;
        }

        public async Task CreateBasicOrderAsync(string userId, ShoppingCart shoppingCart, Address shippingAddress, Address billingAddress, PaymentMethod paymentMethod)
        {
            var basicShippingMethod = await _shippingMethodService.GetBasicShippingMethodAsync();
            _currentOrder = await CreateOrderAsync(userId, shoppingCart, shippingAddress, billingAddress, paymentMethod, basicShippingMethod);
            _sessionStateService.SessionState[OrderKey] = _currentOrder;
        }

        public async Task<Order> CreateOrderAsync(string userId, ShoppingCart shoppingCart, Address shippingAddress,
                                                  Address billingAddress, PaymentMethod paymentMethod, ShippingMethod shippingMethod)
        {
            Order order = new Order
                {
                    UserId = userId,
                    ShoppingCart = shoppingCart,
                    ShippingAddress = shippingAddress,
                    BillingAddress = billingAddress,
                    PaymentMethod = paymentMethod,
                    ShippingMethod = shippingMethod
                };

            order.Id = await _orderService.CreateOrderAsync(order);

            return order;
        }

        public Order CurrentOrder
        {
            get
            {
                if (_currentOrder != null)
                {
                    return _currentOrder;
                }

                var order = _sessionStateService.SessionState[OrderKey] as Order;
                return order;
            }
        }
    }
}
