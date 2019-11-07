using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CompuSight.Metro.Samples.Logging.Log;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CompuSight.Metro.Samples.Logging
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            MetroEventSource.Log.Debug("Initializing the MainPage");

            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MetroEventSource.Log.Info("On Navigated to the main page");
        }

        private void VerboseMessage_Click_1(object sender, RoutedEventArgs e)
        {
            MetroEventSource.Log.Debug("Here is the verbose message");
        }

        private void InfoMessage_Click_1(object sender, RoutedEventArgs e)
        {
            MetroEventSource.Log.Info("Here is the info message");
        }

        private void ErrorMessage_Click_1(object sender, RoutedEventArgs e)
        {
            MetroEventSource.Log.Error("Here is the error message");
        }

        private void CriticalMessage_Click_1(object sender, RoutedEventArgs e)
        {
            MetroEventSource.Log.Critical("Here is the critical message");
        }
    }
}
