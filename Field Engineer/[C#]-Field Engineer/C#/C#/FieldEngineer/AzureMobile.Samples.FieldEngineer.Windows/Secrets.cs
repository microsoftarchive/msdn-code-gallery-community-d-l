// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

namespace AzureMobile.Samples.FieldEngineer
{
    internal static class Secrets
    {
        public static string MobileServiceUrl { get; private set; }
        public static string MobileServiceAccessKey { get; private set; }
        
        public const string ImageBlobLocationUrl = "ms-appx:///";

        public const string BingMapsCredentials = "BING-MAPS-CREDENTIALS-HERE";

        public static string AadTenantDomain { get; private set; }
        public static string AadNativeClientId { get; private set; }
        public static string AadResourceUri { get; private set; }
        public static string AadAuthority { get; private set; }

        internal const string UndefinedMobileServiceUrl = "https://MOBILE-SERVICE-URL-HERE.azure-mobile.net/";
        private const string UndefinedMobileServiceAccessKey = "MOBILE-SERVICE-APP-KEY-HERE";
        private const string UndefinedAadTenantDomain = "AAD-TENANT-HERE.onmicrosoft.com";
        private const string UndefinedAadNativeClientId = "AAD-NATIVE-CLIENT-ID-HERE";
        internal const string ServiceLocalAddress = "http://localhost:58972";

        static Secrets()
        {
            MobileServiceUrl = UndefinedMobileServiceUrl;
            MobileServiceAccessKey = UndefinedMobileServiceAccessKey;
            AadTenantDomain = UndefinedAadTenantDomain;
            AadNativeClientId = UndefinedAadNativeClientId;
            AadResourceUri = MobileServiceUrl.TrimEnd('/') + "/login/aad";
            AadAuthority = "https://login.windows.net/" + AadTenantDomain;
        }
    }
}
