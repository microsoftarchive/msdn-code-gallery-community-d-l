// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Windows.Security.Credentials;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockCredentialStore : ICredentialStore
    {
        public Action<string, string, string> SaveCredentialsDelegate { get; set; }
        public Func<string, PasswordCredential> GetSavedCredentialsDelegate { get; set; }
        public Action<string> RemoveSavedCredentialsDelegate { get; set; }

        public void SaveCredentials(string resource, string userName, string password)
        {
            SaveCredentialsDelegate(resource, userName, password);
        }

        public PasswordCredential GetSavedCredentials(string resource)
        {
            return GetSavedCredentialsDelegate(resource);
        }

        public void RemoveSavedCredentials(string resource)
        {
            RemoveSavedCredentialsDelegate(resource);
        }
    }
}
