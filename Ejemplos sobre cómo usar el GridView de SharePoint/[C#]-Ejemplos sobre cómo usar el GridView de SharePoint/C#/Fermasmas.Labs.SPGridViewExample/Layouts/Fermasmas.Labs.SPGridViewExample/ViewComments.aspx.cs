using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace Fermasmas.Labs.SPGridViewExample.Layouts.Fermasmas.Labs.SPGridViewExample
{
    public partial class ViewComments : LayoutsPageBase
    {
        public ViewComments()
        {
        }

        public string Name
        {
            get { return SPEncode.HtmlDecode(Request.QueryString["Name"] ?? "[N/A]"); }
        }

        public string Comments
        {
            get { return SPEncode.HtmlDecode(Request.QueryString["Comments"] ?? "[Sin comentarios.]"); }
        }
    }
}
