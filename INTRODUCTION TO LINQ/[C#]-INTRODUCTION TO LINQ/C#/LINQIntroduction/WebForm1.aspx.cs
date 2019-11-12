using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQIntroduction
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SampleDataContext dataContext = new SampleDataContext();
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //gvData.DataSource = from student in dataContext.Students
            //                    where student.Gender =="Male"
            //                    select student;
            gvData.DataSource = from number in numbers
                                where (number % 2) == 0
                                select number;
            gvData.DataBind();
        }
    }
}