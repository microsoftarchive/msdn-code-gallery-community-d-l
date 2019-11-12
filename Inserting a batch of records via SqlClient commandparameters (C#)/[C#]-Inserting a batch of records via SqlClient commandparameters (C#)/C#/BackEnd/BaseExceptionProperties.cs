using System;

namespace BackEnd
{
    public class BaseExceptionProperties
    {
        protected bool mHasException;
        public bool HasException { get { return mHasException; } }
        protected Exception mLastException;
        public Exception LastException { get { return mLastException; } }
    }
}
