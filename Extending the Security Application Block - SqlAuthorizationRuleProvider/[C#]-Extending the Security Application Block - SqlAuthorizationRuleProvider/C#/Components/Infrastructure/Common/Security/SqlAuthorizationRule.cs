using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security;

namespace Volvo.VehicleMaster.Infrastructure.Common.Utilities.Security
{
    [Serializable]
    public class SqlAuthorizationRule : IAuthorizationRule
    {
        private string name;
        private string expression;

        public string Name
        {
            get { return name; }
        }

        public string Expression
        {
            get { return expression; }
        }

        public SqlAuthorizationRule(string name, string expression)
        {
            this.name = name;
            this.expression = expression;
        }
    }
}
