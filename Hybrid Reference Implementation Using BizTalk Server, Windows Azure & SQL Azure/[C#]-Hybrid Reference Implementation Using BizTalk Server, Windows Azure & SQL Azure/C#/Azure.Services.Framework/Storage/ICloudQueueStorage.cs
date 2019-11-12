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
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Defines a generics-aware abstraction layer for Windows Azure Queue storage.
    /// </summary>
    public interface ICloudQueueStorage : IDisposable
    {
        /// <summary>
        /// Creates a new queue.
        /// </summary>
        /// <param name="queueName">The name of a new queue.</param>
        /// <returns>A flag indicating whether or the queue did not exist and was therefore created.</returns>
        bool CreateQueue(string queueName);

        /// <summary>
        /// Puts a single message on a queue.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The target queue name on which message will be placed.</param>
        /// <param name="message">The payload to be put into a queue.</param>
        void Put<T>(string queueName, T message);

        /// <summary>
        /// Deletes a single message from a queue.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="message">The message to be deleted from a queue.</param>
        /// <returns>A flag indicating whether or not the specified message has actually been deleted.</returns>
        bool Delete<T>(T message);

        /// <summary>
        /// Clears all messages from the specified queue.
        /// </summary>
        /// <param name="queueName">The name of the queue that will be emptied.</param>
        void Clear(string queueName);

        /// <summary>
        /// Retrieves a single message from the specified queue and applies the default visibility timeout.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The name of the source queue.</param>
        /// <returns>An instance of the object that has been fetched from the queue.</returns>
        T Get<T>(string queueName);

        /// <summary>
        /// Gets a collection of messages from the specified queue and applies the specified visibility timeout.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The name of the source queue.</param>
        /// <param name="count">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The timeout during which retrieved messages will remain invisible on the queue.</param>
        /// <returns>The list of messages retrieved from the specified queue.</returns>
        IEnumerable<T> Get<T>(string queueName, int count, TimeSpan visibilityTimeout);

        /// <summary>
        /// Gets a collection of messages from the specified queue and applies the default visibility timeout.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The name of the source queue.</param>
        /// <param name="count">The number of messages to retrieve.</param>
        /// <returns>The list of messages retrieved from the specified queue.</returns>
        IEnumerable<T> Get<T>(string queueName, int count);

        /// <summary>
        /// Deletes the specified queue.
        /// </summary>
        /// <param name="queueName">The name of the queue to be deleted.</param>
        /// <returns>True if the queue name has been actually deleted, otherwise False.</returns>
        bool DeleteQueue(string queueName);

        /// <summary>
        /// Gets the approximate number of items in the specified queue.
        /// </summary>
        /// <param name="queueName">The name of the queue to be queried.</param>
        /// <returns>The approximate number of items in the queue.</returns>
        int GetCount(string queueName);
    }
}
