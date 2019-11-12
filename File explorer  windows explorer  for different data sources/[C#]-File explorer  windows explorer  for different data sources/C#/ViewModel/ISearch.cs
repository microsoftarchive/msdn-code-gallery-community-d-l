using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileExplorer.ViewModel
{
    interface ISearch
    {
        string SearchKeyword { get; }
        bool IsSearchEnabled { get; }
        string NotFoundHint { get; }

        void Search(string keyword);
        void Cancel();
    }
}
