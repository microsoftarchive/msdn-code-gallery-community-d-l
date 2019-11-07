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
    using System.Collections;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Provides helper utility methods for operations with tracking activities.
    /// </summary>
    public static class ActivityTrackingUtility
    {
        /// <summary>
        /// Converts the collection of activity data items into a flat array.
        /// </summary>
        /// <param name="activity">The activity supplying data items.</param>
        /// <returns>An array containing activity item names and their values or a null reference if the specified activity doesn't contain any data items.</returns>
        public static object[] GetActivityData(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            IDictionary<string, object> activityData = activity.ActivityData;

            if (activityData != null)
            {
                ArrayList props = new ArrayList(activityData.Count * 2);

                foreach (KeyValuePair<string, object> activityItem in activityData)
                {
                    props.Add(activityItem.Key);
                    props.Add(activityItem.Value);
                }

                return props.ToArray();
            }
            else
            {
                return null;
            }
        }
    }
}
