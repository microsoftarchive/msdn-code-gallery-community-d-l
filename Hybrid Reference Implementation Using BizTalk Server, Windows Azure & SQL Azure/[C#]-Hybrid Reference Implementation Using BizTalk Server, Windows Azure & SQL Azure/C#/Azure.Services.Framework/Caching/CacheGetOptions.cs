//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Caching
{
    #region Using references
    using System;
    #endregion

    /// <summary>
    /// Defines a set of options that apply when reading data from a cache.
    /// </summary>
    public sealed class CacheGetOptions
    {
        #region Public members
        /// <summary>
        /// Gets the default options that apply when reading data from a cache.
        /// </summary>
        public static readonly CacheGetOptions Default = new CacheGetOptions();
        #endregion
        
        #region Public properties
        /// <summary>
        /// Gets or sets the flag indicating that a cache item must be automatically removed from the cache after it was successfully retrieved.
        /// </summary>
		public bool AutoRemove { get; set; }
    	#endregion    
    }
}
