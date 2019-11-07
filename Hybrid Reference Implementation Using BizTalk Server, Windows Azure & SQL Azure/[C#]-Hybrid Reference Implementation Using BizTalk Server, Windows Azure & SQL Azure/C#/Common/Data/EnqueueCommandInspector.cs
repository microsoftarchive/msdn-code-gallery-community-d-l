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
namespace Contoso.Cloud.Integration.Common.Data
{
    #region Using references
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Data;
    using Contoso.Cloud.Integration.Common.Properties;
    #endregion

    /// <summary>
    /// Implements a SQL command inspector for the Enqueue operation against the Persistence Queue database.
    /// </summary>
    public class EnqueueCommandInspector : IDbCommandInspector
    {
        #region Public properties
        /// <summary>
        /// Returns the size of the item's payload.
        /// </summary>
        public long QueueItemSize { get; private set; }

        /// <summary>
        /// Returns the type of the item (empty for binary payload, a concatenated value of the XML namespace and root node name for XML payload).
        /// </summary>
        public string QueueItemType { get; private set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Inspects the specified SQL command and takes appropriate actions based on the results of inspection.
        /// </summary>
        /// <param name="command">The SQL command to be inspected.</param>
        public void Inspect(IDbCommand command)
        {
            QueueItemSize = SqlParameterUtility.GetParameterValueAs<long>(command, SqlObjectResources.ColumnQueueItemSize);
            QueueItemType = SqlParameterUtility.GetParameterValueAs<string>(command, SqlObjectResources.ColumnQueueItemType);
        }
        #endregion
    }
}
