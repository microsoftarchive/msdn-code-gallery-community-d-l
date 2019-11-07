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
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements a Rules Engine fact representing a dictionary of strings.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class StringDictionaryFact
    {
        #region Public properties
        /// <summary>
        /// Gets the underlying string dictionary.
        /// </summary>
        [DataMember]
        public Dictionary<string, string> Items { get; private set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a string dictionary fact and initializes the collection of strings to an empty collection.
        /// </summary>
        public StringDictionaryFact()
        {
            Items = new Dictionary<string, string>();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        public void Add(string key, string value)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            Items.Add(key, value);
        }
        #endregion
    }
}
