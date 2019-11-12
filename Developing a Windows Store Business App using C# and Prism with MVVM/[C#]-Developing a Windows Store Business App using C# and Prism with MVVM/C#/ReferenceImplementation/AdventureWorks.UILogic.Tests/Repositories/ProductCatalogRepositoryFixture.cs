// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.Repositories;
using AdventureWorks.UILogic.Tests.Mocks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace AdventureWorks.UILogic.Tests.Repositories
{
    [TestClass]
    public class ProductCatalogRepositoryFixture
    {
        [TestMethod]
        public async Task GetCategories_Calls_Service_When_Cache_Miss()
        {
            var cacheService = new MockCacheService();
            cacheService.GetDataDelegate = s => { throw new FileNotFoundException(); };
            cacheService.SaveDataAsyncDelegate = (s, c) => Task.FromResult(new Uri("http://test.org"));

            var productCatalogService = new MockProductCatalogService();
            var categories = new List<Category>
            {
                new Category{ Id = 1},
                new Category{ Id = 2}
            };

            productCatalogService.GetSubcategoriesAsyncDelegate = (parentId, maxProducts) => Task.FromResult(new ReadOnlyCollection<Category>(categories));
            
            var target = new ProductCatalogRepository(productCatalogService, cacheService);
            var returnedCategories = await target.GetRootCategoriesAsync(0);

            Assert.AreEqual(2, returnedCategories.Count);
            Assert.AreEqual(1, returnedCategories[0].Id);
            Assert.AreEqual(2, returnedCategories[1].Id);
        }

        [TestMethod]
        public async Task GetCategories_Uses_Cache_When_Data_Available()
        {
            var cacheService = new MockCacheService();
            // cacheService.DataExistsAndIsValidAsyncDelegate = s => Task.FromResult(true);
            
            var categories = new List<Category>
            {
                new Category{ Id = 1},
                new Category{ Id = 2}
            };

            cacheService.GetDataDelegate = (string s) =>
            {
                if (s == "Categories-0-0")
                    return new ReadOnlyCollection<Category>(categories);

                return new ReadOnlyCollection<Category>(null);
            };

            var productCatalogService = new MockProductCatalogService();
            productCatalogService.GetSubcategoriesAsyncDelegate = (parentId, maxProducts) => Task.FromResult(new ReadOnlyCollection<Category>(null));

            var target = new ProductCatalogRepository(productCatalogService, cacheService);

            var returnedCategories = await target.GetRootCategoriesAsync(0);

            Assert.AreEqual(2, returnedCategories.Count);
            Assert.AreEqual(1, returnedCategories[0].Id);
            Assert.AreEqual(2, returnedCategories[1].Id);
        }

        [TestMethod]
        public async Task GetCategories_Saves_Data_To_Cache()
        {
            var cacheService = new MockCacheService();
            cacheService.GetDataDelegate = s => { throw new FileNotFoundException(); };

            cacheService.SaveDataAsyncDelegate = (s, o) =>
            {
                var collection = (ReadOnlyCollection<Category>)o;
                Assert.AreEqual("Categories-0-0", s);
                Assert.AreEqual(2, collection.Count);
                Assert.AreEqual(1, collection[0].Id);
                Assert.AreEqual(2, collection[1].Id);
                return Task.FromResult(new Uri("http://test.org"));
            };

            var productCatalogService = new MockProductCatalogService();
            var categories = new List<Category>
                                 {
                                     new Category{ Id = 1},
                                     new Category{ Id = 2}
                                 };
            productCatalogService.GetSubcategoriesAsyncDelegate = (parentId, maxProducts) => Task.FromResult(new ReadOnlyCollection<Category>(categories));

            var target = new ProductCatalogRepository(productCatalogService, cacheService);

            await target.GetRootCategoriesAsync(0);
        }

        [TestMethod]
        public async Task GetSubcategories_Calls_Service_When_Cache_Miss()
        {
            var cacheService = new MockCacheService();
            cacheService.GetDataDelegate = s => { throw new FileNotFoundException(); };
            cacheService.SaveDataAsyncDelegate = (s, c) => Task.FromResult(new Uri("http://test.org"));

            var productCatalogService = new MockProductCatalogService();
            var subCategories = new List<Category>
                                 {
                                     new Category{ Id = 10},
                                     new Category{ Id = 11}
                                 };
            productCatalogService.GetSubcategoriesAsyncDelegate = (parentId, maxProducts) => Task.FromResult(new ReadOnlyCollection<Category>(subCategories));

            var target = new ProductCatalogRepository(productCatalogService, cacheService);

            var returnedSubcategories = await target.GetSubcategoriesAsync(1, 10);

            Assert.AreEqual(2, returnedSubcategories.Count);
            Assert.AreEqual(10, returnedSubcategories[0].Id);
            Assert.AreEqual(11, returnedSubcategories[1].Id);
        }

        [TestMethod]
        public async Task GetSubcategories_Uses_Cache_When_Data_Available()
        {
            var cacheService = new MockCacheService();
            var categories = new List<Category>
                                 {
                                     new Category{ Id = 10},
                                     new Category{ Id = 11}
                                 };
            cacheService.GetDataDelegate = s =>
            {
                if (s == "Categories-1-10")
                    return new ReadOnlyCollection<Category>(categories);

                return new ReadOnlyCollection<Category>(null);
            };

            var productCatalogService = new MockProductCatalogService();
            productCatalogService.GetSubcategoriesAsyncDelegate = (parentId, maxProducts) => Task.FromResult(new ReadOnlyCollection<Category>(null));

            var target = new ProductCatalogRepository(productCatalogService, cacheService);

            var returnedCategories = await target.GetSubcategoriesAsync(1,10);

            Assert.AreEqual(2, returnedCategories.Count);
            Assert.AreEqual(10, returnedCategories[0].Id);
            Assert.AreEqual(11, returnedCategories[1].Id);
        }

        [TestMethod]
        public async Task GetSubcategories_Saves_Data_To_Cache()
        {
            var cacheService = new MockCacheService();
            cacheService.GetDataDelegate = s => { throw new FileNotFoundException(); };
            cacheService.SaveDataAsyncDelegate = (s, o) => 
            {
                var collection = (ReadOnlyCollection<Category>)o;
                Assert.AreEqual("Categories-1-10", s);
                Assert.AreEqual(2, collection.Count);
                Assert.AreEqual(10, collection[0].Id);
                Assert.AreEqual(11, collection[1].Id);
                return Task.FromResult(new Uri("http://test.org"));
            };

            var productCatalogService = new MockProductCatalogService();
            var subCategories = new List<Category>
                                 {
                                     new Category{ Id = 10},
                                     new Category{ Id = 11}
                                 };
            productCatalogService.GetSubcategoriesAsyncDelegate = (parentId, maxProducts) => Task.FromResult(new ReadOnlyCollection<Category>(subCategories));

            var target = new ProductCatalogRepository(productCatalogService, cacheService);

            await target.GetSubcategoriesAsync(1,10);
        }
    }
}
