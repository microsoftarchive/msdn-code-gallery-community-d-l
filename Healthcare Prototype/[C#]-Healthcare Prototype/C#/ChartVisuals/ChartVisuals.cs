using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace IdentityMine.Avalon.Controls
{
    public class ChartVisuals : Dictionary<string, VisualBrush>
    {
        public ChartVisuals()
        {
            System.Diagnostics.Debug.WriteLine("ChartVisuals Initialized");
        }
    }
}
