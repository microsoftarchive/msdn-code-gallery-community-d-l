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
    using System.IO;
    using System.Runtime.Serialization;
    #endregion

    /// <summary>
    /// Defines a contract that must be supported by a component which performs serialization and 
    /// deserialization of storage objects such as Azure queue items, blobs and table entries.
    /// </summary>
    public interface ICloudStorageEntitySerializer
    {
        /// <summary>
        /// Serializes the object to the specified stream.
        /// </summary>
        /// <param name="instance">The object instance to be serialized.</param>
        /// <param name="target">The destination stream into which the serialized object will be written.</param>
        void Serialize(object instance, Stream target);

        /// <summary>
        /// Deserializes the object from specified data stream.
        /// </summary>
        /// <param name="source">The source stream from which serialized object will be consumed.</param>
        /// <param name="type">The type of the object that will be deserialized.</param>
        /// <returns>The deserialized object instance.</returns>
        object Deserialize(Stream source, Type type);
    }
}
