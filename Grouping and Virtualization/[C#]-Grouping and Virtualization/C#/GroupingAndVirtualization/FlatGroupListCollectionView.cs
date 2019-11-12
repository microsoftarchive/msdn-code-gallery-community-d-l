using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Data;

namespace GroupingAndVirtualization
{
    /// <summary>
    ///     Provides a view that flattens groups into a list.
    ///     Note: As implemented, it does not support nested grouping.
    /// </summary>
    public class FlatGroupListCollectionView : ListCollectionView
    {
        public FlatGroupListCollectionView(IList list)
            : base(list)
        {
        }

        /// <summary>
        ///     This currently only supports one level of grouping.
        ///     Returns CollectionViewGroups if the index matches a header.
        ///     Otherwise, maps the index into the base range to get the
        ///     actual item.
        /// </summary>
        public override object GetItemAt(int index)
        {
            int delta = 0;
            ReadOnlyObservableCollection<object> groups = BaseGroups;
            if (groups != null)
            {
                int totalCount = 0;
                for (int i = 0; i < groups.Count; i++)
                {
                    CollectionViewGroup group = groups[i] as CollectionViewGroup;
                    if (group != null)
                    {
                        if (index == totalCount)
                        {
                            return group;
                        }

                        delta++;
                        int numInGroup = group.ItemCount;
                        totalCount += numInGroup + 1;

                        if (index < totalCount)
                        {
                            break;
                        }
                    }
                }
            }

            object item = base.GetItemAt(index - delta);
            return item;
        }

        /// <summary>
        ///     In the flat list, the base count is incremented
        ///     by the number of groups since there are that
        ///     many headers. To support nested groups, the nested
        ///     groups must also be counted and added to the count.
        /// </summary>
        public override int Count
        {
            get
            {
                int count = base.Count;
                count += BaseGroups.Count;
                return count;
            }
        }

        /// <summary>
        ///     By returning null, we trick the generator into thinking
        ///     that we are not grouping. Thus, we avoid the default
        ///     grouping code.
        /// </summary>
        public override ReadOnlyObservableCollection<object> Groups
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        ///     Gets the Groups collection from the base class.
        /// </summary>
        private ReadOnlyObservableCollection<object> BaseGroups
        {
            get
            {
                return base.Groups;
            }
        }

        /// <summary>
        ///     DetectGroupHeaders is a way to get access to the containers by setting 
        ///     the value to true in the container style. That way, the change handler 
        ///     can hook up to the container and provide a value for IsHeader.
        /// </summary>
        public static readonly DependencyProperty DetectGroupHeadersProperty =
            DependencyProperty.RegisterAttached("DetectGroupHeaders", typeof(bool), typeof(FlatGroupListCollectionView), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnDetectGroupHeaders)));

        public static bool GetDetectGroupHeaders(DependencyObject obj)
        {
            return (bool)obj.GetValue(DetectGroupHeadersProperty);
        }

        public static void SetDetectGroupHeaders(DependencyObject obj, bool value)
        {
            obj.SetValue(DetectGroupHeadersProperty, value);
        }

        private static void OnDetectGroupHeaders(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // This assumes that a container will not change between being
            // a header and not. If using ContainerRecycling this may not be
            // the case.
            ((FrameworkElement)d).Loaded += new RoutedEventHandler(OnContainerLoaded);
        }

        private static void OnContainerLoaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            element.Loaded -= new RoutedEventHandler(OnContainerLoaded); // If recycling, remove this line

            // CollectionViewGroup is the type of the header in this sample.
            // Add more types or change the type as necessary.
            if (element.DataContext is CollectionViewGroup)
            {
                SetIsHeader(element, true);
            }
        }

        /// <summary>
        ///     IsHeader can be used to style the container differently when
        ///     it is a header. For instance, it can be disabled to prevent
        ///     selection.
        /// </summary>
        public static readonly DependencyProperty IsHeaderProperty =
            DependencyProperty.RegisterAttached("IsHeader", typeof(bool), typeof(FlatGroupListCollectionView), new FrameworkPropertyMetadata(false));

        public static bool GetIsHeader(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHeaderProperty);
        }

        public static void SetIsHeader(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHeaderProperty, value);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        int flatIndex = ConvertFromItemToFlat(args.NewStartingIndex, false);
                        int headerIndex = Math.Max(0, flatIndex - 1);
                        object o = GetItemAt(headerIndex);
                        CollectionViewGroup group = o as CollectionViewGroup;
                        if ((group != null) && (group.ItemCount == args.NewItems.Count))
                        {
                            // Notify that a header was added
                            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new object[] { group }, headerIndex));
                        }

                        base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, args.NewItems, flatIndex));
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    // TODO: Implement this action
                    break;

                case NotifyCollectionChangedAction.Move:
                    // TODO: Implement this action
                    break;

                case NotifyCollectionChangedAction.Replace:
                    // TODO: Implement this action
                    break;

                default:
                    base.OnCollectionChanged(args);
                    break;
            }
        }

        private int ConvertFromItemToFlat(int index, bool removed)
        {
            ReadOnlyObservableCollection<object> groups = BaseGroups;
            if (groups != null)
            {
                int start = 1;
                for (int i = 0; i < groups.Count; i++)
                {
                    CollectionViewGroup group = groups[i] as CollectionViewGroup;
                    if (group != null)
                    {
                        index++;
                        int end = start + group.ItemCount;

                        if ((start <= index) && 
                            ((!removed && index < end) || (removed && index <= end)))
                        {
                            break;
                        }

                        start = end + 1;
                    }
                }
            }

            return index;
        }
    }
}
