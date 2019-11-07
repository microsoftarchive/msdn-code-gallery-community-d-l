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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Storage
{
    #region Using references
    using System;
    
    using Microsoft.WindowsAzure.StorageClient;
    #endregion

    /// <summary>
    /// Represents a set of behavior options for a specific request related to Azure blob containers.
    /// </summary>
    public class ContainerRequestOptions
    {
        /// <summary>
        /// Gets or sets the level of details that will be included when listing the containers in this storage account.
        /// </summary>
        public ContainerListingDetails ListingDetails { get; set; }

        /// <summary>
        /// Gets or sets a prefix that will be used when looking for containers whose names begin with the specified prefix.
        /// </summary>
        public string NamePrefix { get; set; }
    }
}
