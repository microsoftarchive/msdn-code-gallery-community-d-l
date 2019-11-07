using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
using Microsoft.Practices.EnterpriseLibrary.Security.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Security;

namespace Volvo.VehicleMaster.Infrastructure.Common.Utilities.Security
{
    public class SqlAuthorizationProviderData : AuthorizationProviderData
    {
        private const string repositoryProperty = "repositories";

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="SqlAuthorizationRuleProvider"/> class.
        /// </summary>
        public SqlAuthorizationProviderData()
        {
            Type = typeof(SqlAuthorizationRuleProvider);
        }

        
		/// <summary>
		/// Initializes a new instance of the 
        /// <see cref="SqlAuthorizationRuleProvider"/> class.
		/// </summary>
		/// <param name="name">The name of the element.</param>
        public SqlAuthorizationProviderData(string name)
            : base(name, typeof(SqlAuthorizationRuleProvider))
		{
		}							

        /// <summary>
        /// Gets or sets the list of rules associated with
        /// the provider.
        /// </summary>
        /// <value>A collection of <see cref="SqlAuthorizationData"/>.</value>
        [ConfigurationProperty(repositoryProperty, IsRequired = false)]
        [ConfigurationCollection(typeof(SqlAuthorizationData))]
        public NamedElementCollection<SqlAuthorizationData> Rules
		{
			get
			{
                return (NamedElementCollection<SqlAuthorizationData>)base[repositoryProperty];
			}
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurationSource"></param>
        /// <returns></returns>
        public override IEnumerable<TypeRegistration> GetRegistrations(IConfigurationSource configurationSource)
        {
            yield return GetInstrumentationProviderRegistration(configurationSource);

            Dictionary<string, IAuthorizationRepository> authorizationRepositories = Rules.ToDictionary(ruleData => ruleData.Name, ruleData => (IAuthorizationRepository)ruleData);

            yield return new TypeRegistration<IAuthorizationProvider>(() => new SqlAuthorizationRuleProvider(authorizationRepositories, Container.Resolved<IAuthorizationProviderInstrumentationProvider>(Name)))
                {
                    Name = this.Name,
                    Lifetime = TypeRegistrationLifetime.Transient
                };
        }
    }
}
