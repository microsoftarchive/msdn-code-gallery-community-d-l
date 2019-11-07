using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using FlashCards.ViewModel;
using System.Text;
using System.Windows.Threading;
using System.IO;
using System.Reflection;

namespace FlashCards.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (new EnableThemingInScope(true))
            {
                FlashCards.UI.App app = new FlashCards.UI.App();
                app.InitializeComponent();
                app.Run();
            }
        }

        /// <summary>
        /// Load different Resource dictionaries based on whether the App is Game or Admin mode.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // splash screen is shown manually due to a race condition bug in WPF 3.5 (which was fixed in WPF 4.0)
            SplashScreen splashScreen = new SplashScreen("Resource/Images/FlashCardSplashScreen.png");
            splashScreen.Show(false);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            InstallDefaultDecks();

            // get arguments from ClickOnce activation arguments or command line
            string[] arguments;

            if ((AppDomain.CurrentDomain.SetupInformation != null) &&
                (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null) && 
                (AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null))
            {
                arguments = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            }
            else
            {
                arguments = e.Args;
            }

            // parse arguments
            if (arguments.Length > 0)
            {
                // check if open as Admin
                if (string.Compare(arguments[0], Taskbar.AdminArgument, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    MainViewModel.Instance.IsAdmin = true;
                }
                // check if open CreateNewCardDeck
                else if (string.Compare(arguments[0], Taskbar.CreateNewCardDeckArgument, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    MainViewModel.Instance.IsAdmin = true;
                    MainViewModel.Instance.Decks.IsNew = true;
                }
                // check if first argument is a deck filename
                else if (arguments[0].EndsWith(MainViewModel.ZippedDeckExtension, StringComparison.InvariantCultureIgnoreCase))
                {
                    MainViewModel.Instance.SelectedZipPath = arguments[0];
                }
                // else, open as Game

                // check if second parameter is a deck filename
                if ((arguments.Length > 1) && (arguments[1].EndsWith(MainViewModel.ZippedDeckExtension, StringComparison.InvariantCultureIgnoreCase)))
                {
                    MainViewModel.Instance.SelectedZipPath = arguments[1];
                }
            }

            // work according to passed arguments
            if (MainViewModel.Instance.IsAdmin)
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("/FlashCards.Show;component/ViewModelMappingAdmin.xaml", UriKind.RelativeOrAbsolute);
                App.Current.Resources.MergedDictionaries.Add(dic);
            }
            else
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Source = new Uri("/FlashCards.Show;component/ViewModelMappingGame.xaml", UriKind.RelativeOrAbsolute);
                App.Current.Resources.MergedDictionaries.Add(dic);
            }

            Taskbar.InitJumpList(MainViewModel.Instance.IsAdmin);

            if (!string.IsNullOrEmpty(MainViewModel.Instance.SelectedZipPath))
            {
                string outputPath = DeckPackagingHelper.ExtractFromZip(MainViewModel.Instance.SelectedZipPath);

                if (!string.IsNullOrEmpty(outputPath))
                {
                    string deckTitle = MainViewModel.Instance.LoadUnzippedDeck(MainViewModel.Instance.SelectedZipPath, outputPath);
                    Taskbar.AddEntryToJumpList(MainViewModel.Instance.SelectedZipPath, deckTitle);
                }
            }

            splashScreen.Close(TimeSpan.FromTicks(0));
            base.OnStartup(e);
        }

        private void InstallDefaultDecks()
        {
            string zippedDecksPath = DeckFileHelper.ZippedDecksPath;

            try
            {
                // Sample data files.
                Directory.CreateDirectory(zippedDecksPath);
                CreateDeckFile(zippedDecksPath, "Animals.deckx", FlashCards.UI.Resources.Animals);
                CreateDeckFile(zippedDecksPath, "Flowers.deckx", FlashCards.UI.Resources.Flowers);
                CreateDeckFile(zippedDecksPath, "Alphabet.deckx", FlashCards.UI.Resources.Alphabet);
            }
            catch (Exception exception)
            {
                // Could not install the deck files, handle all exceptions the same, 
                // ignore and continue without installing the deck files
                Utils.LogException(MethodBase.GetCurrentMethod(), exception);
            }
        }

        private static void CreateDeckFile(string location, string fileName, byte[] fileContent)
        {
            // Full path to the sample file.
            string path = Path.Combine(location, fileName);

            // Return right away if the file already exists.
            if (File.Exists(path))
            {
                return;
            }

            // Create the file.
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(fileContent);
            }
        }        

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            PrintException(e.ExceptionObject as Exception);

            // Return exit code
            this.Shutdown(-1);

        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            PrintException(e.Exception);

            // Return exit code
            this.Shutdown(-1);

#if !DEBUG
            // Prevent default unhandled exception processing
            e.Handled = true;
#endif
        }

        private static void PrintException(Exception exception)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0}\n", exception.Message);
#if DEBUG
            stringBuilder.AppendFormat("{0}\n", exception.StackTrace);
#endif
            stringBuilder.AppendFormat("Exception handled on main UI thread {0}.", Dispatcher.CurrentDispatcher.Thread.ManagedThreadId);

            var result = MessageBox.Show(
                            "Application must exit:\n\n" + stringBuilder.ToString(),
                            "Application Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }


    }
}
