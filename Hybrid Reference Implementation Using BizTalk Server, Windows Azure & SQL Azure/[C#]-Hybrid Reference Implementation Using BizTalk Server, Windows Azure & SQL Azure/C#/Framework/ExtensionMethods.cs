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
namespace Contoso.Cloud.Integration.Framework
{
    #region Using statements
    using System;
    using System.IO;
    using System.Threading;
    using System.Xml;
    #endregion

    #region General extension methods
    /// <summary>
    /// Provides a set of extension methods that supplement various .NET Framework classes with value-add functionality.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Reads the specified number of bytes from the stream, starting from a specified point in the byte array. Ensures that the number of bytes 
        /// read from the stream will match the specified count unless the stream is empty or doesn't contain the expected amount of data.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryReader"/> instance providing access to the data stream.</param>
        /// <param name="buffer">The buffer to read data into.</param>
        /// <param name="index">The starting point in the buffer at which to begin reading into the buffer.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The number of bytes read into buffer. This might be less than the number of bytes requested if that many bytes are not available, or it might be zero if the end of the stream is reached.</returns>
        public static int ReadBuffered(this BinaryReader reader, byte[] buffer, int index, int count)
        {
            Guard.ArgumentNotNull(buffer, "buffer");
            Guard.ArgumentNotZeroOrNegativeValue(count, "count");

            int offset = 0;

            do
            {
                int bytesRead = reader.Read(buffer, index + offset, count);

                if (bytesRead == 0)
                {
                    break;
                }

                offset += bytesRead;
                count -= bytesRead;
            }
            while (count > 0);

            return offset;
        }
    }
    #endregion

    #region ReaderWriterLockSlim extension methods
    /// <summary>
    /// Provides a set of extension methods that supplement the <see cref="System.Threading.ReaderWriterLockSlim"/> class with value-add functionality.
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        /// <summary>
        /// Executes the specified action inside a read lock which is guaranteed to be reliably released upon completing the action.
        /// </summary>
        /// <param name="rwLock">The <see cref="System.Threading.ReaderWriterLockSlim"/> instance which this method extends.</param>
        /// <param name="action">The action to execute.</param>
        public static void PerformUsingReadLock(this ReaderWriterLockSlim rwLock, Action action)
        {
            Guard.ArgumentNotNull(rwLock, "rwLock");
            Guard.ArgumentNotNull(action, "action");

            try
            {
                rwLock.EnterReadLock();
                action();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Executes the specified function inside a read lock which is guaranteed to be reliably released upon completing the execution.
        /// </summary>
        /// <typeparam name="T">The type of the result returned by the executable function.</typeparam>
        /// <param name="rwLock">The <see cref="System.Threading.ReaderWriterLockSlim"/> instance which this method extends.</param>
        /// <param name="action">The function to execute.</param>
        /// <returns>The result returned by the executable function.</returns>
        public static T PerformUsingReadLock<T>(this ReaderWriterLockSlim rwLock, Func<T> action)
        {
            Guard.ArgumentNotNull(rwLock, "rwLock");
            Guard.ArgumentNotNull(action, "action");

            try
            {
                rwLock.EnterReadLock();
                return action();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Executes the specified action inside a write lock which is guaranteed to be reliably released upon completing the action.
        /// </summary>
        /// <param name="rwLock">The <see cref="System.Threading.ReaderWriterLockSlim"/> instance which this method extends.</param>
        /// <param name="action">The action to execute.</param>
        public static void PerformUsingWriteLock(this ReaderWriterLockSlim rwLock, Action action)
        {
            Guard.ArgumentNotNull(rwLock, "rwLock");
            Guard.ArgumentNotNull(action, "action");
            
            try
            {
                rwLock.EnterWriteLock();
                action();
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Executes the specified function inside a write lock which is guaranteed to be reliably released upon completing the execution.
        /// </summary>
        /// <typeparam name="T">The type of the result returned by the executable function.</typeparam>
        /// <param name="rwLock">The <see cref="System.Threading.ReaderWriterLockSlim"/> instance which this method extends.</param>
        /// <param name="action">The function to execute.</param>
        /// <returns>The result returned by the executable function.</returns>
        public static T PerformUsingWriteLock<T>(this ReaderWriterLockSlim rwLock, Func<T> action)
        {
            Guard.ArgumentNotNull(rwLock, "rwLock");
            Guard.ArgumentNotNull(action, "action");

            try
            {
                rwLock.EnterWriteLock();
                return action();
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Executes the specified action inside an upgradeable read lock which is guaranteed to be reliably released upon completing the action.
        /// </summary>
        /// <param name="rwLock">The <see cref="System.Threading.ReaderWriterLockSlim"/> instance which this method extends.</param>
        /// <param name="action">The action to execute.</param>
        public static void PerformUsingUpgradeableReadLock(this ReaderWriterLockSlim rwLock, Action action)
        {
            Guard.ArgumentNotNull(rwLock, "rwLock");
            Guard.ArgumentNotNull(action, "action");

            try
            {
                rwLock.EnterUpgradeableReadLock();
                action();
            }
            finally
            {
                rwLock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Executes the specified function inside an upgradeable read lock which is guaranteed to be reliably released upon completing the execution.
        /// </summary>
        /// <typeparam name="T">The type of the result returned by the executable function.</typeparam>
        /// <param name="rwLock">The <see cref="System.Threading.ReaderWriterLockSlim"/> instance which this method extends.</param>
        /// <param name="action">The function to execute.</param>
        /// <returns>The result returned by the executable function.</returns>
        public static T PerformUsingUpgradeableReadLock<T>(this ReaderWriterLockSlim rwLock, Func<T> action)
        {
            Guard.ArgumentNotNull(rwLock, "rwLock");
            Guard.ArgumentNotNull(action, "action");
            
            try
            {
                rwLock.EnterUpgradeableReadLock();
                return action();
            }
            finally
            {
                rwLock.ExitUpgradeableReadLock();
            }
        }
    }
    #endregion

    #region XmlWriter extension methods
    /// <summary>
    /// Provides a set of extension methods that supplement the <see cref="System.Xml.XmlWriter"/> class with value-add functionality.
    /// </summary>
    public static class XmlWriterExtensionMethods
    {
        /// <summary>
        /// Writes the specified start tag for a response message and associates it with the given namespace and prefix.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> instance which this method extends.</param>
        /// <param name="prefix">The namespace prefix of the element.</param>
        /// <param name="localName">The local name of the element.</param>
        /// <param name="ns">The namespace URI to associate with the element.</param>
        public static void WriteResponseStartElement(this XmlWriter writer, string prefix, string localName, string ns)
        {
            writer.WriteStartElement(prefix, String.Concat(localName, WellKnownContractMember.ResponseMethodSuffix), ns);
        }

        /// <summary>
        /// Writes the specified start tag for a result message and associates it with the given namespace and prefix.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> instance which this method extends.</param>
        /// <param name="prefix">The namespace prefix of the element.</param>
        /// <param name="localName">The local name of the element.</param>
        /// <param name="ns">The namespace URI to associate with the element.</param>
        public static void WriteResultStartElement(this XmlWriter writer, string prefix, string localName, string ns)
        {
            writer.WriteStartElement(prefix, String.Concat(localName, WellKnownContractMember.ResultMethodSuffix), ns);
        }
    } 
    #endregion

    #region TimeSpan extension methods
    /// <summary>
    /// Provides a set of extension methods that supplement the <see cref="System.TimeSpan"/> class with value-add functionality.
    /// </summary>
    public static class TimeSpanExtensionMethods
    {
        /// <summary>
        /// Returns the first non-default non-zero <see cref="System.TimeSpan"/> value from the given set of two arguments.
        /// </summary>
        /// <param name="first">The first <see cref="System.TimeSpan"/> value.</param>
        /// <param name="second">The second <see cref="System.TimeSpan"/> value.</param>
        /// <returns>The first <see cref="System.TimeSpan"/> value out of the two arguments that doesn't represent either a default, zero or minimum value for the given type.</returns>
        public static TimeSpan Coalesce(this TimeSpan first, TimeSpan second)
        {
            return first != default(TimeSpan) && first != TimeSpan.Zero && first != TimeSpan.MinValue ? first : second;
        }
    }
    #endregion

}