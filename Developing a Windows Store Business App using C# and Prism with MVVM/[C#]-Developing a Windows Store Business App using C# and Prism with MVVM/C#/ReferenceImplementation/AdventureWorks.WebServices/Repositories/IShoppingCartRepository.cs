// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using AdventureWorks.WebServices.Models;

namespace AdventureWorks.WebServices.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetById(string shoppingCartId);
        bool Delete(string userId);
        void AddProductToCart(string shoppingCartId, Product product);
        bool RemoveProductFromCart(string shoppingCartId, string productId);
        bool RemoveItemFromCart(ShoppingCart shoppingCart, string itemId);
    }
}