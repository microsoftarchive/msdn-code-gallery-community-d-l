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
using System.Windows.Automation.Peers;

namespace FlashCards.UI.Controls
{
    
    public class ScatterView : Selector
    {
        ScatterCanvas _canvas;

        public ScatterCanvas ScatterViewPanel
        {
            get { return _canvas; }
        }

        static ScatterView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScatterView), new FrameworkPropertyMetadata(typeof(ScatterView)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = Template.FindName("PART_PANEL",this) as ScatterCanvas;

        }

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new ScatterViewItem(this);
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is ScatterViewItem);
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return base.VisualChildrenCount;
            }
        }

        internal void SetSelectedItem(ScatterViewItem item, bool value)
        {
            if (SelectedItem != null)
            {
                if (SelectedItem is DependencyObject)
                {
                    SetIsSelected((DependencyObject)SelectedItem, false);
                    ScatterViewItem.SetIsSelected((DependencyObject)SelectedItem, false);
                }
                else
                {
                    DependencyObject dp = ItemContainerGenerator.ContainerFromItem(SelectedItem);

                    SetIsSelected(dp, false);
                    ScatterViewItem.SetIsSelected(dp, false);
                }
            }

            SetIsSelected(item , value);
        }

    }
}
