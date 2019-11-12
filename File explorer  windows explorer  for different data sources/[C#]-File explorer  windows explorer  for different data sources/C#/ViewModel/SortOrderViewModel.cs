using FileExplorer.Helper;
using System.ComponentModel;

namespace FileExplorer.ViewModel
{
    public abstract class SortOrderViewModel : ViewModelBase, ISortOrder
    {
        ICollectionView contentView;
        public ICollectionView ContentView
        {
            get { return contentView; }
            protected set
            {
                SetProperty(ref contentView, value, "ContentView");
            }
        }

        #region Sort order

        private SortOrderCallback sortOrderCallback = null;

        public void SetSortOrderCallback(SortOrderCallback callback)
        {
            if (callback.IsNull())
            {
                return;
            }
            sortOrderCallback = callback;
        }

        protected void InvokeSortOrderCallback(bool isRefresh = true)
        {
            if (!sortOrderCallback.IsNull())
            {
                sortOrderCallback(isRefresh);
            }
        }

        public const string SortPropertyName = "Name";
        public const string SortPropertyIsFolder = "IsFolder";
        public const string SortPropertyIsFile = "IsFile";

        public void SetSortOrder(string propName, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            if (propName.IsNullOrEmpty() || this.ContentView.IsNull())
            {
                return;
            }

            this.ClearSortOptions();

            if (sortDirection == ListSortDirection.Ascending)
            {
                this.ContentView.SortDescriptions.Add(new SortDescription(SortPropertyIsFolder, ListSortDirection.Descending));
                this.ContentView.SortDescriptions.Add(new SortDescription(propName, sortDirection));
            }
            else
            {
                this.ContentView.SortDescriptions.Add(new SortDescription(SortPropertyIsFile, ListSortDirection.Descending));
                this.ContentView.SortDescriptions.Add(new SortDescription(propName, sortDirection));
            }
        }

        protected void ClearSortOptions()
        {
            if (!this.ContentView.IsNull())
            {
                this.ContentView.SortDescriptions.Clear();
            }
        }

        #endregion

        protected override void OnDisposing(bool isDisposing)
        {
            this.sortOrderCallback = null;
            this.ClearSortOptions();
            base.OnDisposing(isDisposing);
        }
    }
}
