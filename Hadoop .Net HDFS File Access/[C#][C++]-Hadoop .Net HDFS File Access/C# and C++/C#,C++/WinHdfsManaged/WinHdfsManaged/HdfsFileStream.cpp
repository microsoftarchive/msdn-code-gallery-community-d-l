#include "stdafx.h"

#include <string>

#include "Enumerations.h"
#include "ExceptionUtil.h"

#include "HdfsFileStream.h"
#include "HdfsFileSystem.h"
#include "HdfsFileInfoEntry.h"

using namespace std;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Text;

namespace Microsoft
{
    namespace Hdfs
    {
        /// <summary>
        /// Gets a HDFS File from a Handle.
        /// </summary>
        hdfsFile HdfsFileStream::GetFile()
        {
            ThrowIoIfFalse(file != NULL, "File Handle is no longer valid for this operation");

            return this->file;
        }
        
        /// <summary>
        /// Gets a Connection Handle.
        /// </summary>
        hdfsFS HdfsFileStream::GetConnection()
        {
            ThrowIoIfFalse(connection != IntPtr::Zero, "Connection has not yet been opened or has been closed");

            return this->connection.ToPointer();
        }

        /// <summary>
        /// Gets the HDFS file path.
        /// </summary>
        String^ HdfsFileStream::Name::get()
        {
            return this->filePath;
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        bool HdfsFileStream::CanRead::get()
        {
            return !this->writeMode;
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        bool HdfsFileStream::CanSeek::get()
        {
            return !this->writeMode;
        }

        /// <summary>
        /// Gets a value that determines whether the current stream can time out.
        /// </summary>
        bool HdfsFileStream::CanTimeout::get()
        {
            return false;
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        bool HdfsFileStream::CanWrite::get()
        {
            return this->writeMode;
        }

        /// <summary>
        /// Gets the number of bytes that can be read from this input stream without blocking.
        /// </summary>
        long long HdfsFileStream::Length::get()
        {
            if (!this->CanRead)
            {
                return -1;
            }

            return (long long)hdfsAvailable(this->GetConnection(), this->GetFile());
        }

        /// <summary>
        /// Gets the position within the current stream.
        /// </summary>
        long long HdfsFileStream::Position::get()
        {
            if (!this->CanSeek)
            {
                return -1;
            }

            return (long long)hdfsTell(this->GetConnection(), this->GetFile());
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        void HdfsFileStream::Position::set(long long value)
        {
            ThrowArgIfFalse(value >= 0, "Position must be positive", "value");
            ThrowNotSupportedIfFalse(this->CanSeek, "Seek operations are only supported on Read only Streams");

            hdfsSeek(this->GetConnection(), this->GetFile(), (tOffset)(value));
        }

        /// <summary>
        /// Gets or sets a value, in miliseconds, that determines how long the stream will attempt to read before timing out. 
        /// </summary>
        int HdfsFileStream::ReadTimeout::get()
        {
            throw gcnew InvalidOperationException("Stream does not Timeout operations");
        }

        /// <summary>
        /// Sets a value, in miliseconds, that determines how long the stream will attempt to read before timing out. 
        /// </summary>
        void HdfsFileStream::ReadTimeout::set(int value)
        {
            throw gcnew InvalidOperationException("Stream does not Timeout operations");
        }

        /// <summary>
        /// Gets or sets a value, in miliseconds, that determines how long the stream will attempt to write before timing out.
        /// </summary>
        int HdfsFileStream::WriteTimeout::get()
        {
            throw gcnew InvalidOperationException("Stream does not Timeout operations");
        }

        /// <summary>
        /// Sets a value, in miliseconds, that determines how long the stream will attempt to write before timing out.
        /// </summary>
        void HdfsFileStream::WriteTimeout::set(int value)
        {
            throw gcnew InvalidOperationException("Stream does not Timeout operations");
        }

        /// <summary>
        /// Closes the current stream and releases any resources
        /// </summary>
        void HdfsFileStream::Close()
        {
            int retVal = -1;

            if (this->file != NULL)
            {
                retVal = hdfsCloseFile(this->GetConnection(), this->GetFile());
                this->file = NULL;
            }

            ThrowIoIfFalse(retVal == 0, "Close failed");
        }

        /// <summary>
        /// Reads the bytes from the current stream and writes them to the destination stream.
        /// </summary>
        void HdfsFileStream::CopyTo(Stream^ destination)
        {
            return CopyTo(destination, 1024);
        }

        /// <summary>
        /// Reads all the bytes from the current stream and writes them to a destination stream, using a specified buffer size.
        /// </summary>
        void HdfsFileStream::CopyTo(Stream^ destination, int bufferSize)
        {
            ThrowArgIfFalse(bufferSize > 0, "Buffer Size must be greater than 0", "bufferSize");

            ThrowNotSupportedIfFalse(this->CanRead, "Read operations are not supported on the current stream");
            ThrowNotSupportedIfFalse(destination->CanWrite, "Write operations are not supported on Destination Stream");

            array<Byte>^ buffer = gcnew array<Byte>(bufferSize);
            int chunkSize;

            while ((chunkSize = Read(buffer, 0, bufferSize)) > 0)
            {
                destination->Write(buffer, 0, chunkSize);
            }

            return;
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written.
        /// </summary>
        void HdfsFileStream::Flush()
        {
            tSize retVal = -1;

            ThrowNotSupportedIfFalse(this->CanWrite, "Write operations are not supported on the current stream");

            retVal = hdfsFlush(this->GetConnection(), this->GetFile());

            ThrowIoIfFalse(retVal == 0, "Flush failed");
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        int HdfsFileStream::Read([InAttribute] [OutAttribute] array<Byte>^ buffer, int offset, int count)
        {
            ThrowArgIfFalse(offset >= 0, "Offset must be positive", "offset");
            ThrowArgIfFalse(count > 0, "Count must be greater than 0", "count");

            ThrowNotSupportedIfFalse(this->CanRead, "Read operations are not supported on the current stream");

            int32_t retVal = -1;
            int32_t size = Marshal::SizeOf(buffer[0]) * count;
            IntPtr pnt = Marshal::AllocHGlobal(size);
            retVal = (int32_t)hdfsRead(this->GetConnection(), this->GetFile(), pnt.ToPointer(), (tSize)count);

            if (retVal != -1)
            {
                Marshal::Copy(pnt, buffer, offset, retVal);
            }

            Marshal::FreeHGlobal(pnt);

            return retVal;
        }

        /// <summary>
        /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
        /// </summary>
        int HdfsFileStream::ReadByte()
        {
            ThrowNotSupportedIfFalse(this->CanRead, "Read operations are not supported on the current stream");

            int32_t retVal = -1;
            char* buffer = (char*)malloc(sizeof(char));
            tSize found = hdfsRead(this->GetConnection(), this->GetFile(), (void*)buffer, 1);
            if (found > 0)
            {
                retVal = (int32_t)buffer[0];
            }
    
            free(buffer);

            return retVal;
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        long long HdfsFileStream::Seek(long long offset, SeekOrigin origin)
        {
            ThrowArgIfFalse(offset >= 0, "Offset must be positive", "offset");

            ThrowNotSupportedIfFalse(this->CanSeek, "Seek operations are not supported on the current stream");

            // Determine seek position based on origin
            tOffset seekoffset;
            switch (origin) {
            case SeekOrigin::Current:
                seekoffset = (tOffset)(this->Position + offset);
                break;        
            case SeekOrigin::End:
                seekoffset = (tOffset)(this->Length - offset);
                break;  
            case SeekOrigin::Begin:
            default:
                seekoffset = (tOffset)offset;
            } 

            ThrowArgIfFalse(seekoffset >= 0, "Calculated offset must be positive", "offset");

            return hdfsSeek(this->GetConnection(), this->GetFile(), seekoffset);
        }

        /// <summary>
        /// Sets the length of the current stream.
        /// </summary>
        void HdfsFileStream::SetLength(long long value)
        {
            throw gcnew InvalidOperationException("Stream does not support Seeking and Writing");
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        void HdfsFileStream::Write(array<Byte>^ buffer, int offset, int count)
        {
            ThrowArgIfFalse(offset >= 0, "Offset must be positive", "offset");
            ThrowArgIfFalse(count > 0, "Count must be greater than 0", "count");

            ThrowNotSupportedIfFalse(this->CanWrite, "Write operations are not supported on the current stream");

            int32_t size = Marshal::SizeOf(buffer[0]) * count;
            IntPtr pnt = Marshal::AllocHGlobal(size);
            Marshal::Copy(buffer, offset, pnt, count); 
            int32_t retVal = (int32_t)hdfsWrite(this->GetConnection(), this->GetFile(), pnt.ToPointer(), (tSize)count);
            Marshal::FreeHGlobal(pnt);

            return;
        }

        /// <summary>
        /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
        /// </summary>
        void HdfsFileStream::WriteByte(Byte value)
        {
            ThrowNotSupportedIfFalse(this->CanWrite, "Write operations are not supported on the current stream");

            char* buffer = (char*)malloc(sizeof(char));
            if(buffer == NULL)
            {
                return;
            }

            buffer[0] = Convert::ToInt32(value);
            int32_t retVal = (int32_t)hdfsWrite(this->GetConnection(), this->GetFile(), buffer, 1);

            free(buffer);

            return;
        }                  

        /// <summary>
        /// Reads bytes from a HDFS file from a specified position.
        /// </summary>
        int HdfsFileStream::PositionalRead(array<Byte>^ bytes, int position, int offset, int len)
        {
            ThrowArgIfFalse(position >= 0, "Position must be positive", "position");
            ThrowArgIfFalse(offset >= 0, "Offset must be positive", "offset");
            ThrowArgIfFalse(len > 0, "Length must be greater than 0", "len");

            ThrowNotSupportedIfFalse(this->CanRead, "Read operations are not supported on the current stream");

            int32_t retVal = -1;
            int32_t size = Marshal::SizeOf(bytes[0]) * len;
            IntPtr pnt = Marshal::AllocHGlobal(size);
            retVal = (int32_t)hdfsPread(this->GetConnection(), this->GetFile(), (tOffset)position, pnt.ToPointer(), (tSize)len);

            if (retVal != -1)
            {
                Marshal::Copy(pnt, bytes, offset, retVal);
            }

            Marshal::FreeHGlobal(pnt);

            return (int)retVal;
        }

        /// <summary>
        /// Reads a single byte from a HDFS file from a specified position.
        /// </summary>
        int HdfsFileStream::PositionalReadByte(int position)
        {
            ThrowArgIfFalse(position >= 0, "Position must be positive", "position");

            ThrowNotSupportedIfFalse(this->CanRead, "Read operations are not supported on the current stream");

            int32_t retVal = -1;
            char* buffer = (char*)malloc(sizeof(char));
            tSize found = hdfsPread(this->GetConnection(), this->GetFile(), (tOffset)position, (void*)buffer, 1);
            if (found > 0)
            {
                retVal = (int32_t)buffer[0];
            }
    
            free(buffer);

            return (int)retVal;
        }      

        /// <summary>
        /// Performs a chown of the HDFS File.
        /// </summary>
        void HdfsFileStream::Chown(String^ owner, String^ group)
        {
            HdfsFileSystem::Chown(this->GetConnection(), this->filePath, owner, group);
        }

        /// <summary>
        /// Performs a chmod of the HDFS File.
        /// </summary>
        void HdfsFileStream::Chmod(short mode)
        {
            HdfsFileSystem::Chmod(this->GetConnection(), this->filePath, mode);
        }

        /// <summary>
        /// Modifies the File Modified and Last Accessed Time.
        /// </summary>
        void HdfsFileStream::SetTimes(System::DateTime modifiedTime, System::DateTime accessedTime)
        {
            HdfsFileSystem::SetTimes(this->GetConnection(), this->filePath, modifiedTime, accessedTime);
        }

        /// <summary>
        /// Gets the information associated with the File.
        /// </summary>
        /// <returns>File Information.</returns>
        HdfsFileInfoEntry^ HdfsFileStream::GetInformation()
        {
            return HdfsFileSystem::GetPathInfo(this->GetConnection(), this->filePath);
        }

        /// <summary>
        /// Determines if the HDFS file handle is valid.
        /// </summary>
        bool HdfsFileStream::IsValid()
        { 
            return this->file != NULL;
        }
    }
}

