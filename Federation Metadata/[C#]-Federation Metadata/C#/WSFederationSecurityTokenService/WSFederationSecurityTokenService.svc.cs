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
using System.IdentityModel;
using System.IdentityModel.Services;
using System.IO;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace WSFederationSecurityTokenService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WSFederationSecurityTokenService : IWSFederationSecurityTokenService
    {
        CustomSecurityTokenServiceConfiguration stsConfiguration;
        SecurityTokenService securityTokenService;

        public WSFederationSecurityTokenService()
            : base()
        {
            stsConfiguration = new CustomSecurityTokenServiceConfiguration();
            securityTokenService = new CustomSecurityTokenService(this.stsConfiguration);
        }

        public Stream Issue(string realm, string wctx, string wct, string wreply)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

            string fullRequest = Constants.HttpLocalhost + 
                Constants.Port + 
                Constants.WSFedStsIssue + 
                string.Format("?wa=wsignin1.0&wtrealm={0}&wctx={1}&wct={2}&wreply={3}", realm, HttpUtility.UrlEncode(wctx), wct, wreply);

            SignInRequestMessage requestMessage = (SignInRequestMessage)WSFederationMessage.CreateFromUri(new Uri(fullRequest));

            ClaimsIdentity identity = new ClaimsIdentity(AuthenticationTypes.Federation);
            identity.AddClaim(new Claim(ClaimTypes.Name, "foo"));
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);           

            SignInResponseMessage responseMessage = FederatedPassiveSecurityTokenServiceOperations.ProcessSignInRequest(requestMessage, principal, this.securityTokenService);
            responseMessage.Write(writer);

            writer.Flush();
            stream.Position = 0;

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return stream;
        }

        public XElement FederationMetadata()
        {             
             return this.stsConfiguration.GetFederationMetadata();
        }
    }
}