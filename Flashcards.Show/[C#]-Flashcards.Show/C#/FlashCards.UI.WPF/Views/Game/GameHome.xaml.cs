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
using System.Windows.Media.Animation;
using FlashCards.UI.Controls;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for AdminHome.xaml
	/// </summary>
	public partial class GameHome : UserControl
	{
        public GameHome()
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
                Emitter.IsEmitting = true;
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
	}
}