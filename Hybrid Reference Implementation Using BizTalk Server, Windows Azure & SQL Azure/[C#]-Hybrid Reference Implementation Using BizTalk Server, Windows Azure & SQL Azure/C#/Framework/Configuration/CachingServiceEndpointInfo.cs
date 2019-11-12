//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.Security;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration element holding parameters defining an endpoint of the Windows Azure Caching Service.
    /// </summary>
    public sealed class CachingServiceEndpointInfo : NamedConfigurationElement
    {
        #region Private members
        private const string ServiceHostNameProperty = "serviceHostName";
        private const string CachePortProperty = "cachePort";
        private const string AuthTokenProperty = "authToken";
        private const string RetryPolicyProperty = "retryPolicy";
        private const string SslEnabledProperty = "sslEnabled";
        private const string DefaultCacheServerDomain = ".cache.windows.net";
        
        private const int DefaultDataCacheServerEndpointPort = 22233;
        private const int DefaultDataCacheSecureServerEndpointPort = 22243;

        private SecureString secureStringToken = new SecureString();
        private readonly object secureStringTokenLock = new object();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="CachingServiceEndpointInfo"/> object with default settings.
        /// </summary>
        public CachingServiceEndpointInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="CachingServiceEndpointInfo"/> object with specified specified endpoint namespace and ACS authentication token.
        /// </summary>
        /// <param name="serviceNamespace">The unique service namespace name used by the endpoint.</param>
        /// <param name="authToken">The service authentication token.</param>
        public CachingServiceEndpointInfo(string serviceNamespace, string authToken)
        {
            Guard.ArgumentNotNullOrEmptyString(serviceNamespace, "serviceNamespace");
            Guard.ArgumentNotNullOrEmptyString(authToken, "authToken");

            Name = serviceNamespace;
            AuthenticationToken = authToken;

            UpdateServiceHostName(serviceNamespace);
            UpdateCachePort(SslEnabled);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the key value containing an ACS key that secures access to the cache.
        /// </summary>
        [ConfigurationProperty(AuthTokenProperty, IsRequired = true)]
        public string AuthenticationToken
        {
            get
            {
                return (string)base[AuthTokenProperty];
            }
            set
            {
                base[AuthTokenProperty] = value;
                UpdateSecureToken(value);
            }
        }

        /// <summary>
        /// Gets or sets the FQDN-style service host name used by the endpoint.
        /// </summary>
        [ConfigurationProperty(ServiceHostNameProperty, IsRequired = false)]
        public string ServiceHostName
        {
            get { return (string)base[ServiceHostNameProperty]; }
            set { base[ServiceHostNameProperty] = value;  }
        }

        /// <summary>
        /// Gets or sets the port number of the caching service host.
        /// </summary>
        [ConfigurationProperty(CachePortProperty, IsRequired = false, DefaultValue = 0)]
        public int CachePort
        {
            get { return Convert.ToInt32(base[CachePortProperty]); }
            set { base[CachePortProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the flag indicating that communication between cache client and caching service will be protected by SSL.
        /// </summary>
        [ConfigurationProperty(SslEnabledProperty, IsRequired = false, DefaultValue = true)]
        public bool SslEnabled
        {
            get 
            { 
                return Convert.ToBoolean(base[SslEnabledProperty]); 
            }
            set 
            { 
                base[SslEnabledProperty] = value;
                UpdateCachePort(value);
            }
        }

        /// <summary>
        /// Gets the key value containing a read-only secure version of the ACS key that secures access to the cache.
        /// </summary>
        public SecureString SecureAuthenticationToken
        {
            get { return this.secureStringToken; }
        }

        /// <summary>
        /// Gets or sets the retry policy definition associated with the caching service endpoint.
        /// </summary>
        [ConfigurationProperty(RetryPolicyProperty, IsRequired = false)]
        public string RetryPolicy
        {
            get { return (string)base[RetryPolicyProperty]; }
            set { base[RetryPolicyProperty] = value; }
        }
        #endregion

        #region Private methods
        private void UpdateSecureToken(string authToken)
        {
            // Critical section ensures thread safety.
            lock(this.secureStringTokenLock)
            {
                // Need to safely dispose the original secure string instance.
                if (this.secureStringToken.IsReadOnly())
                {
                    this.secureStringToken.Dispose();
                    this.secureStringToken = new SecureString();
                }

                foreach (char c in authToken)
                {
                    this.secureStringToken.AppendChar(c);
                }

                this.secureStringToken.MakeReadOnly();
            }
        }

        /// <summary>
        /// Implements an extension point that gets called after deserialization.
        /// </summary>
        protected override void PostDeserialize()
        {
            base.PostDeserialize();

            if (String.IsNullOrEmpty(ServiceHostName))
            {
                UpdateServiceHostName(Name);
            }

            if (CachePort == 0)
            {
                UpdateCachePort(SslEnabled);
            }

            UpdateSecureToken(AuthenticationToken);
        }

        private void UpdateCachePort(bool sslEnabled)
        {
            CachePort = sslEnabled ? DefaultDataCacheSecureServerEndpointPort : DefaultDataCacheServerEndpointPort;
        }

        private void UpdateServiceHostName(string serviceNamespace)
        {
            ServiceHostName = String.Concat(serviceNamespace, DefaultCacheServerDomain);
        }
        #endregion
    }
}
