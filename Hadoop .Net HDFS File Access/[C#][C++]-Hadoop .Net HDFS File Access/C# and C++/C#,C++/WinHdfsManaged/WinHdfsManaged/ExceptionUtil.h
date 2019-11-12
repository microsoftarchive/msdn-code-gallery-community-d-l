namespace Microsoft
{
    namespace Hdfs
    {
        using namespace System;
        using namespace System::IO;

        /// <summary>
        /// Throws an exception if an HDFS error occured.
        /// </summary>
        static void ThrowIoIfFalse(bool code, const char* expText)
        {
            if (!code)
            {
                throw gcnew IOException(gcnew String(expText));
            }
        }

        /// <summary>
        /// Throws an argument exception if value not correct.
        /// </summary>
        static void ThrowArgIfFalse(bool code, const char* expText, const char* argText)
        {
            if (!code)
            {
                throw gcnew ArgumentException(gcnew String(expText), gcnew String(argText));
            }
        }

        /// <summary>
        /// Throws an argument exception if value not correct.
        /// </summary>
        static void ThrowNotSupportedIfFalse(bool code, const char* expText)
        {
            if (!code)
            {
                throw gcnew NotSupportedException(gcnew String(expText));
            }
        }
    }
}