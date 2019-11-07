// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;

namespace AdventureWorks.UILogic.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetShoppingCartAsync(string shoppingCartId);
        Task AddProductToShoppingCartAsync(string shoppingCartId, string productIdToIncrement);
        Task RemoveProductFromShoppingCartAsync(string shoppingCartId, string productIdToDecrement);
        Task RemoveShoppingCartItemAsync(string shoppingCartId, string itemIdToRemove);
        Task DeleteShoppingCartAsync(string shoppingCartId);
        Task<bool> MergeShoppingCartsAsync(string anonymousShoppingCartId, string authenticatedShoppingCartId);
    }
}
