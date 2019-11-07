// ***********************************************************************
// Assembly         : BizTalk.CRMOnline.WCF.Behavior
// Author           : SMSVikasK
// Created          : 24-03-2015
//
// Last Modified By : Vikas Kerehalli
// Last Modified On : 24-03-2015
// ***********************************************************************
// <copyright file="CRMExtensionElement.cs" company="BizTalk">
//     Copyright © 
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BizTalk.CRMOnline.WCF.Behavior
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel.Configuration;
    using System.Text;
    using System.Threading.Tasks;  
  
    /// <summary>
    /// Implementing the interface BehaviorExtensionElement
    /// </summary>
    public class CRMExtensionElement : BehaviorExtensionElement
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>        
        [ConfigurationProperty("UserName", DefaultValue = "", IsRequired = true)]
        public string Username
        {
            get { return (string)base["UserName"]; }
            set { base["UserName"] = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [ConfigurationProperty("Password", DefaultValue = "", IsRequired = true)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }

        /// <summary>
        /// Gets or sets the CRM URI.
        /// </summary>
        /// <value>The CRM URI.</value>
        [ConfigurationProperty("CRMUri", DefaultValue = "", IsRequired = true)]
        public string CRMUri
        {
            get { return (string)base["CRMUri"]; }
            set { base["CRMUri"] = value; }
        }

        /// <summary>
        /// Gets or sets the applies to.
        /// </summary>
        /// <value>The applies to.</value>
        [ConfigurationProperty("AppliesTo", DefaultValue = "", IsRequired = true)]
        public string AppliesTo
        {
            get { return (string)base["AppliesTo"]; }
            set { base["AppliesTo"] = value; }
        }

        /// <summary>
        /// Gets the type of behavior.
        /// </summary>
        /// <value>The type of the behavior.</value>
        public override Type BehaviorType
        {
            get { return typeof(CRMEndpoint); }
        }

        /// <summary>
        /// Sets the <see cref="T:System.Configuration.ConfigurationElement" /> object to its initial state.
        /// </summary>
        protected override void Init()
        {
            base.Init();
        }

        /// <summary>
        /// Used to initialize a default set of values for the <see cref="T:System.Configuration.ConfigurationElement" /> object.
        /// </summary>
        protected override void InitializeDefault()
        {
            base.InitializeDefault();
        }

        /// <summary>
        /// Creates a behavior extension based on the current configuration settings.
        /// </summary>
        /// <returns>The behavior extension.</returns>
        protected override object CreateBehavior()
        {
            CRMEndpoint behavior = new CRMEndpoint();
            behavior.UserName = this.Username;
            behavior.Password = this.Password;
            behavior.CRMUrl = this.CRMUri;
            behavior.AppliesTo = this.AppliesTo;
            return behavior;
        }
    }
}
