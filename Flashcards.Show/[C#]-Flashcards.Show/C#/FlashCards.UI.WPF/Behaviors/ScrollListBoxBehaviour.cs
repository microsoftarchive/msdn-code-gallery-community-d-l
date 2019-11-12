using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Expression.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
using Windows7.Multitouch.Manipulation;
using System.Drawing;


namespace FlashCardUI.Behaviors
{

    /// <summary>
    /// A Inertia Enabled Scroll Behavior to apply to a scrollviewer
    /// </summary>
    public class ScrollListBoxBehavior : Behavior<ListBox>
    {
   
        #region Behaviour Overrides

        protected override void OnAttached()
        {
            base.OnAttached();

     
            AssociatedObject.PreviewMouseDoubleClick += (s, e) =>
            {
              DependencyObject clicked = (DependencyObject)e.OriginalSource;
              if (clicked != null)
              {
                  ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor(clicked, (o) => o.GetType() == typeof(ListBoxItem));

                  if(item != null)
                    item.IsSelected = true;
              }
            };

            AssociatedObject.PreviewMouseDown += (s, e) =>
            {
                DependencyObject clicked = (DependencyObject)e.OriginalSource;
                if (clicked != null)
                {
                    ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor(clicked, (o) => o.GetType() == typeof(ListBoxItem));

                    if (item != null)
                    {
                        if (!item.IsSelected)
                        {
                            AssociatedObject.SelectedIndex = -1;
                        }
                    }
                }
            };
            
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
        #endregion

    }
}
