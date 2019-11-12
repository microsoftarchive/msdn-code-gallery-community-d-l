using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 
using Tools;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = this.GetVisitor();  
        }
    }
    private string GetVisitor()
    {
        
        string strIPAddress = string.Empty;
        string strVisitorCountry = string.Empty;

        strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (strIPAddress == "" || strIPAddress == null)
            strIPAddress = Request.ServerVariables["REMOTE_ADDR"];

        Tools.GetLocation.IVisitorsGeographicalLocation _objLocation;
        _objLocation = new Tools.GetLocation.ClsVisitorsGeographicalLocation();

        DataTable _objDataTable = _objLocation.GetLocation(strIPAddress);

        if (_objDataTable != null)
        {

            if (_objDataTable.Rows.Count > 0)
            {
                strVisitorCountry = 
                            "IP: "
                            + strIPAddress
                            + ", TIMESTAMP: " 
                            + Convert.ToString(System.DateTime.Now)     
                            + ", CITY: "
                            + Convert.ToString(_objDataTable.Rows[0]["City"]).ToUpper()
                            + ", COUNTRY: "
                            + Convert.ToString(_objDataTable.Rows[0]["CountryName"]).ToUpper()
                            + ", COUNTRY CODE: "
                            + Convert.ToString(_objDataTable.Rows[0]["CountryCode"]).ToUpper();
            }

            else
            {
                strVisitorCountry = null;

            }

        }
        return strVisitorCountry;
    }


}
