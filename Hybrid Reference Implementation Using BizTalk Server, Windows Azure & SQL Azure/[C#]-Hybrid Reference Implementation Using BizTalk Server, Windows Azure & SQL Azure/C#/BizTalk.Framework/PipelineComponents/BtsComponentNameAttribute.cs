//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.PipelineComponents
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    /// <summary>
    /// Enables declaratively assigning a name to the custom BizTalk pipeline component implementations.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class BtsComponentNameAttribute : Attribute
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="BtsComponentNameAttribute"/> object using the specified component name.
        /// </summary>
        /// <param name="componentName">Either a resource key that returns the localized component name or the actual component name if resources are not being used.</param>
        public BtsComponentNameAttribute(string componentName)
        {
            this.ComponentName = componentName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a resource key containing the localized component name or the actual component name if resources are not being used.
        /// </summary>
        public string ComponentName
        {
            get;
            private set;
        }
        #endregion
    }
}
