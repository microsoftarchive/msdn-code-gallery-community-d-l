using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Timers;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;  
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Markup;


namespace IdentityMine.Avalon.Controls
{
    /// <summary>
    /// Interaction logic for DocumentWindow.xaml
    /// </summary>

    public partial class DocumentWindow : Window
    {
        public DocumentWindow()
        {
            InitializeComponent();
        }

         void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            string fileFullName = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Documents\NephrolDialTransplant.xaml";
            FileStream fs = File.OpenRead(fileFullName);

            JournalDocumentReader.Document = XamlReader.Load(fs) as FlowDocument;  
        }

    }
}