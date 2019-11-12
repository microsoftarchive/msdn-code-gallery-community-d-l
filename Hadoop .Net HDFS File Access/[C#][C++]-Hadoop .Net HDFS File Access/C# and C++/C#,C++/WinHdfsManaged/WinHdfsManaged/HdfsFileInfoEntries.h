#pragma once

#include <hdfs.h>
#include <time.h>

#include "HdfsFileInfoEntry.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace Hdfs
    {       
        /// <summary>
        /// Class containing the list of FileInfoEntries.
        /// </summary>
        public ref class HdfsFileInfoEntries sealed
        {
        internal:
            hdfsFileInfo * fInfo;

            int entries;

            /// <summary>
            /// Create the File Info Entries.
            /// </summary>
            HdfsFileInfoEntries(hdfsFileInfo * info, int numEntries): fInfo(info), entries(numEntries) { }

        public:
            /// <summary>
            /// Disposes of the HDFS File Info Entries.
            /// </summary>
            !HdfsFileInfoEntries()
            {
                if (fInfo != NULL)
                {
                    hdfsFreeFileInfo(fInfo, entries);
                    fInfo = NULL;
                }
            }

            /// <summary>
            /// Destroys the HDFS File Info Entries.
            /// </summary>
            ~HdfsFileInfoEntries()
            {
                this->!HdfsFileInfoEntries();
            }
            
            /// <summary>
            /// Get the List of FileInfoEntry elements.
            /// </summary>
            property List<HdfsFileInfoEntry^>^ Entries { List<HdfsFileInfoEntry^>^ get(); }
        };
    }
}
