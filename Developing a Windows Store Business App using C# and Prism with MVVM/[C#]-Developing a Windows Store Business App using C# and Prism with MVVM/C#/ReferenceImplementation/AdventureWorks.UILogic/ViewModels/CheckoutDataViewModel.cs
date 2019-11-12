// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Globalization;

namespace AdventureWorks.UILogic.ViewModels
{
    public class CheckoutDataViewModel
    {
        public string EntityId { get; set; }

        public string Title { get; set; }

        public string FirstLine { get; set; }

        public string SecondLine { get; set; }

        public string BottomLine { get; set; }

        public Uri LogoUri { get; set; }

        public string DataType { get; set; }

        public override string ToString()
        {
            // For Accessibility purposes
            return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}, {4}", DataType, Title, FirstLine, SecondLine, BottomLine);
        }
    }
}
