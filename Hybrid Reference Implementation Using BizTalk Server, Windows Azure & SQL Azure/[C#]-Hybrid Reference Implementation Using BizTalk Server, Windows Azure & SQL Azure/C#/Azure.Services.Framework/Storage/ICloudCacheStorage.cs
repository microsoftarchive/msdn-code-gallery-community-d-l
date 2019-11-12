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
    #endregion

    /// <summary>
    /// Defines a generics-aware abstraction layer for Windows Azure Caching Service.
    /// </summary>
    public interface ICloudCacheStorage : IDisposable
    {
        // This interface can be enhanced with operations that are specific to interoperability with the caching service.
    }
}