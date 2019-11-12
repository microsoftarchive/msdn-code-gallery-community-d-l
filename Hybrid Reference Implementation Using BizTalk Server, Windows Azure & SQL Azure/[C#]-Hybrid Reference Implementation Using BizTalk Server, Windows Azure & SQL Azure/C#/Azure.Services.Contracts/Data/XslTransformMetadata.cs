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
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Defines a set of metadata for the XSLT-based transformation object.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class XslTransformMetadata
    {
        #region Public properties
        /// <summary>
        /// Returns the list of schema names associated with the source documents.
        /// </summary>
        [DataMember]
        public string[] SourceSchemas { get; private set; }

        /// <summary>
        /// Returns the list of schema names associated with the output documents.
        /// </summary>
        [DataMember]
        public string[] TargetSchemas { get; private set; }

        /// <summary>
        /// Returns the raw XSLT template defining the transformation logic.
        /// </summary>
        [DataMember]
        public string XsltContentRaw { get; private set; }

        /// <summary>
        /// Returns the definition of the XSLT arguments.
        /// </summary>
        [DataMember]
        public string XsltArgumentsRaw { get; private set; }

        /// <summary>
        /// Gets or sets the date and time indicating when the XSTL transformation object was last updated at the origin.
        /// </summary>
        [DataMember]
        DateTime LastUpdated { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a metadata set describing a given for the XSLT-based transformation object.
        /// </summary>
        /// <param name="xsltContent">The raw XSLT template defining the transformation logic.</param>
        /// <param name="xsltArguments">The definition of the XSLT arguments.</param>
        /// <param name="sourceSchemas">The optional list of schema names associated with the source documents.</param>
        /// <param name="targetSchemas">The optional list of schema names associated with the output documents.</param>
        public XslTransformMetadata(string xsltContent, string xsltArguments, string[] sourceSchemas, string[] targetSchemas)
        {
            XsltContentRaw = xsltContent;
            XsltArgumentsRaw = xsltArguments;
            SourceSchemas = sourceSchemas;
            TargetSchemas = targetSchemas;
            LastUpdated = DateTime.UtcNow;
        } 
        #endregion
    }
}
