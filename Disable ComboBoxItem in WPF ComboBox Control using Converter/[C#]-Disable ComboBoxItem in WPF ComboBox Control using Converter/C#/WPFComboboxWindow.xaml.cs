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

namespace ComboboxDisable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WPFComboboxWindow : Window
    {
        public WPFComboboxWindow()
        {
            InitializeComponent();
            var clas = new ExampleClass();
            
            this.DataContext = clas;
        }

        private void comboBox1_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            
            foreach (Object s in cb.Items)
            {
                //ComboBoxItem cbt = s as ComboBoxItem;
                //cbt.IsEnabled = false;

                //Type t = cb.Items[0].GetType();
                //ComboBoxItem
                //if (s.Content.ToString() == "item2")
                //{
                //    s.IsEnabled = false;
                //}
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (null != comboBox)
            {
                var item = comboBox.SelectedItem as ComboBoxItem;
                if (null != item)
                {
                    
                }
            }
        }
    }
}
