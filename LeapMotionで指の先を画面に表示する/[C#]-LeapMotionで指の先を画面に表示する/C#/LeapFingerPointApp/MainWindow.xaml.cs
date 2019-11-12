using Codeplex.Reactive;
using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;

namespace LeapFingerPointApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        private LeapListener listener;
        private Model model;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new Model();
            this.DataContext = model;
            this.controller = new Controller();
            this.listener = new LeapListener(this.model);
            this.controller.AddListener(listener);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            this.controller.RemoveListener(this.listener);
            this.controller.Dispose();
        }
    }

    class LeapListener : Listener
    {
        private Model model;

        public LeapListener(Model model)
        {
            this.model = model;
        }

        public override void OnFrame(Controller c)
        {
            this.model.Frame.Value = c.Frame();
        }
    }

}
