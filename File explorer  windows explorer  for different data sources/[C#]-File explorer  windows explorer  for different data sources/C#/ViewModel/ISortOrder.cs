using FileExplorer.Model;
using System.ComponentModel;

namespace FileExplorer.ViewModel
{
    public delegate void SortOrderCallback(bool isRefresh);

    public interface ISortOrder
    {
        void SetSortOrderCallback(SortOrderCallback callback);
        void SetSortOrder(string propName, ListSortDirection sortDirection);
    }
}
