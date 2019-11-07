//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Scalable Transform worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Internal
{
    #region Using references
    using System;
    using System.Xml.Xsl;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a data transfer object carrying the XSLT cache item metadata. 
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    internal sealed class XslTransformCacheItemInfo
    {
        #region Private members
        private const int DefaultTimeToLiveSeconds = 60 * 60;

        [DataMember(Name = "LastUpdated")]
        private DateTime lastUpdated { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Instantiate a new instance of the <see cref="XslTransformCacheItemInfo"/> object using the specified XSLT transformation metadata.
        /// </summary>
        /// <param name="transformSet">The object carrying the XSLT transformation metadata, XSLT transformation object and its arguments.</param>
        public XslTransformCacheItemInfo(XslTransformSet transformSet)
        {
            Guard.ArgumentNotNull(transformSet, "transformSet");

            TransformSet = transformSet;
            CreatedOn = DateTime.UtcNow;
            ExpiresOn = CreatedOn.AddSeconds(DefaultTimeToLiveSeconds);
        }

        /// <summary>
        /// Instantiate a new instance of the <see cref="XslTransformCacheItemInfo"/> object using the specified XSLT transformation metadata
        /// and a custom cache TTL value.
        /// </summary>
        /// <param name="transformSet">The object carrying the XSLT transformation metadata, XSLT transformation object and its arguments.</param>
        /// <param name="timeToLive">The time value indicating how long cached items will be kept inside the cache.</param>
        public XslTransformCacheItemInfo(XslTransformSet transformSet, TimeSpan timeToLive) : this(transformSet)
        {
            if (timeToLive != TimeSpan.Zero)
            {
                ExpiresOn = CreatedOn.Add(timeToLive);
            }
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns an object carrying the XSLT transformation metadata, XSLT transformation object and its arguments.
        /// </summary>
        [DataMember]
        public XslTransformSet TransformSet { get; private set; }

        /// <summary>
        /// Returns the data/time value indicating when a cache item has been created. This does not indicate when the cache item was added to the cache.
        /// </summary>
        [DataMember]
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// Returns the data/time value indicating when a cache item was last updated.
        /// </summary>
        [IgnoreDataMember]
        public DateTime LastUpdated
        {
            get
            {
                return this.lastUpdated;
            }
            set
            {
                this.lastUpdated = value;
                ExpiresOn = this.lastUpdated.AddSeconds(DefaultTimeToLiveSeconds);
            }
        }

        /// <summary>
        /// Returns the data/time value indicating when a cache item is set to expire.
        /// </summary>
        [DataMember]
        public DateTime ExpiresOn { get; private set; }

        /// <summary>
        /// Returns a Boolean flag indicating whether or not a cache item is expired.
        /// </summary>
        [IgnoreDataMember]
        public bool IsExpired
        {
            get { return ExpiresOn <= DateTime.UtcNow; }
        }
        #endregion
    }
}
