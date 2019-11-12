//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Persistence worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Contracts
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a contract supported by all implementations of a persistence queue.
    /// </summary>
    public interface IPersistenceQueue : IDisposable
    {
        /// <summary>
        /// Opens the specified persistence queue.
        /// </summary>
        /// <param name="queueName">The name of the persistence queue that needs to be opened.</param>
        void Open(string queueName);

        /// <summary>
        /// Persists the specified stream of data into the queue.
        /// </summary>
        /// <param name="data">The stream containing the data to be persisted.</param>
        /// <returns>A data transfer object carrying the details of the persisted queue item.</returns>
        PersistenceQueueItemInfo Enqueue(Stream data);

        /// <summary>
        /// Retrieves data from the specified queue item stored in the persistence queue. Doesn't remove the item from the queue.
        /// </summary>
        /// <param name="queueItemId">The unique identity of the queue item.</param>
        /// <param name="headerXPath">The optional set of XPath expressions defining a header portion of the queue data.</param>
        /// <param name="bodyXPath">The optional set of XPath expressions defining a body portion of the queue data.</param>
        /// <param name="footerXPath">The optional set of XPath expressions defining a footer portion of the queue data.</param>
        /// <param name="nsManager">The optional XML namespace manager that will be used for XML namespace resolution.</param>
        /// <returns>An instance of the XML reader that provides non-cached, forward-only access to queue item data.</returns>
        XmlReader DequeueXmlData(Guid queueItemId, IEnumerable<string> headerXPath, IEnumerable<string> bodyXPath, IEnumerable<string> footerXPath, XmlNamespaceManager nsManager);
        
        /// <summary>
        /// Performs a query against the XML data stored in the queue item.
        /// </summary>
        /// <param name="queueItemId">The unique identity of the queue item.</param>
        /// <param name="xPathCollection">One or more XPath expressions which will be invoked against the queue item's XML data.</param>
        /// <param name="nsManager">The XML namespace manager that will be used for XML namespace resolution.</param>
        /// <returns>An instance of the XML reader that provides non-cached, forward-only access to queue item data.</returns>
        XmlReader QueryXmlData(Guid queueItemId, IEnumerable<string> xPathCollection, XmlNamespaceManager nsManager);

        /// <summary>
        /// Removes the specified queue item from the persistence queue.
        /// </summary>
        /// <param name="queueItemId">The unique identity of the queue item.</param>
        /// <returns>A flag indicating whether or not the queue item has been actually deleted.</returns>
        bool Remove(Guid queueItemId);

        /// <summary>
        /// Closes the currently open persistence queue.
        /// </summary>
        void Close();
    }
}
