using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Client
{
    public partial class App : Application
    {
        void Catch(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            StringBuilder s = new StringBuilder();
            Report(e.Exception, s);
            Trace.WriteLine(s.ToString());
        }

        static void Report(Exception e, StringBuilder s)
        {
            s.AppendLine(e.Message).AppendLine(e.StackTrace);
            var e1 = e.InnerException;
            if (e1 != null)
                Report(e1, s);
        }
    }
}