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
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Security.Cryptography;

    using Microsoft.WindowsAzure.StorageClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides helper methods to enable cloud application code to invoke common, globally accessible functions.
    /// </summary>
    public static class CloudUtility
    {
        #region Private members
        private static readonly Regex containerNameRegex = new Regex(Resources.ContainerNameCheckRegEx, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex containerNameDashRegex = new Regex(Resources.ContainerNameDashRuleCheckRegEx, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex containerNameCleanupRegex = new Regex(Resources.ContainerNameCleanupRegEx, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        
        private static readonly long optimalCacheItemSize = 8 * 1024 * 1024;
        #endregion

        #region Public methods
        /// <summary>
        /// Verifies whether or not the specified message size can be accommodated in a Windows Azure queue.
        /// </summary>
        /// <param name="size">The message size value to be inspected.</param>
        /// <returns>True if the specified size can be accommodated in a Windows Azure queue, otherwise false.</returns>
        public static bool IsAllowedQueueMessageSize(long size)
        {
            return size >= 0 && size <= (CloudQueueMessage.MaxMessageSize - 1) / 4 * 3;
        }

        /// <summary>
        /// Determines whether or not the specified value can be considered as optimal when storing an item of the given size in the cache.
        /// </summary>
        /// <param name="size">The item size value to be inspected.</param>
        /// <returns>True if the specified size can be considered as optimal, otherwise false.</returns>
        public static bool IsOptimalCacheItemSize(long size)
        {
            return size >= 0 && size <= optimalCacheItemSize;
        }

        /// <summary>
        /// Ensures that the specified container name doesn't contain any invalid characters and is compliant with Azure Storage resource names.
        /// More information is on http://msdn.microsoft.com/en-us/library/dd135715.aspx.
        /// </summary>
        /// <param name="containerName">The original name.</param>
        /// <returns>The normalized name that is compliant with Azure Storage resource names.</returns>
        public static string GetSafeContainerName(string containerName)
        {
            if (!String.IsNullOrEmpty(containerName))
            {
                // Rule 1: All letters in a container name must be lowercase.
                string safeName = containerName.ToLowerInvariant();

                // Rule 2: Container names must be from 3 through 63 characters long.
                if (safeName.Length < 3 || safeName.Length > 63)
                {
                    throw new ArgumentException(ExceptionMessages.ContainerNameTooLong, "containerName");
                }

                // Rule 3: Container names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.
                if (!containerNameRegex.IsMatch(safeName))
                {
                    throw new ArgumentException(ExceptionMessages.ContainerNameContainsInvalidCharacters, "containerName");
                }

                // Rule 4: Every dash (-) character must be immediately preceded and followed by a letter or number.
                if (!containerNameDashRegex.IsMatch(safeName))
                {
                    throw new ArgumentException(ExceptionMessages.ContainerNameInvalidDashSequence, "containerName");
                }

                return safeName;
            }
            else
            {
                return containerName;
            }
        }

        /// <summary>
        /// Removes all unsupported characters from the specified container name.
        /// </summary>
        /// <param name="containerName">The original name.</param>
        /// <returns>The new name that does not contain any unsupported characters.</returns>
        public static string CleanupContainerName(string containerName)
        {
            if (!String.IsNullOrEmpty(containerName))
            {
                return containerNameCleanupRegex.Replace(containerName, (match) => { return "-"; });
            }
            else
            {
                return containerName;
            }
        }
        #endregion

        #region Internal methods
        internal static TraceListener GetDevFabricTraceListener()
        {
            return GetDevFabricTraceListener(Trace.Listeners);
        }

        internal static TraceListener GetDevFabricTraceListener(TraceListenerCollection listeners)
        {
            var result = from TraceListener listener in listeners.Cast<TraceListener>()
                         where IsDevFabricTraceListener(listener)
                         select listener;

            return result.FirstOrDefault();
        }
        #endregion

        #region Private methods
        private static bool IsDevFabricTraceListener(TraceListener listener)
        {
            return String.Compare(listener.GetType().Name, Resources.DevelopmentFabricTraceListenerName, true) == 0;
        }
        #endregion
    }
}
