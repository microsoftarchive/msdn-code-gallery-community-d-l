// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Linq;
using AdventureWorks.UILogic.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Windows.UI.Xaml.Navigation;
using AdventureWorks.UILogic.Services;
using System.Globalization;
using System.Collections.ObjectModel;

namespace AdventureWorks.UILogic.ViewModels
{
    public class GroupDetailPageViewModel : ViewModel
    {
        private readonly IProductCatalogRepository _productCatalogRepository;
        private readonly IAlertMessageService _alertMessageService;
        private readonly IResourceLoader _resourceLoader;
        private string _title;
        private IReadOnlyCollection<ProductViewModel> _items;

        public GroupDetailPageViewModel(IProductCatalogRepository productCatalogRepository, IAlertMessageService alertMessageService, IResourceLoader resourceLoader)
        {
            _productCatalogRepository = productCatalogRepository;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;
        }

        public string Title
        {
            get { return _title; }
            private set { SetProperty(ref _title, value); }
        }

        public IReadOnlyCollection<ProductViewModel> Items
        {
            get { return _items; }
            private set { SetProperty(ref _items, value); }
        }

        public async override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            var categoryId = Convert.ToInt32(navigationParameter);

            string errorMessage = string.Empty;
            try
            {
                var category = await _productCatalogRepository.GetCategoryAsync(categoryId);

                Title = category.Title;

                var products = await _productCatalogRepository.GetProductsAsync(categoryId);
                Items = new ReadOnlyCollection<ProductViewModel>(products
                                                                         .Select(product => new ProductViewModel(product))
                                                                         .ToList());
            }
            catch (Exception ex)
            {
            errorMessage = string.Format(CultureInfo.CurrentCulture, _resourceLoader.GetString("GeneralServiceErrorMessage"), Environment.NewLine, ex.Message);
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                await _alertMessageService.ShowAsync(errorMessage, _resourceLoader.GetString("ErrorServiceUnreachable"));
            }
        }
    }
}
