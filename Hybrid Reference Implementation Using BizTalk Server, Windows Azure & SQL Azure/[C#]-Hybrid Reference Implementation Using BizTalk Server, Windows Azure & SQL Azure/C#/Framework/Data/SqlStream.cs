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
    using System.IO;
    using System.Data.SqlClient;
    using System.Data;
    #endregion

    /// <summary>
    /// Implements a data stream over a VarChar(max) or VarBinary(max) field.
    /// </summary>
    public class SqlStream : Stream
    {
        #region Private members
        private long position = 0;
        private readonly SqlCommand readCommand;
        private readonly SqlCommand writeCommand;
        private readonly long dataLength;
        private readonly RetryPolicy commandRetryPolicy;
        private readonly bool disposeCommands;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="SqlStream"/> object using the specified custom commands for manipulating with the source field holding the underlying data.
        /// </summary>
        /// <param name="connection">The database connection providing access to the underlying data.</param>
        /// <param name="readCommand">The instance of a SQL command responsible for retrieving the data from the source field.</param>
        /// <param name="writeCommand">The instance of a SQL command responsible for updating the data held in the source field.</param>
        /// <param name="getLengthCommand">The instance of a SQL command responsible for returning the size of the data held in the source field.</param>
        public SqlStream(ReliableSqlConnection connection, SqlCommand readCommand, SqlCommand writeCommand, SqlCommand getLengthCommand)
        {
            Guard.ArgumentNotNull(connection, "connection");
            Guard.ArgumentNotNull(readCommand, "readCommand");
            Guard.ArgumentNotNull(writeCommand, "writeCommand");
            Guard.ArgumentNotNull(getLengthCommand, "getLengthCommand");

            this.readCommand = readCommand;
            this.writeCommand = writeCommand;
            this.commandRetryPolicy = connection.CommandRetryPolicy;
            this.dataLength = GetLength(connection, getLengthCommand);
            this.disposeCommands = false;
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="SqlStream"/> object using the specified details describing the source field holding the underlying data.
        /// </summary>
        /// <param name="connection">The database connection providing access to the underlying data.</param>
        /// <param name="schemaName">The name of the database schema holding the source table.</param>
        /// <param name="tableName">The name of the database table holding the source field containing the data.</param>
        /// <param name="dataColumn">The name of the database column holding the data.</param>
        /// <param name="keyColumn">The name of the database field which represents a lookup key for the source row containing the data.</param>
        /// <param name="keyType">The type of the lookup key.</param>
        /// <param name="keyValue">The value of the lookup key.</param>
        public SqlStream(ReliableSqlConnection connection, string schemaName, string tableName, string dataColumn, string keyColumn, SqlDbType keyType, object keyValue)
        {
            Guard.ArgumentNotNull(connection, "connection");
            Guard.ArgumentNotNullOrEmptyString(schemaName, "schemaName");
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            Guard.ArgumentNotNullOrEmptyString(dataColumn, "dataColumn");
            Guard.ArgumentNotNullOrEmptyString(keyColumn, "keyColumn");
            Guard.ArgumentNotNull(keyValue, "keyValue");

            this.dataLength = GetLength(connection, schemaName, tableName, dataColumn, keyColumn, keyType, keyValue);
            this.readCommand = SqlCommandFactory.CreateSqlStreamReadCommand(connection, schemaName, tableName, dataColumn, keyColumn, keyType, keyValue) as SqlCommand;
            this.writeCommand = SqlCommandFactory.CreateSqlStreamWriteCommand(connection, schemaName, tableName, dataColumn, keyColumn, keyType, keyValue) as SqlCommand;
            this.commandRetryPolicy = connection.CommandRetryPolicy;
            this.disposeCommands = true;
        }
        #endregion

        #region Stream implementation
        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        public override bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length
        {
            get { return this.dataLength; }
        }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        public override long Position
        {
            get { return position; }
            set { this.Seek(value, SeekOrigin.Begin); }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying data store.
        /// </summary>
        public override void Flush()
        { 
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A  value of type <see cref="System.IO.SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    if ((offset < 0) && (offset > this.Length))
                    {
                        throw new ArgumentException("Invalid seek origin.");
                    }

                    position = offset;
                    break;
                
                case SeekOrigin.End:
                    if ((offset > 0) && (offset < -this.Length))
                    {
                        throw new ArgumentException("Invalid seek origin.");
                    }

                    position = this.Length - offset;
                    break;

                case SeekOrigin.Current:
                    if ((position + offset > this.Length) || ((position + offset) < 0))
                    {
                        throw new ArgumentException("Invalid seek origin.");
                    }

                    position = position + offset;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("origin", origin, "Invalid Origin");
            }
            return position;
        }

        /// <summary>
        /// Sets the length of the current stream.
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero if the end of the stream has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            Guard.ArgumentNotNull(buffer, "buffer");
            Guard.ArgumentNotNegativeValue(offset, "offset");
            Guard.ArgumentNotNegativeValue(count, "count");

            if (buffer.Length - offset < count) throw new ArgumentException("Offset and length were out of bounds for the array");

            byte[] data = Read(Position, count);
            if (data == null) return 0;

            Buffer.BlockCopy(data, 0, buffer, offset, data.Length);
            position += data.Length;

            return data.Length;
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            Guard.ArgumentNotNull(buffer, "buffer");
            Guard.ArgumentNotNegativeValue(offset, "offset");
            Guard.ArgumentNotNegativeValue(count, "count");

            if (buffer.Length - offset < count) throw new ArgumentException("Offset and length were out of bounds for the array");

            byte[] data = GetWriteBuffer(buffer, count, offset);
            Write(data, position, count);
            position += count;
        }
        #endregion

        #region Private methods
        private static long GetLength(ReliableSqlConnection connection, string schemaName, string tableName, string dataColumn, string keyColumn, SqlDbType keyType, object keyValue)
        {
            using (IDbCommand getLengthCommand = SqlCommandFactory.CreateSqlStreamGetSizeCommand(connection, schemaName, tableName, dataColumn, keyColumn, keyType, keyValue))
            {
                return GetLength(connection, getLengthCommand);
            }
        }

        private static long GetLength(ReliableSqlConnection connection, IDbCommand getLengthCommand)
        {
            long? length = connection.ExecuteCommand<long?>(getLengthCommand);
            return length.HasValue ? length.Value : 0;
        }

        private byte[] Read(long offset, long length)
        {
            readCommand.Parameters["@offset"].Value = offset + 1;
            readCommand.Parameters["@length"].Value = length;

            return (byte[])readCommand.ExecuteScalarWithRetry(this.commandRetryPolicy);
        }

        private void Write(byte[] buffer, long offset, long length)
        {
            writeCommand.Parameters["@buffer"].Value = buffer;
            writeCommand.Parameters["@offset"].Value = offset;
            writeCommand.Parameters["@length"].Value = length;

            writeCommand.ExecuteNonQueryWithRetry(this.commandRetryPolicy);
        }

        private static byte[] GetWriteBuffer(byte[] buffer, int count, int offset)
        {
            if (buffer.Length == count) return buffer;
            
            byte[] data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);
            
            return data;
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        /// <param name="disposing">Determines whether this was called by Dispose or by the finaliser.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (readCommand != null && this.disposeCommands)
                {
                    this.readCommand.Dispose();
                }

                if (writeCommand != null && this.disposeCommands)
                {
                    this.writeCommand.Dispose();
                }
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}