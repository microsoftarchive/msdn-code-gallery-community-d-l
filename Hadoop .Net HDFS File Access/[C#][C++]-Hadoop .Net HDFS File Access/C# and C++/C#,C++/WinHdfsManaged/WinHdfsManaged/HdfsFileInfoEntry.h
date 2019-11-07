#pragma once

#include <hdfs.h>

#include "Enumerations.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace Hdfs
    {
        /// <summary>
        /// Class for all the properties of a FileInfoEntry.
        /// </summary>
        public ref class HdfsFileInfoEntry sealed
        {
        internal:
            HdfsFileInfoEntryKind kind;     /* the kind of the file */
            String^ name;                   /* the name of the file */
            System::DateTime lastMod;       /* the last modification time for the file in seconds */
            int64_t size;                   /* the size of the file in bytes */
            short replication;              /* the count of replicas */
            int64_t blockSize;              /* the block size for the file */
            String^ owner;                  /* the owner of the file */
            String^ group;                  /* the group associated with the file */
            short permissions;              /* the permissions associated with the file */
            System::DateTime lastAccess;    /* the last access time for the file in seconds */
            hdfsFileInfo * info;

            /// <summary>
            /// Internal constructor.
            /// </summary>
            HdfsFileInfoEntry(hdfsFileInfo * fInfo):info(fInfo) {}

            /// <summary>
            /// Converts a UNIX tTime to a DateTime.
            /// </summary>
            /// <returns>Explicit DateTime.</returns>
            static System::DateTime GetDateTime(tTime filetime);

            /// <summary>
            /// Converts a DateTime to UNIX tTime.
            /// </summary>
            /// <returns>Unix Time.</returns>
            static tTime GetUnixTime(System::DateTime datetime);

            /// <summary>
            /// Converts from and unmanged to managed FileInfoEntry.
            /// </summary>
            /// <returns>Managed HdfsFileInfoEntry.</returns>
            static void SetFileInfoEntryValues(hdfsFileInfo fInfo, HdfsFileInfoEntry^ entry);
        
        public: 
            /// <summary>
            /// Create a new HDFS File Info Entry.
            /// </summary>
            HdfsFileInfoEntry()
            {
                info = NULL;
            }

            /// <summary>
            /// Disposes of the HDFS File Info Entry.
            /// </summary>
            !HdfsFileInfoEntry()
            {
                 if (info != NULL)
                {
                    hdfsFreeFileInfo(info, 1);	
                    info = NULL;
                }
            }

            /// <summary>
            /// Destroys of the HDFS File Info Entry.
            /// </summary>
            ~HdfsFileInfoEntry()
            {
                this->!HdfsFileInfoEntry();
            }

            /// <summary>
            /// Get the HDFS File Information Kind.
            /// </summary>
            property HdfsFileInfoEntryKind Kind
            {
                HdfsFileInfoEntryKind get()
                {
                    return kind;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Name.
            /// </summary>
            property String^ Name
            {
                String^ get()
                {
                    return name;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Last Modified Date.
            /// </summary>
            property System::DateTime LastModified
            {
                System::DateTime get()
                {
                    return lastMod;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Last Accessed Date.
            /// </summary>
            property System::DateTime LastAccessed
            {
                System::DateTime get()
                {
                    return lastAccess;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Size.
            /// </summary>
            property int64_t Size
            {
                int64_t get()
                {
                    return size;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Replication Count.
            /// </summary>
            property short Replication
            {
                short get()
                {
                    return replication;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Block Size.
            /// </summary>
            property int64_t BlockSize
            {
                int64_t get()
                {
                    return blockSize;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Owner.
            /// </summary>
            property String^ Owner
            {
                String^ get()
                {
                    return owner;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Group.
            /// </summary>
            property String^ Group
            {
                String^ get()
                {
                    return group;
                }
            }

            /// <summary>
            /// Get the HDFS File Infomation Permission.
            /// </summary>
            property short Permissions 
            {
                short get()
                {
                    return permissions;
                }
            }
        };
    }
}
