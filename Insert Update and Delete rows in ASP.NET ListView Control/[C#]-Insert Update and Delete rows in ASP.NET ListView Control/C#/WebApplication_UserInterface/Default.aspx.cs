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


            ListView1.DataSource = _dsBind.Tables[0].DefaultView;
            ListView1.DataBind();

        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                getRowCount = _ObjBusiness.AddDetails(txtProductId.Text, txtProductName.Text, txtProductLoc.Text, txtProductQty.Text, txtProductPrice.Text);
                if (getRowCount > 0)
                {
                    lblmsg.Text = "Successfully Addded!...";
                }
                else
                {
                    lblmsg.Text = "Add Row Operation failed!...";
                }
                BindData();
                txtProductId.Text = "";
                txtProductName.Text = "";
                txtProductLoc.Text = "";
                txtProductQty.Text = "";
                txtProductPrice.Text = "";
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            } 
        }



        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
          
            lvDataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);           
            BindData();
        }              

        protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Label lblPrdId = ((Label)ListView1.Items[e.ItemIndex].FindControl("lblPkId"));
            TextBox txtPrdId = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("txtpdtId"));
            TextBox txtPrdName = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("txtPdtName"));
            TextBox txtPrdLoc = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("txtPdtLoc"));
            TextBox txtPrdQty = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("txtPdtQty"));
            TextBox txtPrdPrice = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("txtPDtPrce"));

            getRowCount = _ObjBusiness.UpdateDetails(Convert.ToInt32(lblPrdId.Text), txtPrdId.Text, txtPrdName.Text, txtPrdLoc.Text, txtPrdQty.Text, txtPrdPrice.Text);
            if (getRowCount > 0)
            {
                ListView1.EditIndex = -1;
                BindData();
                lblmsg.Text = "Successfully Updated!...";
            }

            else
            {
                ListView1.EditIndex = -1;
                BindData();
                lblmsg.Text = "Update Operation failed!...";
            }
            lblmsg.Text = "Successfully Updated!...";
        }

        protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
            BindData();
        }
              

        protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                Label lblPrdId = ((Label)ListView1.Items[e.ItemIndex].FindControl("lblDelPkId"));
                getRowCount = _ObjBusiness.DeleteDetails( Convert.ToInt32(lblPrdId.Text));
                if (getRowCount > 0)
                {
                    BindData();
                    lblmsg.Text = "Successfully Deleted!...";
                }
                else
                {
                    lblmsg.Text = "Delete Operation failed!...";
                }
           }
                     
            catch (Exception)
            {
                
                throw;
            }

            

        }

       
       
    }
}
