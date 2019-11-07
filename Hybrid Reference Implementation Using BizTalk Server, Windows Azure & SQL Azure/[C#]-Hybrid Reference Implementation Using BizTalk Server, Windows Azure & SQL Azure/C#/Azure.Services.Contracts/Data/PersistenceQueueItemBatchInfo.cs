//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains service and data contract definitions.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Contracts.Data
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements a Rules Engine fact carrying the metadata that describes a batch in the item stored in the Persistence Queue.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class PersistenceQueueItemBatchInfo
    {
        #region Public properties
        /// <summary>
        /// Represents a collection of XPath queries the results of which form a header of the batch.
        /// </summary>
        [DataMember]
        public List<string> HeaderSegments { get; private set; }

        /// <summary>
        /// Represents a collection of XPath queries the results of which form a body of the batch.
        /// </summary>
        [DataMember]
        public List<string> BodySegments { get; private set; }

        /// <summary>
        /// Represents a collection of XPath queries the results of which form a footer of the batch.
        /// </summary>
        [DataMember]
        public List<string> FooterSegments { get; private set; }

        /// <summary>
        /// Represent an XPath query that references a single item in the batch.
        /// </summary>
        [DataMember]
        public string BodyItemXPath { get; set; }

        /// <summary>
        /// Represent an XPath query that returns the number of items in the batch.
        /// </summary>
        [DataMember]
        public string BodyItemCountXPath { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instances of the <see cref="PersistenceQueueItemBatchInfo"/> object.
        /// </summary>
        public PersistenceQueueItemBatchInfo()
        {
            HeaderSegments = new List<string>();
            BodySegments = new List<string>();
            FooterSegments = new List<string>();
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new XPath query describing the location of batch header.
        /// </summary>
        /// <param name="xPath">The XPath expression.</param>
        public void AddHeaderSegment(string xPath)
        {
            HeaderSegments.Add(xPath);
        }

        /// <summary>
        /// Adds a new XPath query describing the location of batch body.
        /// </summary>
        /// <param name="xPath">The XPath expression.</param>
        public void AddBodySegment(string xPath)
        {
            BodySegments.Add(xPath);
        }

        /// <summary>
        /// Adds a new XPath query describing the location of batch footer.
        /// </summary>
        /// <param name="xPath">The XPath expression.</param>
        public void AddFooterSegment(string xPath)
        {
            FooterSegments.Add(xPath);
        } 
        #endregion
    }
}
