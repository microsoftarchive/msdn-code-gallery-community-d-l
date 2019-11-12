// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockFlyoutService : IFlyoutService
    {
        public Action<string, object, Action> ShowFlyoutDelegate { get; set; }

        public Func<string, FlyoutView> FlyoutResolver { get; set; }

        public void ShowFlyout(string flyoutId)
        {
            ShowFlyoutDelegate(flyoutId, null, null);
        }

        public void ShowFlyout(string flyoutId, object parameter, Action successAction)
        {
            ShowFlyoutDelegate(flyoutId, parameter, successAction);
        }
    }
}
