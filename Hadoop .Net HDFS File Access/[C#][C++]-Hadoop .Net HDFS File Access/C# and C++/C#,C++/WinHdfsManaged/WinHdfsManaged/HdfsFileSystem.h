#pragma once

#include <hdfs.h>

#include "Enumerations.h"
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
        /// Class for a connection to HDFS.
        /// </summary>
        public ref class HdfsFileSystem sealed
        {
        private:
            IntPtr handle;

        internal:
            /// <summary>
            /// Create the HDFS Connection Handle.
            /// </summary>
            HdfsFileSystem(IntPtr chandle):handle(chandle) { }

            /// <summary>
            /// Returns the HDFS Connection Handle.
            /// </summary>
            hdfsFS GetHandlePointer();

            /// <summary>
            /// Opens an HDFS file.
            /// </summary>
            HdfsFileHandle^ OpenFile(String^ path, int flags, int bufferSize, short replication, tSize blocksize);

            /// <summary>
            /// Performs a chown of a HDFS Path or File given a connection.
            /// </summary>
            static void Chown(hdfsFS connection, String^ path, String^ owner, String^ group);

            /// <summary>
            /// Performs a chmod of a HDFS Path or File given a connection.
            /// </summary>
            static void Chmod(hdfsFS connection, String^ path, short mode);

            /// <summary>
            /// Modifies the Path or File Modified and Last Accessed Time given a connection.
            /// </summary>
            static void SetTimes(hdfsFS connection, String^ path, System::DateTime modifiedTime, System::DateTime accessedTime);

            /// <summary>
            /// Gets the information associated with a File or Path given a connection.
            /// </summary>
            static HdfsFileInfoEntry^ GetPathInfo(hdfsFS connection, String^ path);

        public:
            /// <summary>
            /// Gets a connection to an Hadoop cluster.
            /// </summary>
            /// <param name="host">The host name or IP address.</param>
            /// <param name="port">The port on which the server is listening.</param>
            /// <returns>HDFS Connection Handle.</returns>
            /// <exception cref="System::IO::IOException">Thrown when the Connect fails.</exception>
            static HdfsFileSystem^ Connect(String^ host, uint16_t port);

            /// <summary>
            /// Gets a connection to an Hadoop cluster with a user name.
            /// </summary>
            /// <param name="host">The host name or IP address.</param>
            /// <param name="port">The port on which the server is listening.</param>
            /// <param name="user">The user for the connection.</param>
            /// <returns>HDFS Connection Handle.</returns>
            /// <exception cref="System::IO::IOException">Thrown when the Connect fails.</exception>
            static HdfsFileSystem^ Connect(String^ host, uint16_t port, String^ user);

            /// <summary>
            /// Disposes of the HDFS Connection Handle.
            /// </summary>
            !HdfsFileSystem()
            {
                if (handle != IntPtr::Zero)
                {
                    Close();
                }
            }

            /// <summary>
            /// Destroys the HDFS Connection Handle.
            /// </summary>
            ~HdfsFileSystem()
            {
                this->!HdfsFileSystem();
            }

            /// <summary>
            /// Check for the existence of a file within HDFS.
            /// </summary>
            /// <param name="filePath">The file path to look for.</param>
            /// <returns>Indicator for whether file exists.</returns>
            bool FileExists(String^ filePath);

            /// <summary>
            /// Deletes and existsing file from HDFS.
            /// </summary>
            /// <param name="filePath">The file path to delete.</param>
            /// <returns>Indicator for whether file has been deleted.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Delete fails.</exception>
            void DeleteFile(String^ filePath);

            /// <summary>
            /// Renames and existing HDFS file.
            /// </summary>
            /// <param name="filePathFrom">The From file path.</param>
            /// <param name="filePathTo">The To file path.</param>
            /// <returns>Indicator for whether file has been renamed.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Rename fails.</exception>
            void RenameFile(String^ filePathFrom, String^ filePathTo);

            /// <summary>
            /// Gets the current HDFS Working Directory.
            /// </summary>
            /// <returns>The Working Directory.</returns>
            String^ GetWorkingDirectory();

            /// <summary>
            /// Sets the current HDFS Working Directory.
            /// </summary>
            /// <param name="filePathTo">The directory to set as working.</param>
            /// <returns>Indicator for whether the Working Directory has changed.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Set fails.</exception>
            void SetWorkingDirectory(String^ filePathTo);

            /// <summary>
            /// Creates a new HDFS Directory.
            /// </summary>
            /// <param name="dir">The directory to create.</param>
            /// <returns>Indicator for whether the Directory was created.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Directory Create fails.</exception>
            void CreateDirectory(String^ dir);

            /// <summary>
            /// Sets the replication count for a HDFS file.
            /// </summary>
            /// <param name="path">The file path.</param>
            /// <param name="replication">The replication factor to set.</param>
            /// <returns>Indicator for whether the Replication was set.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Set fails.</exception>
            void SetReplication(String^ path, int16_t replication);

            /// <summary>
            /// Lists the Files and Directories within a Directory.
            /// </summary>
            /// <param name="path">The directory path to list.</param>
            /// <returns>List of File Information.</returns>
            HdfsFileInfoEntries^ ListDirectory(String^ path);

            /// <summary>
            /// Gets the information associated with a File or Path.
            /// </summary>
            /// <param name="path">The file path to query.</param>
            /// <returns>Path or File Information.</returns>
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
            /// Performs a chown of a HDFS Path or File.
            /// </summary>
            /// <param name="path">The directory or file path to configure.</param>
            /// <param name="owner">The new owner.</param>
            /// <param name="group">The new group.</param>
            /// <returns>Indicator for whether the chown was successful.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Chown fails.</exception>
            void Chown(String^ path, String^ owner, String^ group);

            /// <summary>
            /// Performs a chmod of a HDFS Path or File.
            /// </summary>
            /// <param name="path">The directory or file path to configure.</param>
            /// <param name="mode">The mode bitmask.</param>
            /// <returns>Indicator for whether the chmod was successful.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Chmod fails.</exception>
            void Chmod(String^ path, short mode);

            /// <summary>
            /// Gets the hostnames where a particular block of a HDFS file is stored.
            /// </summary>
            /// <param name="path">The file path to query.</param>
            /// <param name="start">The block start.</param>
            /// <param name="length">The block length.</param>
            /// <returns>A List of host names.</returns>
            List<String^>^ GetHosts(String^ path, int64_t start, int64_t length);

            /// <summary>
            /// Modifies the Path or File Modified and Last Accessed Time.
            /// </summary>
            /// <param name="path">The file path to configure.</param>
            /// <param name="modifiedTime">The modified time.</param>
            /// <param name="accessedTime">The last accessed time.</param>
            /// <returns>Indicator for whether the file modification was successful.</returns>
            /// <exception cref="System::IO::IOException">Thrown when the Set fails.</exception>
            void SetTimes(String^ path, System::DateTime modifiedTime, System::DateTime accessedTime);

            /// <summary>
            /// Opens a HDFS file stream for processing.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <param name="path">The file access mode.</param>
            /// <param name="bufferSize">Buffer size or 0 if you want to use the default configured values.</param>
            /// <param name="replication">Block replication or 0 if you want to use the default configured values.</param>
            /// <param name="blocksize">Block size or 0 if you want to use the default configured values.</param>
            /// <returns>HDFS File Stream.</returns>
            HdfsFileStream^ OpenFileStream(String^ path, HdfsFileAccess accessMode, int bufferSize, short replication, int32_t blocksize);

            /// <summary>
            /// Opens a HDFS file stream for processing.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <param name="path">The file access mode.</param>
            /// <param name="bufferSize">Buffer size or 0 if you want to use the default configured values.</param>
            /// <returns>HDFS File Stream.</returns>
            HdfsFileStream^ OpenFileStream(String^ path, HdfsFileAccess accessMode, int bufferSize);

            /// <summary>
            /// Opens a HDFS file stream for processing.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <param name="path">The file access mode.</param>
            /// <returns>HDFS File Stream.</returns>
            HdfsFileStream^ OpenFileStream(String^ path, HdfsFileAccess accessMode);

            /// <summary>
            /// Opens a HDFS file for reading.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <param name="bufferSize">Buffer size or 0 if you want to use the default configured values.</param>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForRead(String^ path, int bufferSize);

            /// <summary>
            /// Opens a HDFS file for reading using default open values.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForRead(String^ path);

            /// <summary>
            /// Opens a HDFS file for writing.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <param name="bufferSize">Buffer size or 0 if you want to use the default configured values.</param>
            /// <param name="replication">Block replication or 0 if you want to use the default configured values.</param>
            /// <param name="blocksize">Block size or 0 if you want to use the default configured values.</param>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForWrite(String^ path, int bufferSize, short replication, int32_t blocksize);

            /// <summary>
            /// Opens a HDFS file for writing using default open values.
            /// </summary>
            /// <param name="path">The file path to open.</param>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForWrite(String^ path);

            /// <summary>
            /// Opens a HDFS file for appending.
            /// </summary>
            /// <remarks>Only support in version 1.0.0 and above.</remarks>
            /// <param name="path">The file path to open.</param>
            /// <param name="bufferSize">Buffer size or 0 if you want to use the default configured values.</param>
            /// <param name="replication">Block replication or 0 if you want to use the default configured values.</param>
            /// <param name="blocksize">Block size or 0 if you want to use the default configured values.</param>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForAppend(String^ path, int bufferSize, short replication, int32_t blocksize);

            /// <summary>
            /// Opens a HDFS file for appending using default open values.
            /// </summary>
            /// <remarks>Only support in version 1.0.0 and above.</remarks>
            /// <param name="path">The file path to open.</param>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForAppend(String^ path);

            /// <summary>
            /// Copies a HDFS file from one system to another.
            /// </summary>
            /// <param name="conHandleFrom">Connection handle to source file system.</param>
            /// <param name="pathFrom">Source file path.</param>
            /// <param name="conHandleTo">Connection handle to destination file system.</param>
            /// <param name="pathTo">Destination file path.</param>
            /// <exception cref="System::IO::IOException">Thrown when copy fails.</exception>
            static void Copy(HdfsFileSystem^ conHandleFrom, String^ pathFrom, HdfsFileSystem^ conHandleTo, String^ pathTo);

            /// <summary>
            /// Moves a HDFS file from one system to another.
            /// </summary>
            /// <param name="conHandleFrom">Connection handle to source file system.</param>
            /// <param name="pathFrom">Source file path.</param>
            /// <param name="conHandleTo">Connection handle to destination file system.</param>
            /// <param name="pathTo">Destination file path.</param>
            /// <exception cref="System::IO::IOException">Thrown when move fails.</exception>
            static void Move(HdfsFileSystem^ conHandleFrom, String^ pathFrom, HdfsFileSystem^ conHandleTo, String^ pathTo);

            /// <summary>
            /// Closes a HDFS file system connection.
            /// </summary>
            /// <returns>Indicator for whether the file was closed.</returns>
            /// <exception cref="System::IO::IOException">Thrown when Close fails.</exception>
            void Close();

            /// <summary>
            /// Determines if the HDFS file system connection is valid.
            /// </summary>
            /// <returns>Indicator for whether file system is valid.</returns>
            bool IsValid();
        }; 
    }
}
