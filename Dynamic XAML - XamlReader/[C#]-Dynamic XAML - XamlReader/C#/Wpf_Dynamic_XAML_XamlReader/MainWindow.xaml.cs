using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Wpf_Dynamic_XAML_XamlReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("Button1.xaml");
            Button btn = XamlReader.Load(sr.BaseStream) as Button;
            this.AddHere.Children.Add(btn);
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlDoc = new XDocument();
            var xmltxt = Application.GetContentStream(new Uri(@"pack://application:,,,/Button2.xml"));
            string elfull = new StreamReader(xmltxt.Stream).ReadToEnd();

            xmlDoc = XDocument.Parse(elfull);
            XElement el = xmlDoc.Root;

            // In a more complex situation, manipulate as XML/XElement tree 

            ParserContext context = new ParserContext();
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            // context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

            Button btn = (Button)XamlReader.Parse(el.ToString(), context);
            this.AddHere.Children.Add(btn);
        }


        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlDoc = new XDocument();
            var xmltxt = Application.GetContentStream(new Uri(@"pack://application:,,,/tv.txt"));
            string elfull = new StreamReader(xmltxt.Stream).ReadToEnd();

            xmlDoc = XDocument.Parse(elfull);
            XElement el = xmlDoc.Root;
            XElement tc = el.Descendants("TextBlock").First();
            XAttribute a = new XAttribute("Name", "MyTextBlock");
            tc.Add(a);
            string x = "";  // Put break point here
        }
    }
}

            //XDocument xmlDoc = new XDocument();
            //var xmltxt = Application.GetContentStream(new Uri(@"pack://application:,,,/Experiment.txt"));
            //string elfull = new StreamReader(xmltxt.Stream).ReadToEnd();

            //xmlDoc = XDocument.Parse(elfull);
            //XElement el = xmlDoc.Root;
            //XElement tc = el.Descendants("DataGridTextColumn").First();
            //string x = "";  // Put break point here
