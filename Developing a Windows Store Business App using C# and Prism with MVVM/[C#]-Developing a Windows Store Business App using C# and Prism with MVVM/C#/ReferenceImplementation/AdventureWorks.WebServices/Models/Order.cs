// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.ComponentModel.DataAnnotations;
using AdventureWorks.WebServices.Strings;

namespace AdventureWorks.WebServices.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorRequired")]
        public string UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorRequired")]
        public ShoppingCart ShoppingCart { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorRequired")]
        public Address ShippingAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorRequired")]
        public Address BillingAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorRequired")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorRequired")]
        public ShippingMethod ShippingMethod { get; set; }
    }
}
