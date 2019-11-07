#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Microsoft
{
    namespace Hdfs
    {
        /// <summary>
        /// File Info Entry Kind
        /// File or Directory
        /// </summary>
        public enum class HdfsFileInfoEntryKind
        {
            File,
            Directory
        };

        /// <summary>
        /// File Access Mode.
        /// Open, Write or Append.
        /// </summary>
        public enum class HdfsFileAccess
        {
            Read,
            Write,
            Append
        };
    }
}