using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;

namespace FlashCardsService.Entities
{
    public abstract class EntitiesDataSource
    {
        protected CloudStorageAccount _storageAccount;
        protected CloudTableClient _cloudTableClient;

        protected TableServiceContext GetUsersContext()
        {
            if (_storageAccount ==  null)
                _storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");

            if (_cloudTableClient == null)
                _cloudTableClient = _storageAccount.CreateCloudTableClient();

            TableServiceContext tableServiceContext = _cloudTableClient.GetDataServiceContext();
            tableServiceContext.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromMinutes(1));
            tableServiceContext.ResolveType = (unused) => typeof(UserProfile);

            return tableServiceContext;
        }

        protected TableServiceContext GetFilesContext()
        {
            if (_storageAccount == null)
               _storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
           
            if (_cloudTableClient == null)
               _cloudTableClient = _storageAccount.CreateCloudTableClient();

            TableServiceContext tableServiceContext = _cloudTableClient.GetDataServiceContext();
            tableServiceContext.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromMinutes(1));
            tableServiceContext.ResolveType = (unused) => typeof(FlashCardFileInfo);

            return tableServiceContext;
        }
    }
}
