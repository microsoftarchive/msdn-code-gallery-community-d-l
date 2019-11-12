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

namespace FlashCards.UI
{
    /// <summary>
    /// Interaction logic for WaitIndicator.xaml
    /// </summary>
	public partial class WaitIndicator : UserControl
	{
		public WaitIndicator()
		{
			InitializeComponent();
		}

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(WaitIndicator), new UIPropertyMetadata(string.Empty));


		public double IndicatorSize
		{
			get { return (double)GetValue(IndicatorSizeProperty); }
			set { SetValue(IndicatorSizeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IndicatorSize.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IndicatorSizeProperty =
			DependencyProperty.Register("IndicatorSize", typeof(double), typeof(WaitIndicator), new UIPropertyMetadata(100.0));



		public bool IsWaiting
		{
			get { return (bool)GetValue(IsWaitingProperty); }
			set { SetValue(IsWaitingProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsWaiting.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsWaitingProperty =
			DependencyProperty.Register("IsWaiting", typeof(bool), typeof(WaitIndicator), new UIPropertyMetadata(false));

		public Brush IndicatorBrush
		{
			get { return (Brush)GetValue(IndicatorBrushProperty); }
			set { SetValue(IndicatorBrushProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IndicatorBrush.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IndicatorBrushProperty =
			DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(WaitIndicator), new UIPropertyMetadata(Brushes.White));

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(WaitIndicator), new UIPropertyMetadata(null));


	}
}
