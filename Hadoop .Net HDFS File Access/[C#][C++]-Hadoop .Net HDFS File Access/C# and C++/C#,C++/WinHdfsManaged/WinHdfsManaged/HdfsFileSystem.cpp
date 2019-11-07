#include "stdafx.h"

#include "Enumerations.h"
#include "ExceptionUtil.h"

#include "ConfigureIsotope.h"

#include "HdfsFileSystem.h"
#include "HdfsFileStream.h"
#include "HdfsFileHandle.h"
#include "HdfsFileInfoEntry.h"
#include "HdfsFileInfoEntries.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace Hdfs
    {
        /// <summary>
        /// Gets a connection to an Hadoop cluster.
        /// </summary>
        HdfsFileSystem^ HdfsFileSystem::Connect(String^ host, uint16_t port)
        {
            return HdfsFileSystem::Connect(host, (tPort)port, nullptr);
        }

        /// <summary>
        /// Gets a connection to an Hadoop cluster with a user name.
        /// </summary>
        HdfsFileSystem^ HdfsFileSystem::Connect(String^ host, uint16_t port, String^ user)
        {
            // first check that paths have been defined for Isotope
            ConfigureIsotope::Setup();

            char * userPtr = NULL;
            if (user != nullptr)
            {
                userPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(user);
            }

            char * hostPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(host); //use of newer marshal_context stuff causes redefine errors not going to work around at the moment
            void * retVal = userPtr == NULL ? hdfsConnect(hostPtr, (tPort)port):hdfsConnectAsUser(hostPtr, (tPort)port, userPtr);
            Marshal::FreeHGlobal((IntPtr)hostPtr);
            Marshal::FreeHGlobal((IntPtr)userPtr);
            
            IntPtr chandle = IntPtr(retVal);
            ThrowIoIfFalse(chandle != IntPtr::Zero, "Connection failed");

            return gcnew HdfsFileSystem(chandle);
        }

        /// <summary>
        /// Returns the HDFS Connection Handle Pointer.
        /// </summary>
        hdfsFS HdfsFileSystem::GetHandlePointer()
        {
            ThrowIoIfFalse(this->handle != IntPtr::Zero, "Connection has not yet been opened");

            return this->handle.ToPointer();
        }

        /// <summary>
        /// Performs a chown of a HDFS Path or File given a connection.
        /// </summary>
        void HdfsFileSystem::Chown(hdfsFS connection, String^ path, String^ owner, String^ group)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            char * ownerPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(owner); 
            char * groupPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(group); 
            bool retVal = hdfsChown(connection, pathPtr, ownerPtr, groupPtr) == 0;

            Marshal::FreeHGlobal((IntPtr)pathPtr);
            Marshal::FreeHGlobal((IntPtr)ownerPtr);
            Marshal::FreeHGlobal((IntPtr)groupPtr);

            ThrowIoIfFalse(retVal, "Chown failed");
        }

        /// <summary>
        /// Performs a chmod of a HDFS Path or File given a connection.
        /// </summary>
        void HdfsFileSystem::Chmod(hdfsFS connection, String^ path, short mode)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            bool retVal = hdfsChmod(connection, pathPtr, mode) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);

            ThrowIoIfFalse(retVal, "Chmod failed");
        }

        /// <summary>
        /// Modifies the Path or File Modified and Last Accessed Time given a connection.
        /// </summary>
        void HdfsFileSystem::SetTimes(hdfsFS connection, String^ path, System::DateTime modifiedTime, System::DateTime accessedTime)
        {
            tTime mtime = HdfsFileInfoEntry::GetUnixTime(modifiedTime);
            tTime atime = HdfsFileInfoEntry::GetUnixTime(accessedTime);

            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            bool retVal = hdfsUtime(connection, pathPtr, mtime, atime) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);

            ThrowIoIfFalse(retVal, "SetTimes failed");
        }

        /// <summary>
        /// Gets the information associated with a File or Path given a connection.
        /// </summary>
        HdfsFileInfoEntry^ HdfsFileSystem::GetPathInfo(hdfsFS connection, String^ path)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            hdfsFileInfo * pathEntry = hdfsGetPathInfo(connection, pathPtr);
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
        /// Check for the existence of a file within HDFS.
        /// </summary>
        bool HdfsFileSystem::FileExists(String^ filePath)
        {
            char * filePathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePath); // use of newer marshal_context stuff causes redefine errors not going to work around at the moment
            bool retVal = hdfsExists(this->GetHandlePointer(), filePathPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathPtr);

            return retVal;
        }

        /// <summary>
        /// Deletes and existsing file from HDFS.
        /// </summary>
        void HdfsFileSystem::DeleteFile(String^ filePath)
        {
            char * filePathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePath); 
            bool retVal = hdfsDelete(this->GetHandlePointer(), filePathPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathPtr);

            ThrowIoIfFalse(retVal, "Delete failed");
        }

        /// <summary>
        /// Renames and existing HDFS file.
        /// </summary>
        void HdfsFileSystem::RenameFile(String^ filePathFrom, String^ filePathTo)
        {
            char * filePathFromPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePathFrom); 
            char * filePathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePathTo); 
            bool retVal = hdfsRename(this->GetHandlePointer(),filePathFromPtr, filePathToPtr) == 0;

            Marshal::FreeHGlobal((IntPtr)filePathFromPtr);
            Marshal::FreeHGlobal((IntPtr)filePathToPtr);

            ThrowIoIfFalse(retVal, "Rename failed");
        }

        /// <summary>
        /// Gets the current HDFS Working Directory.
        /// </summary>
        String^ HdfsFileSystem::GetWorkingDirectory()
        {
            const int maxDirLen = 2048; //arbitrarily long path.. MAX_PATH  is 260 and Unicode for long paths go to approx 32,767 but that is not supported by all API's 
            char buf[maxDirLen + 1];
            buf[maxDirLen] = 0;
            char * retPtr = hdfsGetWorkingDirectory(this->GetHandlePointer(), &buf[0], maxDirLen);

            ThrowIoIfFalse(retPtr != NULL, "Get Working Directory failed");

            return gcnew String(buf);
        }

        /// <summary>
        /// Sets the current HDFS Working Directory.
        /// </summary>
        void HdfsFileSystem::SetWorkingDirectory(String^ filePathTo)
        {
            char * filePathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filePathTo); 
            bool retVal = hdfsSetWorkingDirectory(this->GetHandlePointer(), filePathToPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)filePathToPtr);

            ThrowIoIfFalse(retVal, "Set Working Directory failed");
        }

        /// <summary>
        /// Creates a new HDFS Directory.
        /// </summary>
        void HdfsFileSystem::CreateDirectory(String^ dir)
        {
            char * dirPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(dir); 
            bool retVal = hdfsCreateDirectory(this->GetHandlePointer(), dirPtr) == 0;
            Marshal::FreeHGlobal((IntPtr)dirPtr);

            ThrowIoIfFalse(retVal, "Create Directory failed");
        }

        /// <summary>
        /// Sets the replication count for a HDFS file.
        /// </summary>
        void HdfsFileSystem::SetReplication(String^ path, int16_t replication)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            bool retVal = hdfsSetReplication(this->GetHandlePointer(), pathPtr, replication) == 0;
            Marshal::FreeHGlobal((IntPtr)pathPtr);

            ThrowIoIfFalse(retVal, "Set Replication failed");
        }

        /// <summary>
        /// Lists the Files and Directories within a Directory.
        /// </summary>
        HdfsFileInfoEntries^ HdfsFileSystem::ListDirectory(String^ path)
        {
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path); 
            int numEntries = 0;
            hdfsFileInfo * dirEntry = hdfsListDirectory(this->GetHandlePointer(), pathPtr, &numEntries);
            Marshal::FreeHGlobal((IntPtr)pathPtr);
            HdfsFileInfoEntries^ entries = gcnew HdfsFileInfoEntries(dirEntry, numEntries);

            return entries;
        }

        /// <summary>
        /// Gets the information associated with a File or Path.
        /// </summary>
        HdfsFileInfoEntry^ HdfsFileSystem::GetPathInfo(String^ path)
        {
            return HdfsFileSystem::GetPathInfo(this->GetHandlePointer(), path);
        }

        /// <summary>
        /// Gets the HDFS Default Block Size.
        /// </summary>
        int64_t HdfsFileSystem::GetDefaultBlockSize()
        {
            return (int64_t)hdfsGetDefaultBlockSize(this->GetHandlePointer());
        }

        /// <summary>
        /// Gets the HDFS available capacity.
        /// </summary>
        int64_t HdfsFileSystem::GetCapacity()
        {
            return (int64_t)hdfsGetCapacity(this->GetHandlePointer());
        }

        /// <summary>
        /// Gets the used HDFS capacity.
        /// </summary>
        int64_t HdfsFileSystem::GetUsed()
        {
            return (int64_t)hdfsGetUsed(this->GetHandlePointer());
        }

        /// <summary>
        /// Performs a chown of a HDFS Path or File.
        /// </summary>
        void HdfsFileSystem::Chown(String^ path, String^ owner, String^ group)
        {
            HdfsFileSystem::Chown(this->GetHandlePointer(), path, owner, group);
        }

        /// <summary>
        /// Performs a chmod of a HDFS Path or File.
        /// </summary>
        void HdfsFileSystem::Chmod(String^ path, short mode)
        {
            HdfsFileSystem::Chmod(this->GetHandlePointer(), path, mode);
        }

        /// <summary>
        /// Gets the hostnames where a particular block of a HDFS file is stored.
        /// </summary>
        List<String^>^ HdfsFileSystem::GetHosts(String^ path, int64_t start, int64_t length) 
        {
            List<String^> ^ retVal = nullptr;
            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path);
            char *** hosts = hdfsGetHosts(this->GetHandlePointer(), pathPtr, (tOffset)start, (tOffset)length);
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
        /// Modifies the Path or File Modified and Last Accessed Time.
        /// </summary>
        void HdfsFileSystem::SetTimes(String^ path, System::DateTime modifiedTime, System::DateTime accessedTime)
        {
            HdfsFileSystem::SetTimes(this->GetHandlePointer(), path, modifiedTime, accessedTime);
        }

        /// <summary>
        /// Opens a HDFS file stream for processing.
        /// </summary>
        HdfsFileStream^ HdfsFileSystem::OpenFileStream(String^ path, HdfsFileAccess accessMode, int bufferSize, short replication, int32_t blocksize)
        {
            ThrowIoIfFalse(this->handle != IntPtr::Zero, "Connection has not yet ben opened");

            int flags;
            switch (accessMode) {
            case HdfsFileAccess::Append:
                    flags = O_WRONLY|O_APPEND;
                    break;        
            case HdfsFileAccess::Write: 
                    flags = O_WRONLY;
                    break;
            case HdfsFileAccess::Read:
                    flags = O_RDONLY;
                    break;        
              default:
                    flags = O_RDONLY;
            }

            bool writeMode = (accessMode != HdfsFileAccess::Read);

            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path);
            HdfsFileStream^ retVal = gcnew HdfsFileStream(path, this->handle, hdfsOpenFile(this->GetHandlePointer(), pathPtr, flags, bufferSize, replication, (tSize)blocksize), writeMode); 
            Marshal::FreeHGlobal((IntPtr)pathPtr);

            return retVal;
        }

        /// <summary>
        /// Opens a HDFS file stream for processing.
        /// </summary>
        HdfsFileStream^ HdfsFileSystem::OpenFileStream(String^ path, HdfsFileAccess accessMode, int bufferSize)
        {
            return OpenFileStream(path, accessMode, bufferSize, 0, 0);
        }

        /// <summary>
        /// Opens a HDFS file stream for processing.
        /// </summary>
        HdfsFileStream^ HdfsFileSystem::OpenFileStream(String^ path, HdfsFileAccess accessMode)
        {
            return OpenFileStream(path, accessMode, 0, 0, 0);
        }

        /// <summary>
        /// Opens an HDFS file.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFile(String^ path, int flags, int bufferSize, short replication, tSize blocksize)
        {
            ThrowIoIfFalse(this->handle != IntPtr::Zero, "Connection has not yet been opened");

            char * pathPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(path);
            HdfsFileHandle^ retVal = gcnew HdfsFileHandle(path, this->handle, hdfsOpenFile(this->GetHandlePointer(), pathPtr, flags, bufferSize, replication, blocksize)); 
            Marshal::FreeHGlobal((IntPtr)pathPtr);

            return retVal;
        }

        /// <summary>
        /// Opens a HDFS file for reading.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFileForRead(String^ path, int bufferSize)
        {
            return this->OpenFile(path, O_RDONLY, bufferSize, 0, (tSize)0);
        }

        /// <summary>
        /// Opens a HDFS file for reading using default open values.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFileForRead(String^ path)
        {
            return this->OpenFile(path, O_RDONLY, 0, 0, (tSize)0);
        }

        /// <summary>
        /// Opens a HDFS file for writing.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFileForWrite(String^ path, int bufferSize, short replication, int32_t blocksize)
        {
            return this->OpenFile(path, O_WRONLY, bufferSize, replication, (tSize)blocksize);
        }

        /// <summary>
        /// Opens a HDFS file for writing using default open values.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFileForWrite(String^ path)
        {
            return this->OpenFile(path, O_WRONLY, 0, 0, (tSize)0);
        }

        /// <summary>
        /// Opens a HDFS file for appending.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFileForAppend(String^ path, int bufferSize, short replication, int32_t blocksize)
        {
            return this->OpenFile(path, O_WRONLY|O_APPEND, bufferSize, replication, (tSize)blocksize);
        }

        /// <summary>
        /// Opens a HDFS file for appending using default open values.
        /// </summary>
        HdfsFileHandle^ HdfsFileSystem::OpenFileForAppend(String^ path)
        {
            return this->OpenFile(path, O_WRONLY|O_APPEND, 0, 0, (tSize)0);
        }

        /// <summary>
        /// Copies a HDFS file.
        /// </summary>
        void HdfsFileSystem::Copy(HdfsFileSystem^ conHandleFrom, String^ pathFrom, HdfsFileSystem^ conHandleTo, String^ pathTo)
        {
            char * pathFromPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathFrom);
            char * pathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathTo);
            bool retVal = hdfsCopy(conHandleFrom->GetHandlePointer(), pathFromPtr, conHandleTo->GetHandlePointer(), pathToPtr) == 0;

            Marshal::FreeHGlobal((IntPtr)pathToPtr);
            Marshal::FreeHGlobal((IntPtr)pathFromPtr);

            ThrowIoIfFalse(retVal, "Copy failed");
        }

        /// <summary>
        /// Moves a HDFS file.
        /// </summary>
        void HdfsFileSystem::Move(HdfsFileSystem^ conHandleFrom, String^ pathFrom, HdfsFileSystem^ conHandleTo, String^ pathTo)
        {
            char * pathFromPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathFrom);
            char * pathToPtr = (char*)(void*)Marshal::StringToHGlobalAnsi(pathTo);
            bool retVal = hdfsMove(conHandleFrom->GetHandlePointer(), pathFromPtr, conHandleTo->GetHandlePointer(), pathToPtr) == 0;

            Marshal::FreeHGlobal((IntPtr)pathFromPtr);
            Marshal::FreeHGlobal((IntPtr)pathToPtr);

            ThrowIoIfFalse(retVal, "Move failed");
        }
    
        /// <summary>
        /// Closes a HDFS file system connection.
        /// </summary>
        void HdfsFileSystem::Close()
        {
            int retVal = -1;

            if (this->handle != IntPtr::Zero)
            {
                retVal = hdfsDisconnect(this->GetHandlePointer());
                this->handle = IntPtr::Zero;
            }

            ThrowIoIfFalse(retVal == 0, "Close failed");
        }
        
        /// <summary>
        /// Determines if the HDFS file system connection is valid.
        /// </summary>
        bool HdfsFileSystem::IsValid()
        { 
            return this->handle != IntPtr::Zero;
        }
    }
}

