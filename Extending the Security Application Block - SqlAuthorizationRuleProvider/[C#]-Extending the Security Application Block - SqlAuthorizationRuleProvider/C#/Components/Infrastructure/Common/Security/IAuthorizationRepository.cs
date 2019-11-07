using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Volvo.VehicleMaster.Infrastructure.Common.Utilities.Security
{
    public interface IAuthorizationRepository
    {
        /// <summary>
        /// Gets the name of the rule repository.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets the Connectionstring of the rule repository.
        /// </summary>
        string Connectionstring
        {
            get;
        }
    }
}
