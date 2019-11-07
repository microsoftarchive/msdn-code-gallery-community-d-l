using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

namespace WebApplication_UserInterface
{
    public partial class _Default : System.Web.UI.Page
    {
        #region "Object Initialization"
        businessProductDetails _ObjBusiness = new businessProductDetails();
        #endregion

        #region "Variable Declaration"
        DataSet _dsBind = null;
        int getRowCount = 0;
        string strPk_id = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                lblmsg.Text = "";
            }
         

        }

        #region "Bind Grid Details"
        public void BindData()
        {
            _dsBind = new DataSet();
            _dsBind = _ObjBusiness.GetBindDetails();
            GridView1.DataSource = _dsBind;
            GridView1.DataBind();

        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            getRowCount = _ObjBusiness.AddDetails(txtProductId.Text, txtProductName.Text, txtProductPrice.Text);
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = false;
            BindData();
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtProductPrice.Text = "";

            lblmsg.Text = "Successfully Addded!...";
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           

            GridViewRow _row = GridView1.Rows[e.RowIndex];
            TextBox txtProdId = (TextBox)_row.FindControl("txtProductId");
            TextBox txtProdName = (TextBox)_row.FindControl("txtProductName");
            TextBox txtProdPrice = (TextBox)_row.FindControl("txtProductPrice");
            Label lblPk_id = (Label)_row.FindControl("lblPk_id");

            getRowCount = _ObjBusiness.UpdateDetails(lblPk_id.Text, txtProdId.Text, txtProdName.Text, txtProdPrice.Text);
            GridView1.EditIndex = -1;
            BindData();
            lblmsg.Text = "Successfully Updated!...";
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
            lblmsg.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow _row = GridView1.Rows[e.RowIndex];
            Label lblPk_id = (Label)_row.FindControl("lblPk_id");

            getRowCount = _ObjBusiness.DeleteDetails(lblPk_id.Text);
            GridView1.EditIndex = -1;
            BindData();
            lblmsg.Text = "Successfully Deleted!...";
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
            lblmsg.Text = "";

        }
       
    }
}
