// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Capptain.Agent;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureMobile.Samples.FieldEngineer.DataSources
{
    public static class ValidateAzureCredentials
    {
        public static async Task<bool> ValidateBlobStorageUrl(string blobStorageUrl)
        {
            try
            {
                var blobToCheck = blobStorageUrl + Constants.BlobCheckURL;

                var request = (HttpWebRequest)HttpWebRequest.Create(new Uri(blobToCheck));
                request.Method = "Head";

                using (var webResponse = (HttpWebResponse)await request.GetResponseAsync())
                {
                    var statusCode = webResponse.StatusCode;

                    if (statusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (WebException ex)
            {
                CapptainAgent.Instance.SendError("ValidateBlobStorageUrl.Error", new Dictionary<object, object>() { { "errorMessage", ex.Message } });
                return false;
            }
        }

        public static async Task<bool> ValidateMobileServiceUrl<T>(string mobileServiceUrl, string mobileServiceKey)
        {
            try
            {
                await LoginHelper.MobileServiceAuthenticate();

                IMobileServiceClient mobileServiceClient = AzureDataServices.MobileServiceClient;

                var mobileServiceTable = mobileServiceClient.GetTable<T>();

                var testData = await mobileServiceTable.Take(1).ToListAsync();

                return true;
            }
            catch (Exception ex)
            {
                CapptainAgent.Instance.SendError("ValidateMobileServiceUrl.Error", new Dictionary<object, object>() { { "errorMessage", ex.Message } });
                return false;
            }
        }
    }
}
