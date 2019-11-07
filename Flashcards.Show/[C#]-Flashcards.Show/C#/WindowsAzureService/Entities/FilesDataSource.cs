using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Text.RegularExpressions;

namespace FlashCardsService.Entities
{
    /// <summary>
    /// Helper class to access the Files table
    /// </summary>
    public class FilesDataSource : EntitiesDataSource
    {
        
        public FilesDataSource()
        {
            //Init the storage account
            _storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            _cloudTableClient = _storageAccount.CreateCloudTableClient();

            _cloudTableClient.CreateTableIfNotExist("Files");
        }


        public FilesDataSource(CloudStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
            _cloudTableClient = _storageAccount.CreateCloudTableClient();

            _cloudTableClient.CreateTableIfNotExist("Files");
        }

        /// <summary>
        /// Get a FlashCardFileInfo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FlashCardFileInfo GetFile(string name)
        {
            FlashCardFileInfo res = null;

            if (string.IsNullOrEmpty(name))
                return null;

            var tableServiceContext = GetFilesContext();

            try
            {
                res = tableServiceContext.CreateQuery<FlashCardFileInfo>("Files").Where(fi => fi.Name == name).FirstOrDefault();
            }
            catch (Exception) { }
                    

            return res;
        }

       
        /// <summary>
        /// Add a FlashCardFileInfo to the Files table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="container"></param>
        /// <param name="blobUri"></param>
        /// <returns>The token to be used to access the file</returns>
        public Guid AddFile(string name, string container, string blobUri)
        {
            if (string.IsNullOrEmpty(name))
               throw new ArgumentException("Blob name can't be null or empty");

            var validator = new Regex(RegularExpressions.Uri);
            if (!validator.IsMatch(blobUri))
                throw new ArgumentException("Blob uri is invalid");
            
            //The blob already exist
            var existingFile = GetFile(name);
            if (existingFile != null)
                return existingFile.Token;

            var tableServiceContext = GetFilesContext();

            FlashCardFileInfo newFile = new FlashCardFileInfo() { Name = name, BlobUri = blobUri, Container = container };
            newFile.Token = Guid.NewGuid();

            tableServiceContext.AddObject("Files", newFile);
            tableServiceContext.SaveChangesWithRetries();

            return newFile.Token;

        }

        /// <summary>
        /// Delete a FlashCardFileInfo from the Files table
        /// </summary>
        /// <param name="name"></param>
        public void DeleteFile(string name)
        {
            if (string.IsNullOrEmpty(name))
               return;         

            //The blob does not exist
            var existingFile = GetFile(name);
            if (existingFile != null)
                return;

            var tableServiceContext = GetFilesContext();
            tableServiceContext.DeleteObject(existingFile);
            tableServiceContext.SaveChangesWithRetries();
        }

        

    }
}
