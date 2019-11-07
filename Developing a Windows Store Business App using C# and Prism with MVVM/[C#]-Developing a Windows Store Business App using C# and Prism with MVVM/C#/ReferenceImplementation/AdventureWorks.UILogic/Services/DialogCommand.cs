// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;

namespace AdventureWorks.UILogic.Services
{
    public class DialogCommand
    {
        public object Id { get; set; }
        public string Label { get; set; }
        public Action Invoked { get; set; }
    }
}
