namespace Avalon_Patient_Monitoring
{
	using System;
    using System.Configuration; 
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Ink;
	using System.Windows.Documents;
	using System.Windows.Shapes;
	using System.Windows.Threading;
	using System.Windows.Media;
	using System.Windows.Media.Media3D;
	using System.Windows.Media.Animation;
	using System.Windows.Media.Imaging;
	using System.Timers;
	using System.Windows.Input;
	using System.Diagnostics;
	using System.IO;
	using System.Xml.Serialization;
	using System.Xml;
	using System.Text;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Formatters.Binary;
	using IdentityMine.Avalon.Controls;
	using IdentityMine.Avalon.PatientSimulator;
    using PatientHelper;

   	public partial class AppWindow
	{
        private WindowsSearchHelper windowsSearcher;
        private MSNSearchHelper  msnSearcher;
        private ScrollViewer hiddenScrollViewer = null;
        private ScrollViewer visibleScrollViewer = null;

		public AppWindow()
		{
			this.InitializeComponent();
        }

		private void OnWindowInitialized(object sender, EventArgs e)
		{            
            chartsManager = new ChartsManager(this);
            rosterListManager = new RosterListManager(this);
            liveChartsManager = new LiveChartsManager(this, chartsManager);
            chartRotatorManager = new ChartRotatorManager (this, chartsManager);
            patientDetail3DManager = new PatientDetail3DManager(this);
            powerChecker = new PowerChecker();

            //The WindowsSearch class will work only for Vista
            windowsSearcher = new WindowsSearchHelper();
            windowsSearcher.ConnectionString = @"Provider=Search.CollatorDSO;Extended Properties='Application=Windows'";
            windowsSearcher.QueryText = "SELECT \"System.ParsingName\",\"System.ItemPathDisplay\" FROM SYSTEMINDEX..SCOPE() WHERE CONTAINS('#')"; // # will be replaced with the query text.
            windowsSearcher.WindowsSearchCompleteEvent += new WindowsSearchHelper.WindowsSearchCompleteEventHandler(windowsSearcher_WindowsSearchCompleteEvent);
            msnSearcher = new MSNSearchHelper();

            msnSearcher.MsnAppID = ConfigurationSettings.AppSettings["MSNAppID"];  

            msnSearcher.MSNSearchCompleteEvent += new MSNSearchHelper.MSNSearchCompleteEventHandler(msnSearcher_MSNSearchCompleteEvent);
        }

        void windowsSearcher_WindowsSearchCompleteEvent(object sender)
        {
            LocalExpander.Header = "Local Search Results";

            if (sender == null) return;

            // Fill in search results
            ObjectDataProvider odp = (ObjectDataProvider)this.FindResource("SearchDataResults");
            if (odp == null)
                return;

            SearchData sd = odp.Data as SearchData;
            if (sd == null)
                return;
            SearchXPSItemCollection xpsCollection = null;
            try
            {
                //check if Operating System is Vista
                if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 6)
                {
                    SearchXPSItemCollection windowsSearchResults = sender as SearchXPSItemCollection;
                    xpsCollection = sd.SearchXPSData;

                    if (windowsSearchResults != null)
                    {
                        foreach (SearchXPSItem var in windowsSearchResults)
                        {
                            xpsCollection.Add(var);
                        }

                    }
                }
            }
            catch
            {
                if (xpsCollection != null)
                    xpsCollection.Clear();
            }

        }

        void msnSearcher_MSNSearchCompleteEvent(object sender)
        {
            MSNExpander.Header = "Web Search Results";
            
            if (sender == null) return;

            // Fill in search results
            ObjectDataProvider odp = (ObjectDataProvider)this.FindResource("SearchDataResults");
            if (odp == null)
                return;

            SearchData sd = odp.Data as SearchData;
            if (sd == null)
                return;

            SearchMSNItemCollection msnCollection = null;
            try
            {

                SearchMSNItemCollection msnSearchResults = sender as SearchMSNItemCollection;
                msnCollection = sd.SearchMSNData;

                if (msnSearchResults != null)
                {
                    foreach (SearchMSNItem var in msnSearchResults)
                    {
                        msnCollection.Add(var);
                    }
                }
            }
            catch
            {
                if (msnCollection != null)
                    msnCollection.Clear();
            }
        }

       	private void OnWindowLoaded(object sender, EventArgs e)
		{
            chartsManager.Load();
            rosterListManager.Load();
            liveChartsManager.Load();
            chartRotatorManager.Load();           
            powerChecker.Load();

            PatientRosterList3DOverlay.ApplyTemplate();
            PatientRosterList.ApplyTemplate();

            hiddenScrollViewer = PatientRosterList3DOverlay.Template.FindName("scrollViewer", PatientRosterList3DOverlay) as ScrollViewer;
            visibleScrollViewer = PatientRosterList.Template.FindName("scrollViewer", PatientRosterList) as ScrollViewer;

            hiddenScrollViewer.ScrollChanged += new ScrollChangedEventHandler(SyncronizeScrollViewers);
            visibleScrollViewer.ScrollChanged += new ScrollChangedEventHandler(SyncronizeScrollViewers);
        }

        void SyncronizeScrollViewers(object sender, ScrollChangedEventArgs e)
        {
            if (sender == hiddenScrollViewer)
            {
                visibleScrollViewer.ScrollToVerticalOffset(hiddenScrollViewer.VerticalOffset);
            }
            else
            {
                hiddenScrollViewer.ScrollToVerticalOffset(visibleScrollViewer.VerticalOffset); 
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // This can't be done any earlier than the SourceInitialized event:
            GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
        }

		protected override void OnContentRendered(EventArgs e)
		{
            ///Iterate through the itemsource of the Master List and 
            ///set the selected item to the patient received from command line
            ///
            if (MyApp.PatientId != null)
            {
                commandLinePatientId = MyApp.PatientId;
                foreach (XmlElement xe in PatientRosterList.ItemsSource)
                {
                    if (xe.SelectSingleNode("patient_Id").InnerText.ToString() == commandLinePatientId.ToString())
                    {
                        PatientRosterList.SelectedItem = xe;
                        break;
                    }
                }
            }
        }

        #region Events
        private void OnSearchButton(object sender, RoutedEventArgs e)
        {
            DetailBack2DWrapperTranslate.X = 0;
        }
        
        private void OnPatientDetailButton (object sender, RoutedEventArgs e)
        {
            patientDetail3DManager.ShowDetailBack();
            PatientRosterList3DOverlay.Visibility = Visibility.Visible;

        }

        private void OnBackToPatientOverview(object sender, RoutedEventArgs e)
        {
            patientDetail3DManager.ShowDetailFront();
            PatientRosterList3DOverlay.Visibility = Visibility.Collapsed;
        }

        private void OnPatientRosterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XmlElement xe = e.AddedItems[0] as XmlElement;

            if (xe == null)
                return;

            // update the workspace charts to include the default chart
            XmlNodeList xnl = xe.GetElementsByTagName("chart");
            XmlNode xn = xnl[0];

            if (xn != null)
            {
                liveChartsManager.AddChart(xn.InnerText);
            }

            
            // Setup for 3D transition
            if (powerChecker.ActivePowerPlan != PowerChecker.PowerPlan.PowerSaver)
            {
                Brush brush = Transition3DHelper.CreateBrushFromUIElementWithBitmap(PatientOverview2D);
                if (brush != null)
                {
                    DiffuseMaterial dm = new DiffuseMaterial(brush);
                    PatientOverview3D.Visibility = Visibility.Visible;
                    PatientOverview3D.Flip(dm, dm);
                }
            }


            PatientRosterList3DOverlay.SelectedItem = xe;
        }

        private void OnPatientRoster3DOverlaySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            PatientRosterList.SelectedItem = lb.SelectedItem;
        }

        void PatientOverview3D_FlipCompleted(object sender, EventArgs e)
        {

            double angleTo = (double)PatientMasterRotater3DTransition.GetValue(IdentityMine.Avalon.Controls.Rotater3DTransition.AngleRotateToProperty);
            double angleFrom = (double)PatientMasterRotater3DTransition.GetValue(IdentityMine.Avalon.Controls.Rotater3DTransition.AngleRotateFromProperty);

            PatientOverview3D.Visibility = Visibility.Collapsed;
        }

        private void ShowAboutIdentityMineDialog(object sender, RoutedEventArgs e)
        {
            Nullable<bool> dlgResult;
            AboutIdentityMineDialogWindow dlgWindow = new AboutIdentityMineDialogWindow();
            dlgWindow.Height = 315;
            dlgWindow.Width = 500;

            dlgWindow.InitializeComponent();

            dlgWindow.Owner = this;
            dlgWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            dlgResult = dlgWindow.ShowDialog();
        }

        private void SearchTextBoxButtonClick(object sender, RoutedEventArgs args)
        {
            if (args.OriginalSource is Button)
            {
                switch ((args.OriginalSource as Button).Name)
                {
                    case "SearchButton":
                        if (SearchBox.DisplayText != SearchBox.Text)
                        {
                            ShowSearchDialog(SearchBox.Text);
                        }
                        break;
                }
            }
        }
       
        #region Search Events

        private void ReturnKeyUpHandler(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;

            ShowSearchDialog(tb.Text);
        }

        void PatientSearchCloseButton_Click(object sender, RoutedEventArgs e)
        {

            PatientSearchResults.Visibility = Visibility.Collapsed;
        }

        void ShowSettingsDialog_Click(object sender, RoutedEventArgs e)
        {

            SettingsDialog.Visibility = Visibility.Visible;
        }
        void SettingsDialog_Click(object sender, RoutedEventArgs e)
        {

            SettingsDialog.Visibility = Visibility.Collapsed;
        }

        void PatientLocalSearchList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((e == null) || (e.AddedItems.Count == 0))
                return;

            SearchXPSItem xpsItem = e.AddedItems[0] as SearchXPSItem;
            if (xpsItem == null)
                return;

            if (xpsItem.Path == null)
                return;

            System.Diagnostics.Process.Start(xpsItem.Path);
        }

        void PatientMSNSearchList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((e == null) || (e.AddedItems.Count == 0))
                return;

            SearchMSNItem xpsItem = e.AddedItems[0] as SearchMSNItem;
            if (xpsItem == null)
                return;

            if (xpsItem.Path == null)
                return;

            System.Diagnostics.Process.Start(xpsItem.Path);
        }

        #endregion

        #endregion

        #region Private Methods

        private void ShowSearchDialog(string searchText)
        {
            if ((searchText == null) || (searchText.Length == 0))
                return;

            PatientSearchResults.Visibility = Visibility.Visible;
            
            // Fill in search results
            ObjectDataProvider odp = (ObjectDataProvider)this.FindResource("SearchDataResults");
            if (odp == null)
                return;

            SearchData sd = odp.Data as SearchData;
            if (sd == null)
                return;

            sd.SearchMSNData.Clear();
            sd.SearchXPSData.Clear();

            LocalExpander.Header = "Local Search Results" + " (Searching...)";
            MSNExpander.Header = "Web Search Results" + " (Searching...)";

            windowsSearcher.ExecuteWindowsSearch(searchText);
            msnSearcher.ExecuteMSNSearch(searchText);
        }

        #endregion

        #region Globals

        ChartsManager chartsManager;
        RosterListManager rosterListManager;
        LiveChartsManager liveChartsManager;
        ChartRotatorManager chartRotatorManager;
        PatientDetail3DManager patientDetail3DManager;
        PowerChecker powerChecker;
        String commandLinePatientId = string.Empty;
        #endregion

    }
}
