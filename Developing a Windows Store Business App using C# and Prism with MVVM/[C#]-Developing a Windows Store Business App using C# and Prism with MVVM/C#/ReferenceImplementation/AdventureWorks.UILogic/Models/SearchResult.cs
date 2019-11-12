// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.ObjectModel;

namespace AdventureWorks.UILogic.Models
{
    public class SearchResult
    {
        public SearchResult(int totalCount, ReadOnlyCollection<Product> products)
        {
            TotalCount = totalCount;
            Products = products;
        }
        public int TotalCount { get; private set; }
        public ReadOnlyCollection<Product> Products { get; private set; }
    }
}
