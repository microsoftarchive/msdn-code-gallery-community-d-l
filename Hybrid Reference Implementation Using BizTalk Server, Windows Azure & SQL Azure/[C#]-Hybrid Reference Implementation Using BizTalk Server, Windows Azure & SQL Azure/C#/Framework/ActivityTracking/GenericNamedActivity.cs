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
namespace Contoso.Cloud.Integration.Framework.ActivityTracking
{
    #region Using references
    using System;
    #endregion

    /// <summary>
    /// Implements a generic tracking activity identified by its name.
    /// </summary>
    public sealed class GenericNamedActivity : ActivityBase
    {
        #region Private members
        private readonly string activityName;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="GenericNamedActivity"/> object using the specified tracking activity name.
        /// </summary>
        /// <param name="activityName">The name of the tracking activity.</param>
        private GenericNamedActivity(string activityName)
        {
            this.activityName = activityName;
        }
        /// <summary>
        /// Initializes a new instance of a <see cref="GenericNamedActivity"/> object using the specified tracking activity name and unique activity ID.
        /// </summary>
        /// <param name="activityName">The name of the tracking activity.</param>
        /// <param name="activityID">The ID of the BAM activity.</param>
        public GenericNamedActivity(string activityName, string activityID) : this(activityName)
        {
            this.ActivityID = activityID;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the name of the tracking activity.
        /// </summary>
        public override string ActivityName
        {
            get { return this.activityName; }
        }
        #endregion
    }
}
