// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace AdventureWorks.Shopper
{
    public static class VisualTreeUtilities
    {
        public static T GetVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                DependencyObject v = VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                    child = GetVisualChild<T>(v);
                if (child != null)
                    break;
            }
            return child;
        }

    }
}
