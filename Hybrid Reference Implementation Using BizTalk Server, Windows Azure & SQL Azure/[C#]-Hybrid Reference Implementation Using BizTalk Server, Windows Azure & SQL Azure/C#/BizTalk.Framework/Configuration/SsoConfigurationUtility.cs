//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.Configuration
{
    #region Using statements
    using System;
    using System.Collections.Generic;

    using Microsoft.BizTalk.SSOClient.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// A helper class for reading and writing custom property bags in the SSO Configuration Store.
    /// </summary>
    public static class SsoConfigurationUtility
    {
        #region Private members
        /// <summary>
        /// Contains the identifier for the configuration info. 
        /// </summary>
        private static string idenifierGUID = "ConfigProperties";
        #endregion

        #region Read method
        /// <summary>
        /// Reads the configuration data from the SSO Config Store.
        /// </summary>        
        /// <param name="appName">The name of the affiliate application to represent the configuration container to access.</param>
        /// <param name="propName">The property name to read.</param>
        /// <returns>The value of the property stored in the given affiliate application of this component.</returns>
        public static string Read(string appName, string propName)
        {
            Guard.ArgumentNotNullOrEmptyString(appName, "appName");
            Guard.ArgumentNotNullOrEmptyString(propName, "propName");

            var callToken = TraceManager.CustomComponent.TraceIn(appName, propName);

            try
            {
                SSOConfigStore ssoStore = new SSOConfigStore();
                SsoConfigurationPropertyBag appMgmtBag = new SsoConfigurationPropertyBag();

                ((ISSOConfigStore)ssoStore).GetConfigInfo(appName, idenifierGUID, SSOFlag.SSO_FLAG_RUNTIME, (IPropertyBag)appMgmtBag);

                object propertyValue = null;
                appMgmtBag.Read(propName, out propertyValue, 0);

                return (string)propertyValue;
            }
            catch (Exception e)
            {
                TraceManager.CustomComponent.TraceError(e);

                throw;
            }
            finally
            {
                TraceManager.CustomComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region Write method
        /// <summary>
        /// Writes the configuration data to the SSO Config Store.
        /// </summary>
        /// <param name="appName">The name of the affiliate application to represent the configuration container to access.</param>
        /// <param name="properties">A collection of name/value pairs that represent the configuration settings.</param>
        public static void Write(string appName, IDictionary<string, string> properties)
        {
            Guard.ArgumentNotNullOrEmptyString(appName, "appName");
            Guard.ArgumentNotNull(properties, "properties");

            var callToken = TraceManager.CustomComponent.TraceIn(appName, properties.Count);

            try
            {
                SSOConfigStore ssoStore = new SSOConfigStore();
                SsoConfigurationPropertyBag appMgmtBag = new SsoConfigurationPropertyBag();

                foreach (KeyValuePair<string, string> property in properties)
                {
                    object tempPropValue = property.Value;
                    appMgmtBag.Write(property.Key, ref tempPropValue);
                }

                ((ISSOConfigStore)ssoStore).SetConfigInfo(appName, idenifierGUID, appMgmtBag);
            }
            catch (Exception e)
            {
                TraceManager.CustomComponent.TraceError(e);

                throw;
            }
            finally
            {
                TraceManager.CustomComponent.TraceOut(callToken);
            }
        }
        #endregion
    }

}
