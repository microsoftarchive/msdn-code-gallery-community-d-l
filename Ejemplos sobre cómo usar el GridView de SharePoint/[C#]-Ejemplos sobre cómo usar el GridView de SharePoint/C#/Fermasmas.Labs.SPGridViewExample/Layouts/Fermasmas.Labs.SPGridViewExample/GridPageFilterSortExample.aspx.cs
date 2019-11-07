using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Fermasmas.Labs.SPGridViewExample.Layouts.Fermasmas.Labs.SPGridViewExample
{
    public partial class GridPageFilterSortExample : LayoutsPageBase
    {
        protected override void OnLoad(EventArgs args)
        {
            _grid.PagerTemplate = null;
        }
    }
}
