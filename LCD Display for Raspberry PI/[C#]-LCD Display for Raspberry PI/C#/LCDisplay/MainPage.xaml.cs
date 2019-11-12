using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LCDisplay
{
    public sealed partial class MainPage : Page
    {
        I2CLibrary.Lcd2004 _display = new I2CLibrary.Lcd2004();
        
        public MainPage()
        {
            this.InitializeComponent();

            System.Diagnostics.Debug.WriteLine("Initializing LCD");
            _display.Initialize();
        }

        ~MainPage()
        {
           _display.Dispose();    
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Clear screen and display cursor on LCD");

            _display.Clear();
            _display.Home();
            _display.BlinkingCursor(true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string message = "Hello World! ";
            System.Diagnostics.Debug.WriteLine($"Print to LCD: {message}");
            _display.Print(message);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
              System.Diagnostics.Debug.WriteLine("Exit application");
            
            _display.Clear();
            _display.SetCursor(0, 3);
            _display.Print("Bye.");

            _display.Dispose();

            Application.Current.Exit();
        }
    }
}
