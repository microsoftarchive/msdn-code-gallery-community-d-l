using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TestDragDropTreeView
{
    public class Stuff
    {
        public Stuff()
        {
            Name = String.Empty;
        }

        public Stuff(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     The string that will be displayed for this item.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///     The parent of this item.
        /// </summary>
        public Stuff Parent
        {
            get;
            set;
        }

        /// <summary>
        ///     The child data for this item.
        /// </summary>
        public ObservableCollection<Stuff> MoreStuff
        {
            get
            {
                if (_moreStuff == null)
                {
                    _moreStuff = new ObservableCollection<Stuff>();
                    _moreStuff.CollectionChanged += new NotifyCollectionChangedEventHandler(OnMoreStuffChanged);
                }

                return _moreStuff;
            }
        }

        private void OnMoreStuffChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Note: This section does not account for multiple items being involved in change operations.
            // Note: This section does not account for the replace operation.
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Stuff stuff = (Stuff)e.NewItems[0];
                stuff.Parent = this;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Stuff stuff = (Stuff)e.OldItems[0];
                if (stuff.Parent == this)
                {
                    stuff.Parent = null;
                }
            }
        }

        private ObservableCollection<Stuff> _moreStuff;
    }
}
