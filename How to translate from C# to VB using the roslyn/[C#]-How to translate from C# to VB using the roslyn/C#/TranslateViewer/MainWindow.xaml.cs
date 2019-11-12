using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gekka.Roslyn.TranslateViewer
{
    public partial class MainWindow : Window
    {
		public MainWindow()
		{
			InitializeComponent();
		}

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
			var tv=(TreeView)sender;
			var x = e.NewValue as Item;
			if (x == null)
			{
			}
			else
			{
				tv.SetValue(Control.TagProperty, e.NewValue as Item);
			}
            this.pg.SelectedObject = e.NewValue;

        }


        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }

        public static readonly DependencyProperty InputTextProperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(MainWindow), new PropertyMetadata(null));

        public string OutputText
        {
            get { return (string)GetValue(OutputTextProperty); }
            set { SetValue(OutputTextProperty, value); }
        }

        public static readonly DependencyProperty OutputTextProperty =
            DependencyProperty.Register
                ("OutputText", typeof(string), typeof(MainWindow)
                , new FrameworkPropertyMetadata
                    (default(string) , new PropertyChangedCallback(OnOutputTextChangedCallback)));

        private static void OnOutputTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow target = d as MainWindow;
            if (target != null)
            {
                string oldValue = (string)e.OldValue;
                string newValue = (string)e.NewValue;

                target.output.Text = newValue;
            }
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            InputText = input.Text;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "C# Code File|*.cs|All|*.*";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    using (var stream = dlg.OpenFile())
                    {
                        var sr = new System.IO.StreamReader(stream);
                        this.input.Text= sr.ReadToEnd();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }        
    }

    
}
