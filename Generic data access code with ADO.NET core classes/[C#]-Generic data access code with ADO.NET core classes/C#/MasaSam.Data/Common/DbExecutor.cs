using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasaSam.Data.Common
{
    /// <summary>
    /// Base class for the ADO.NET provider specific database executor.
    /// </summary>
    public abstract class DbExecutor
    {
        #region Fields

        private readonly string connectionString;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes new instance of the <see cref="DbExecutor"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        protected DbExecutor(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString");

            this.connectionString = connectionString;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute query that returns only single record.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="settings">The settings for the command to be executed.</param>
        /// <param name="mappings">The mappings between properties and columns.</param>
        /// <returns>A single <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public T GetSingleRecord<T>(CommandSettings settings, IEnumerable<PropertyColumnMapping> mappings) where T : class, new()
        {
            using (var connection = GetConnection())
            using (var command = GetCommand(settings, connection))
            {
                Exception exception;

                if (connection.TryOpen(out exception))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.GetSingleRecord<T>(mappings);
                    }
                }
                else
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// Execute query that returns only single record.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="settings">The settings for the command to be executed.</param>
        /// <param name="ctorMappings">The mappings between constructor arguments and columns.</param>
        /// <param name="propMappings">The mappings between properties and columns.</param>
        /// <returns>A single <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public T GetSingleRecord<T>(CommandSettings settings, ColumnConstructorParameterMappingCollection<T> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings = null) where T : class
        {
            using (var connection = GetConnection())
            using (var command = GetCommand(settings, connection))
            {
                Exception exception;

                if (connection.TryOpen(out exception))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.GetSingleRecord<T>(ctorMappings, propMappings);
                    }
                }
                else
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// Execute query that might return multiple records, but only 1st one is retrieved.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="settings">The settings for the command to be executed.</param>
        /// <param name="mappings">The mappings between properties and columns.</param>
        /// <returns>A first <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public T GetFirstRecord<T>(CommandSettings settings, IEnumerable<PropertyColumnMapping> mappings) where T : class, new()
        {
            using (var connection = GetConnection())
            using (var command = GetCommand(settings, connection))
            {
                Exception exception;

                if (connection.TryOpen(out exception))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.GetFirstRecord<T>(mappings);
                    }
                }
                else
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// Execute query that might return multiple records, but only 1st one is retrieved.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="settings">The settings for the command to be executed.</param>
        /// <param name="ctorMappings">The mappings between constructor arguments and columns.</param>
        /// <param name="propMappings">The mappings between properties and columns.</param>
        /// <returns>A first <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public T GetFirstRecord<T>(CommandSettings settings, ColumnConstructorParameterMappingCollection<T> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings = null) where T : class
        {
            using (var connection = GetConnection())
            using (var command = GetCommand(settings, connection))
            {
                Exception exception;

                if (connection.TryOpen(out exception))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.GetFirstRecord<T>(ctorMappings, propMappings);
                    }
                }
                else
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// Execute query that returns all the records.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="settings">The settings for the command to be executed.</param>
        /// <param name="mappings">The mappings between properties and columns.</param>
        /// <returns>A enumerable of <typeparamref name="T"/> instances.</returns>
        public IEnumerable<T> GetRecords<T>(CommandSettings settings, IEnumerable<PropertyColumnMapping> mappings) where T : class, new()
        {
            using (var connection = GetConnection())
            using (var command = GetCommand(settings, connection))
            {
                Exception exception;

                if (connection.TryOpen(out exception))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.GetRecords<T>(mappings);
                    }
                }
                else
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// Execute query that returns all the records.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="settings">The settings for the command to be executed.</param>
        /// <param name="ctorMappings">The mappings between constructor arguments and columns.</param>
        /// <param name="propMappings">The mappings between properties and columns.</param>
        /// <returns>A enumerable of <typeparamref name="T"/> instances.</returns>
        public IEnumerable<T> GetRecords<T>(CommandSettings settings, ColumnConstructorParameterMappingCollection<T> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings = null) where T : class
        {
            using (var connection = GetConnection())
            using (var command = GetCommand(settings, connection))
            {
                Exception exception;

                if (connection.TryOpen(out exception))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.GetRecords<T>(ctorMappings, propMappings);
                    }
                }
                else
                {
                    throw exception;
                }
            }
        }
       
        #endregion

        #region Abstract methods

        /// <summary>
        /// Derived class must override to return provider specific <see cref="DbConnection"/> instance.
        /// </summary>
        /// <returns>A ADO.NET provider specific <see cref="DbConnection"/> instance.</returns>
        protected abstract DbConnection GetConnection();

        /// <summary>
        /// Derived class mut override to return provider specific <see cref="DbCommand"/> instance.
        /// </summary>
        /// <param name="settings">The <see cref="CommandSettings"/>.</param>
        /// <param name="connection">The <see cref="DbConnection"/>.</param>
        /// <returns>A ADO.NET provider specific <see cref="DbCommand"/> instance.</returns>
        protected abstract DbCommand GetCommand(CommandSettings settings, DbConnection connection);

        #endregion
    }
}
