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

namespace WSFederationSecurityTokenService
{
    public class Constants
    {
        public const string Port = "21402";
        public const string SigningCertificate = "LocalSTS.pfx";
        public const string SigningCertificatePassword = "LocalSTS";
        public const string IssuerName = "WSFederationSTS";
        public const string HttpLocalhost = "http://localhost:";
        public const string WSFedSts = "/WSFederationSecurityTokenService.svc/";
        public const string WSFedStsIssue = WSFedSts + "Issue/";
        public const string LocalStsExeConfig = "WSFederationSecurityTokenService.exe.config";
        public const string FederationMetadataAddress = "FederationMetadata/2007-06/FederationMetadata.xml";
        public const string FederationMetadataEndpoint = WSFedSts + FederationMetadataAddress;
        public const string WSTrustSTS = "/wsTrustSTS/";
    }
}