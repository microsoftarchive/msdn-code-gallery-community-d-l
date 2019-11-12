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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Storage
{
    #region Using references
    using System;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements an object holding metadata related to a large message which is stored in 
    /// the overflow message store such as Windows Azure blob container.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    internal sealed class LargeQueueMessageInfo
    {
        #region Private members
        private const string ContainerNameFormat = "LargeMsgCache-{0}";
        #endregion

        #region Piblic properties
        /// <summary>
        /// Returns the name of the blob container holding the large message payload.
        /// </summary>
        [DataMember]
        public string ContainerName { get; private set; }

        /// <summary>
        /// Returns the unique reference to a blob holding the large message payload.
        /// </summary>
        [DataMember]
        public string BlobReference { get; private set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// The default constructor is inaccessible, the object needs to be instantiated using its Create method.
        /// </summary>
        private LargeQueueMessageInfo()
        {
        }
        #endregion

        #region Piblic methods
        /// <summary>
        /// Creates a new instance of the large message metadata object and allocates a globally unique blob reference.
        /// </summary>
        /// <param name="queueName">The name of the Windows Azure queue on which a reference to the large message will be stored.</param>
        /// <returns>The instance of the large message metadata object.</returns>
        public static LargeQueueMessageInfo Create(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");

            return new LargeQueueMessageInfo() { ContainerName = String.Format(ContainerNameFormat, queueName), BlobReference = Guid.NewGuid().ToString("N") };
        }
        #endregion
    }
}
