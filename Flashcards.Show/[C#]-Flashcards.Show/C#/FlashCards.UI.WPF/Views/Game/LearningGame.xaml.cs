using System;
using System.Collections.Generic;
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
using IdentityMine.Windows.SimpleMultitouch;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for DeckView.xaml
	/// </summary>
	public partial class LearningGame : UserControl
	{
        public LearningGame()
        {
            this.InitializeComponent();
            Emitter.StylusDown += new StylusDownEventHandler(LayoutRoot_StylusDown);
            Emitter.StylusUp += new StylusEventHandler(LayoutRoot_StylusUp);
            Emitter.StylusMove += new StylusEventHandler(LayoutRoot_StylusMove);
            Emitter.StylusLeave += new StylusEventHandler(LayoutRoot_StylusUp);

            Emitter.MouseDown += new MouseButtonEventHandler(LayoutRoot_MouseDown);
            Emitter.MouseUp += new MouseButtonEventHandler(LayoutRoot_MouseUp);
            Emitter.MouseMove += new MouseEventHandler(LayoutRoot_MouseMove);
            Emitter.MouseLeave += new MouseEventHandler(LayoutRoot_MouseLeave);

        }

        void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            Emitter.IsEmitting = false;
        }

        void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Emitter.EmitLocation = e.GetPosition(Emitter);
            }
        }

        void LayoutRoot_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Emitter.IsEmitting = false;

        }

        void LayoutRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Emitter.EmitLocation = e.GetPosition(Emitter);
            Emitter.IsEmitting = true;
            //DoubleAnimation anim = new DoubleAnimation(0., 6, new Duration(TimeSpan.FromSeconds(1.5)));
            //Emitter.BeginAnimation(ParticleEmitter.ZoomProperty, anim);
        }

        void LayoutRoot_StylusMove(object sender, StylusEventArgs e)
        {
            Emitter.EmitLocation = e.GetPosition(Emitter);

        }

        void LayoutRoot_StylusUp(object sender, StylusEventArgs e)
        {
            Emitter.IsEmitting = false;

        }

        void LayoutRoot_StylusDown(object sender, StylusDownEventArgs e)
        {
            Emitter.EmitLocation = e.GetPosition(Emitter);
            Emitter.IsEmitting = true;
        }


        private void TapBehavior_Tap(object sender, TapEventArgs e)
        {
            if (e.Device is StylusDevice)
            {
                double position = ((StylusDevice)e.Device).GetPosition(flipper).X;
                flipper.Rotate(position < flipper.ActualWidth / 2.0);
            }
            else
            {
                double position = ((MouseDevice)e.Device).GetPosition(flipper).X;
                flipper.Rotate(position < flipper.ActualWidth / 2.0);
            }
        }

        private void Flickable_HorizontalFlick(object sender, IdentityMine.Windows.SimpleMultitouch.FlickEventArgs e)
        {
            if(e.AlignedDirection.X <0)
                flipper.Rotate(true);
            else
                flipper.Rotate(false);
        }

        private void flipper_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            flipper.Reset();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog dlg = new AboutDialog();
            dlg.Owner = App.Current.MainWindow;
            dlg.ShowDialog();
        }

	}
}
