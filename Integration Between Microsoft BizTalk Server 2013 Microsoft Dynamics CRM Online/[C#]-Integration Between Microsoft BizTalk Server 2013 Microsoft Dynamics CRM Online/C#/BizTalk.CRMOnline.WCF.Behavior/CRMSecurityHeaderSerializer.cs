// ***********************************************************************
// Assembly         : BizTalk.CRMOnline.WCF.Behavior
// Author           : SMSVikasK
// Created          : 24-03-2015
//
// Last Modified By : Vikas Kerehalli
// Last Modified On : 24-03-2015
// ***********************************************************************
// <copyright file="CRMSecurityHeaderSerializer.cs" company="BizTalk">
//     Copyright © 
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BizTalk.CRMOnline.WCF.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Class CRMSecurityHeaderSerializer.
    /// </summary>
    public class CRMSecurityHeaderSerializer : XmlObjectSerializer
    {
        /// <summary>
        /// The security header
        /// </summary>
        private string securityHeader;

        /// <summary>
        /// Initializes a new instance of the <see cref="CRMSecurityHeaderSerializer"/> class.
        /// </summary>
        /// <param name="securityHeader">The security header.</param>
        public CRMSecurityHeaderSerializer(string securityHeader)
        {
            this.securityHeader = securityHeader;
        }

        /// <summary>
        /// Gets a value that specifies whether the <see cref="T:System.Xml.XmlDictionaryReader" /> is positioned over an XML element that can be read.
        /// </summary>
        /// <param name="reader">An <see cref="T:System.Xml.XmlDictionaryReader" /> used to read the XML stream or document.</param>
        /// <returns>true if the reader can read the data; otherwise, false.</returns>
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return true;
        }

        /// <summary>
        /// Reads the XML stream or document with an <see cref="T:System.Xml.XmlDictionaryReader" /> and returns the deserialized object; it also enables you to specify whether the serializer can read the data before attempting to read it.
        /// </summary>
        /// <param name="reader">An <see cref="T:System.Xml.XmlDictionaryReader" /> used to read the XML document.</param>
        /// <param name="verifyObjectName">true to check whether the enclosing XML element name and namespace correspond to the root name and root namespace; otherwise, false to skip the verification.</param>
        /// <returns>The deserialized object.</returns>
        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return null;
        }

        /// <summary>
        /// Writes the end of the object data as a closing XML element to the XML document or stream with an <see cref="T:System.Xml.XmlDictionaryWriter" />.
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Xml.XmlDictionaryWriter" /> used to write the XML document or stream.</param>
        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
        }

        /// <summary>
        /// Writes only the content of the object to the XML document or stream using the specified <see cref="T:System.Xml.XmlDictionaryWriter" />.
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Xml.XmlDictionaryWriter" /> used to write the XML document or stream.</param>
        /// <param name="graph">The object that contains the content to write.</param>
        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            if (writer != null)
            {
                writer.WriteRaw(this.securityHeader);
            }
        }

        /// <summary>
        /// Writes the start of the object's data as an opening XML element using the specified <see cref="T:System.Xml.XmlDictionaryWriter" />.
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Xml.XmlDictionaryWriter" /> used to write the XML document.</param>
        /// <param name="graph">The object to serialize.</param>
        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
        }
    }
}
