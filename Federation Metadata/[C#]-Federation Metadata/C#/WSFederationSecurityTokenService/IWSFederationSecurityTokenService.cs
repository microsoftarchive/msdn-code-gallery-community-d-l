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

using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml.Linq;

namespace WSFederationSecurityTokenService
{
    [ServiceContract]
    internal interface IWSFederationSecurityTokenService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Issue/?wa=wsignin1.0&wtrealm={realm}&wctx={wctx}&wct={wct}&wreply={wreply}")]
        Stream Issue(string realm, string wctx, string wct, string wreply);

        [OperationContract]
        [WebGet(UriTemplate = "/" + Constants.FederationMetadataAddress)]
        XElement FederationMetadata();
    }
}
