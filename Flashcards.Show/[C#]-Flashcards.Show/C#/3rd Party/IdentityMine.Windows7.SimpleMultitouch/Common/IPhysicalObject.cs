using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace IdentityMine.Windows.SimpleMultitouch
{
    public interface IPhysicalObject
    {
        UIElement ContainerVisual { get; }

        Vector ApplyManipulation(int id, Point loc);

        void SetPoint(int id, Point pos);
    }
}
