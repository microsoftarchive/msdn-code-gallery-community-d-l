using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;

namespace Fermasmas.Labs.SPGridViewExample.Model
{
    public class AsgardSource
    {
        private SPWeb _web;
        private SPList _list;

        public AsgardSource()
        {
            _web = SPContext.Current.Web;
            _list = _web.Lists["Asgard List"];
        }

        public AsgardSource(SPWeb web)
        {
            if (web == null)
                throw new ArgumentNullException("web");

            _web = web;
            _list = _web.Lists["Asgard List"];
        }

        public SPList List
        {
            get { return _list; }
        }

        public DataView SelectAll()
        {
            DataTable table = List.Items.GetDataTable();
            table.DefaultView.Sort = "Gender";

            return table.DefaultView;
        }

        public DataTable SelectAdvanced(int maximumRows, int startRowIndex)
        {
            DataTable table = List.Items.GetDataTable();

            DataTable filteredTable;
            if (maximumRows > 0)
                filteredTable = table.Rows.OfType<DataRow>().Skip(startRowIndex).Take(maximumRows).CopyToDataTable();
            else
                filteredTable = table;

            return filteredTable;
        }

        public int CountSelectAdvanced()
        {
            return SelectAll().Count;
        }

        public void UpdateItem(int id, string name, string influence, string gender, string comments)
        {
            bool allowUpdates = List.ParentWeb.AllowUnsafeUpdates;
            List.ParentWeb.AllowUnsafeUpdates = true;

            SPListItem item = List.GetItemById(id);
            item["Name"] = name;
            item["Influence"] = influence;
            item["Gender"] = gender;
            item["Comments"] = comments;
            item.Update();
        }
    }
}
