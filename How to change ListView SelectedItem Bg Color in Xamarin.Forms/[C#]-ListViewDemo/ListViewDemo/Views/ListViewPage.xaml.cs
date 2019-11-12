using ListViewDemo.ViewModels;
using Xamarin.Forms;

namespace ListViewDemo.Views
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            BindingContext = new ListViewPageViewModel();
        }
    }
}