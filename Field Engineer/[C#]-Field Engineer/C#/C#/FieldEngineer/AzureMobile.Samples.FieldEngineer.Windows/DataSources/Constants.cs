// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

namespace AzureMobile.Samples.FieldEngineer.DataSources
{
    public static class Constants
    {
        public const string CompletedStatus = "Completed";
        public const string CompleteStatus = "Complete";
        public const string PendingStatus = "Not Started";
        public const string CurrentStatus = "On Site";
        public const string PendingJobsTitle = "Pending Jobs";
        public const string CompletedJobsTitle = "Completed Jobs";
        public const string CurrentJobTitle = "Current Job";
        public const string ResultsFound = "ResultsFound";
        public const string NoResultsFound = "NoResultsFound";
        public const string CompletedJobItemTemplate = "CompletedJobItemTemplate";
        public const string JobItemTemplate = "JobItemTemplate";
        public const string CurrentJobItemTemplate = "CurrentJobItemTemplate";
        public const string FormStatusInProgress = "In Progress";
        public const string GenericErrorMessage = "Some Error occurred. Please try later.";
        public const string PrivacyPolicyUrl = "http://mobileaccelerators.azurewebsites.net/policies/FieldEngineer.html";
        
        /// <summary>
        /// Warning message to user that he is not connected to internet
        /// </summary>
        public const string DataConnectionUnavailableWarning = "There is no network connectivity and hence the app is switching to offline mode.";

        public const string NoInternetMessageHeader = "No Internet Connection. Please retry when connected to internet.";

        public const string DoNotAskAgainText = "Don't ask for this session";

        public const string ShowInternetNotAvailableMessageKey = "InternetNotAvailable";

        public const string MobileServiceUrlError = "Please enter mobile service URL";
        public const string MobileServiceAccessKeyError = "Please enter mobile service access key";
        public const string ImageBlobLocationUrlError = "Please enter image blob location URL";
        public const string InvalidMobileServiceCredential = "Please enter a valid mobile service Url and access key";

        public const string ValidatingMobileServiceDetails = "Validating the Mobile service details";

        public const string Online = "Online";
        public const string Offline = "Offline";

        /// <summary>
        /// This will be appended to the blob url URL given by the user and validated to check that the blob exists.
        /// </summary>
        public const string BlobCheckURL = "equipmentimages/Dish_1.jpg";
        public const string InvalidBlobUrl = "Invalid blob url";

        public static class Settings
        {
            public const string NotFirstTimeFlag = "NotFirstTimeFlag";
            public const string LoggedInUserId = "LoggedInUserId";
            public const string StorageMode = "StorageMode";
            public const string MobileServiceUrl = "MobileServiceURL";
            public const string MobileServiceAccessKey = "MobileServiceAccessKey";
            public const string ImageBlobLocationUrl = "ImageBlobLocationURL";
            public const string AadAuthority = "AadAuthority";
            public const string AadResourceUri = "AadResourceUri";
            public const string AadClientId = "AadClientId";
        }
    }
}
