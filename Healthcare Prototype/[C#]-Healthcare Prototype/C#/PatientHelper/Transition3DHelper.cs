using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PatientHelper
{
    public class Transition3DHelper
    {
        public static Brush CreateBrushFromUIElementWithBitmap(UIElement element)
        {
            FrameworkElement fe = element as FrameworkElement;
            if ((fe == null) || (fe.ActualWidth == 0.0))
                return null;

            //Snap the current visual of "this" to a bitmap to be used in 3d animation
            RenderTargetBitmap bitmapImage = new RenderTargetBitmap((int)fe.ActualWidth, (int)fe.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmapImage.Render(element);

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;
            imageBrush.ViewportUnits = BrushMappingMode.Absolute;

            return imageBrush as Brush;
        }


    }
}
