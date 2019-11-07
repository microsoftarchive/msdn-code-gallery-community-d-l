using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HamburgerTutorial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HamItemsListView.ItemsSource = hamOptions;      //populate the listview

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;   //toggle splitview pane
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack();   //can be implemented according to the needs of your application
        }
        private void goBack() 
        {
            BackButton.Visibility = Visibility.Collapsed;  
        }
        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            BackButton.Visibility = Visibility.Visible;
        }

        private void HamItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ListView;
            var op = list.SelectedItem as HamOption;

            DasboardFrame.Navigate(op.PageType);    //load selected page type into the frame
        }
    }
}
