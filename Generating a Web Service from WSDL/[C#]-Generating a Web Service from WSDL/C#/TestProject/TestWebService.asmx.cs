/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace TestProject
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.Web.Services.WebServiceAttribute(Namespace = "http://softwarebydefault.com")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "TestWebService", Namespace = "http://softwarebydefault.com")]
    public class TestWebService : System.Web.Services.WebService
    {
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://softwarebydefault.com/HelloWorld",
        RequestNamespace = "http://softwarebydefault.com", ResponseNamespace = "http://softwarebydefault.com",
        Use = System.Web.Services.Description.SoapBindingUse.Literal, 
        ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld()
        {
            return "Hello Generated World";
        }
    }
}