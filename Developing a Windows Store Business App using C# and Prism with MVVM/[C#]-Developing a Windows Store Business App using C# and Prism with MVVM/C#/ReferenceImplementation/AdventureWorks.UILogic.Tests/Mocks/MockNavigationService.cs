// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockNavigationService : INavigationService
    {
        public Func<string, object, bool> NavigateDelegate { get; set; }
        public Action GoBackDelegate { get; set; }
        public Func<bool> CanGoBackDelegate { get; set; }
        public Action ClearHistoryDelegate { get; set; }

        public bool Navigate(string pageToken, object parameter)
        {
            return this.NavigateDelegate(pageToken, parameter);
        }

        public void GoBack()
        {
            this.GoBackDelegate();
        }

        public bool CanGoBack()
        {
            return this.CanGoBackDelegate();
        }

        public void ClearHistory()
        {
            ClearHistoryDelegate();
        }

        public void RestoreSavedNavigation()
        {
            throw new NotImplementedException();
        }

        public void Suspending()
        {
            throw new NotImplementedException();
        }

        public int BackStackDepth { get; set; }
    }
}
