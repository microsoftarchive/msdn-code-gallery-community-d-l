// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Storage;

namespace AzureMobile.Samples.FieldEngineer.DataSources
{
    public static class AzureDataServices
    {
        private static MobileServiceClient mobileServiceClient;
        private static string loggedInUser;
        private static bool mobileServiceUserPushRegistered;
        private static bool refreshJobsListPage;

        public static MobileServiceClient MobileServiceClient
        {
            get { return mobileServiceClient; }
        }

        public static string LoggedInUser
        {
            get { return loggedInUser; }
            set { loggedInUser = value; }
        }

        public static bool MobileServiceUserPushRegistered
        {
            get { return mobileServiceUserPushRegistered; }
            set { mobileServiceUserPushRegistered = value; }
        }

        public static bool RefreshJobsListPage
        {
            get { return refreshJobsListPage; }
            set { refreshJobsListPage = value; }
        }

        public static async Task UpdateJob(Job jobToUpdate)
        {
            var localTable = mobileServiceClient.GetSyncTable<Job>();
            await localTable.UpdateAsync(jobToUpdate);
        }

        public static void InitializeMobileServiceClient()
        {
            var appUrl = ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceUrl].ToString();
            var appKey = ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceAccessKey].ToString();
            if (appUrl == Secrets.UndefinedMobileServiceUrl)
            {
                // Attempt to use the localhost address of the local server
                appUrl = Secrets.ServiceLocalAddress;
                appKey = null;
            }

            mobileServiceClient = new MobileServiceClient(appUrl, appKey, new JobExpandHandler());
        }

        public class JobExpandHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Content != null)
                {
                    var body = await request.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(body);
                }
                bool requestToJobTable = request.RequestUri.PathAndQuery.StartsWith("/tables/job", StringComparison.OrdinalIgnoreCase)
                     && !request.RequestUri.PathAndQuery.StartsWith("/tables/jobhistory", StringComparison.OrdinalIgnoreCase)
                    && request.Method == HttpMethod.Get;

                if (request.Method.Method == HttpMethod.Get.Method && requestToJobTable)
                {
                    UriBuilder builder = new UriBuilder(request.RequestUri);
                    string query = builder.Query;
                    if (!query.Contains("$expand"))
                    {
                        if (string.IsNullOrEmpty(query))
                        {
                            query = string.Empty;
                        }
                        else
                        {
                            query = query + "&";
                        }

                        query = query + "$expand=equipments,customer,JobHistories";
                        builder.Query = query.TrimStart('?');
                        request.RequestUri = builder.Uri;
                    }
                }

                var result = await base.SendAsync(request, cancellationToken);
                if (result.Content != null)
                {
                    var body = await result.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(body);
                }
                return result;
            }
        }
    }
}
