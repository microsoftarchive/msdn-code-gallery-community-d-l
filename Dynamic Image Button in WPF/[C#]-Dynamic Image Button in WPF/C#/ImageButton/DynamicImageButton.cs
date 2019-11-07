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
using System.Windows.Controls.Primitives;

namespace ImageButton
{
  public class DynamicImageButton : ButtonBase
  {
    static DynamicImageButton()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicImageButton), new FrameworkPropertyMetadata(typeof(DynamicImageButton)));
    }

    public string IconImageUri
    {
      get { return (string)GetValue(IconImageUriProperty); }
      set
      {
        SetValue(IconImageUriProperty, value);
      }
    }
    public static readonly DependencyProperty IconImageUriProperty =
        DependencyProperty.Register("IconImageUri", typeof(string), typeof(DynamicImageButton), new UIPropertyMetadata(string.Empty,
          (o, e) =>
          {
            try
            {
              Uri uriSource = new Uri((string)e.NewValue, UriKind.RelativeOrAbsolute);
              if (uriSource != null)
              {
                DynamicImageButton button = o as DynamicImageButton;
                BitmapImage img = new BitmapImage(uriSource);
                button.SetValue(IconImageProperty, img);
              }
            }
            catch (Exception ex)
            {
              throw ex;
            }
          }));

    public BitmapImage IconImage
    {
      get { return (BitmapImage)GetValue(IconImageProperty); }
      set { SetValue(IconImageProperty, value); }
    }
    public static readonly DependencyProperty IconImageProperty =
        DependencyProperty.Register("IconImage", typeof(BitmapImage), typeof(DynamicImageButton), new UIPropertyMetadata(null));
  }
}
