// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;

namespace AdventureWorks.UILogic.Models
{
    public class Category
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Title { get; set; }

        public Uri ImageUri { get; set; }

        public IEnumerable<Category> Subcategories { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public int TotalNumberOfItems { get; set; }

        public bool HasSubcategories { get; set; }
    }
}