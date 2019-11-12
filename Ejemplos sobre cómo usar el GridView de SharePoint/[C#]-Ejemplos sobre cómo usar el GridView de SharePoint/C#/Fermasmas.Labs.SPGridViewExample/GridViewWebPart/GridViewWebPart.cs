using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace Fermasmas.Labs.SPGridViewExample.GridViewWebPart
{
    [ToolboxItemAttribute(false)]
    public class GridViewWebPart : WebPart
    {
        private SPGridView _gridView;
        private SPList _list;

        public GridViewWebPart()
            : base()
        {
            _gridView = null;
            _list = null;
        }

        public SPList List
        {
            get
            {
                if (_list == null)
                    _list = SPContext.Current.Web.Lists["Asgard List"];

                return _list;
            }
        }

        private DataTable GetSource()
        {
            DataTable table = List.Items.GetDataTable();

            return table;
        }

        protected override void CreateChildControls()
        {
            Controls.Add(new Literal { Text = "<br/><h3>Asgard Pantheon</h3>" });

            DataTable table = GetSource();
            table.DefaultView.Sort = "Gender";

            _gridView = new SPGridView();
            _gridView.ID = "_gridView";
            _gridView.AutoGenerateColumns = false;
            _gridView.Width = new Unit(100, UnitType.Pixel);
            _gridView.DataSource = table.DefaultView;
            _gridView.AllowGrouping = true;

            // le quitamos el view state
            _gridView.EnableViewState = false;
            // agrupamos por el campo "Gender" del DataSource
            _gridView.GroupField = "Gender";
            // un nombre bonito para el campo
            _gridView.GroupFieldDisplayName = "Gender";
            // permitimos que los grupos generados colapsen
            _gridView.AllowGroupCollapse = true;
            // adicionalmente, podemos añadir algún campo descriptivo o una imagen
            // _gridView.GroupDescriptionField = "Mi Campo Descriptivo";
            // _gridView.GroupImageUrlField = "Mi campo con imagen";

            _gridView.Columns.Add(new CommandField {
                ButtonType = ButtonType.Image,
                ShowSelectButton = true,
                SelectImageUrl = string.Format("{0}/asgard/_layouts/images/arrowright_light.gif", SPContext.Current.Web.Url)
            }); 
            _gridView.Columns.Add(new SPBoundField { DataField = "Name", HeaderText = "Nombre" });
            _gridView.Columns.Add(new SPBoundField { DataField = "Influence", HeaderText = "Influencia" });
            _gridView.Columns.Add(new SPBoundField { DataField = "Comments", HeaderText = "Comentarios" });
            _gridView.DataBind();

            Controls.Add(_gridView);
            Controls.Add(new Literal { Text = "<hr/>" });
        }
    }
}
