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
    using System.Resources;

    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;

    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Provides a base class that can be extended by a custom implementation of a decoder pipeline component.
    /// </summary>
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    public abstract class DecoderComponentBase : CustomComponentBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DecoderComponentBase"/> using the specified resource manager.
        /// </summary>
        /// <param name="resourceManager">The resource manager object providing access to the component resources.</param>
        protected DecoderComponentBase(ResourceManager resourceManager)
            : base(resourceManager)
        {
        }
        #endregion
    }
}
