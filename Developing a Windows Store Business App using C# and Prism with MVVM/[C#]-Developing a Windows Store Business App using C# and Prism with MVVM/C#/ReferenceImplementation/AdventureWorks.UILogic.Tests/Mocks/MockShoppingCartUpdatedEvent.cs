// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using AdventureWorks.UILogic.Models;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockShoppingCartUpdatedEvent : ShoppingCartUpdatedEvent
    {
        public MockShoppingCartUpdatedEvent()
        {
            PublishDelegate = () => { };
        }

        public Action PublishDelegate { get; set; }

        public override void Publish(object argument)
        {
            PublishDelegate();
        }
    }
}
