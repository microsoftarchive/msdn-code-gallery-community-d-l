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
    /// Implements a Rules Engine fact representing a single simple-type value.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class SimpleValueFact
    {
        #region Public properties
        /// <summary>
        /// Gets or sets the value of the Rules Engine fact.
        /// </summary>
        [DataMember]
        public object Value { get; set; }
        #endregion
    }
}
