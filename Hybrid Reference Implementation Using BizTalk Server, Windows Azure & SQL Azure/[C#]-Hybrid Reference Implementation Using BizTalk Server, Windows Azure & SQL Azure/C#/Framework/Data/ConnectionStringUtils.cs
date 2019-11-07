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
namespace Contoso.Cloud.Integration.Framework.Data
{
    #region Using references
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Data.SqlClient;
    #endregion

    /// <summary>
    /// Implements helper methods for parsing, cleaning up and dealing with SQL connection strings in general.
    /// </summary>
    internal static class ConnectionStringUtils
    {
        #region Private members
        private const string MaxRetryCountParamName = "MaxRetryCount";
        private const string RetryIntervalParamName = "RetryInterval";
        private const string RetryMinBackoffParamName = "RetryMinBackoff";
        private const string RetryMaxBackoffParamName = "RetryMaxBackoff";
        private const string RetryDeltaBackoffParamName = "RetryDeltaBackoff";
        private const string RetryIncrementParamName = "RetryIncrement";

        private const string RegexGroupParam = "param";
        private const string RegexGroupValue = "value";

        private static readonly string RetrySettingsParserRegex = String.Format(@"((?<{6}>{0}|{1}|{2}|{3}|{4}|{5})=(?<{7}>[0-9]+|$)(;+|$))+", MaxRetryCountParamName, RetryIntervalParamName, RetryMinBackoffParamName, RetryMaxBackoffParamName, RetryDeltaBackoffParamName, RetryIncrementParamName, RegexGroupParam, RegexGroupValue);
        private static readonly Regex retrySettingsParser = new Regex(RetrySettingsParserRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        #endregion

        #region Public methods
        /// <summary>
        /// Extracts the retry settings from the specified SQL connection string and returns a retry policy which corresponds to these settings.
        /// </summary>
        /// <param name="connectionString">The connection string containing the retry settings.</param>
        /// <returns>An instance of RetryPolicy containing the configuration settings captured from the connection string if retry settings were found, otherwise null.</returns>
        public static RetryPolicy GetRetryPolicy(string connectionString)
        {
            RetryPolicy retryPolicy = null;

            if (!String.IsNullOrEmpty(connectionString))
            {
                // Create a list of all retry settings initialized with default value of zero.
                IDictionary<string, int> retrySettings = new Dictionary<string, int>(6);

                retrySettings.Add(MaxRetryCountParamName, 0);
                retrySettings.Add(RetryIntervalParamName, 0);
                retrySettings.Add(RetryMinBackoffParamName, 0);
                retrySettings.Add(RetryMaxBackoffParamName, 0);
                retrySettings.Add(RetryDeltaBackoffParamName, 0);
                retrySettings.Add(RetryIncrementParamName, 0);

                // Parse the connection string and extract matching patterns.
                MatchCollection matches = retrySettingsParser.Matches(connectionString);

                if (matches != null && matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        Group paramNames = match.Groups[RegexGroupParam];
                        Group paramValues = match.Groups[RegexGroupValue];

                        // Should check both boundaries while looping to prevent going out of bound.
                        for (int i = 0; i < paramNames.Captures.Count && i < paramValues.Captures.Count; i++)
                        {
                            // Grab the parameter name and value and place it into the list.
                            retrySettings[paramNames.Captures[i].Value] = Convert.ToInt32(paramValues.Captures[i].Value);
                        }
                    }
                }

                // Now it's time to make a decision as to what retry policy is required. First, check for any backoff parameters.
                if (retrySettings[RetryMinBackoffParamName] != 0 || retrySettings[RetryMaxBackoffParamName] != 0 || retrySettings[RetryDeltaBackoffParamName] != 0)
                {
                    retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(retrySettings[MaxRetryCountParamName], TimeSpan.FromMilliseconds(retrySettings[RetryMinBackoffParamName]), TimeSpan.FromMilliseconds(retrySettings[RetryMaxBackoffParamName]), TimeSpan.FromMilliseconds(retrySettings[RetryDeltaBackoffParamName]));
                }
                // Check if both RetryInterval and RetryIncrement were specified.
                else if (retrySettings[RetryIntervalParamName] != 0 && retrySettings[RetryIncrementParamName] != 0)
                {
                    retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(retrySettings[MaxRetryCountParamName], TimeSpan.FromMilliseconds(retrySettings[RetryIntervalParamName]), TimeSpan.FromMilliseconds(retrySettings[RetryIncrementParamName]));
                }
                // Check if at least RetryInterval was specified.
                else if (retrySettings[RetryIntervalParamName] != 0)
                {
                    retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(retrySettings[MaxRetryCountParamName], TimeSpan.FromMilliseconds(retrySettings[RetryIntervalParamName]));
                }
            }

            return retryPolicy;
        }

        /// <summary>
        /// Cleans up the specified connection string by removing any settings related to a retry policy.
        /// </summary>
        /// <param name="connectionString">The connection string which may contain the retry settings.</param>
        /// <returns>A clean copy of the connection string which is free from all settings related to a retry policy.</returns>
        public static string RemoveRetrySettings(string connectionString)
        {
            string newConnectionString = null;

            if (!String.IsNullOrEmpty(connectionString))
            {
                newConnectionString = retrySettingsParser.Replace(connectionString, (match) =>
                {
                    return String.Empty;
                });
            }

            return newConnectionString;
        }

        /// <summary>
        /// Builds a connection string which adheres to the requirements of the SQL Azure infrastructure.
        /// </summary>
        /// <param name="serverName">The DNS name of the SQL Azure database virtual server</param>
        /// <param name="databaseName">The name of the SQL Azure database</param>
        /// <param name="userName">The user name who has permissions to access the specified SQL Azure database</param>
        /// <param name="password">The user password</param>
        /// <returns></returns>
        public static string ConstructSqlAzureConnectionString(string serverName, string databaseName, string userName, string password)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = serverName;
            sqlConnectionStringBuilder.UserID = userName;
            sqlConnectionStringBuilder.Password = password;
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.InitialCatalog = databaseName;
            sqlConnectionStringBuilder.MultipleActiveResultSets = false;
            sqlConnectionStringBuilder.AsynchronousProcessing = true;

            // Required by SQL Azure security infrastructure.
            sqlConnectionStringBuilder.Encrypt = true;
            sqlConnectionStringBuilder.TrustServerCertificate = false;
            sqlConnectionStringBuilder.MinPoolSize = 0;
            sqlConnectionStringBuilder.MaxPoolSize = 100;

            return sqlConnectionStringBuilder.ConnectionString;
        }
        #endregion
    }
}
