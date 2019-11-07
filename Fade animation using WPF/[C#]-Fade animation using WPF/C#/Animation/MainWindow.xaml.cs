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
using System.Windows.Media.Animation;

namespace Animation
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

        private void canvas1_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(5));
            c.BeginAnimation(Canvas.OpacityProperty,animation);
            textBlock2.Visibility = Visibility.Hidden;
            textBlock1.Visibility = Visibility.Visible;
        }

        private void canvas1_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            DoubleAnimation animation = new DoubleAnimation(2, TimeSpan.FromSeconds(5));
            c.BeginAnimation(Canvas.OpacityProperty, animation);
            textBlock1.Visibility = Visibility.Hidden;
            textBlock2.Visibility = Visibility.Visible;
        }

        private void ellipse1_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse e1 = (Ellipse)sender;
            DoubleAnimation animation1 = new DoubleAnimation(2, TimeSpan.FromSeconds(5));
            e1.BeginAnimation(Ellipse.OpacityProperty, animation1);
        }

        private void ellipse1_MouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse e1 = (Ellipse)sender;
            DoubleAnimation animation1 = new DoubleAnimation(0, TimeSpan.FromSeconds(5));
            e1.BeginAnimation(Ellipse.OpacityProperty, animation1);
        }

        private void ellipse2_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse e2 = (Ellipse)sender;
            DoubleAnimation animation2 = new DoubleAnimation(2, TimeSpan.FromSeconds(5));
            e2.BeginAnimation(Ellipse.OpacityProperty, animation2);
            
        }

        private void ellipse2_MouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse e2 = (Ellipse)sender;
            DoubleAnimation animation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(5));
            e2.BeginAnimation(Ellipse.OpacityProperty, animation2);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBlock8.Text = "34376";
        }

       /* private void ellipse2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ellipse2.Opacity = 1;
        }*/
    }
}
