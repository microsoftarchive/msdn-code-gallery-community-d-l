/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System;
using System.Web.UI.WebControls;
using Eisk.BusinessLogicLayer;
using System.Collections.Generic;
using System.Threading;
using Eisk.Helpers;

public partial class Listing_Page : System.Web.UI.Page
{
   protected void ButtonDeleteSelected_Click(object sender, System.EventArgs e)
    {
        try
        {
            // Create a List to hold the EmployeeID values to delete
            List<Int32> employeeIDsToDelete = new List<Int32>();

            // Iterate through the Employees.Rows property
            foreach (GridViewRow row in gridViewEmployees.Rows)
            {

                // Access the CheckBox
                CheckBox cb = (CheckBox)(row.FindControl("chkEmployeeSelector"));
                if (cb != null && cb.Checked)
                {
                    // Save the EmployeeID value for deletion
                    // First, get the EmployeeID for the selected row
                    Int32 employeeId = (Int32)gridViewEmployees.DataKeys[row.RowIndex].Value;

                    // Add it to the List...
                    employeeIDsToDelete.Add(employeeId);

                    // Add a confirmation message
                    ltlMessage.Text += String.Format(MessageFormatter.GetFormattedSuccessMessage("Delete successful. EmployeeId {0} has been deleted"), employeeId);

                }
            }

            //perform the actual delete
            new EmployeeBLL().DeleteEmployees(employeeIDsToDelete);
        }
        catch (Exception ex)
        {
            ltlMessage.Text = ExceptionManager.DoLogAndGetFriendlyMessageForException(ex);
        }

        //re-binding the dropdown
        dropDownListEmployee.Items.Clear();
        dropDownListEmployee.DataBind();
        dropDownListEmployee.Items.Insert(0, new ListItem("No Supervisor", ""));
        dropDownListEmployee.Items.Insert(0, new ListItem("Select Supervisor", "0"));
        
        //binding the grid
        gridViewEmployees.PageIndex = 0;
        gridViewEmployees.DataBind();
       
    }

   protected void ButtonAddNewEmployee_Click(object sender, System.EventArgs e)
   {
       Response.RedirectToRoute("employee-details", new { edit_mode = "new", employee_id = 0 });
   }
}
