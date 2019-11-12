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
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Extensions
{
    #region Using references
    using System;
    using System.Xml.Xsl;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines an interface that must be supported by an extension component providing caching capabilities
    /// for the XSLT-based transformation objects.
    /// </summary>
    #region IXslTransformCacheExtension interface
    public interface IXslTransformCacheExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Gets or sets the time value indicating how long transform objects will be kept inside the cache.
        /// </summary>
        TimeSpan CacheTimeToLive { get; set; }

        /// <summary>
        /// Looks up for a transform object in the cache and returns its metadata if the specified transform was found.
        /// </summary>
        /// <param name="transformName">The unique name of the transform object that is being used as a cache key.</param>
        /// <returns>An instance of the object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments, or null if the specified transform was not found.</returns>
        XslTransformSet Get(string transformName);

        /// <summary>
        /// Puts the specified transform object and its metadata into the underlying cache.
        /// </summary>
        /// <param name="transformName">The unique name of the transform object that will be used as a cache key.</param>
        /// <param name="transformSet">The object carrying the XSLT transformation metadata, XSLT transformation object and its arguments.</param>
        void Put(string transformName, XslTransformSet transformSet);
    }
    #endregion
}