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
    #region Using references
    using System;
    using System.ServiceModel;
    #endregion

    /// <summary>
    /// Provides value-add extension methods for objects implementing the <see cref="System.ServiceModel.ICommunicationObject"/> interface.
    /// </summary>
    public static class CommunicationObjectExtensionMethods
    {
        /// <summary>
        /// Performs a safe close of the current communication object instance.
        /// </summary>
        /// <param name="commObj">The instance of the object implementing the <see cref="System.ServiceModel.ICommunicationObject"/> interface.</param>
        public static void SafeClose(this ICommunicationObject commObj)
        {
            try
            {
                if (commObj.State == CommunicationState.Opened)
                {
                    commObj.Close();
                }
                else
                {
                    commObj.Abort();
                }
            }
            catch
            {
                try
                {
                    commObj.Abort();
                }
                catch
                {
                    // It is acceptable to ignore any exceptions if abort falls through.
                }
            }
        }

        /// <summary>
        /// Verifies whether the specified communication object is in a valid state. If a communication object is not in a valid state, it needs to be recreated.
        /// </summary>
        /// <param name="commObj">The instance of the object implementing the <see cref="System.ServiceModel.ICommunicationObject"/> interface.</param>
        /// <returns>True if the specified communication object is in a valid state, otherwise false.</returns>
        public static bool IsValidState(this ICommunicationObject commObj)
        {
            return commObj != null && commObj.State != CommunicationState.Closed && commObj.State != CommunicationState.Closing && commObj.State != CommunicationState.Faulted;
        }
    }
}