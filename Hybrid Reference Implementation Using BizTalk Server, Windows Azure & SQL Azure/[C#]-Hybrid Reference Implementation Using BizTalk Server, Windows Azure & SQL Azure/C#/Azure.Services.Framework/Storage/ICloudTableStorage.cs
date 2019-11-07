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

    using Microsoft.WindowsAzure.StorageClient;
    #endregion

    /// <summary>
    /// Defines a generics-aware abstraction layer for Windows Azure Table storage.
    /// </summary>
    public interface ICloudTableStorage : IDisposable
    {
        /// <summary>
        /// Creates a new table if it does not already exist.
        /// </summary>
        /// <param name="tableName">The name of the table to be created.</param>
        /// <returns>A flag indicating whether or not the table has actually been created.</returns>
        bool CreateTable(string tableName);

        /// <summary>
        /// Deletes a table if it exists.
        /// </summary>
        /// <param name="tableName">The name of the table to be deleted.</param>
        /// <returns>A flag indicating whether or not the table has actually been deleted.</returns>
        bool DeleteTable(string tableName);

        /// <summary>
        /// Gets a collection of entities from the specified table.
        /// </summary>
        /// <typeparam name="T">The type of the entity stored in the table.</typeparam>
        /// <param name="tableName">The name of the source table.</param>
        /// <returns>The list of entities retrieved from the specified table.</returns>
        IEnumerable<T> Get<T>(string tableName);

        /// <summary>
        /// Adds the specified entity into the table.
        /// </summary>
        /// <typeparam name="T">The type of the table entity.</typeparam>
        /// <param name="entity">The instance of the entity to be added into the table.</param>
        /// <param name="tableName">The name of the table into which the specified entity will be added.</param>
        /// <returns>True if the entity has been successfully added, otherwise False.</returns>
        bool Add<T>(T entity, string tableName);

        /// <summary>
        /// Updates the specified entity stored in the table.
        /// </summary>
        /// <typeparam name="T">The type of the table entity.</typeparam>
        /// <param name="entity">The instance of the entity to be updated.</param>
        /// <param name="tableName">The name of the table containing the entity to be updated.</param>
        /// <returns>True if the entity has been successfully updated, otherwise False.</returns>
        bool Update<T>(T entity, string tableName);

        /// <summary>
        /// Deletes the specified entity stored in the table.
        /// </summary>
        /// <typeparam name="T">The type of the table entity.</typeparam>
        /// <param name="entity">The instance of the entity to be deleted.</param>
        /// <param name="tableName">The name of the table containing the entity to be deleted.</param>
        /// <returns>True if the entity has been successfully deleted, otherwise False.</returns>
        bool Delete<T>(T entity, string tableName);
    }
}
