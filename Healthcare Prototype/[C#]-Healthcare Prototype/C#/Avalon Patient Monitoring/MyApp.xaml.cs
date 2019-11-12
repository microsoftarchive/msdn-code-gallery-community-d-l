using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace Avalon_Patient_Monitoring
{
	/// <summary>
	/// Interaction logic for MyApp.xaml
	/// </summary>

	public partial class MyApp : Application
	{
        void ApplicationStartingUp(object sender, StartupEventArgs args)
		{
			//Window1 mainWindow = new Window1();
			//mainWindow.Show();
            AppWindow _window1 = new AppWindow();
             // Create the application window (as defined in Window1.xaml).
            String windowArgs = string.Empty;
            // Check for arguments; if there are some build the path to the package out of the args.
            if (args.Args.Length > 0 &&  args.Args[0] != null)
            {       
                for (int i = 0; i < args.Args.Length; ++i)
                {
                    windowArgs = args.Args[i];
                    switch (i)
                    {
                        case 0: // Patient Id
                            patientId = windowArgs;
                            break;
                    }
                }                
            }
            
            _window1.Show();
        }// end:AppStartup()

        static string patientId = string.Empty;

        public static string PatientId
        {
            get { return patientId; }
            set { patientId = value; } 
        }

	}
}