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

namespace wpfScalingEntireApplication
{
    /// <summary>
    /// Interaction logic for CommonUserControl.xaml
    /// </summary>
    public partial class CommonUserControl : UserControl
    {
        public CommonUserControl()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ucScale != null && slider != null)   // exclude of exception during LOAD ...
            {
                ucScale.ScaleX = slider.Value;
                ucScale.ScaleY = slider.Value;
            }

        }
    }
}
