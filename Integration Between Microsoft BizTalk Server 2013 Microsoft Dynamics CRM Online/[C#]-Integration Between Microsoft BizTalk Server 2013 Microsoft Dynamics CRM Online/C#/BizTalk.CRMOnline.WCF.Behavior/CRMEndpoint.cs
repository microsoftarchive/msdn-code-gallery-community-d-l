// ***********************************************************************
// Assembly         : BizTalk.CRMOnline.WCF.Behavior
// Author           : SMSVikasK
// Created          : 24-03-2015
//
// Last Modified By : Vikas Kerehalli
// Last Modified On : 24-03-2015
// ***********************************************************************
// <copyright file="CRMEndpoint.cs" company="BizTalk">
//     Copyright © 
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BizTalk.CRMOnline.WCF.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Description;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing the interface IEndpointBehavior to add message inspector object
    /// </summary>
    public class CRMEndpoint : IEndpointBehavior
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

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
        /// Implement to pass data at runtime to bindings to support custom behavior.
        /// </summary>
        /// <param name="endpoint">The endpoint to modify.</param>
        /// <param name="bindingParameters">The objects that binding elements require to support the behavior.</param>
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Implements a modification or extension of the client across an endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint that is to be customized.</param>
        /// <param name="clientRuntime">The client runtime to be customized.</param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            CRMMessageInspector msginsp = new CRMMessageInspector(this.UserName, this.Password, this.CRMUrl, this.AppliesTo);
            if (clientRuntime != null)
            {
                clientRuntime.ClientMessageInspectors.Add(msginsp);
            }
        }

        /// <summary>
        /// Implements a modification or extension of the service across an endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint that exposes the contract.</param>
        /// <param name="endpointDispatcher">The endpoint dispatcher to be modified or extended.</param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
        }

        /// <summary>
        /// Implement to confirm that the endpoint meets some intended criteria.
        /// </summary>
        /// <param name="endpoint">The endpoint to validate.</param>
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
