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
using FlashCards.UI.Common;

namespace FlashCards.UI.Controls
{
    
    public class ScatterView : ListBox
    {
        ScatterCanvas _canvas;

        public ScatterCanvas ScatterViewPanel
        {
            get { return _canvas; }
        }

        static ScatterView()
        {
        }

        public ScatterView()
        {
            this.DefaultStyleKey = typeof(ScatterView);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //_canvas = Template.FindName("PART_PANEL",this) as ScatterCanvas;

            _canvas = TreeHelper.FindDescendent(this, "PART_PANEL") as ScatterCanvas;


        }

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new ScatterViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is ScatterViewItem);
        }
    }
}
