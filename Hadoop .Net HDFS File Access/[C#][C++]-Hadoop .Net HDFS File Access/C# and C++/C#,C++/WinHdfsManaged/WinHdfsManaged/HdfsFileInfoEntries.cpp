#include "stdafx.h"

#include "HdfsFileInfoEntries.h"
#include "HdfsFileInfoEntry.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace Hdfs
    {   
        /// <summary>
        /// Gets the List of HdfsFileInfoEntry elements.
        /// </summary>
        List<HdfsFileInfoEntry^>^ HdfsFileInfoEntries::Entries::get()
        {
            List<HdfsFileInfoEntry^>^ managedEntries = nullptr;

            if (this->fInfo != NULL)
            {
                managedEntries = gcnew List<HdfsFileInfoEntry^>(); 
                for(int i = 0; i < this->entries; ++i)
                {
                    HdfsFileInfoEntry^ entry = gcnew HdfsFileInfoEntry();
                    HdfsFileInfoEntry::SetFileInfoEntryValues(fInfo[i],entry);
                    managedEntries->Add(entry);
                }
            }

            return managedEntries;
        }
    }
}

