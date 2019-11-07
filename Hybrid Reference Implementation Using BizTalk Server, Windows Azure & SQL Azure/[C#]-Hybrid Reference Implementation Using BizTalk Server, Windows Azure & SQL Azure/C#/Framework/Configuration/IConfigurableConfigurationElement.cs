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
    #endregion

    /// <summary>
    /// Enables derived implementations of <see cref="System.Configuration.ConfigurationElement"/> to configure their properties when requested by external components at runtime.
    /// </summary>
    public interface IConfigurableConfigurationElement
    {
        /// <summary>
        /// Changes the current value of the specified configuration property to a new value.
        /// </summary>
        /// <param name="name">The name of the configuration property.</param>
        /// <param name="value">The new value that will be set on the specified configuration property.</param>
        void SetPropertyValue(string name, object value);
    }
}
