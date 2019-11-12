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
    using System.IO.Compression;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides a default implementation of ICloudStorageEntitySerializer which performs serialization and 
    /// deserialization of storage objects such as Azure queue items, blobs and table entries.
    /// </summary>
    internal sealed class CloudStorageEntitySerializer : ICloudStorageEntitySerializer
    {
        #region ICloudStorageEntitySerializer implementation
        /// <summary>
        /// Serializes the object to the specified stream.
        /// </summary>
        /// <param name="instance">The object instance to be serialized.</param>
        /// <param name="target">The destination stream into which the serialized object will be written.</param>
        public void Serialize(object instance, Stream target)
        {
            Guard.ArgumentNotNull(instance, "instance");
            Guard.ArgumentNotNull(target, "target");

            XDocument xmlDocument = null;
            XElement xmlElement = null;
            XmlDocument domDocument = null;
            XmlElement domElement = null;

            if ((xmlElement = (instance as XElement)) != null)
            {
                // Handle XML element serialization using separate technique.
                SerializeXml<XElement>(xmlElement, target, (xml, writer) => { xml.Save(writer); });
            }
            else if ((xmlDocument = (instance as XDocument)) != null)
            {
                // Handle XML document serialization using separate technique.
                SerializeXml<XDocument>(xmlDocument, target, (xml, writer) => { xml.Save(writer); });
            }
            else if ((domDocument = (instance as XmlDocument)) != null)
            {
                // Handle XML DOM document serialization using separate technique.
                SerializeXml<XmlDocument>(domDocument, target, (xml, writer) => { xml.Save(writer); });
            }
            else if ((domElement = (instance as XmlElement)) != null)
            {
                // Handle XML DOM element serialization using separate technique.
                SerializeXml<XmlElement>(domElement, target, (xml, writer) => { xml.WriteTo(writer); });
            }
            else
            {
                var serializer = GetXmlSerializer(instance.GetType());

                using (var compressedStream = new DeflateStream(target, CompressionMode.Compress, true))
                using (var xmlWriter = XmlDictionaryWriter.CreateBinaryWriter(compressedStream, null, null, false))
                {
                    serializer.WriteObject(xmlWriter, instance);
                }
            }
        }

        /// <summary>
        /// Deserializes the object from specified data stream.
        /// </summary>
        /// <param name="source">The source stream from which serialized object will be consumed.</param>
        /// <param name="type">The type of the object that will be deserialized.</param>
        /// <returns>The deserialized object instance.</returns>
        public object Deserialize(Stream source, Type type)
        {
            Guard.ArgumentNotNull(source, "source");
            Guard.ArgumentNotNull(type, "type");

            if (type == typeof(XElement))
            {
                // Handle XML element deserialization using separate technique.
                return DeserializeXml<XElement>(source, (reader) => { return XElement.Load(reader); });
            }
            else if (type == typeof(XDocument))
            {
                // Handle XML document deserialization using separate technique.
                return DeserializeXml<XDocument>(source, (reader) => { return XDocument.Load(reader); });
            }
            else if (type == typeof(XmlDocument))
            {
                // Handle XML DOM document deserialization using separate technique.
                return DeserializeXml<XmlDocument>(source, (reader) => { var xml = new XmlDocument(); xml.Load(reader); return xml; });
            }
            else if (type == typeof(XmlElement))
            {
                // Handle XML DOM element deserialization using separate technique.
                return DeserializeXml<XmlElement>(source, (reader) => { var xml = new XmlDocument(); xml.Load(reader); return xml.DocumentElement; });
            }
            else
            {
                var serializer = GetXmlSerializer(type);

                using (var compressedStream = new DeflateStream(source, CompressionMode.Decompress, true))
                using (var xmlReader = XmlDictionaryReader.CreateBinaryReader(compressedStream, XmlDictionaryReaderQuotas.Max))
                {
                    return serializer.ReadObject(xmlReader);
                }
            }
        }
        #endregion

        #region Private members
        private XmlObjectSerializer GetXmlSerializer(Type type)
        {
            if (FrameworkUtility.GetDeclarativeAttribute<DataContractAttribute>(type) != null)
            {
                return new DataContractSerializer(type);
            }
            else
            {
                return new NetDataContractSerializer();
            }
        }

        private void SerializeXml<T>(T instance, Stream target, Action<T, XmlWriter> serializeAction)
        {
            using (var compressedStream = new DeflateStream(target, CompressionMode.Compress, true))
            using (var xmlWriter = XmlDictionaryWriter.CreateBinaryWriter(compressedStream, null, null, false))
            {
                serializeAction(instance, xmlWriter);

                xmlWriter.Flush();
                compressedStream.Flush();
            }
        }

        private T DeserializeXml<T>(Stream source, Func<XmlReader, T> deserializeAction)
        {
            using (var compressedStream = new DeflateStream(source, CompressionMode.Decompress, true))
            using (var xmlReader = XmlDictionaryReader.CreateBinaryReader(compressedStream, XmlDictionaryReaderQuotas.Max))
            {
                return deserializeAction(xmlReader);
            }
        }
        #endregion
    }
}