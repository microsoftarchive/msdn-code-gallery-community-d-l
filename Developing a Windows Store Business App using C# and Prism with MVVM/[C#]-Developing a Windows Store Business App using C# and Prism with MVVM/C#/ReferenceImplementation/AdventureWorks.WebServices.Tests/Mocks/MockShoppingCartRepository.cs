// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using AdventureWorks.WebServices.Models;
using AdventureWorks.WebServices.Repositories;

namespace AdventureWorks.WebServices.Tests.Mocks
{
    public class MockShoppingCartRepository : IShoppingCartRepository
    {
        public Func<string, ShoppingCart> GetByIdDelegate { get; set; }
        public Func<string, bool> DeleteDelegate { get; set; }
        public Action<string, Product> AddProductToCartDelegate { get; set; }
        public Func<string, string, bool> RemoveProductFromCartDelegate { get; set; }
        public Func<ShoppingCart, string, bool> RemoveItemFromCartDelegate { get; set; }
        

        ShoppingCart IShoppingCartRepository.GetById(string shoppingCartId)
        {
            return GetByIdDelegate(shoppingCartId);
        }

        bool IShoppingCartRepository.Delete(string userId)
        {
            return DeleteDelegate(userId);
        }

        void IShoppingCartRepository.AddProductToCart(string shoppingCartId, Product product)
        {
            AddProductToCartDelegate(shoppingCartId, product);
        }

        bool IShoppingCartRepository.RemoveProductFromCart(string shoppingCartId, string productId)
        {
            return RemoveProductFromCartDelegate(shoppingCartId, productId);
        }

        bool IShoppingCartRepository.RemoveItemFromCart(ShoppingCart shoppingCart, string itemId)
        {
            return RemoveItemFromCartDelegate(shoppingCart, itemId);
        }
    }
}
