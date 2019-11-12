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
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Properties;
    #endregion

    #region RulesEngineDataExchangeMessage class definition
    /// <summary>
    /// Provides the base abstract class defining common elements of functionality that apply to data exchange when communicating with an on-premises Rules Engine.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public abstract class RulesEngineDataExchangeMessage
    {
        #region Private members
        [DataMember(Name = "Facts")]
        private readonly IDictionary<string, string> facts = new Dictionary<string, string>();
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the policy name. 
        /// </summary>
        [DataMember]
        public string PolicyName { get; protected set; }

        /// <summary>
        /// Gets or sets the policy version number. If version is not provided, the latest version will be invoked.
        /// </summary>
        [DataMember]
        public Version PolicyVersion { get; protected set; }

        /// <summary>
        /// Returns the list of Rules Engine facts participating in the policy invocation.
        /// </summary>
        [IgnoreDataMember]
        public IEnumerable<object> Facts
        {
            get
            {
                return (from f in (from fact in facts.AsParallel() select fact) select CreateFact(f.Key, f.Value)).ToList<object>();
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds the specified facts into the internal collection by serializing these using DataContractSerializer.
        /// </summary>
        /// <param name="facts">A collection of facts.</param>
        public void AddFacts(IEnumerable<object> facts)
        {
            Guard.ArgumentNotNull(facts, "facts");

            foreach (object fact in facts)
            {
                var dcAttribute = FrameworkUtility.GetDeclarativeAttribute<DataContractAttribute>(fact);

                if (dcAttribute != null)
                {
                    DataContractSerializer serializer = !String.IsNullOrEmpty(dcAttribute.Name) && !String.IsNullOrEmpty(dcAttribute.Namespace) ? new DataContractSerializer(fact.GetType(), dcAttribute.Name, dcAttribute.Namespace) : new DataContractSerializer(fact.GetType());

                    using (MemoryStream serializationBuffer = new MemoryStream())
                    {
                        using (var xmlWriter = XmlDictionaryWriter.CreateTextWriter(serializationBuffer, Encoding.UTF8, false))
                        {
                            serializer.WriteObject(xmlWriter, fact);
                        }

                        serializationBuffer.Seek(0, SeekOrigin.Begin);

                        using (StreamReader dataReader = new StreamReader(serializationBuffer))
                        {
                            this.facts[fact.GetType().AssemblyQualifiedName] = dataReader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    throw new InvalidDataContractException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.MustSupplyDataContractAttribute, fact.GetType().FullName));
                }
            }
        }

        /// <summary>
        /// Adds the specified facts into the internal collection by serializing these using DataContractSerializer.
        /// </summary>
        /// <param name="facts">A list of facts.</param>
        public void AddFacts(params object[] facts)
        {
            Guard.ArgumentNotNull(facts, "facts");
            AddFacts(facts.ToList<object>());
        }
        #endregion

        #region Private methods
        private object CreateFact(string typeName, string payload)
        {
            Guard.ArgumentNotNullOrEmptyString(typeName, "typeName");
            Guard.ArgumentNotNullOrEmptyString(payload, "payload");

            Type factType = Type.GetType(typeName, true);
            DataContractSerializer serializer = new DataContractSerializer(factType);

            using (var xmlReader = XmlDictionaryReader.CreateTextReader(Encoding.UTF8.GetBytes(payload), XmlDictionaryReaderQuotas.Max))
            {
                return serializer.ReadObject(xmlReader);
            }
        }
        #endregion
    }
    #endregion
}
