// ***********************************************************************
// Assembly         : BizTalk.CRMOnline.WCF.Behavior
// Author           : SMSVikasK
// Created          : 24-03-2015
//
// Last Modified By : Vikas Kerehalli
// Last Modified On : 24-03-2015
// ***********************************************************************
// <copyright file="CRMMessageInspector.cs" company="BizTalk">
//     Copyright © 
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BizTalk.CRMOnline.WCF.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using BizTalk.CRMOnline.WCF.Behavior;

    /// <summary>
    /// Class CRMMessageInspector.
    /// </summary>
    public class CRMMessageInspector : IClientMessageInspector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CRMMessageInspector"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="crmUrl">The CRM URL.</param>
        /// <param name="appliesTo">The applies to.</param>
        public CRMMessageInspector(string userName, string password, string crmUrl, string appliesTo)
        {
            this.Username = userName;
            this.Password = password;
            this.CRMUrl = crmUrl;
            this.AppliesTo = appliesTo;
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the CRM URL.
        /// </summary>
        /// <value>The CRM URL.</value>
        public string CRMUrl { get; set; }

        /// <summary>
        /// Gets or sets the applies to.
        /// </summary>
        /// <value>The applies to.</value>
        public string AppliesTo { get; set; }

        /// <summary>
        /// Enables inspection or modification of a message after a reply message is received but prior to passing it back to the client application.
        /// </summary>
        /// <param name="reply">The message to be transformed into types and handed back to the client application.</param>
        /// <param name="correlationState">Correlation state data.</param>
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            if (reply != null)
            {
                if (reply.Headers != null && reply.Headers.Count > 3 && reply.Headers.ElementAt(3).Name.StartsWith("Security"))
                {
                    reply.Headers.RemoveAt(3);
                }
            }
        }

        /// <summary>
        /// Enables inspection or modification of a message before a request message is sent to a service.
        /// </summary>
        /// <param name="request">The message to be sent to the service.</param>
        /// <param name="channel">The WCF client object channel.</param>
        /// <returns>The object that is returned as the <paramref name="correlationState " />argument of the <see cref="M:System.ServiceModel.Dispatcher.IClientMessageInspector.AfterReceiveReply(System.ServiceModel.Channels.Message@,System.Object)" /> method. This is null if no correlation state is used.The best practice is to make this a <see cref="T:System.Guid" /> to ensure that no two <paramref name="correlationState" /> objects are the same.</returns>
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            string securityHeader = CRMHelper.GetMessageHeader(this.Username, this.Password, this.CRMUrl, this.AppliesTo);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(securityHeader);
            string strsecurity = doc.SelectSingleNode("/*[local-name()='Envelope' and namespace-uri()='http://www.w3.org/2003/05/soap-envelope']/*[local-name()='Header' and namespace-uri()='http://www.w3.org/2003/05/soap-envelope']/*[local-name()='Security' and namespace-uri()='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd']").InnerXml.ToString();
            if (request != null)
            {
                request.Headers.Add(MessageHeader.CreateHeader("VsDebuggerCausalityData", "http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink", "uIDPozJEz+P/wJdOhoN2XNauvYcAAAAAK0Y6fOjvMEqbgs9ivCmFPaZlxcAnCJ1GiX+Rpi09nSYACQAA"));
                request.Headers.Add(MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", string.Empty, new CRMSecurityHeaderSerializer(strsecurity), true));
            }

            return null;
        }
    }
}
