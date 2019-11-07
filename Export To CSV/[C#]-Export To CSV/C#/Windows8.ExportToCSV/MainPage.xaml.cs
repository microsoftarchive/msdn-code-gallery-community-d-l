namespace Windows8.ExportToCSV
{
    using ViewModel;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new ConvertingToCSVFileViewModel();
        }
    }
}
