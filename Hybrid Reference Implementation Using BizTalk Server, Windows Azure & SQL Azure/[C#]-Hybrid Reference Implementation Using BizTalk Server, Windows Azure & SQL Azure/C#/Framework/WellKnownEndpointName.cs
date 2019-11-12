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
namespace Contoso.Cloud.Integration.Framework
{
    #region Using statements
    using System;
    #endregion

    /// <summary>
    /// Provides a central place for storing the well-known Azure Service Bus endpoint identifiers.
    /// </summary>
    public static class WellKnownEndpointName
    {
        /// <summary>
        /// The GenericCloudRequestOnRamp endpoint identifier.
        /// </summary>
        public const string GenericCloudRequestOnRamp = "GenericCloudRequestOnRamp";

        /// <summary>
        /// The GenericCloudRequestResponseOnRamp endpoint identifier.
        /// </summary>
        public const string GenericCloudRequestResponseOnRamp = "GenericCloudRequestResponseOnRamp";

        /// <summary>
        /// The ScalableTransformService endpoint identifier.
        /// </summary>
        public const string ScalableTransformService = "ScalableTransformService";

        /// <summary>
        /// The ScalableTransformService endpoint identifier.
        /// </summary>
        public const string InterRoleCommunication = "InterRoleCommunication";
    }
}
