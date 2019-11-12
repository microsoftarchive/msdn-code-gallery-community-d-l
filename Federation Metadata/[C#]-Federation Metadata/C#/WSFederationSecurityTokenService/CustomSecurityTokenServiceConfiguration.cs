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
using System.IdentityModel.Configuration;
using System.IdentityModel.Metadata;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;

namespace WSFederationSecurityTokenService
{
    internal class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        public CustomSecurityTokenServiceConfiguration()
        {
            this.TokenIssuerName = Constants.IssuerName;
            string signingCertificatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.SigningCertificate);
            X509Certificate2 signignCert = new X509Certificate2(signingCertificatePath, Constants.SigningCertificatePassword, X509KeyStorageFlags.PersistKeySet);
            this.SigningCredentials = new X509SigningCredentials(signignCert);
            this.ServiceCertificate = signignCert;

            this.SecurityTokenService = typeof(CustomSecurityTokenService);
        }

        public XElement GetFederationMetadata()
        {
            // hostname
            EndpointReference passiveEndpoint = new EndpointReference(Constants.HttpLocalhost + Constants.Port + Constants.WSFedStsIssue);
            EndpointReference activeEndpoint = new EndpointReference(Constants.HttpLocalhost + Constants.Port + Constants.WSTrustSTS);

            // metadata document 
            EntityDescriptor entity = new EntityDescriptor(new EntityId(Constants.IssuerName));
            SecurityTokenServiceDescriptor sts = new SecurityTokenServiceDescriptor();
            entity.RoleDescriptors.Add(sts);

            // signing key
            KeyDescriptor signingKey = new KeyDescriptor(this.SigningCredentials.SigningKeyIdentifier);
            signingKey.Use = KeyType.Signing;
            sts.Keys.Add(signingKey);

            // claim types
            sts.ClaimTypesOffered.Add(new DisplayClaim(ClaimTypes.Email, "Email Address", "User email address"));
            sts.ClaimTypesOffered.Add(new DisplayClaim(ClaimTypes.Surname, "Surname", "User last name"));
            sts.ClaimTypesOffered.Add(new DisplayClaim(ClaimTypes.Name, "Name", "User name"));
            sts.ClaimTypesOffered.Add(new DisplayClaim(ClaimTypes.Role, "Role", "Roles user are in"));
            sts.ClaimTypesOffered.Add(new DisplayClaim("http://schemas.xmlsoap.org/claims/Group", "Group", "Groups users are in"));

            // passive federation endpoint
            sts.PassiveRequestorEndpoints.Add(passiveEndpoint);

            // supported protocols

            //Inaccessable due to protection level
            //sts.ProtocolsSupported.Add(new Uri(WSFederationConstants.Namespace));
            sts.ProtocolsSupported.Add(new Uri("http://docs.oasis-open.org/wsfed/federation/200706"));

            // add passive STS endpoint
            sts.SecurityTokenServiceEndpoints.Add(activeEndpoint);

            // metadata signing
            entity.SigningCredentials = this.SigningCredentials;

            // serialize 
            var serializer = new MetadataSerializer();
            XElement federationMetadata = null;

            using (var stream = new MemoryStream())
            {
                serializer.WriteMetadata(stream, entity);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                XmlReaderSettings readerSettings = new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Prohibit, // prohibit DTD processing
                    XmlResolver = null, // disallow opening any external resources
                    // no need to do anything to limit the size of the input, given the input is crafted internally and it is of small size
                };

                XmlReader xmlReader = XmlTextReader.Create(stream, readerSettings);
                federationMetadata = XElement.Load(xmlReader);
            }

            return federationMetadata;
        }
    }
}