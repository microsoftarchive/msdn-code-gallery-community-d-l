using System;
using System.Data;
using System.Data.Common;

namespace MasaSam.Data
{
    /// <summary>
    /// Class that contains extension methods for the <see cref="IDbConnection"/> interface.
    /// </summary>
    public static class ConnectionExtensions
    {
        public static bool TryOpen(this IDbConnection connection, out Exception exception)
        {
            exception = null;

            try
            {
                if (connection == null)
                {
                    exception = new ArgumentNullException("connection");
                    return false;
                }

                if (connection.State == ConnectionState.Open)
                {
                    return true;
                }

                connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }
    }
}
