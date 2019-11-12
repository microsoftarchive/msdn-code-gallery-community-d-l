//==================================================================================
// Contoso Cloud Integration Service Layer Solution - Loan Application
//
// The web role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Demo.LoanApplication
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    #endregion

    /// <summary>
    /// Defines the methods, properties, and events that are common to all application objects in an Web Role application.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Returns a global singleton instance of the web role implementation that provides shared services for this application.
        /// </summary>
        public static readonly LoanApplicationWebRole WebRoleSingleton = new LoanApplicationWebRole();

        /// <summary>
        /// Called when the first resource (such as a page) in an ASP.NET application is requested. The Application_Start method is called only one time 
        /// during the life cycle of an application. You can use this method to perform startup tasks such as loading data into the cache and initializing static values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        void Application_Start(object sender, EventArgs e)
        {
            WebRoleSingleton.OnStart();
        }

        /// <summary>
        /// Called once per lifetime of the application before the application is unloaded. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        void Application_End(object sender, EventArgs e)
        {
            WebRoleSingleton.OnStop();
        }

        /// <summary>
        /// Indicates that the application encountered an error.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        void Application_Error(object sender, EventArgs e)
        {
            WebRoleSingleton.OnError(Server.GetLastError());
        }

        /// <summary>
        /// The infrastructure event that is raised each time a new session is created.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        void Session_Start(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The infrastructure event that is raised each time a session is terminated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        void Session_End(object sender, EventArgs e)
        {
        }
    }
}
