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

using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Security.Claims;

namespace WSFederationSecurityTokenService
{
    internal class CustomSecurityTokenService : SecurityTokenService
    {
        public CustomSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
        }

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            this.ValidateAppliesTo(request.AppliesTo);
            Scope scope = new Scope(request.AppliesTo.Uri.OriginalString, SecurityTokenServiceConfiguration.SigningCredentials);

            scope.TokenEncryptionRequired = false;
            scope.SymmetricKeyEncryptionRequired = false;

            if (string.IsNullOrEmpty(request.ReplyTo))
            {
                scope.ReplyToAddress = scope.AppliesToAddress;
            }
            else
            {
                scope.ReplyToAddress = request.ReplyTo;
            }

            return scope;
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            if (principal == null)
            {
                throw new InvalidRequestException("The caller's principal is null.");
            }

            ClaimsIdentity outputIdentity = new ClaimsIdentity();

            outputIdentity.AddClaim(new Claim(ClaimTypes.Email, "terry@contoso.com"));
            outputIdentity.AddClaim(new Claim(ClaimTypes.Surname, "Adams"));
            outputIdentity.AddClaim(new Claim(ClaimTypes.Name, "Terry"));
            outputIdentity.AddClaim(new Claim(ClaimTypes.Role, "developer"));
            outputIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/claims/Group", "Sales"));
            outputIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/claims/Group", "Marketing"));

            return outputIdentity;
        }

        private void ValidateAppliesTo(EndpointReference appliesTo)
        {
            if (appliesTo == null)
            {
                throw new InvalidRequestException("The AppliesTo is null.");
            }
        }
    }
}