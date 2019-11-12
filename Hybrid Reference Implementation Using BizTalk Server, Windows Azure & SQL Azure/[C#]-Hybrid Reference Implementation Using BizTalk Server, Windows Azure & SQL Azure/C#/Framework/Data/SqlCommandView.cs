//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Data
{
    #region Using references
    using System;
    using System.Data;
    #endregion

    /// <summary>
    /// Defines the interface that must be implemented by read-only viewers of SQL command objects.
    /// </summary>
    public interface IDbCommandInspector
    {
        /// <summary>
        /// Inspects the specified SQL command and takes appropriate actions based on the results of inspection.
        /// </summary>
        /// <param name="command">The SQL command to be inspected.</param>
        void Inspect(IDbCommand command);
    }

    /// <summary>
    /// Implements a generic mechanism for supporting application-specific views against SQL commands using the concept of a command inspector.
    /// </summary>
    /// <typeparam name="T">The type that implements the <see cref="IDbCommandInspector"/> interface which provides the command inspection facility.</typeparam>
    public class SqlCommandView<T> where T : IDbCommandInspector, new()
    {
        #region Private members
        private readonly T inspector;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="SqlCommandView&lt;T&gt;"/> object using the specified SQL command that is intended to be inspected.
        /// </summary>
        /// <param name="command">The SQL command to be inspected.</param>
        public SqlCommandView(IDbCommand command)
        {
            this.inspector = new T();
            this.inspector.Inspect(command);
        }
        #endregion

        #region Public members
        /// <summary>
        /// Returns the SQL command inspector object associated with the current instance. 
        /// </summary>
        public T Inspector
        {
            get { return this.inspector; }
        }
        #endregion
    }
}
