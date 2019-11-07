// ***********************************************************************
// Assembly         : BizTalk.CRMOnline.WCF.Behavior
// Author           : SMSVikasK
// Created          : 24-03-2015
//
// Last Modified By : Vikas Kerehalli
// Last Modified On : 24-03-2015
// ***********************************************************************
// <copyright file="CRMHelper.cs" company="BizTalk">
//     Copyright © 
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BizTalk.CRMOnline.WCF.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Class CRMHelper.
    /// </summary>
    public class CRMHelper
    {
        /// <summary>
        /// Gets the SOAP response.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="soapEnvelope">The SOAP envelope.</param>
        /// <returns>System String.</returns>
        public static string GetSOAPResponse(string url, string soapEnvelope)
        {
            Uri targetUri = new Uri(url);
            WebRequest request = WebRequest.Create(targetUri);
            request.Method = "POST";
            request.ContentType = "application/soap+xml; charset=UTF-8";

            request.Timeout = 180000;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(soapEnvelope);
            using (Stream str = request.GetRequestStream())
            {
                str.Write(bytes, 0, bytes.Length);
            }

            string soapXMLResponse = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    soapXMLResponse = reader.ReadToEnd();
                }
            }

            return soapXMLResponse;
        }

        /// <summary>
        /// Gets the value from XML.
        /// </summary>
        /// <param name="inputXML">The input XML.</param>
        /// <param name="strXPathQuery">The x path query.</param>
        /// <returns>System String.</returns>
        public static string GetValueFromXML(string inputXML, string strXPathQuery)
        {
            return GetValueFromXML(inputXML, strXPathQuery, 0);
        }

        /// <summary>
        /// Gets the value from XML.
        /// </summary>
        /// <param name="strInputXML">The input XML.</param>
        /// <param name="strXPathQuery">The x path query.</param>
        /// <param name="index">The index.</param>
        /// <returns>System String.</returns>
        public static string GetValueFromXML(string strInputXML, string strXPathQuery, int index)
        {
            return GetValueFromXML(strInputXML, strXPathQuery, index, null);
        }

        /// <summary>
        /// Gets the value from XML.
        /// </summary>
        /// <param name="strInputXML">The input XML.</param>
        /// <param name="strXPathQuery">The x path query.</param>
        /// <param name="index">The index.</param>
        /// <param name="strnamespaces">The namespaces.</param>
        /// <returns>System String.</returns>
        public static string GetValueFromXML(string strInputXML, string strXPathQuery, int index, string[,] strnamespaces)
        {
            XmlDocument document = new XmlDocument();
            XmlNodeList nodes;
            document.LoadXml(strInputXML);
            if (strnamespaces != null)
            {
                XmlNamespaceManager namespaceManager = new XmlNamespaceManager(document.NameTable);
                for (int i = 0; i < strnamespaces.Length / strnamespaces.Rank; i++)
                {
                    namespaceManager.AddNamespace(strnamespaces[i, 0], strnamespaces[i, 1]);
                }

                nodes = document.SelectNodes(strXPathQuery, namespaceManager);
            }
            else
            {
                nodes = document.SelectNodes(strXPathQuery);
            }

            if (nodes != null && nodes.Count > 0 && nodes[index] != null)
            {
                return nodes[index].Value;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the message header.
        /// </summary>
        /// <param name="strUsername">The username.</param>
        /// <param name="strPassword">The password.</param>
        /// <param name="strCRMUrl">The CRM URL.</param>
        /// <param name="strAppliesTo">The applies to.</param>
        /// <returns>System String.</returns>
        public static string GetMessageHeader(string strUsername, string strPassword, string strCRMUrl, string strAppliesTo)
        {
            string strSTSEnpoint = "https://login.microsoftonline.com/RST2.srf";

            //// Step 1: Determine which authentication method (LiveID or OCP) and authenticate to get tokens and key.

            string keyIdentifier = null;
            string securityToken0 = null;
            string securityToken1 = null;

            //// OCP Authentication

            //// Step A: Get Security Token by sending OCP username, password

            string securityTokenSoapTemplate = @"
                <s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope""
	                xmlns:a=""http://www.w3.org/2005/08/addressing""
	                xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
	                <s:Header>
		                <a:Action s:mustUnderstand=""1"">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue
		                </a:Action>
		                <a:MessageID>urn:uuid:{4:MessageID}
		                </a:MessageID>
		                <a:ReplyTo>
			                <a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>
		                </a:ReplyTo>
		                <VsDebuggerCausalityData
			                xmlns=""http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink"">uIDPo4TBVw9fIMZFmc7ZFxBXIcYAAAAAbd1LF/fnfUOzaja8sGev0GKsBdINtR5Jt13WPsZ9dPgACQAA
		                </VsDebuggerCausalityData>
		                <a:To s:mustUnderstand=""1"">{6:STSEndpoint}
		                </a:To>
		                <o:Security s:mustUnderstand=""1""
			                xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
			                <u:Timestamp u:Id=""_0"">
				                <u:Created>{0:timeCreated}Z</u:Created>
				                <u:Expires>{1:timeExpires}Z</u:Expires>
			                </u:Timestamp>
			                <o:UsernameToken u:Id=""uuid-14bed392-2320-44ae-859d-fa4ec83df57a-1"">
				                <o:Username>{2:UserName}</o:Username>
				                <o:Password
					                Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{3:Password}</o:Password>
			                </o:UsernameToken>
		                </o:Security>
	                </s:Header>
	                <s:Body>
		                <t:RequestSecurityToken xmlns:t=""http://schemas.xmlsoap.org/ws/2005/02/trust"">
			                <wsp:AppliesTo xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"">
				                <a:EndpointReference>
					                <a:Address>{5:URNAddress}</a:Address>
				                </a:EndpointReference>
			                </wsp:AppliesTo>
			                <t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue
			                </t:RequestType>
		                </t:RequestSecurityToken>
	                </s:Body>
                </s:Envelope>
                ";

            DateTime securityTokenRequestCreatedTime = DateTime.Now.ToUniversalTime();

            string securityTokenXML = GetSOAPResponse(strSTSEnpoint, string.Format(securityTokenSoapTemplate, securityTokenRequestCreatedTime.ToString("s") + "." + securityTokenRequestCreatedTime.Millisecond, securityTokenRequestCreatedTime.AddMinutes(10.0).ToString("s") + "." + securityTokenRequestCreatedTime.Millisecond, strUsername, strPassword, Guid.NewGuid().ToString(), strAppliesTo, strSTSEnpoint));

            securityToken0 = GetValueFromXML(securityTokenXML, @"//*[local-name()='CipherValue']/text()");
            securityToken1 = GetValueFromXML(securityTokenXML, @"//*[local-name()='CipherValue']/text()", 1);
            keyIdentifier = GetValueFromXML(securityTokenXML, @"//*[local-name()='KeyIdentifier']/text()");

            //// Step 2: Get / Set CRM Data by sending FetchXML Query
            string crmSoapRequestHeader = @"
                <s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope""
                xmlns:a=""http://www.w3.org/2005/08/addressing""
                xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" 
                xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                  <s:Header>
                    <a:Action s:mustUnderstand=""1"">
                    http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/{7:Action}</a:Action>
                    <a:MessageID>
                    urn:uuid:{6:MessageID}</a:MessageID>
                    <a:ReplyTo>
                      <a:Address>
                      http://www.w3.org/2005/08/addressing/anonymous</a:Address>
                    </a:ReplyTo>
                    <VsDebuggerCausalityData xmlns=""http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink"">
                    uIDPozJEz+P/wJdOhoN2XNauvYcAAAAAK0Y6fOjvMEqbgs9ivCmFPaZlxcAnCJ1GiX+Rpi09nSYACQAA</VsDebuggerCausalityData>
                    <a:To s:mustUnderstand=""1"">
                    {2:CRMURL}</a:To>
                    <o:Security s:mustUnderstand=""1"">
                      <u:Timestamp u:Id=""_0"">
                        <u:Created>{0:timeCreated}Z</u:Created>
                        <u:Expires>{1:timeExpires}Z</u:Expires>
                      </u:Timestamp>
                      <EncryptedData Id=""Assertion0""
                      Type=""http://www.w3.org/2001/04/xmlenc#Element""
                      xmlns=""http://www.w3.org/2001/04/xmlenc#"">
                        <EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#tripledes-cbc"">
                        </EncryptionMethod>
                        <ds:KeyInfo xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"">
                          <EncryptedKey>
                            <EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p"">
                            </EncryptionMethod>
                            <ds:KeyInfo Id=""keyinfo"">
                              <wsse:SecurityTokenReference xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">

                                <wsse:KeyIdentifier EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary""
                                ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier"">
                                {3:KeyIdentifier}</wsse:KeyIdentifier>
                              </wsse:SecurityTokenReference>
                            </ds:KeyInfo>
                            <CipherData>
                              <CipherValue>
                              {4:SecurityToken0}</CipherValue>
                            </CipherData>
                          </EncryptedKey>
                        </ds:KeyInfo>
                        <CipherData>
                          <CipherValue>
                          {5:SecurityToken1}</CipherValue>
                        </CipherData>
                      </EncryptedData>
                    </o:Security>
                  </s:Header>  
                 </s:Envelope>             
                  ";
            DateTime retrieveRequestCreatedTime = DateTime.Now.ToUniversalTime();
            string strEnvelopHeader = string.Format(crmSoapRequestHeader, retrieveRequestCreatedTime.ToString("s") + "." + retrieveRequestCreatedTime.Millisecond, retrieveRequestCreatedTime.AddMinutes(10.0).ToString("s") + "." + retrieveRequestCreatedTime.Millisecond, strCRMUrl, keyIdentifier, securityToken0, securityToken1, Guid.NewGuid().ToString(), "Retrieve");
            return strEnvelopHeader;
        }
    }
}
