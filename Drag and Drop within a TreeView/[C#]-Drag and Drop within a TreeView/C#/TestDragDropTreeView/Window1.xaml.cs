using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace TestDragDropTreeView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     These are the items that will populate the TreeView.
        /// </summary>
        public ObservableCollection<Stuff> Stuff
        {
            get
            {
                if (_stuff == null)
                {
                    MakeStuff();
                }

                return _stuff;
            }
        }

        /// <summary>
        ///     Creates sample data.
        /// </summary>
        private void MakeStuff()
        {
            _stuff = new ObservableCollection<Stuff>();

            Stuff source = new Stuff("Source");
            _stuff.Add(source);
            _stuff.Add(new Stuff("Destination"));

            source.MoreStuff.Add(new Stuff("Item 1"));
            source.MoreStuff.Add(new Stuff("Item 2"));
            source.MoreStuff.Add(new Stuff("Item 3"));
            source.MoreStuff.Add(new Stuff("Item 4"));
        }

        private void TreeView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _lastMouseDown = e.GetPosition(TheTreeView);
            }
        }

        private void TreeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(TheTreeView);

                // Note: This should be based on some accessibility number and not just 2 pixels
                if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 2.0) ||
                    (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 2.0))
                {
                    Stuff selectedItem = (Stuff)TheTreeView.SelectedItem;
                    if ((selectedItem != null) && (selectedItem.Parent != null))
                    {
                        TreeViewItem container = GetContainerFromStuff(selectedItem);
                        if (container != null)
                        {
                            DragDropEffects finalDropEffect = DragDrop.DoDragDrop(container, selectedItem, DragDropEffects.Move);
                            if ((finalDropEffect == DragDropEffects.Move) && (_targetStuff != null))
                            {
                                // A Move drop was accepted
                                selectedItem.Parent.MoreStuff.Remove(selectedItem);
                                _targetStuff.MoreStuff.Add(selectedItem);
                                _targetStuff = null;
                            }
                        }
                    }
                }
            }
        }

        private TreeViewItem GetContainerFromStuff(Stuff stuff)
        {
            Stack<Stuff> _stack = new Stack<Stuff>();
            _stack.Push(stuff);
            Stuff parent = stuff.Parent;

            while (parent != null)
            {
                _stack.Push(parent);
                parent = parent.Parent;
            }

            ItemsControl container = TheTreeView;
            while ((_stack.Count > 0) && (container != null))
            {
                Stuff top = _stack.Pop();
                container = (ItemsControl)container.ItemContainerGenerator.ContainerFromItem(top);
            }

            return container as TreeViewItem;
        }

        private TreeViewItem GetNearestContainer(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            TreeViewItem container = element as TreeViewItem;
            while ((container == null) && (element != null))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                container = element as TreeViewItem;
            }

            return container;
        }

        private void TheTreeView_Drop(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            e.Handled = true;


            // Verify that this is a valid drop and then store the drop target
            TreeViewItem container = GetNearestContainer(e.OriginalSource as UIElement);
            if (container != null)
            {
                Stuff sourceStuff = (Stuff)e.Data.GetData(typeof(Stuff));
                Stuff targetStuff = (Stuff)container.Header;
                if ((sourceStuff != null) && (targetStuff != null))
                {
                    if (!targetStuff.MoreStuff.Contains(sourceStuff))
                    {
                        _targetStuff = targetStuff;
                        e.Effects = DragDropEffects.Move;
                    }
                }
            }
        }

        private void TheTreeView_CheckDropTarget(object sender, DragEventArgs e)
        {
            if (!IsValidDropTarget(e.OriginalSource as UIElement))
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private bool IsValidDropTarget(UIElement target)
        {
            if (target != null)
            {
                TreeViewItem container = GetNearestContainer(target);

                // Ensure that the target is one of the root items
                return ((container != null) && (((Stuff)container.Header).Parent == null));
            }

            return false;
        }

        private ObservableCollection<Stuff> _stuff;
        private Point _lastMouseDown;
        private Stuff _targetStuff;

    }
}
