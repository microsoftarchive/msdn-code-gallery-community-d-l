using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace FlashCards.UI
{
    internal static class HelperClass
    {

        public static DependencyObject FindVisualAncestor(this DependencyObject wpfObject, Predicate<DependencyObject> condition)
        {
            while (wpfObject != null)
            {
                if (condition(wpfObject))
                {
                    return wpfObject;
                }

                wpfObject = VisualTreeHelper.GetParent(wpfObject);
            }

            return null;
        }
    }
}
