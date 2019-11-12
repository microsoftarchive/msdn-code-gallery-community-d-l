// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;

namespace AdventureWorks.UILogic.Services
{
    public interface IAccountService
    {
        UserInfo SignedInUser { get; }

        Task<UserInfo> VerifyUserAuthenticationAsync();
        Task<UserInfo> VerifySavedCredentialsAsync();

        Task<bool> SignInUserAsync(string userName, string password, bool useCredentialStore);
        
        void SignOut();
        
        event EventHandler<UserChangedEventArgs> UserChanged;
    }
}
