using System;
using System.Windows;
using System.Windows.Threading;

using SyncClient;

using Client.Properties;

namespace Client
{
    public partial class SyncManager : Window
    {
        public SyncManager()
        {
            InitializeComponent();
            Settings.Default.PropertyChanged += (sender, e)  => Settings.Default.Save();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.StartOnline) {
                if (!Settings.Default.LastRunOnline) Synchronise();
                new MainWindow().ShowDialog();
                if (Settings.Default.SyncAfterClose) Synchronise();
                Settings.Default.LastRunOnline = true;
            }
            else if (!Sync.IsProvisioned())
                MessageBox.Show("The database has not been provisioned yet.\nPlease synchronise.", "Offline database not provisioned", MessageBoxButton.OK, MessageBoxImage.Error);
            else {
                new MainWindow().ShowDialog();
                Settings.Default.LastRunOnline = false;
            }
        }

        void Synchronise()
        {
            Synchronising.Visibility = Visibility.Visible;
            Dispatcher.Invoke(DispatcherPriority.Background, new Action(Sync.Synchronize));
            Synchronising.Visibility = Visibility.Hidden;
        }

        private void synchronise_Click(object sender, RoutedEventArgs e)
        {
            Synchronise();
        }
    }
}