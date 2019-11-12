using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace diceRoll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Random num = new Random();
            int Number = num.Next(1, 7);
            BitmapImage Img = new BitmapImage(new Uri(@"DiceFaces\"+Number.ToString()+".png",UriKind.Relative));
            
            textBlock1.Text = Number.ToString()+" Number";
            image1.Source = Img;
        }
    }
}
