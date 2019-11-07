#include "stdafx.h"

#include "Enumerations.h"

#include "HdfsFileInfoEntry.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace Hdfs
    {   
        /// <summary>
        /// Converts a UNIX tTime to a DateTime.
        /// </summary>
        System::DateTime HdfsFileInfoEntry::GetDateTime(time_t tTime)
        {
            return (System::DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds((double)tTime);     
        }

        /// <summary>
        /// Converts a DateTime to UNIX tTime.
        /// </summary>
        tTime HdfsFileInfoEntry::GetUnixTime(System::DateTime datetime)
        {
            TimeSpan tSpan = (datetime - System::DateTime(1970, 1, 1, 0, 0, 0));
            return safe_cast<tTime>(tSpan.TotalSeconds); 
        }

        /// <summary>
        /// Converts from and unmanged to managed FileInfoEntry.
        /// </summary>
        void HdfsFileInfoEntry::SetFileInfoEntryValues(hdfsFileInfo fInfo,HdfsFileInfoEntry^ entry)
        {
            entry->kind = fInfo.mKind == 'F' ? HdfsFileInfoEntryKind::File : HdfsFileInfoEntryKind::Directory;
            entry->name = gcnew String(fInfo.mName);
            entry->lastMod = HdfsFileInfoEntry::GetDateTime(fInfo.mLastMod);
            entry->size = (int64_t)fInfo.mSize;
            entry->replication = fInfo.mReplication;
            entry->blockSize = (int64_t)fInfo.mBlockSize;
            entry->owner = gcnew String(fInfo.mOwner);
            entry->group = gcnew String(fInfo.mGroup);
            entry->permissions = fInfo.mPermissions;
            entry->lastAccess = HdfsFileInfoEntry::GetDateTime(fInfo.mLastAccess);
        }
    }
}

