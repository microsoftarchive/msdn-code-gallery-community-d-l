using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;


namespace IdentityMine.Avalon.Controls
{
    public class VistaTypeTextBox : TextBox
    {
        private bool textTypedIn = false;

        private FontStyle defaultFontStyle;
        private Brush defaultBackground = null;
        private Brush defaultForeground = null;

        public delegate void ReturnKeyUpEventHandler(object sender, System.Windows.Input.KeyEventArgs e);
        public event ReturnKeyUpEventHandler ReturnKeyUp;

        public string DisplayText
        {
            get
            {
                return (string)GetValue(DisplayTextProperty);
            }
            set
            {
                SetValue(DisplayTextProperty, value);
            }
        }

        public FontStyle NewFontStyle
        {
            get
            {
                return (FontStyle)GetValue(NewFontStyleProperty);
            }
            set
            {
                SetValue(NewFontStyleProperty, value);
            }
        }

        public Brush NewBackground
        {
            get
            {
                return (Brush)GetValue(NewBackgroundProperty);
            }
            set
            {
                SetValue(NewBackgroundProperty, value);
            }
        }

        public Brush NewForeground
        {
            get
            {
                return (Brush)GetValue(NewForegroundProperty);
            }
            set
            {
                SetValue(NewForegroundProperty, value);
            }
        }

        //This is the text that will appear in the textbox when it does not have focus
        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register(
                "DisplayText",
                typeof(string),
                typeof(VistaTypeTextBox),
                new PropertyMetadata("Search"));

        //This is the font style of the text that will appear in the textbox when it does not have focus
        public static readonly DependencyProperty NewFontStyleProperty = DependencyProperty.Register(
            "NewFontStyle",
            typeof(FontStyle),
            typeof(VistaTypeTextBox),
            new PropertyMetadata(FontStyles.Italic));

        //This is the background of the textbox when it does not have focus
          public static readonly DependencyProperty NewBackgroundProperty = DependencyProperty.Register(
            "NewBackground",
            typeof(Brush),
            typeof(VistaTypeTextBox),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(243, 243, 243))));

          //This is the foreground of the textbox when it does not have focus
        public static readonly DependencyProperty NewForegroundProperty = DependencyProperty.Register(
            "NewForeground",
            typeof(Brush),
            typeof(VistaTypeTextBox),
            new PropertyMetadata(new SolidColorBrush(Colors.Gray)));


              
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //save the default properties of the textbox before saving them
            defaultFontStyle = this.FontStyle;
            defaultBackground = this.Background;
            defaultForeground = this.Foreground;

            SetNewProperties();
            this.Background = NewBackground;
            this.Text = DisplayText;
        }
               

        protected override void OnGotFocus(System.Windows.RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            this.Background = defaultBackground;
            SetDefaultProperties();
            if (!textTypedIn)
                this.Text = String.Empty; 
        }

        protected override void OnLostFocus(System.Windows.RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            this.Background = NewBackground;
            if (this.Text == string.Empty)
            {
                this.Text = DisplayText;
                SetNewProperties();               
                textTypedIn = false;
            }
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!textTypedIn)
                this.Text = string.Empty;
        }

        protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == System.Windows.Input.Key.Return)
            {
                if (ReturnKeyUp != null)
                    ReturnKeyUp(this, e);
            }
            else
                textTypedIn = true;            
        }

        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.Background = defaultBackground;
        }

        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if(!this.IsFocused)
                this.Background = NewBackground;
        }

        private void SetDefaultProperties()
        {
            this.FontStyle = defaultFontStyle;
            this.Foreground = defaultForeground;
        }

        private void SetNewProperties()
        {
            this.FontStyle = NewFontStyle;
            this.Foreground = NewForeground;
        }
   
    }
}
