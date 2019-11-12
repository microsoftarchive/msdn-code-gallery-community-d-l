// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Windows.Input;
using AdventureWorks.UILogic.Models;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace AdventureWorks.UILogic.ViewModels
{
    public class CategoryViewModel
    {
        private readonly Category _category;
        private INavigationService _navigationService;

        public CategoryViewModel(Category category, INavigationService navigationService)
        {
            _category = category;
            _navigationService = navigationService;
            CategoryNavigationCommand = new DelegateCommand(NavigateToCategory);
            
            if (category != null && category.Products != null)
            {
                int position = 0;
                Products = new ReadOnlyCollection<ProductViewModel>(category.Products
                                                                            .Select(p => new ProductViewModel(p) { ItemPosition = position++ })
                                                                            .ToList());
            }
        }

        public int CategoryId { get { return _category.Id; } }

        public int ParentCategoryId { get { return _category.ParentId; } }

        public string Title { get { return _category.Title; } }

        public IReadOnlyCollection<ProductViewModel> Products { get; private set; }

        public int TotalNumberOfItems { get { return _category.TotalNumberOfItems; } }

        public ICommand CategoryNavigationCommand { get; private set; }

        public Uri Image { get { return _category.ImageUri;} }

        public override string ToString()
        {
            return Title;
        }

        private void NavigateToCategory()
        {
            if (_category.HasSubcategories)
            {
                _navigationService.Navigate("Category", CategoryId);
            }
            else
            {
                _navigationService.Navigate("GroupDetail", CategoryId);
            }
        }
    }
}
