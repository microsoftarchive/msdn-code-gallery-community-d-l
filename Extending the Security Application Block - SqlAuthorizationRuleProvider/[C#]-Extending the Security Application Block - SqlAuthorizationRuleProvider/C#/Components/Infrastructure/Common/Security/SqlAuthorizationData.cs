using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace Volvo.VehicleMaster.Infrastructure.Common.Utilities.Security
{
    public class SqlAuthorizationData : NamedConfigurationElement, IAuthorizationRepository
    {
        private const string connectionstringProperty = "connectionstring";

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="SqlAuthorizationData"/> class.
        /// </summary>
        public SqlAuthorizationData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlAuthorizationData"/> class with the specified name and connectionstring.
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="connectionstring">The connectionstring associated with this rule repository.</param>
        public SqlAuthorizationData(string name, string connectionstring)
            : base(name)
        {
            this.Connectionstring = connectionstring;
        }

        /// <summary>
        /// Gets or sets the connectionstring associated with
        /// this rule repository.
        /// </summary>
        [ConfigurationProperty(connectionstringProperty, IsRequired = true)]
        public string Connectionstring
        {
            get
            {
                return (string)this[connectionstringProperty];
            }
            set
            {
                this[connectionstringProperty] = value;
            }
        }
    }
}
