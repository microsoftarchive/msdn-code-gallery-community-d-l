// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


namespace AdventureWorks.UILogic.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public Address ShippingAddress { get; set; }

        public Address BillingAddress { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public ShippingMethod ShippingMethod { get; set; }
    }
}
