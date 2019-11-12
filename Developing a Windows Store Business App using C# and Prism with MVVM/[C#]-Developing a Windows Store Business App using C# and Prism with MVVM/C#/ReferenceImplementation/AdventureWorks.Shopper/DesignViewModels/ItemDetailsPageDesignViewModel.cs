// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Linq;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AdventureWorks.Shopper.DesignViewModels
{
    public class ItemDetailsPageDesignViewModel
    {
        public ItemDetailsPageDesignViewModel()
        {
            FillWithDummyData();
        }

        public ProductViewModel SelectedProduct { get; set; }

        public IEnumerable<ProductViewModel> Items { get; private set; }

        private void FillWithDummyData()
        {
            Items = new List<ProductViewModel> 
            {
                new ProductViewModel(
                    new Product()
                        {
                            Title = "Product 1",  
                            Description = "Description of Product 1", 
                            ListPrice = 99.99, 
                            DiscountPercentage = 0, 
                            ProductNumber = "1", 
                            ImageUri = new Uri("ms-appx:///Assets/WideLogo.scale-100.png"), 
                            Currency= "USD"
                        }
                )
            };

            SelectedProduct = Items.First();
        }
    }
}