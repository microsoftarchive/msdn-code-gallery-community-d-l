using FileExplorer.Helper;
using FileExplorer.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for UCSearchCategory.xaml
    /// </summary>
    public partial class UCSearchCategory : UserControl
    {
        public UCSearchCategory()
        {
            InitializeComponent();
        }

        private SearchViewModel ViewModel
        {
            get { return this.DataContext as SearchViewModel; }
        }

        void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.IsNull())
            {
                return;
            }

            switch (button.Name)
            {
                case "btnImage":
                    this.ViewModel.AddFilter(MediaType.Image);
                    break;
                case "btnVideo":
                    this.ViewModel.AddFilter(MediaType.Video);
                    break;
                case "btnMusic":
                    this.ViewModel.AddFilter(MediaType.Music);
                    break;
                case "btnDocument":
                    this.ViewModel.AddFilter(MediaType.Document);
                    break;
                default:
                    this.ViewModel.AddFilter(MediaType.All);
                    break;
            }
        }

    }
}
