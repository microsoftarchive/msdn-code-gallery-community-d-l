// HdfsConnectionHandle.h

#pragma once
#include <hdfs.h>

#include "HdfsFileInfoEntry.h"
#include "HdfsFileInfoEntries.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace WinHdfsManaged
    {   
        /// <summary>
        /// Class for a connection to HDFS.
        /// </summary>
        public ref class HdfsConnectionHandle
        {
        private:
            IntPtr handle;

        internal:
            /// <summary>
            /// Create the HDFS Connection Handle.
            /// </summary>
            HdfsConnectionHandle(IntPtr chandle):handle(chandle) { }

            /// <summary>
            /// Returns the HDFS Connection Handle.
            /// </summary>
            IntPtr GetHandle();

        public:	

            /// <summary>
            /// Disposes of the HDFS Connection Handle.
            /// </summary>
            !HdfsConnectionHandle()
            {
                if (handle != IntPtr::Zero)
                {
                    hdfsDisconnect(handle.ToPointer());
                    handle = IntPtr::Zero;
                }
            }

            /// <summary>
            /// Destroys the HDFS Connection Handle.
            /// </summary>
            ~HdfsConnectionHandle()
            {
                this->!HdfsConnectionHandle();
            }

            /// <summary>
            /// Check for the existence of a file within HDFS.
            /// </summary>
            /// <returns>Indicator for whether file exists.</returns>
            bool FileExists(String^ filePath);

            /// <summary>
            /// Deletes and existsing file from HDFS.
            /// </summary>
            /// <returns>Indicator for whether file has been deleted.</returns>
            void DeleteFile(String^ filePath);

            /// <summary>
            /// Renames and existing HDFS file.
            /// </summary>
            /// <returns>Indicator for whether file has been renamed.</returns>
            void RenameFile(String^ filePathFrom, String^ filePathTo);

            /// <summary>
            /// Gets the current HDFS Working Directory.
            /// </summary>
            /// <returns>The Working Directory.</returns>
            String^ GetWorkingDirectory();

            /// <summary>
            /// Sets the current HDFS Working Directory.
            /// </summary>
            /// <returns>Indicator for whether the Working Directory has changed.</returns>
            void SetWorkingDirectory(String^ filePathTo);

            /// <summary>
            /// Creates a new HDFS Directory.
            /// </summary>
            /// <returns>Indicator for whether the Directory was created.</returns>
            void CreateDirectory(String^ dir);

            /// <summary>
            /// Sets the replication count for a HDFS file.
            /// </summary>
            /// <returns>Indicator for whether the Replication was set.</returns>
            void SetReplication(String^ path, int16_t replication);

            /// <summary>
            /// Lists the Files and Directories within a Directory.
            /// </summary>
            /// <returns>List of File Information.</returns>
            HdfsFileInfoEntries^ ListDirectory(String^ path);

            /// <summary>
            /// Gets the information associated with a Path.
            /// </summary>
            /// <returns>List of File Information.</returns>
            HdfsFileInfoEntry^ GetPathInfo(String^ path);

            /// <summary>
            /// Gets the HDFS Default Block Size.
            /// </summary>
            /// <returns>The Default Block Size.</returns>
            int64_t GetDefaultBlockSize();

            /// <summary>
            /// Gets the HDFS available capacity.
            /// </summary>
            /// <returns>The available Capacity.</returns>
            int64_t GetCapacity();

            /// <summary>
            /// Gets the used HDFS capacity.
            /// </summary>
            /// <returns>The used Capacity.</returns>
            int64_t GetUsed();

            /// <summary>
            /// Performs a chown of a HDFS Path.
            /// </summary>
            /// <returns>Indicator for whether the chown was successful.</returns>
            void Chown(String^ path, String^ owner, String^ group);

            /// <summary>
            /// Performs a chmod of a HDFS Path.
            /// </summary>
            /// <returns>Indicator for whether the chmod was successful.</returns>
            void Chmod(String^ path, short mode);

            /// <summary>
            /// Gets the hostnames where a particular block of a HDFS file is stored.
            /// </summary>
            /// <returns>A List of host names.</returns>
            List<String^>^ GetHosts(String^ path, int64_t start, int64_t length);

            /// <summary>
            /// Modifies the file Modified and Last Accessed Time.
            /// </summary>
            /// <returns>Indicator for whether the file modification was successful.</returns>
            void SetTimes(String^ path, System::DateTime modifiedTime, System::DateTime accessedTime);

            /// <summary>
            /// Checks to see if the current connection handle is valid.
            /// </summary>
            /// <returns>Indicator for whether the file modification was successful.</returns>
            bool IsZero();
        }; 
    }
}
