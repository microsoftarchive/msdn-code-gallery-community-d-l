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
    using System.Drawing;
    #endregion

    /// <summary>
    /// Enables declaratively assigning a toolbox icon to the custom BizTalk pipeline component implementations.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class BtsComponentToolboxIconAttribute : Attribute
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="BtsComponentToolboxIconAttribute"/> object using the specified icon bitmap.
        /// </summary>
        /// <param name="iconBitmap">The bitmap that will be visualized on the toolbox as pipeline component's icon.</param>
        public BtsComponentToolboxIconAttribute(Bitmap iconBitmap)
        {
            this.IconBitmap = iconBitmap;
            this.IconHandle = iconBitmap.GetHicon();
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="BtsComponentToolboxIconAttribute"/> object using the specified resource containing the icon bitmap.
        /// </summary>
        /// <param name="iconResourceName">The resource key referencing the icon bitmap.</param>
        public BtsComponentToolboxIconAttribute(string iconResourceName)
        {
            this.IconResourceName = iconResourceName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the resource key referencing the icon bitmap.
        /// </summary>
        public string IconResourceName
        {
            get;
            private set;
        }

        /// <summary>
        /// The icon bitmap's handle.
        /// </summary>
        public IntPtr IconHandle
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the bitmap that will be visualized on the toolbox as pipeline component's icon.
        /// </summary>
        public Bitmap IconBitmap
        {
            get;
            private set;
        }
        #endregion
    }
}
