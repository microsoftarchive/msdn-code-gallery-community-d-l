//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.ActivityTracking
{
    #region Using references
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.Text;
    using System.ServiceModel;
    using System.Globalization;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides a base class for all BAM activities containing common fields, activity property bag and other shared artifacts.
    /// </summary>
    [Serializable]
    [MessageContract(IsWrapped = true, WrapperNamespace = WellKnownNamespace.DataContracts.General)]
    public abstract class ActivityBase
    {
        #region Private members
        private const string ActivityIdPropertyName = "ActivityID";
        private const string ActivityNamePropertyName = "ActivityName";
        private const string ContinuationTokenPropertyName = "ContinuationToken";
        private const string ActivityDataPropertyName = "ActivityData";

        [MessageBodyMember(Name = ActivityDataPropertyName, Namespace = WellKnownNamespace.DataContracts.General)]
        private readonly IDictionary<string, object> propertyBag = new Dictionary<string, object>();
        #endregion

        #region Public properties
        /// <summary>
        /// The ID of the BAM activity.
        /// </summary>
        [MessageBodyMember(Name = ActivityIdPropertyName, Namespace = WellKnownNamespace.DataContracts.General)]
        public string ActivityID { get; set; }

        /// <summary>
        /// The continuation token which applies when using continuation.
        /// </summary>
        [MessageBodyMember(Name = ContinuationTokenPropertyName, Namespace = WellKnownNamespace.DataContracts.General)]
        public string ContinuationToken { get; set; }

        /// <summary>
        /// The name of this activity.
        /// </summary>
        [MessageBodyMember(Name = ActivityNamePropertyName, Namespace = WellKnownNamespace.DataContracts.General)]
        public abstract string ActivityName { get; }

        /// <summary>
        /// Returns the collection of activity data items.
        /// </summary>
        public IDictionary<string, object> ActivityData
        {
            get { return this.propertyBag; }
        }
        #endregion 

        #region Public methods
        /// <summary>
        /// Returns an instance of the <see cref="ActivityBase"/> object constructed from an XML representation of the source activity.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> object supplying an XML representation of the activity.</param>
        /// <returns>The activity instance constructed from its XML representation.</returns>
        public static ActivityBase Create(XmlReader reader)
        {
            GenericNamedActivity genericActivity = null;
            XElement activityXml = XElement.Load(reader, LoadOptions.None);
            XElement childElement;

            if (activityXml.Name.LocalName == typeof(ActivityBase).Name && activityXml.Name.Namespace == WellKnownNamespace.DataContracts.General)
            {
                // Extract the main activity properties from the XML data.
                string activityName = (childElement = (from child in activityXml.Descendants(XName.Get(ActivityNamePropertyName, WellKnownNamespace.DataContracts.General)) select child).FirstOrDefault()) != null ? childElement.Value : null;
                string activityId = (childElement = (from child in activityXml.Descendants(XName.Get(ActivityIdPropertyName, WellKnownNamespace.DataContracts.General)) select child).FirstOrDefault()) != null ? childElement.Value : null;
                string continuationToken = (childElement = (from child in activityXml.Descendants(XName.Get(ContinuationTokenPropertyName, WellKnownNamespace.DataContracts.General)) select child).FirstOrDefault()) != null ? childElement.Value : null;

                // Instantiate a generic activity that will be populated with data items and returned as method result.
                genericActivity = new GenericNamedActivity(activityName, activityId) { ContinuationToken = continuationToken };

                DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Dictionary<string, object>), ActivityDataPropertyName, WellKnownNamespace.DataContracts.General);
                XmlReaderSettings readerSettings = new XmlReaderSettings() { CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };
                XmlReader propertyBagReader = XmlReader.Create(activityXml.DescendantsAndSelf(XName.Get(ActivityDataPropertyName, WellKnownNamespace.DataContracts.General)).First().CreateReader(), readerSettings);
                
                IDictionary<string, object> activityPropertyBag = dcSerializer.ReadObject(propertyBagReader) as Dictionary<string, object>;

                if (activityPropertyBag != null)
                {
                    foreach (var prop in activityPropertyBag)
                    {
                        genericActivity.ActivityData.Add(prop);
                    }
                }
            }
            else
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.CannotCreateInstanceFromXmlReader, typeof(ActivityBase).Name, WellKnownNamespace.DataContracts.General, activityXml.Name.LocalName, activityXml.Name.Namespace), "reader");
            }

            return genericActivity;
        }
        #endregion
    }
}