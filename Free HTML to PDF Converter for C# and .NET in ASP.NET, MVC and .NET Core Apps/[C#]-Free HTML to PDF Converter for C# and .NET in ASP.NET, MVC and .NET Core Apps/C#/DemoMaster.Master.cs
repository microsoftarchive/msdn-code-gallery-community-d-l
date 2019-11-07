using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HiQPdf_Demo
{
    public partial class DemoMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SelectNode(string nodeValue)
        {
            SelectNodeInCollection(treeView.Nodes, nodeValue);
        }

        private bool SelectNodeInCollection(TreeNodeCollection nodes, string nodeValue)
        {
            if (nodes == null)
                return false;

            if (nodes.Count == 0)
                return false;

            foreach (TreeNode tn in nodes)
            {
                if (tn.Value == nodeValue)
                {
                    tn.Selected = true;
                    return true;
                }
                else if (SelectNodeInCollection(tn.ChildNodes, nodeValue))
                    return true; // a node was selected lower in hierarchy
            }

            return false;
        }
    }
}
