// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Capptain.Agent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using Windows.Storage;
using Windows.UI.Popups;

namespace AzureMobile.Samples.FieldEngineer.Utilities
{
    public class LoginHelper
    {
        public static async Task MobileServiceAuthenticate(bool forceLoginWhenOffline = false)
        {
            if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online || forceLoginWhenOffline)
            {
                var aadAuthority = ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadAuthority].ToString();
                var aadResourceUri = ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadResourceUri].ToString();
                var aadClientId = ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadClientId].ToString();
                bool isLoggedOut = (ApplicationData.Current.LocalSettings.Values[Constants.Settings.LoggedInUserId] == null);
                MobileServiceUser mobileServiceUser = null;
                if (ConnectionHelper.IsServiceAtLocalhost())
                {
                    // F5-experience: talking to localhost, no need to authenticate
                    return;
                }

                while (mobileServiceUser == null)
                {
                    string message = string.Empty;
                    AuthenticationContext authenticationContext = null;
                    AuthenticationResult authenticationResult = null;
                    MobileServiceInvalidOperationException msioe = null;

                    try
                    {
                        authenticationContext = new AuthenticationContext(aadAuthority, false);
                        authenticationResult = await authenticationContext.AcquireTokenAsync(aadResourceUri, aadClientId, (Uri)null, isLoggedOut ? PromptBehavior.Always : PromptBehavior.Auto);
                        if (string.IsNullOrEmpty(authenticationResult.AccessToken))
                        {
                            message = "AAD access token is null. Please check AAD settings";
                            await ShowLoginRequiredDialog(message);
                            continue;
                        }
                        JObject payload = new JObject();
                        payload["access_token"] = authenticationResult.AccessToken;
                        mobileServiceUser = await AzureDataServices.MobileServiceClient.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, payload);
                        var fieldAgentDisplayName = await AzureDataServices.MobileServiceClient.InvokeApiAsync("getFieldAgentDisplayName", HttpMethod.Get, null);
                        AzureDataServices.LoggedInUser = fieldAgentDisplayName.ToString();

                        if (isLoggedOut || ApplicationData.Current.LocalSettings.Values[Constants.Settings.LoggedInUserId].ToString() != mobileServiceUser.UserId)
                        {
                            string loggedInUserId = RemoveInvalidCharacters(mobileServiceUser.UserId);
                            ApplicationData.Current.LocalSettings.Values[Constants.Settings.LoggedInUserId] = loggedInUserId;
                            await Utilities.LocalStoreHelper.InitializeLocalStore(loggedInUserId);
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        msioe = e as MobileServiceInvalidOperationException;
                        if (mobileServiceUser == null)
                        {
                            message = "Authorizing with MobileService failed. Please check MobileService AAD settigs";
                        }
                        else
                        {
                            AzureDataServices.MobileServiceClient.Logout();
                            mobileServiceUser = null;
                            authenticationContext.TokenCacheStore.Clear();
                            message = "User does not have permissions. Log in with valid FieldAgent credentials";
                        }
                    }
                    if (msioe != null)
                    {
                        var response = msioe.Response.Content;
                        if (response != null)
                        {
                            var respBody = await response.ReadAsStringAsync();
                            message = message + " - server response:\n" + respBody;
                        }
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        //Only show dialog if login fails
                        await ShowLoginRequiredDialog(message);
                    }
                }
            }
        }

        public static void MobileServicesLogout()
        {
            AzureDataServices.MobileServiceClient.Logout();
            var aadAuthority = ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadAuthority].ToString();
            AuthenticationContext authenticationContext = new AuthenticationContext(aadAuthority, false);
            authenticationContext.TokenCacheStore.Clear();
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.LoggedInUserId] = null;
        }

        private static async Task ShowLoginRequiredDialog(string message)
        {
            CapptainAgent.Instance.SendError("MobileServiceAuthenticate.Error", new Dictionary<object, object>() { { "errorMessage", message } });
            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
        }

        private static string RemoveInvalidCharacters(string userId)
        {
            char[] invalidChars = { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };
            string[] userIdSplit = userId.Split(invalidChars);
            if (userIdSplit.Length > 1)
            {
                userId = string.Join("-", userIdSplit);
            }
            return userId;
        }
    }
}
