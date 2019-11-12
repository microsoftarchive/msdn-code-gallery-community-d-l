#pragma once

#include <hdfs.h>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Text;

namespace Microsoft
{
    namespace Hdfs
    {       
        /// <summary>
        /// Class for a connection to HDFS file.
        /// </summary>
        public ref class HdfsFileHandle sealed
        {
        private:
            IntPtr connection;

            hdfsFile file;

            String^ filePath;

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
            /// Create the HDFS File Handle.
            /// </summary>
            HdfsFileHandle(String^ path, IntPtr conHandle, hdfsFile fileArg):filePath(path), connection(conHandle), file(fileArg) { }

        public: 
            /// <summary>
            /// Disposes of the HDFS File Handle.
            /// </summary>
            !HdfsFileHandle() 
            {
                if (file != NULL)
                {
                    Close();
                }
            }

            /// <summary>
            /// Destroys the HDFS File Handle.
            /// </summary>
            ~HdfsFileHandle()
            {
                this->!HdfsFileHandle();
            }

            /// <summary>
            /// Gets the HDFS file path.
            /// </summary>
            property String^ Name { String^ get (); }

            /// <summary>
            /// Performs a write of bytes to the HDFS file.
            /// </summary>
            /// <param name="bytes">The bytes to write.</param>
            /// <param name="pos">The byte array starting position.</param>
            /// <param name="len">The byte array length.</param>
            /// <returns>Number of Bytes written.</returns>
            int32_t WriteBytes(array<Byte>^ bytes, int32_t pos, int32_t len);

            /// <summary>
            /// Performs a write of a single byte to the HDFS file.
            /// </summary>
            /// <param name="inputbyte">The byte to write.</param>
            /// <returns>Number of Bytes written.</returns>
            int32_t WriteByte(Byte^ inputbyte);

            /// <summary>
            /// Performs a write of a text line to the HDFS file.
            /// </summary>
            /// <param name="inputline">The text line to write.</param>
            /// <returns>Number of Bytes written.</returns>
            int32_t WriteLine(String^ inputline);

            /// <summary>
            /// Reads bytes from a HDFS file.
            /// </summary>
            /// <param name="bytes">The byte array to populate.</param>
            /// <param name="offset">The byte array starting position.</param>
            /// <param name="len">The byte array length.</param>
            /// <returns>Number of Bytes read.</returns>
            int32_t ReadBytes(array<Byte>^ bytes, int32_t offset, int32_t len);

            /// <summary>
            /// Reads a single byte from a HDFS file.
            /// </summary>
            /// <returns>Value of bytes read.</returns>
            int32_t ReadByte();

            /// <summary>
            /// Reads a text line from a HDFS file.
            /// </summary>
            /// <returns>Number of Bytes read.</returns>
            String^ ReadLine();

            /// <summary>
            /// Reads bytes from a HDFS file from a specified position.
            /// </summary>
            /// <param name="bytes">The byte array to populate.</param>
            /// <param name="position">The file read starting position.</param>
            /// <param name="offset">The byte array starting position.</param>
            /// <param name="len">The byte array length.</param>
            /// <returns>Number of Bytes read.</returns>
            int32_t PositionalReadBytes(array<Byte>^ bytes, int32_t position, int32_t offset, int32_t len);

            /// <summary>
            /// Reads a single byte from a HDFS file from a specified position.
            /// </summary>
            /// <param name="position">The file read starting position.</param>
            /// <returns>Number of Bytes read.</returns>
            int32_t PositionalReadByte(int32_t position);

            /// <summary>
            /// Performs a seek of a HDFS file.
            /// </summary>
            /// <returns>Position set within the file.</returns>
            int Seek(int64_t desiredPos);

            /// <summary>
            /// Determines the current offset of a HDFS file.
            /// </summary>
            /// <returns>Current position within the file.</returns>
            int64_t Tell();
        
            /// <summary>
            /// Determines what is availble in the HDFS file.
            /// </summary>
            /// <returns>Available bytes within the file.</returns>
            int64_t Available();

            /// <summary>
            /// Closes a HDFS file.
            /// </summary>
            /// <exception cref="System::IO::IOException">Thrown when Close fails.</exception>
            void Close();
        
            /// <summary>
            /// Flushes the contents of an HDFS file.
            /// </summary>
            /// <returns>Indicator for whether the file was flushed.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Flush fails.</exception>
            void Flush();

            /// <summary>
            /// Determines if the HDFS file handle is valid.
            /// </summary>
            /// <returns>Indicator for whether file handle is valid.</returns>
            bool IsValid();
        };    
    }
}
