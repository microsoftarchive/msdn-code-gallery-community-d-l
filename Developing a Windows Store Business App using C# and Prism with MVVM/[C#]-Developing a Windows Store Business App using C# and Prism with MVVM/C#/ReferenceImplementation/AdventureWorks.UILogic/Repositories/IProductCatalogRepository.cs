// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;

namespace AdventureWorks.UILogic.Repositories
{
    public interface IProductCatalogRepository
    {
        Task<ReadOnlyCollection<Category>> GetRootCategoriesAsync(int maxAmountOfProducts);

        Task<ReadOnlyCollection<Category>> GetSubcategoriesAsync(int parentId, int maxAmountOfProducts);

        Task<SearchResult> GetFilteredProductsAsync(string productsQueryString, int maxResults);

        Task<ReadOnlyCollection<Product>> GetProductsAsync(int categoryId);

        Task<ReadOnlyCollection<string>> GetSearchSuggestionsAsync(string searchTerm);

        Task<Category> GetCategoryAsync(int categoryId);

        Task<Product> GetProductAsync(string productNumber);

        string GetCategoryName(int parentId);
    }
}