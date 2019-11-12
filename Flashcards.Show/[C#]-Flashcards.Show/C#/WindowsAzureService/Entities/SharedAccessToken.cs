using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace FlashCardsService.Entities
{
    /// <summary>
    /// Heleper class to create a Shared Access Token to a certain blob.
    ///  Shared Access Token allows to access to the blob from a non public container
    /// </summary>
    public class SharedAccessToken
    {
        public static string GenerateSAS(string containerName, string blobUri)
        {
            string res = null;

            if ((string.IsNullOrEmpty(containerName)) || (string.IsNullOrEmpty(blobUri)))
                throw new ArgumentException("Both container name and blob Uri must containt valid values");


            var storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            var blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlob blob = blobClient.GetBlobReference(blobUri);
            container.CreateIfNotExist();

            try
            {
                BlobContainerPermissions permissions = new BlobContainerPermissions();
                // The container itself doesn't allow public access.
                permissions.PublicAccess = BlobContainerPublicAccessType.Off;
                // The container itself doesn't allow SAS access.
                SharedAccessPolicy containerPolicy = new SharedAccessPolicy() { Permissions = SharedAccessPermissions.None };
                permissions.SharedAccessPolicies.Clear();
                permissions.SharedAccessPolicies.Add("SASPolicy", containerPolicy);
                container.SetPermissions(permissions);
                // Generate an SAS for the blob.
                SharedAccessPolicy blobPolicy = new SharedAccessPolicy()
                {
                    Permissions = SharedAccessPermissions.Read,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddDays(1d)
                };

                res = blob.GetSharedAccessSignature(blobPolicy, "SASPolicy");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }
    }
}
