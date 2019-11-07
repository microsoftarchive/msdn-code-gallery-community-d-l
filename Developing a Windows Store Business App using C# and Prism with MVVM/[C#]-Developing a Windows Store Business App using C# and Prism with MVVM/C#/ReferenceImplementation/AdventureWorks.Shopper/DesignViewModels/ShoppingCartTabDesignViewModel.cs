// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


namespace AdventureWorks.Shopper.DesignViewModels
{
    public class ShoppingCartTabDesignViewModel
    {
        public ShoppingCartTabDesignViewModel()
        {
            FillWithDummyData();
        }

        public int ItemCount { get; set; }

        private void FillWithDummyData()
        {
            ItemCount = 5;
        }
    }
}
