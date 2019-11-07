// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;

namespace AdventureWorks.WebServices.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(ICollection<ShoppingCartItem> shoppingCartItems)
        {
            ShoppingCartItems = shoppingCartItems;
        }

        public string ShoppingCartId { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems {get; private set;}

        public double FullPrice { get; set; }

        public double TotalDiscount { get; set; }

        public double TotalPrice { get; set; }

        public string Currency { get; set; }

        public double TaxRate { get; set; }
    }
}
