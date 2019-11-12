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
    using System.Runtime.Serialization;
    using System.Collections.Specialized;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Defines a generic exception for the user code running on Windows Azure. The exceptions of this type will include environmental details
    /// such as Azure role name and instance ID to be able to isolate an exception to a particular role instance.
    /// </summary>
    [Serializable]
    public class CloudApplicationException : ApplicationException
    {
        #region Private members
        private readonly NameValueCollection exceptionInfo = new NameValueCollection();
        private readonly List<Exception> errors = new List<Exception>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudApplicationException"/> class.
        /// </summary>
        public CloudApplicationException() : base() 
        {
            CollectAdditionalInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudApplicationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public CloudApplicationException(string message) : base(message) 
        {
            CollectAdditionalInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudApplicationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="errors">A list of exceptions associated with the error.</param>
        public CloudApplicationException(string message, IEnumerable<Exception> errors) : this(message)
        {
            this.errors.AddRange(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudApplicationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public CloudApplicationException(string message, Exception innerException) : base(message, innerException) 
        {
            CollectAdditionalInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudApplicationException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected CloudApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CollectAdditionalInfo();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the custom information about the error. The content of this collection will be included into the error details.
        /// </summary>
        public NameValueCollection AdditionalInformation
        {
            get { return this.exceptionInfo; }
        }

        /// <summary>
        /// Returns the list of exceptions associated with the error.
        /// </summary>
        public IList<Exception> Errors
        {
            get { return this.errors; }
        }
        #endregion

        #region Private methods
        private void CollectAdditionalInfo()
        {
            this.exceptionInfo.Add(Resources.CloudApplicationInfoRoleNameProperty, CloudEnvironment.CurrentRoleName);
            this.exceptionInfo.Add(Resources.CloudApplicationInfoRoleInstanceIdProperty, CloudEnvironment.CurrentRoleInstanceId);
        }
        #endregion
    }
}
