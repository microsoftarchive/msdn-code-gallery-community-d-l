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
namespace Contoso.Cloud.Integration.BizTalk.Core.RulesEngine
{
    #region Using references
    using System;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    using System.Text;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides the means of referencing to a Business Rules policy by its name, version number and parameters when invoking the policy.
    /// </summary>
    [Serializable]
    public sealed class PolicyExecutionInfo
    {
        #region Private members
        private readonly IDictionary<string, object> parameters;
        private readonly string policyName;

        /// <summary>
        /// The policy version number. If version is not provided, the latest version will be invoked.
        /// </summary>
        private readonly Version policyVersion;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="PolicyExecutionInfo"/> object for the specified Business Rules policy name.
        /// </summary>
        /// <param name="policyName">The name of the Business Rules policy.</param>
        public PolicyExecutionInfo(string policyName) : this(policyName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="PolicyExecutionInfo"/> object for the specified Business Rules policy name and its specific version number.
        /// If version is not provided, the latest version will be invoked.
        /// </summary>
        /// <param name="policyName">The name of the Business Rules policy.</param>
        /// <param name="policyVersion">The version number of the Business Rules policy.</param>
        public PolicyExecutionInfo(string policyName, Version policyVersion)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");

            this.policyName = policyName;
            this.policyVersion = policyVersion;
            this.parameters = new Dictionary<string, object>();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the name of the Business Rules policy.
        /// </summary>
        public string PolicyName
        {
            get { return this.policyName; }
        }

        /// <summary>
        /// Returns the version number of the Business Rules policy. If version is not provided, the latest version will be invoked.
        /// </summary>
        public Version PolicyVersion
        {
            get { return this.policyVersion; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns policy execution parameter by its name.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The value associated with the parameter or a null reference if the specified parameter was not found.</returns>
        public object GetParameter(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            object value = null;
            this.parameters.TryGetValue(name, out value);

            return value;
        }

        /// <summary>
        /// Returns policy execution parameter by its name assuming it's value can be safely converted into a string.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The string value associated with the parameter or a null reference if the specified parameter was not found.</returns>
        public string GetParameterAsString(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            object value = null;
            this.parameters.TryGetValue(name, out value);

            return value != null ? Convert.ToString(value) : null;
        }

        /// <summary>
        /// Adds policy execution parameter.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value associated with the parameter.</param>
        public void AddParameter(string name, object value)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            this.parameters[name] = value;
        }

        /// <summary>
        /// Adds policy execution parameters.
        /// </summary>
        /// <param name="parameters">A collection of parameters that will be added.</param>
        public void AddParameters(NameValueCollection parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (string key in parameters.Keys)
                {
                    AddParameter(key, parameters[key]);
                }
            }
        }

        /// <summary>
        /// Removes all policy execution parameters.
        /// </summary>
        public void ClearParameters()
        {
            this.parameters.Clear();
        }
        #endregion
    }
}