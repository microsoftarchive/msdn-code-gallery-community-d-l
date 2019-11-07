using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientSample
{

    #region DragItemData Class

    /// <summary>
    /// Contains information for dragging items.
    /// </summary>
    internal class DragItemData
    {
        private readonly List<ListViewItem> _dragItems; // Draging items.
        private readonly DragAndDropListView _listView; // Drag and Drop list view object.

        #region Public Properties

        /// <summary>
        /// Gets the drag-drop enabled list view control.
        /// </summary>
        public DragAndDropListView ListView
        {
            get { return _listView; }
        }

        /// <summary>
        /// Gets a list of ListViewItem for drag and drop.
        /// </summary>
        public List<ListViewItem> DragItems
        {
            get { return _dragItems; }
        }

        #endregion

        #region Public Methods and Implementation

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="listView">The drag-drop enabled list view control.</param>
        public DragItemData(DragAndDropListView listView)
        {
            _listView = listView;
            _dragItems = new List<ListViewItem>();
        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Represents a drag-drop enabled ListView control.
    /// </summary>
    public class DragAndDropListView : ListView
    {
        #region Properties

        private bool _allowDrag = true;

        /// <summary>
        /// Gets or set a boolean value indicating whether the Drag feature is enabled.
        /// </summary>
        public bool AllowDrag
        {
            get { return _allowDrag; }
            set { _allowDrag = value; }
        }

        #endregion

        /// <summary>
        /// Gets data for drag and drop.
        /// </summary>
        /// <returns>The DragItemData object.</returns>
        private DragItemData GetDataForDragDrop()
        {
            // create a drag item data object that will be used to pass along with the drag and drop
            DragItemData data = new DragItemData(this);

            // go through each of the selected items and 
            // add them to the drag items collection
            // by creating a clone of the list item
            foreach (ListViewItem item in SelectedItems)
            {
                data.DragItems.Add((ListViewItem) item.Clone());
            }

            return data;
        }

        /// <summary>
        /// Handles the DragDrop event.
        /// </summary>
        /// <param name="lvevent">The event arguments.</param>
        protected override void OnDragDrop(DragEventArgs lvevent)
        {
            if (!lvevent.Data.GetDataPresent(typeof (DragItemData).ToString()))
            {
                // the item(s) being dragged do not have any data associated
                lvevent.Effect = DragDropEffects.None;
                return;
            }

            base.OnDragDrop(lvevent);
        }

        /// <summary>
        /// Handles the ItemDrag event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            if (!_allowDrag)
            {
                base.OnItemDrag(e);
                return;
            }

            // call the DoDragDrop method
            DoDragDrop(GetDataForDragDrop(), DragDropEffects.Move);

            // call the base OnItemDrag event
            base.OnItemDrag(e);
        }

        /// <summary>
        /// Returns a boolean value indicating whether the provided event arguments contain a valid drag item.
        /// </summary>
        /// <param name="lvevent">The arguments for the Drag event.</param>
        /// <returns>true if valid; otherwise is false.</returns>
        public static bool IsValidDragItem(DragEventArgs lvevent)
        {
            return lvevent.Data.GetDataPresent(typeof (DragItemData).ToString());
        }

        /// <summary>
        /// Handles the DragEnter event.
        /// </summary>
        /// <param name="lvevent">The event arguments.</param>
        protected override void OnDragEnter(DragEventArgs lvevent)
        {
            if (!IsValidDragItem(lvevent))
            {
                // the item(s) being dragged do not have any data associated
                lvevent.Effect = DragDropEffects.None;
                return;
            }

            // everything is fine, allow the user to move the items
            lvevent.Effect = DragDropEffects.Move;

            // call the base OnDragEnter event
            base.OnDragEnter(lvevent);
        }

        /// <summary>
        /// Handles the DragOver event.
        /// </summary>
        /// <param name="lvevent">The event arguments.</param>
        protected override void OnDragOver(DragEventArgs lvevent)
        {
            if (!IsValidDragItem(lvevent))
            {
                // the item(s) being dragged do not have any data associated
                lvevent.Effect = DragDropEffects.None;
                return;
            }

            // everything is fine, allow the user to move the items
            lvevent.Effect = DragDropEffects.Move;

            // call the base OnDragOver event
            base.OnDragOver(lvevent);
        }
    }
}