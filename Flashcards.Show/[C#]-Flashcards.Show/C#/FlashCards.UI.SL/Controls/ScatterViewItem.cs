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
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Automation.Peers;

namespace FlashCards.UI.Controls
{
   /// <summary>
   /// This class instances can be manipulated with Multi-gestures to do Zoom, Pan and Roate
   /// </summary>
    public class ScatterViewItem : ListBoxItem
    {
  
        #region Ctrs

        static ScatterViewItem()
        {
        }

        public ScatterViewItem()
        {
            this.DefaultStyleKey = typeof(ScatterViewItem);
        }
        
        #endregion

        #region DPs

        #region Stretch DP
        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ScatterViewItem), new FrameworkPropertyMetadata(Stretch.Fill));


        #endregion

        #endregion

   

    }
}
