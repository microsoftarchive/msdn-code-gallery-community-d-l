// HdfsConnectionHandle.cpp

#include "stdafx.h"
#include "HdfsConnectionHandle.h"

#include "HdfsFileInfoEntry.h"
#include "HdfsFileInfoEntries.h"

#include "ExceptionUtil.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace WinHdfsManaged
    {   
        /// <summary>
        /// Returns the HDFS Connection Handle.
        /// </summary>
        IntPtr HdfsConnectionHandle::GetHandle()
        {
            return handle;
        }

        /// <summary>
        /// Check for the existence of a file within HDFS.
        /// </summary>
        bool HdfsConnectionHandle::FileExists(String^ filePath)
        {
            char * filePathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePath); // use of newer marshal_context stuff causes redefine errors not going to work around at the moment
            bool retVal = hdfsExists(handle.ToPointer(), filePathPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathPtr);
            return retVal;
        }

        /// <summary>
        /// Deletes and existsing file from HDFS.
        /// </summary>
        void HdfsConnectionHandle::DeleteFile(String^ filePath)
        {
            char * filePathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePath); 
            bool retVal = hdfsDelete(handle.ToPointer(), filePathPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathPtr);
            ThrowIfFalse(retVal, "Delete failed");
        }

        /// <summary>
        /// Renames and existing HDFS file.
        /// </summary>
        void HdfsConnectionHandle::RenameFile(String^ filePathFrom, String^ filePathTo)
        {
            char * filePathFromPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePathFrom); 
            char * filePathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePathTo); 
            bool retVal = hdfsRename(handle.ToPointer(),filePathFromPtr, filePathToPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathFromPtr);
            Marshal::FreeHGlobal((IntPtr)filePathToPtr);
            ThrowIfFalse(retVal, "Rename failed");
        }

        /// <summary>
        /// Gets the current HDFS Working Directory.
        /// </summary>
        String^ HdfsConnectionHandle::GetWorkingDirectory()
        {
            const int maxDirLen = 2048; //arbitrarily long path.. MAX_PATH  is 260 and Unicode for long paths go to approx 32,767 but that is not supported by all API's 
            char buf[maxDirLen + 1];
            buf[maxDirLen] = 0;
            char * retPtr = hdfsGetWorkingDirectory(handle.ToPointer(), &buf[0], maxDirLen);
            return gcnew String(buf);
        }

        /// <summary>
        /// Sets the current HDFS Working Directory.
        /// </summary>
        void HdfsConnectionHandle::SetWorkingDirectory(String^ filePathTo)
        {
            char * filePathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePathTo); 
            bool retVal = hdfsSetWorkingDirectory(handle.ToPointer(), filePathToPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathToPtr);
            ThrowIfFalse(retVal, "SetWorkingDirectory failed");
        }

        /// <summary>
        /// Creates a new HDFS Directory.
        /// </summary>
        void HdfsConnectionHandle::CreateDirectory(String^ dir)
        {
            char * dirPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(dir); 
            bool retVal = hdfsCreateDirectory(handle.ToPointer(), dirPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)dirPtr);
            ThrowIfFalse(retVal, "CreateDirectory failed");
        }

        /// <summary>
        /// Sets the replication count for a HDFS file.
        /// </summary>
        void HdfsConnectionHandle::SetReplication(String^ path, int16_t replication)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            bool retVal = hdfsSetReplication(handle.ToPointer(), pathPtr, replication) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            ThrowIfFalse(retVal, "SetReplication failed");
        }

        /// <summary>
        /// Lists the Files and Directories within a Directory.
        /// </summary>
        HdfsFileInfoEntries^ HdfsConnectionHandle::ListDirectory(String^ path)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            int numEntries = 0;
            hdfsFileInfo * dirEntry = hdfsListDirectory(handle.ToPointer(), pathPtr, &numEntries);
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            HdfsFileInfoEntries^ entries = gcnew HdfsFileInfoEntries(dirEntry, numEntries);
            return entries;
        }

        /// <summary>
        /// Gets the information associated with a Path.
        /// </summary>
        HdfsFileInfoEntry^ HdfsConnectionHandle::GetPathInfo(String^ path)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            hdfsFileInfo * pathEntry = hdfsGetPathInfo(handle.ToPointer(), pathPtr);
            Marshal::FreeHGlobal((IntPtr)pathPtr);

            HdfsFileInfoEntry^ entry = nullptr;
            if (pathEntry != NULL)
            {
                entry = gcnew HdfsFileInfoEntry(pathEntry);
                HdfsFileInfoEntry::SetFileInfoEntryValues(pathEntry[0],entry);
            }
            return entry;
        }

        /// <summary>
        /// Gets the HDFS Default Block Size.
        /// </summary>
        int64_t HdfsConnectionHandle::GetDefaultBlockSize()
        {
            return (int64_t)hdfsGetDefaultBlockSize(handle.ToPointer());
        }

        /// <summary>
        /// Gets the HDFS available capacity.
        /// </summary>
        int64_t HdfsConnectionHandle::GetCapacity()
        {
            return (int64_t)hdfsGetCapacity(handle.ToPointer());
        }

        /// <summary>
        /// Gets the used HDFS capacity.
        /// </summary>
        int64_t HdfsConnectionHandle::GetUsed()
        {
            return (int64_t)hdfsGetUsed(handle.ToPointer());
        }

        /// <summary>
        /// Performs a chown of a HDFS Path.
        /// </summary>
        void HdfsConnectionHandle::Chown(String^ path, String^ owner, String^ group)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            char * ownerPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(owner); 
            char * groupPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(group); 
            bool retVal = hdfsChown(handle.ToPointer(), pathPtr, ownerPtr, groupPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            Marshal::FreeHGlobal((IntPtr)ownerPtr);
            Marshal::FreeHGlobal((IntPtr)groupPtr);
            ThrowIfFalse(retVal, "Chown failed");
        }

        /// <summary>
        /// Performs a chmod of a HDFS Path.
        /// </summary>
        void HdfsConnectionHandle::Chmod(String^ path, short mode)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            bool retVal = hdfsChmod(handle.ToPointer(), pathPtr, mode) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            ThrowIfFalse(retVal, "Chmod failed");
        }

        /// <summary>
        /// Gets the hostnames where a particular block of a HDFS file is stored.
        /// </summary>
        List<String^>^ HdfsConnectionHandle::GetHosts(String^ path, int64_t start, int64_t length) 
        {
            List<String^> ^ retVal = nullptr;
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path);
            char *** hosts = hdfsGetHosts(handle.ToPointer(), pathPtr, (tOffset)start, (tOffset)length);
            if (hosts)
            {
                retVal = gcnew List<String^>();
                int i=0; 
                while (hosts[i]) 
                {
                    int j = 0;
                    while (hosts[i][j]) 
                    {
                        retVal->Add(gcnew String(hosts[i][j]));
                        ++j;
                    }
                    ++i;
                }
                hdfsFreeHosts(hosts);
            }

            Marshal::FreeHGlobal((IntPtr)pathPtr);
            return retVal;
        }

        /// <summary>
        /// Modifies the file Modified and Last Accessed Time.
        /// </summary>
        void HdfsConnectionHandle::SetTimes(String^ path, System::DateTime modifiedTime, System::DateTime accessedTime)
        {
            tTime mtime = HdfsFileInfoEntry::GetUnixTime(modifiedTime);
            tTime atime = HdfsFileInfoEntry::GetUnixTime(accessedTime);

            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            bool retVal = hdfsUtime(handle.ToPointer(), pathPtr, mtime, atime) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            ThrowIfFalse(retVal, "SetTimes failed");
        }

        /// <summary>
        /// Checks to see if the current connection handle is valid.
        /// </summary>
        bool HdfsConnectionHandle::IsZero()
        {
            return handle == IntPtr::Zero;
        }
    }
}

