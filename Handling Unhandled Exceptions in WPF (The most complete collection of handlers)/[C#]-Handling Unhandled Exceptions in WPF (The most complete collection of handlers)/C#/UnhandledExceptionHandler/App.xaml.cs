using System;
using System.Windows;
using System.Threading.Tasks;
using UnhandledExceptionHandler.Helpers;

namespace UnhandledExceptionHandler
{
    public partial class App : Application
    {
        Log log = Log.GetInstance();

        public App()
        {
            Startup += new StartupEventHandler(App_Startup); // Can be called from XAML

            DispatcherUnhandledException += App_DispatcherUnhandledException; //Example 2

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException; //Example 4

            System.Windows.Forms.Application.ThreadException += WinFormApplication_ThreadException; //Example 5
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            //Here if called from XAML, otherwise, this code can be in App()
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException; // Example 1
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; // Example 3
        }

        // Example 1
        void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            MessageBox.Show("1. CurrentDomain_FirstChanceException");
            //ProcessError(e.Exception);   - This could be used here to log ALL errors, even those caught by a Try/Catch block
        }

        // Example 2
        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("2. App_DispatcherUnhandledException");
            log.ProcessError(e.Exception);
            e.Handled = true;
        }

        // Example 3
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("3. CurrentDomain_UnhandledException");
            var exception = e.ExceptionObject as Exception;
            log.ProcessError(exception);
            if (e.IsTerminating)
            {
                //Now is a good time to write that critical error file!
                MessageBox.Show("Goodbye world!");
            }
        }

        // Example 4
        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            MessageBox.Show("4. TaskScheduler_UnobservedTaskException");
            log.ProcessError(e.Exception);
            e.SetObserved();
        }

        // Example 5
        void WinFormApplication_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("5. WinFormApplication_ThreadException");
            log.ProcessError(e.Exception);
        }
    }
}
