using System;
using System.Windows;

namespace UnhandledExceptionHandler.Helpers
{
    class Log
    {
        static Log log;

        private Log() { }

        public static Log GetInstance()
        {
            if (log == null)
                log = new Log();
            return log;
        }

        internal void ProcessError(Exception exception)
        {
            var error = "LOGGED: Exception = " + exception.Message;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                error += " : Inner Exception = " + exception.Message;
            }

            //This is where you save to file.

            //Don't use MessageBox or anything before actually save the error, 
            // it may itself cause a threading issue and fail to save the original error.
            MessageBox.Show(error);
        }
    }
}
