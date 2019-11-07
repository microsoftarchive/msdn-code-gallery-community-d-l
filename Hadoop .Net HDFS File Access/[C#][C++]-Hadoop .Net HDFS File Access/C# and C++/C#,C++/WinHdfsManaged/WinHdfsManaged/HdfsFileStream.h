#pragma once

#include <hdfs.h>

#include "HdfsFileInfoEntry.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Runtime::InteropServices;
using namespace System::Text;

namespace Microsoft
{
    namespace Hdfs
    {       
        /// <summary>
        /// Class for a connection to HDFS file.
        /// </summary>
        public ref class HdfsFileStream sealed : public Stream
        {
        private:
            IntPtr connection;

            hdfsFile file;

            String^ filePath;

            bool writeMode;

        internal: 
            /// <summary>
            /// Gets a HDFS File from a Handle.
            /// </summary>
            hdfsFile GetFile();

            /// <summary>
            /// Returns the HDFS Connection Handle.
            /// </summary>
            hdfsFS GetConnection();

            /// <summary>
            /// Create the HDFS File Stream.
            /// </summary>
            HdfsFileStream(String^ path, IntPtr conHandle, hdfsFile fileArg, bool writeModeArg):filePath(path), connection(conHandle), file(fileArg), writeMode(writeModeArg) { }

        public: 
            /// <summary>
            /// Disposes of the HDFS File Stream.
            /// </summary>
            !HdfsFileStream() 
            {
                if (file != NULL)
                {
                    Close();
                }
            }

            /// <summary>
            /// Destroys the HDFS File Stream.
            /// </summary>
            ~HdfsFileStream()
            {
                this->!HdfsFileStream();
            }


            /// <summary>
            /// Gets a value indicating whether the current stream supports reading.
            /// </summary>
            virtual property bool CanRead { bool get () override; }

            /// <summary>
            /// Gets a value indicating whether the current stream supports seeking.
            /// </summary>
            virtual property bool CanSeek { bool get () override; }

            /// <summary>
            /// Gets a value that determines whether the current stream can time out.
            /// </summary>
            virtual property bool CanTimeout { bool get () override; }

            /// <summary>
            /// Gets a value indicating whether the current stream supports writing.
            /// </summary>
            virtual property bool CanWrite { bool get () override; }

            /// <summary>
            /// Gets the length in bytes of the stream.
            /// </summary>
            virtual property long long Length { long long get () override; }

            /// <summary>
            /// Gets or sets the position within the current stream.
            /// </summary>
            virtual property long long Position { long long get () override; void set (long long value) override; }

            /// <summary>
            /// Gets or sets a value, in miliseconds, that determines how long the stream will attempt to read before timing out. 
            /// </summary>
            virtual property int ReadTimeout { int get () override; void set (int value) override; }

            /// <summary>
            /// Gets or sets a value, in miliseconds, that determines how long the stream will attempt to write before timing out.
            /// </summary>
            virtual property int WriteTimeout { int get () override; void set (int value) override; }

            /// <summary>
            /// Gets the original path specified for the file.
            /// </summary>
            property String^ Name { String^ get (); }


            /// <summary>
            /// Closes the current stream and releases any resources
            /// </summary>
            virtual void Close() override;

            /// <summary>
            /// Reads the bytes from the current stream and writes them to the destination stream.
            /// </summary>
            /// <param name="destination">The stream to copy File Stream into.</param>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            void CopyTo(Stream^ destination);

            /// <summary>
            /// Reads all the bytes from the current stream and writes them to a destination stream, using a specified buffer size.
            /// </summary>
            /// <param name="destination">The stream to copy File Stream into.</param>
            /// <param name="bufferSize">The bufffer size to use for copying the stream.</param>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            void CopyTo(Stream^ destination, int bufferSize);

            /// <summary>
            /// Clears all buffers for this stream and causes any buffered data to be written.
            /// </summary>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            virtual void Flush() override;

            /// <summary>
            /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
            /// </summary>
            /// <param name="buffer">The byte array to populate.</param>
            /// <param name="offset">The byte array starting position.</param>
            /// <param name="count">The number of bytes to write.</param>
            /// <returns>The number of bytes read.</returns>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            virtual int Read([InAttribute] [OutAttribute] array<Byte>^ buffer, int offset, int count) override;

            /// <summary>
            /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
            /// </summary>
            /// <returns>Value of bytes read.</returns>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            virtual int ReadByte() override;

            /// <summary>
            /// Sets the position within the current stream.
            /// </summary>
            /// <param name="offset">The position to set within the stream.</param>
            /// <param name="origin">The Origin from which to Seek.</param>
            /// <returns>Position set within the file.</returns>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            virtual long long Seek(long long offset, SeekOrigin origin) override;

            /// <summary>
            /// Sets the length of the current stream.
            /// Not supported for the HDFS File Stream.
            /// </summary>
            /// <param name="value">The length to set for the stream.</param>
            /// <exception cref="System::InvalidOperationException">Thrown when the Set Length is called as operation not supported.</exception>
            virtual void SetLength(long long value) override;

            /// <summary>
            /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
            /// </summary>
            /// <param name="buffer">The byte array to write to the stream.</param>
            /// <param name="offset">The byte array starting position.</param>
            /// <param name="count">The number of bytes to write.</param>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            virtual void Write(array<Byte>^ buffer, int offset, int count) override;

            /// <summary>
            /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
            /// </summary>
            /// <param name="value">The byte to write.</param>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            virtual void WriteByte(Byte value) override;

            /// <summary>
            /// Reads bytes from a HDFS file from a specified position.
            /// </summary>
            /// <param name="bytes">The byte array to populate.</param>
            /// <param name="position">The file read starting position.</param>
            /// <param name="offset">The byte array starting position.</param>
            /// <param name="len">The byte array length.</param>
            /// <returns>Number of Bytes read.</returns>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            int PositionalRead(array<Byte>^ bytes, int position, int offset, int len);

            /// <summary>
            /// Reads a single byte from a HDFS file from a specified position.
            /// </summary>
            /// <param name="position">The file read starting position.</param>
            /// <returns>Number of Bytes read.</returns>
            /// <exception cref="System::NotSupportedException">Thrown when Stream does not support this operation.</exception>
            int PositionalReadByte(int position);

            /// <summary>
            /// Performs a chown of the HDFS File.
            /// </summary>
            /// <param name="owner">The new owner.</param>
            /// <param name="group">The new group.</param>
            /// <returns>Indicator for whether the chown was successful.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Chown fails.</exception>
            void Chown(String^ owner, String^ group);

            /// <summary>
            /// Performs a chmod of the HDFS File.
            /// </summary>
            /// <param name="mode">The mode bitmask.</param>
            /// <returns>Indicator for whether the chmod was successful.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Chmod fails.</exception>
            void Chmod(short mode);

            /// <summary>
            /// Modifies the File Modified and Last Accessed Time.
            /// </summary>
            /// <param name="modifiedTime">The modified time.</param>
            /// <param name="accessedTime">The last accessed time.</param>
            /// <returns>Indicator for whether the file modification was successful.</returns>
            /// <exception cref="System::IO::IOException">Thrown when the Set fails.</exception>
            void SetTimes(System::DateTime modifiedTime, System::DateTime accessedTime);

            /// <summary>
            /// Gets the information associated with the File.
            /// </summary>
            /// <returns>File Information.</returns>
            HdfsFileInfoEntry^ GetInformation();

            /// <summary>
            /// Determines if the HDFS file handle is valid.
            /// </summary>
            /// <returns>Indicator for whether file handle is valid.</returns>
            bool IsValid();
        };    
    }
}
