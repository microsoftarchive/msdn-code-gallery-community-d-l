using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SplashScreen = WPF_DynamicSplashScreen.Startup.SplashScreen;

namespace WPF_DynamicSplashScreen
{
    public partial class App : Application
    {
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();

            //set basic dynamic data on splash screen
            splashScreen.AvailablePlugins = new[] { "Plugin 1", "Plugin 2" };
            splashScreen.Licensee = "Musakkhir Sayyed";

            //use during development to generate image and embed it in application
            //splashScreen.Capture(@"c:\StaticSplashScreen.png");

            var startupTask = new Task(() =>
                {
                    //Load plugins in non-UI thread - may be time consuming
                    for (int i = 0; i < 3; i++)
                    {
                        //set custom message on screen
                        splashScreen.Dispatcher.BeginInvoke(
                            (Action)(() => splashScreen.Message = "Loading:  Plugin " + i));

                        Thread.Sleep(1000);
                    }
                });

            //when plugin loading finished, show main window
            startupTask.ContinueWith(t =>
                {
                    MainWindow mainWindow = new MainWindow();

                    //when main windows is loaded close splash screen
                    mainWindow.Loaded += (sender, args) => splashScreen.Close();

                    //set application main window;
                    this.MainWindow = mainWindow;

                    //and finally show it
                    mainWindow.Show();
                }, TaskScheduler.FromCurrentSynchronizationContext());

            startupTask.Start();
        }


    }
}
