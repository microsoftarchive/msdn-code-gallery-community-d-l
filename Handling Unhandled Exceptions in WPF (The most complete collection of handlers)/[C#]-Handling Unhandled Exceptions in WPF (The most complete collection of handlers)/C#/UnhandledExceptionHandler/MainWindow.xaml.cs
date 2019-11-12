using System;
using System.Windows;
using System.Threading.Tasks;
using UnhandledExceptionHandler.Model;
using System.Reflection;

namespace UnhandledExceptionHandler
{
    public partial class MainWindow : Window
    {
        Exception MyInnerException = new ArgumentOutOfRangeException();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TryCatch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //This will still trigger the FirstChanceException
                throw new Exception("Try/Catch Exception!!", MyInnerException);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Caught exception: " + exc.Message);
            }
        }

        private void AppDomainUnhandled_Click(object s, RoutedEventArgs ee)
        {
            throw new Exception("Unhandled Exception!!", MyInnerException);
        }

        private void ApplicationCurrentUnhandled_Click(object s, RoutedEventArgs ee)
        {
            SecondAppDomainUnhandledException();
        }

        private void TaskException_Click(object sender, RoutedEventArgs e)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                throw new Exception("Task Exception!!", MyInnerException);
            });

            ((IAsyncResult)t).AsyncWaitHandle.WaitOne();
            t = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

 
        void SecondAppDomainUnhandledException()
        {
            // Make second AppDomain.
            AppDomainSetup ads = new AppDomainSetup();
            ads.ApplicationBase = System.Environment.CurrentDirectory;
            ads.DisallowBindingRedirects = false;
            ads.DisallowCodeDownload = true;
            ads.ConfigurationFile =  AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            AppDomain ad2 = AppDomain.CreateDomain("AppDomain #2", null, ads);

            //Create A proxy to an object in the second AppDomain
            SecondAppDomainObject objectProxy = 
                (SecondAppDomainObject)ad2.CreateInstanceAndUnwrap(Assembly.GetEntryAssembly().FullName, typeof(SecondAppDomainObject).FullName);

            // Call a method on the proxy object (which will have an unhandled exception
            objectProxy.StartProcessingStuff();

        }
    }
}
