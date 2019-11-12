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
    using System.Xml.Xsl;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Represents a data transfer object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public sealed class XslTransformSet
    {
        #region Public properties
        /// <summary>
        /// Gets the metadata for the XSLT-based transformation object.
        /// </summary>
        [DataMember]
        public XslTransformMetadata Metadata { get; private set; }

        /// <summary>
        /// Gets the instance of the XSLT transformation engine.
        /// </summary>
        [DataMember]
        public XslCompiledTransform Transform { get; private set; }

        /// <summary>
        /// Gets the XSLT transformation arguments.
        /// </summary>
        [DataMember]
        public XsltArgumentList Arguments { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a data transfer object using the specified XSLT transformation metadata and XSLT transformation engine instance.
        /// </summary>
        /// <param name="metadata">The metadata for the XSLT-based transformation object.</param>
        /// <param name="transform">The instance of the XSLT transformation engine.</param>
        public XslTransformSet(XslTransformMetadata metadata, XslCompiledTransform transform)
        {
            Metadata = metadata;
            Transform = transform;
        }

        /// <summary>
        /// Initializes a new instance of a data transfer object using the specified XSLT transformation metadata, XSLT transformation engine instance and transformation arguments.
        /// </summary>
        /// <param name="metadata">The metadata for the XSLT-based transformation object.</param>
        /// <param name="transform">The instance of the XSLT transformation engine.</param>
        /// <param name="arguments">The XSLT transformation arguments.</param>
        public XslTransformSet(XslTransformMetadata metadata, XslCompiledTransform transform, XsltArgumentList arguments) : this(metadata, transform)
        {
            Arguments = arguments;
        }
        #endregion
    }
}
