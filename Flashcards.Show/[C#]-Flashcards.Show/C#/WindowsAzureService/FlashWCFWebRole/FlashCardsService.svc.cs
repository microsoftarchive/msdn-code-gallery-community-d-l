using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FlashCardsService.Contracts;
using FlashCardsService.Entities;
using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Text.RegularExpressions;
using System.Security;
using System.IO.Packaging;
using FlashCards.ViewModel;

namespace FlashWCFWebRole
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class FlashCardService : IFlashCardService
    {
        private const string  ContainerName = "flashcards";
        private const int PasswordLength = 6;
        private char[] PasswordCharArray = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();                                        


        private string CreateBlob(Stream content, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("blob name can't be null or empty");
            }

            if (content == null)
            {
                throw new ArgumentException("stream is null or emply");
            }

            var storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            var blobClient = storageAccount.CreateCloudBlobClient();

//#warning TODO: find better place for creating the cross domain policy file
//            CreateStorageCrossDomainPolicy(blobClient);

            var container = blobClient.GetContainerReference(ContainerName);
            container.CreateIfNotExist();
            CloudBlob blob = container.GetBlobReference(name);
            blob.UploadFromStream(content);

            return blob.Uri.AbsoluteUri;
        }

        private string GetSafeSenderName(string senderName)
        {
            senderName = senderName.Replace(",", string.Empty);
            senderName = senderName.Replace("'", string.Empty);
            senderName = senderName.Replace(".", string.Empty);
            senderName = senderName.Replace("/", string.Empty);
            senderName = senderName.Replace(@"\", string.Empty);
            return senderName;
        }

        private string GeneratePassword()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            char[] password = new char[PasswordLength];

            for (int i = 0; i < PasswordLength; ++i)
			{
                password[i] = PasswordCharArray[random.Next(0, PasswordCharArray.Length-1)];
			}

            return new string(password);
        }

        private bool IsLegalDeckFile(Stream stream)
        {
            try
            {
                using (Package unZip = Package.Open(stream, FileMode.Open, FileAccess.Read))
                {
                    if (unZip == null)
                    {
                        return false;
                    }

                    Uri uri = new Uri("/deck.xml", UriKind.RelativeOrAbsolute);
                    PackagePart xmlPart = unZip.GetPart(uri);
                    if (xmlPart == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Upload a file to the blobs storage and create a record in the files table
        /// </summary>
        /// <param name="fileToLoad"></param>
        /// <returns>The token to be used to access the file later on</returns>
        public UploadFileTokenMessage UploadFile(UploadFileContentMessage fileToLoad)
        {
            // generate random 6 digits password
            string password = GeneratePassword();
            
            // remove bad characters from sender name
            string safeSenderName = GetSafeSenderName(fileToLoad.SenderName);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Utils.CopyStream(fileToLoad.FileByteStream, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                // make sure stream is a valid deck
                if (!IsLegalDeckFile(memoryStream))
                {
                    return new UploadFileTokenMessage() { Password = string.Empty };
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                // save stream as blob
                var blobUri = CreateBlob(memoryStream, password + safeSenderName);

                var files_ds = new FilesDataSource();
                var token = files_ds.AddFile(password + safeSenderName, ContainerName, blobUri);
            }

            return new UploadFileTokenMessage() { Password = password };
        }

        /// <summary>
        /// Provide the url to download the file
        /// The URL is based on the blob uri + SharedAccessToken
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public string GetFileUri(string senderName, string password)
        {
            // remove bad characters from sender name
            string safeSenderName = GetSafeSenderName(senderName);

            var files_ds = new FilesDataSource();
            var fileInfo = files_ds.GetFile(password + safeSenderName);

            if (fileInfo == null)
            {
                return string.Empty;
            }

            var sas = SharedAccessToken.GenerateSAS(ContainerName, fileInfo.BlobUri);

            return fileInfo.BlobUri + sas;
        }

        private static void CreateStorageCrossDomainPolicy(CloudBlobClient blobClient)
        {
            blobClient.GetContainerReference("$root").CreateIfNotExist();
            blobClient.GetContainerReference("$root").SetPermissions(
                new BlobContainerPermissions()
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

            var blob = blobClient.GetBlobReference("clientaccesspolicy.xml");
            blob.Properties.ContentType = "text/xml";
            blob.UploadText(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <access-policy>
              <cross-domain-access>
                <policy>
                  <allow-from http-methods=""*"" http-request-headers=""*"">
                    <domain uri=""*"" />
                    <domain uri=""http://*"" />
                  </allow-from>
                  <grant-to>
                    <resource path=""/"" include-subpaths=""true"" />
                  </grant-to>
                </policy>
              </cross-domain-access>
            </access-policy>");
        }
    }
}
