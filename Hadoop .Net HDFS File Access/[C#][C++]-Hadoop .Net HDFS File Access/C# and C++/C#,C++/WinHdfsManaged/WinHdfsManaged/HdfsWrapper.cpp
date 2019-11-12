// HdfsWrapper.cpp

#include "stdafx.h"
#include "HdfsWrapper.h"

#include "HdfsConnectionHandle.h"
#include "HdfsFileHandle.h"
#include "ExceptionUtil.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace WinHdfsManaged
    {       
        /// <summary>
        /// Gets a connection to an Hadoop cluster.
        /// </summary>
        HdfsConnectionHandle^ HdfsWrapper::HdfsConnect(String^ host, uint16_t port)
        {
            return HdfsConnect(host, (tPort)port, nullptr);
        }

        /// <summary>
        /// Gets a connection to an Hadoop cluster with a user name.
        /// </summary>
        HdfsConnectionHandle^ HdfsWrapper::HdfsConnect(String^ host, uint16_t port, String^ user)
        {
            char * userPtr = NULL;
            if (user != nullptr)
            {
                userPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(user);
            }

            char * hostPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(host); //use of newer marshal_context stuff causes redefine errors not going to work around at the moment
            void * retVal = userPtr == NULL ? hdfsConnect(hostPtr, (tPort)port):hdfsConnectAsUser(hostPtr, (tPort)port, userPtr);
            Marshal::FreeHGlobal((IntPtr)hostPtr);
            Marshal::FreeHGlobal((IntPtr)userPtr);
            return gcnew HdfsConnectionHandle(IntPtr(retVal));
        }

        /// <summary>
        /// Opens a HDFS file for reading.
        /// </summary>
        HdfsFileHandle^ HdfsWrapper::OpenFileForRead(HdfsConnectionHandle^ conHandle, String^ path, int bufferSize, short replication, int32_t blocksize)
        {
            return OpenFile(conHandle, path, O_RDONLY, bufferSize, replication, (tSize)blocksize);
        }

        /// <summary>
        /// Opens a HDFS file for writing.
        /// </summary>
        HdfsFileHandle^ HdfsWrapper::OpenFileForWrite(HdfsConnectionHandle^ conHandle, String^ path, int bufferSize, short replication, int32_t blocksize)
        {
            return OpenFile(conHandle, path, O_WRONLY, bufferSize, replication, (tSize)blocksize);
        }

        /// <summary>
        /// Opens a HDFS file for appending.
        /// </summary>
        HdfsFileHandle^ HdfsWrapper::OpenFileForAppend(HdfsConnectionHandle^ conHandle, String^ path, int bufferSize, short replication, int32_t blocksize)
        {
            return OpenFile(conHandle, path, O_WRONLY|O_APPEND, bufferSize, replication, (tSize)blocksize);
        }

        /// <summary>
        /// Copies a HDFS file.
        /// </summary>
        void HdfsWrapper::Copy(HdfsConnectionHandle^ conHandleFrom, String^ pathFrom, HdfsConnectionHandle^ conHandleTo, String^ pathTo)
        {
            char * pathFromPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathFrom);
            char * pathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathTo);
            bool retVal = hdfsCopy(conHandleFrom->GetHandle().ToPointer(), pathFromPtr, conHandleTo->GetHandle().ToPointer(), pathToPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)pathToPtr);
            Marshal::FreeHGlobal((IntPtr)pathFromPtr);
            ThrowIfFalse(retVal, "Copy failed");
        }

        /// <summary>
        /// Moves a HDFS file.
        /// </summary>
        void HdfsWrapper::Move(HdfsConnectionHandle^ conHandleFrom, String^ pathFrom, HdfsConnectionHandle^ conHandleTo, String^ pathTo)
        {
            char * pathFromPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathFrom);
            char * pathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathTo);
            bool retVal = hdfsMove(conHandleFrom->GetHandle().ToPointer(), pathFromPtr, conHandleTo->GetHandle().ToPointer(), pathToPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)pathFromPtr);
            Marshal::FreeHGlobal((IntPtr)pathToPtr);
            ThrowIfFalse(retVal, "Move failed");
        }
    
        /// <summary>
        /// Opens an HDFS file.
        /// </summary>
        HdfsFileHandle^ HdfsWrapper::OpenFile(HdfsConnectionHandle^ conHandle, String^ path, int flags, int bufferSize, short replication, tSize blocksize)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path);
            HdfsFileHandle^ retVal = gcnew HdfsFileHandle(conHandle, hdfsOpenFile(conHandle->GetHandle().ToPointer(), pathPtr, flags, bufferSize, replication, blocksize)); 
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            return retVal;
        }
    }
}

