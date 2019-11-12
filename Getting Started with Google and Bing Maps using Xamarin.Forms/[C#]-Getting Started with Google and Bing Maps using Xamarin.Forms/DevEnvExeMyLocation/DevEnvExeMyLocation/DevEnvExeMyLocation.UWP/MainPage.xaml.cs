using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DevEnvExeMyLocation.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("2Bqr3cXqACFZKMNT6XFs~TQMFZ6vCmVUv3rDKJqNqtw~An5RkcU0gz5VJdP8ZxGBDWfmBF7BgaB1EabU91oufvb8kgLTgxsfFiAaZUyYwzqs");
            LoadApplication(new DevEnvExeMyLocation.App());
        }
    }
}
