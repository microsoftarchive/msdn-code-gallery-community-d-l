using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using System.Text.RegularExpressions;
using System.Data.Services.Client;

namespace FlashCardsService.Entities
{
    /// <summary>
    /// Helper class to access the Users Table
    /// </summary>
    public class UserDataSource : EntitiesDataSource
    {
       
        public UserDataSource()
        {
            //Init the storage account
            _storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            _cloudTableClient = _storageAccount.CreateCloudTableClient();

            _cloudTableClient.CreateTableIfNotExist("Users");
        }


        public UserDataSource(CloudStorageAccount storageAccount)
        {           
            _storageAccount = storageAccount;
            _cloudTableClient = storageAccount.CreateCloudTableClient();

            _cloudTableClient.CreateTableIfNotExist("Users");
        }

        protected TableServiceContext _tableServiceContext;
        protected TableServiceContext TableServiceContext 
        {
            get 
            { 
                if (_tableServiceContext == null)
                    _tableServiceContext = GetUsersContext();
                return _tableServiceContext; 
            }
        }

        /// <summary>
        /// Get a user profile
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserProfile GetUser(string email)
        {
            var validator = new Regex(RegularExpressions.Email);
            if (!validator.IsMatch(email))
                throw new ArgumentException("email is not in the write format");


            var query = TableServiceContext.CreateQuery<UserProfile>("Users").Where(usr => (usr.Email == email));

            return query.FirstOrDefault();
        }


        private bool UsersTableIsEmpty()
        {
            var tableServiceContext = GetUsersContext();

            return (tableServiceContext.CreateQuery<UserProfile>("Users").FirstOrDefault() == null);
        }

        /// <summary>
        ///  Create or update a user profile
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserProfile CreateNewUser(string email) { return CreateNewUser(email, null); }


        /// <summary>
        /// Create or update a user profile 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="visibleBlobNames"></param>
        /// <returns></returns>
        public UserProfile CreateNewUser(string email, List<string> visibleBlobNames)
        {
           
            var validator = new Regex(RegularExpressions.Email);
            if (!validator.IsMatch(email))
                throw new ArgumentException("email is not in the write format");

            if (!UsersTableIsEmpty())
            {
                var existingUser = GetUser(email);
                if (GetUser(email) != null)
                {
                    if (visibleBlobNames != null && visibleBlobNames.Count > 0)
                    {
                        existingUser.AddVisibleBlobs(visibleBlobNames);
                        TableServiceContext.UpdateObject(existingUser);
                        TableServiceContext.SaveChangesWithRetries();
                    }
                    return existingUser;
                }
            }            

            UserProfile newUserProfile = new UserProfile(email);
            if ((visibleBlobNames != null) && (visibleBlobNames.Count > 0))
                newUserProfile.AddVisibleBlobs(visibleBlobNames);
             
            TableServiceContext.AddObject("Users", newUserProfile); 
            TableServiceContext.SaveChangesWithRetries();

            return newUserProfile;

        }

        /// <summary>
        /// Delete a user from the users table
        /// </summary>
        /// <param name="email"></param>
        public void DeleteUser(string email)
        {
            var validator = new Regex(RegularExpressions.Email);
            if (!validator.IsMatch(email))
                throw new ArgumentException("email is not in the write format");
            var userProfile = GetUser(email);
            if (userProfile == null)
                return;
            
            var tableServiceContext = GetUsersContext();
            tableServiceContext.DeleteObject(userProfile);
            tableServiceContext.SaveChangesWithRetries();
        }

    }
}
