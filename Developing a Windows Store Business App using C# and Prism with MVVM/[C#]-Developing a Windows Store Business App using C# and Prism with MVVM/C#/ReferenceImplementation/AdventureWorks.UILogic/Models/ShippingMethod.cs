// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Globalization;
namespace AdventureWorks.UILogic.Models
{
    public class ShippingMethod
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string EstimatedTime { get; set; }

        public double Cost { get; set; }

        public override string ToString()
        {
            // For Accessibility purposes
            return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}", Description, EstimatedTime, Cost);

        }
    }
}
