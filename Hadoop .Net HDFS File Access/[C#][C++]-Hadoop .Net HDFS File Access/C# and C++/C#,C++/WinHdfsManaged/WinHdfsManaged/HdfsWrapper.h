// HdfsWrapper.h

#pragma once
#include <hdfs.h>

#include "HdfsConnectionHandle.h"
#include "HdfsFileHandle.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace WinHdfsManaged
    {   
        /// <summary>
        /// Class for a HDFS main elements.
        /// </summary>
        public ref class HdfsWrapper
        {
        public: 
            /// <summary>
            /// Create the HDFS Connection Wrapper.
            /// </summary>
            HdfsWrapper() {}

            /// <summary>
            /// Disposes of the HDFS Wrapper.
            /// </summary>
            !HdfsWrapper() {}
                
            /// <summary>
            /// Destroys the HDFS Wrapper.
            /// </summary>
            ~HdfsWrapper() {}

            /// <summary>
            /// Gets a connection to an Hadoop cluster.
            /// </summary>
            /// <returns>HDFS Connection Handle.</returns>
            HdfsConnectionHandle^ HdfsConnect(String^ host, uint16_t port);

            /// <summary>
            /// Gets a connection to an Hadoop cluster with a user name.
            /// </summary>
            /// <returns>HDFS Connection Handle.</returns>
            HdfsConnectionHandle^ HdfsConnect(String^ host, uint16_t port, String^ user);

            /// <summary>
            /// Opens a HDFS file for reading.
            /// </summary>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForRead(HdfsConnectionHandle^ conHandle, String^ path, int bufferSize, short replication, int32_t blocksize);

            /// <summary>
            /// Opens a HDFS file for writing.
            /// </summary>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForWrite(HdfsConnectionHandle^ conHandle, String^ path, int bufferSize, short replication, int32_t blocksize);

            /// <summary>
            /// Opens a HDFS file for appending.
            /// </summary>
            /// <remarks>Only support in version 1.0.0 and above.</remarks>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFileForAppend(HdfsConnectionHandle^ conHandle, String^ path, int bufferSize, short replication, int32_t blocksize);

            /// <summary>
            /// Copies a HDFS file.
            /// </summary>
            /// <returns>Indicator for whether the copy was successful.</returns>
            void Copy(HdfsConnectionHandle^ conHandleFrom, String^ pathFrom, HdfsConnectionHandle^ conHandleTo, String^ pathTo);

            /// <summary>
            /// Moves a HDFS file.
            /// </summary>
            /// <returns>Indicator for whether the move was successful.</returns>
            void Move(HdfsConnectionHandle^ conHandleFrom, String^ pathFrom, HdfsConnectionHandle^ conHandleTo, String^ pathTo);
    
        internal:
            /// <summary>
            /// Opens an HDFS file.
            /// </summary>
            /// <returns>HDFS File Handle.</returns>
            HdfsFileHandle^ OpenFile(HdfsConnectionHandle^ conHandle, String^ path, int flags, int bufferSize, short replication, tSize blocksize);        
        };
    }
}
