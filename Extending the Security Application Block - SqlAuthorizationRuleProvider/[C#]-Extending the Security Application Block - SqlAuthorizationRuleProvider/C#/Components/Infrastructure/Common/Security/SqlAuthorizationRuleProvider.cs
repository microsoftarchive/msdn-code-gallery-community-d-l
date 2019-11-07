using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Configuration;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Security.Instrumentation;
using System.Data.SqlClient;
using Volvo.VehicleMaster.Infrastructure.Common.Utilities.Caching;

namespace Volvo.VehicleMaster.Infrastructure.Common.Utilities.Security
{
    [ConfigurationElementType(typeof(SqlAuthorizationProviderData))]
    public class SqlAuthorizationRuleProvider : AuthorizationProvider
    {
        private readonly IDictionary<string, IAuthorizationRepository> authorizationRepositories;
        private Dictionary<string, IAuthorizationRule> authorizationRules;
        private CacheManager m_CacheManager;
        private static string CACHEKEY = "AuthorizationRules";

        /// <summary>
        /// Initialize an instance of the <see cref="SqlAuthorizationRuleProvider"/> class.
        /// </summary>
        /// <param name="authorizationRules">The collection of rules.</param>
        public SqlAuthorizationRuleProvider(IDictionary<string, IAuthorizationRepository> authorizationRepositories)
            : this(authorizationRepositories, new NullAuthorizationProviderInstrumentationProvider())
        {
        }

		/// <summary>
        /// Initialize an instance of the <see cref="SqlAuthorizationRuleProvider"/> class.
		/// </summary>
		/// <param name="authorizationRules">The collection of rules.</param>
        /// <param name="instrumentationProvider">The instrumentation prover to use.</param>
        public SqlAuthorizationRuleProvider(IDictionary<string, IAuthorizationRepository> authorizationRepositories, IAuthorizationProviderInstrumentationProvider instrumentationProvider)
            :base(instrumentationProvider)
		{
            if (authorizationRepositories == null) throw new ArgumentNullException("authorizationRepositories");
            if (authorizationRepositories.Count ==0) throw new ArgumentNullException("authorizationRepositories");
            this.authorizationRepositories = authorizationRepositories;
            m_CacheManager = new CacheManager();
		}

        /// <summary>
        /// Evaluates the specified authority against the specified context.
        /// </summary>
        /// <param name="principal">Must be an <see cref="IPrincipal"/> object.</param>
        /// <param name="ruleName">The name of the rule to evaluate.</param>
        /// <returns><c>true</c> if the expression evaluates to true,
        /// otherwise <c>false</c>.</returns>
        public override bool Authorize(IPrincipal principal, string ruleName)
        {
            if (principal == null) throw new ArgumentNullException("principal");
			if (ruleName == null || ruleName.Length == 0) throw new ArgumentNullException("ruleName");

            //get the rules from the cache
            if (m_CacheManager.ContainsKey(CACHEKEY))
            {
                GetAuthorizationRulesFromCache();
            }
            else 
            {
                GetAuthorizationRules();
            }

            InstrumentationProvider.FireAuthorizationCheckPerformed(principal.Identity.Name, ruleName);

            BooleanExpression booleanExpression = GetParsedExpression(ruleName);
            if (booleanExpression == null)
            {
                throw new InvalidOperationException(string.Format("Authorization Rule Not Found", ruleName));
            }

            bool result = booleanExpression.Evaluate(principal);

            if (result == false)
            {
                InstrumentationProvider.FireAuthorizationCheckFailed(principal.Identity.Name, ruleName);
            }
            return result;
        }

        /// <summary>
        /// Read rules from db
        /// </summary>
        private void GetAuthorizationRules()
        {
           //Read cache to get the rules
           // if cache does not have it, then read from database
            authorizationRules = new Dictionary<string, IAuthorizationRule>();
            string connectionString = authorizationRepositories["default"].Connectionstring;
           // cache the rules
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT Name, Expression FROM AuthorizationRule;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authorizationRules.Add(reader.GetString(0), new SqlAuthorizationRule(reader.GetString(0), reader.GetString(1)));
                    }
                }                
                reader.Close();
            }

            if (authorizationRules.Count > 0)
            {
                m_CacheManager.Remove(CACHEKEY);
                m_CacheManager.Add(CACHEKEY, authorizationRules);
            }
        }

        /// <summary>
        /// Read rules from Cahce
        /// </summary>
        private void GetAuthorizationRulesFromCache()
        {
            //Read cache to get the rules
            // if cache does not have it, then read from database
            //authorizationRules = new Dictionary<string, IAuthorizationRule>();
            authorizationRules = m_CacheManager.Get(CACHEKEY) as Dictionary<string, IAuthorizationRule>;
        }

        private BooleanExpression GetParsedExpression(string ruleName)
        {
            IAuthorizationRule rule = null;
            authorizationRules.TryGetValue(ruleName, out rule);
            if (rule == null) return null;

            string expression = rule.Expression;
            Parser parser = new Parser();

            return parser.Parse(expression);
        }
    }
}
