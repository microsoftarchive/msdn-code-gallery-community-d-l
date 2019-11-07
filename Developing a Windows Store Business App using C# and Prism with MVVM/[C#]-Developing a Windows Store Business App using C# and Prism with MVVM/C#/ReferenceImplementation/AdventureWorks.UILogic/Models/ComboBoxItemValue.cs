// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


namespace AdventureWorks.UILogic.Models
{
    public class ComboBoxItemValue
    {
        public string Id { get; set; }
        public string Value { get; set; }
        
        public override string ToString()
        {
            // Narrator support
            return Value;
        }
    }
}
