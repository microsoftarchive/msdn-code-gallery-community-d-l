// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using AdventureWorks.UILogic.Models;
using System.Threading.Tasks;

namespace AdventureWorks.UILogic.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartAsync();
        Task AddProductToShoppingCartAsync(string productId);
        Task RemoveProductFromShoppingCartAsync(string productId);
        Task RemoveShoppingCartItemAsync(string itemId);
        Task ClearCartAsync();
    }
}
