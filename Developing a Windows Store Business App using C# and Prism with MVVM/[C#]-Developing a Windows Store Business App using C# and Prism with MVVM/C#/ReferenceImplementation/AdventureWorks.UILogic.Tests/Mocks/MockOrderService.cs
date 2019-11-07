// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.Services;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockOrderService : IOrderService
    {
        public Func<Order, Task<int>> CreateOrderAsyncDelegate { get; set; }
        public Func<Order, Task> ProcessOrderAsyncDelegate { get; set; }

        public Task<int> CreateOrderAsync(Order order)
        {
            return CreateOrderAsyncDelegate(order);
        }

        public Task ProcessOrderAsync(Order order)
        {
            return ProcessOrderAsyncDelegate(order);
        }
    }
}
