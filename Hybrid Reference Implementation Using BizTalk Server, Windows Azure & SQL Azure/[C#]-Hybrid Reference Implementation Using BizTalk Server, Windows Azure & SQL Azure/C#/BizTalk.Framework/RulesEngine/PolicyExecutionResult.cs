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
    using System.Collections.Generic;
    using System.Text;
    #endregion

    /// <summary>
    /// Provides the means of reporting on Business Rules policy execution.
    /// </summary>
    [Serializable]
    public sealed class PolicyExecutionResult
    {
        #region Private members
        private readonly string policyName;
        private readonly Version policyVersion;
        private readonly bool success;
        private readonly IList<Exception> errors; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="PolicyExecutionResult"/> object for the specified Business Rules policy name.
        /// Assumes a successful execution.
        /// </summary>
        /// <param name="policyName">The name of the executed Business Rules policy.</param>
        private PolicyExecutionResult(string policyName)
        {
            this.policyName = policyName;
            this.errors = new List<Exception>();
            this.success = true;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="PolicyExecutionResult"/> object for the specified Business Rules policy name and its execution status.
        /// </summary>
        /// <param name="policyName">The name of the executed Business Rules policy.</param>
        /// <param name="success">A flag indicating whether or not policy execution was successful.</param>
        public PolicyExecutionResult(string policyName, bool success)
            : this(policyName)
        {
            this.success = success;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="PolicyExecutionResult"/> object for the specified Business Rules policy name and its actual version number.
        /// Assumes a successful execution.
        /// </summary>
        /// <param name="policyName">The name of the executed Business Rules policy.</param>
        /// <param name="majorRevision">The major revision of the actual version number of the executed Business Rules policy.</param>
        /// <param name="minorRevision">The minor revision of the actual version number of the executed Business Rules policy.</param>
        public PolicyExecutionResult(string policyName, int majorRevision, int minorRevision)
            : this(policyName)
        {
            this.policyVersion = new Version(majorRevision, minorRevision);
            this.success = true;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="PolicyExecutionResult"/> object for the specified Business Rules policy name.
        /// Assumes an unsuccessful execution.
        /// </summary>
        /// <param name="policyName">The name of the executed Business Rules policy.</param>
        /// <param name="ex">The exception that prevented the policy from being successfully executed.</param>
        public PolicyExecutionResult(string policyName, Exception ex)
            : this(policyName)
        {
            this.success = false;
            this.errors.Add(ex);
        } 
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the name of the executed Business Rules policy.
        /// </summary>
        public string PolicyName
        {
            get { return this.policyName; }
        }

        /// <summary>
        /// Returns the actual version number of the executed Business Rules policy.
        /// </summary>
        public Version PolicyVersion
        {
            get { return this.policyVersion; }
        }

        /// <summary>
        /// Returns a flag indicating whether or not policy execution was successful.
        /// </summary>
        public bool Success
        {
            get { return this.success; }
        }

        /// <summary>
        /// Returns the list of exceptions that prevented the policy from being successfully executed.
        /// </summary>
        public IList<Exception> Errors
        {
            get { return this.errors; }
        }  
        #endregion
    }
}
