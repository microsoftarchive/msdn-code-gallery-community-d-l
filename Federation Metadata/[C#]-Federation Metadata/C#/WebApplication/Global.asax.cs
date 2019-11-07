//----------------------------------------------------------------------------------------------
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------

using System;
using System.IdentityModel.Metadata;
using System.IdentityModel.Services;
using System.ServiceModel.Security;
using System.Web;
using System.Xml;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        private static readonly string ConfigAddress = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Web.config";

        void Application_Start(object sender, EventArgs e)
        {
            // Compute federation metadata address based on web config's 
            // <system.identityModel.services>\<federationConfiguration>\<wsFederation issuer=""> attribute value
            string stsMetadataAddress = ComputeStsMetadataAddress();

            // Update the web config with latest local STS federation meta data each
            // time when instance of the application is created
            XmlReader updatedConfigReader = null;
            using (XmlReader metadataReader = XmlReader.Create(stsMetadataAddress))
            {
                using (XmlReader configReader = XmlReader.Create(ConfigAddress))
                {
                    // Creates the xml reader pointing to the updated web.config contents
                    // Don't validate the cert signing the federation metadata
                    MetadataSerializer serializer = new MetadataSerializer()
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                    };

                    updatedConfigReader = FederationManagement.UpdateIdentityProviderTrustInfo(metadataReader, configReader, false, serializer);
                }
            }

            // Writes the updated web.config contents to web.config file
            using (updatedConfigReader)
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(updatedConfigReader);
                dom.Save(ConfigAddress);
            }

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer
            // or SQLServer, the event is not raised.

        }

        private static string ComputeStsMetadataAddress()
        {
            string stsIssuerAddress = FederatedAuthentication.FederationConfiguration.WsFederationConfiguration.Issuer;
            return new UriBuilder(stsIssuerAddress) { Path = "federationmetadata/2007-06/federationmetadata.xml" }.Uri.AbsoluteUri;
        }
    }
}
