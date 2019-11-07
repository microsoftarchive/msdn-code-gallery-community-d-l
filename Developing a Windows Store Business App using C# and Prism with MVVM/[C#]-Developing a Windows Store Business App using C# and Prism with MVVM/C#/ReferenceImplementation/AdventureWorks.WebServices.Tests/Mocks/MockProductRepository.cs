// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;
using AdventureWorks.WebServices.Models;
using AdventureWorks.WebServices.Repositories;
namespace AdventureWorks.WebServices.Tests.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        public Func<IEnumerable<Product>> GetTodaysDealsProductsDelegate { get; set; }
        public Func<int, IEnumerable<Product>> GetProductsForCategoryDelegate { get; set; }
        public Func<IEnumerable<Product>> GetProductsDelegate { get; set; }
        public Func<string, Product> GetProductDelegate { get; set; }

        public IEnumerable<Product> GetTodaysDealsProducts()
        {
            return GetTodaysDealsProductsDelegate();
        }

        public IEnumerable<Product> GetProductsForCategory(int subcategoryId)
        {
            return GetProductsForCategoryDelegate(subcategoryId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return GetProductsDelegate();
        }

        public Product GetProduct(string productNumber)
        {
            return GetProductDelegate(productNumber);
        }
    }
}
