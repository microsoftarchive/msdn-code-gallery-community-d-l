//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core services used by all Azure-hosted worker roles
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Common.RulesEngine
{
    #region Using references
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements a Rules Engine fact representing an XML message type.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class MessageTypeFact
    {
        #region Private members
        private const string MessageTypeValueFormat = "{0}#{1}";
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the message type which is the result of combining the XML namespace and document's root node name.
        /// </summary>
        [DataMember]
        public string Value { get; set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a fact using the specified message type.
        /// </summary>
        /// <param name="value">The message type value.</param>
        public MessageTypeFact(string value)
        {
            Guard.ArgumentNotNullOrEmptyString(value, "value");

            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of a fact using the specified XML DOM document for which message type will be determined.
        /// </summary>
        /// <param name="document">An instance of the XML DOM document that must contain a root node.</param>
        public MessageTypeFact(XmlDocument document)
        {
            Guard.ArgumentNotNull(document, "document");
            Guard.ArgumentNotNull(document.DocumentElement, "document.DocumentElement");

            Value = String.Format(CultureInfo.InvariantCulture, MessageTypeValueFormat, document.DocumentElement.NamespaceURI, document.DocumentElement.Name);
        }

        /// <summary>
        /// Initializes a new instance of a fact using the specified LINQ-to-XML document for which message type will be determined.
        /// </summary>
        /// <param name="document">An instance of the LINQ-to-XML document that must contain a root node.</param>
        public MessageTypeFact(XDocument document)
        {
            Guard.ArgumentNotNull(document, "document");
            Guard.ArgumentNotNull(document.Root, "document.Root");

            Value = String.Format(CultureInfo.InvariantCulture, MessageTypeValueFormat, document.Root.Name.Namespace, document.Root.Name.LocalName);
        } 
        #endregion
    }
}
