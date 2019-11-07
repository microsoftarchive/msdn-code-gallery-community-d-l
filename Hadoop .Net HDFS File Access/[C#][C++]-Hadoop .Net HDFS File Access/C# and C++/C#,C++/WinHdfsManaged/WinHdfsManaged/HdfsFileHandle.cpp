#include "stdafx.h"

#include <string>

#include "ExceptionUtil.h"

#include "HdfsFileHandle.h"

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
        hdfsFile HdfsFileHandle::GetFile()
        {
            return this->file;
        }
        
        /// <summary>
        /// Gets a Connection Handle.
        /// </summary>
        hdfsFS HdfsFileHandle::GetConnection()
        {
            ThrowIoIfFalse(connection != IntPtr::Zero, "Connection has not yet been opened");

            return connection.ToPointer();
        }

        /// <summary>
        /// Gets the HDFS file path.
        /// </summary>
        String^ HdfsFileHandle::Name::get()
        {
            return this->filePath;
        }

        /// <summary>
        /// Performs a write of bytes to the HDFS file.
        /// </summary>
        int32_t HdfsFileHandle::WriteBytes(array<Byte>^ bytes, int32_t pos, int32_t len)
        {
            ThrowArgIfFalse(pos >= 0, "Position must be positive", "pos");
            ThrowArgIfFalse(len > 0, "Length must be greater than 0", "len");

            if (this->file == NULL)
            {
                return -1;
            }

            int32_t size = Marshal::SizeOf(bytes[0]) * len;
            IntPtr pnt = Marshal::AllocHGlobal(size);
            Marshal::Copy(bytes, pos, pnt, len); 
            int32_t retVal = (int32_t)hdfsWrite(this->GetConnection(), this->file, pnt.ToPointer(), (tSize)len);
            Marshal::FreeHGlobal(pnt);

            return retVal;
        }

        /// <summary>
        /// Performs a write of a single byte to the HDFS file.
        /// </summary>
        int32_t HdfsFileHandle::WriteByte(Byte^ inputbyte)
        {
            if (this->file == NULL)
            {
                return -1;
            }

            char* buffer = (char*)malloc(sizeof(char));
            if(buffer == NULL)
            {
                return -1;
            }

            buffer[0] = Convert::ToInt32(inputbyte);
            int32_t retVal = (int32_t)hdfsWrite(this->GetConnection(), this->file, buffer, 1);

            free(buffer);

            return retVal;
        }

        /// <summary>
        /// Performs a write of a text line to the HDFS file.
        /// </summary>
        int32_t HdfsFileHandle::WriteLine(String^ inputline)
        {
            if (this->file == NULL)
            {
                return -1;
            }

            Encoding^ encoding = Encoding::UTF8;
            array<Byte>^ bytes = encoding->GetBytes(inputline);
            Byte^ newline = gcnew Byte((unsigned char)10);

            HdfsFileHandle::WriteBytes(bytes, 0, bytes->Length);
            HdfsFileHandle::WriteByte(newline);

            return bytes->Length;
        }

        /// <summary>
        /// Reads bytes from a HDFS file.
        /// </summary>
        int32_t HdfsFileHandle::ReadBytes(array<Byte>^ bytes, int32_t offset, int32_t len)
        {
            ThrowArgIfFalse(offset >= 0, "Offset must be positive", "offset");
            ThrowArgIfFalse(len > 0, "Length must be greater than 0", "len");

            if (this->file == NULL)
            {
                return -1;
            }

            int32_t retVal = -1;
            int32_t size = Marshal::SizeOf(bytes[0]) * len;
            IntPtr pnt = Marshal::AllocHGlobal(size);
            retVal = (int32_t)hdfsRead(this->GetConnection(), this->file, pnt.ToPointer(), (tSize)len);

            if (retVal != -1)
            {
                Marshal::Copy(pnt, bytes, offset, retVal);
            }

            Marshal::FreeHGlobal(pnt);

            return retVal;
        }                   

        /// <summary>
        /// Reads a single byte from a HDFS file.
        /// </summary>
        int32_t HdfsFileHandle::ReadByte()
        {
            if (this->file == NULL)
            {
                return -1;
            }

            int32_t retVal = -1;
            char* buffer = (char*)malloc(sizeof(char));
            tSize found = hdfsRead(this->GetConnection(), this->file, (void*)buffer, 1);
            if (found > 0)
            {
                retVal = (int32_t)buffer[0];
            }
    
            free(buffer);

            return retVal;
        }

        /// <summary>
        /// Reads a text line from a HDFS file.
        /// </summary>
        String^ HdfsFileHandle::ReadLine()
        {
            if (this->file == NULL)
            {
                return nullptr;
            }

            string linedata;
            char* buffer = (char*)malloc(sizeof(char));

            if(buffer != NULL)
            {   
                // read from the file until eof or newline found
                bool eof = false;
                do
                {
                    tSize found = hdfsRead(this->GetConnection(), this->file, (void*)buffer, 1);
                    if (found > 0)
                    {
                        if ((int)buffer[0] == 10)
                        {
                            eof = true;
                        }
                        else
                        {
                            linedata.append(buffer, 1);
                        }
                    }
                    else
                    {
                        eof = true;
                    }
                } while (!eof);
    
                free(buffer);
            }

            // Return nullptr to indicate the end of the file
            int len = (int)linedata.size();
            if (len > 0)
            {
                return gcnew String(linedata.c_str());
            }
            else
            {
                return nullptr;
            }
        }

        /// <summary>
        /// Reads bytes from a HDFS file from a specified position.
        /// </summary>
        int32_t HdfsFileHandle::PositionalReadBytes(array<Byte>^ bytes, int32_t position, int32_t offset, int32_t len)
        {
            ThrowArgIfFalse(position >= 0, "Position must be positive", "position");
            ThrowArgIfFalse(offset >= 0, "Offset must be positive", "offset");
            ThrowArgIfFalse(len > 0, "Length must be greater than 0", "len");

            if (this->file == NULL)
            {
                return -1;
            }

            int32_t retVal = -1;
            int32_t size = Marshal::SizeOf(bytes[0]) * len;
            IntPtr pnt = Marshal::AllocHGlobal(size);
            retVal = (int32_t)hdfsPread(this->GetConnection(), this->file, (tOffset)position, pnt.ToPointer(), (tSize)len);

            if (retVal != -1)
            {
                Marshal::Copy(pnt, bytes, offset, retVal);
            }

            Marshal::FreeHGlobal(pnt);

            return retVal;
        }

        /// <summary>
        /// Reads a single byte from a HDFS file from a specified position.
        /// </summary>
        int32_t HdfsFileHandle::PositionalReadByte(int32_t position)
        {
            ThrowArgIfFalse(position >= 0, "Position must be positive", "position");

            if (this->file == NULL)
            {
                return -1;
            }

            int32_t retVal = -1;
            char* buffer = (char*)malloc(sizeof(char));
            tSize found = hdfsPread(this->GetConnection(), this->file, (tOffset)position, (void*)buffer, 1);
            if (found > 0)
            {
                retVal = (int32_t)buffer[0];
            }
    
            free(buffer);

            return retVal;
        }

        /// <summary>
        /// Performs a seek of a HDFS file.
        /// </summary>
        int HdfsFileHandle::Seek(int64_t desiredPos)
        {
            ThrowArgIfFalse(desiredPos >= 0, "Desired Position must be positive", "desiredPos");
            
            if (this->file == NULL)
            {
                return -1;
            }

            return hdfsSeek(this->GetConnection(), this->file, (tOffset)(desiredPos));
        }

        /// <summary>
        /// Determines the current offset of a HDFS file.
        /// </summary>
        int64_t HdfsFileHandle::Tell()
        {
            if (this->file == NULL)
            {
                return -1;
            }

            return (int64_t)hdfsTell(this->GetConnection(), this->file);
        }
        
        /// <summary>
        /// Determines what is availble in the HDFS file.
        /// </summary>
        int64_t HdfsFileHandle::Available()
        {
            if (this->file == NULL)
            {
                return -1;
            }

            return (int64_t)hdfsAvailable(this->GetConnection(), this->file);
        }

        /// <summary>
        /// Closes a HDFS file.
        /// </summary>
        void HdfsFileHandle::Close()
        {
            int retVal = -1;

            if (this->file != NULL)
            {
                retVal = hdfsCloseFile(this->GetConnection(), this->file);
                this->file = NULL;
            }

            ThrowIoIfFalse(retVal == 0, "Close failed");
        }
        
        /// <summary>
        /// Flushes the contents of an HDFS file.
        /// </summary>
        void HdfsFileHandle::Flush()
        {
            tSize retVal = -1;

            if (file != NULL)
            {
                retVal = hdfsFlush(this->GetConnection(), this->file);
            }

            ThrowIoIfFalse(retVal == 0, "Flush failed");
        }

        /// <summary>
        /// Determines if the HDFS file handle is valid.
        /// </summary>
        bool HdfsFileHandle::IsValid()
        { 
            return this->file != NULL;
        }
    }
}

