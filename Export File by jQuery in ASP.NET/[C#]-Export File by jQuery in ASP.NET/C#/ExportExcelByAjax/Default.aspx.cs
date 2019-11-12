using ExportExcelByAjax.ObjectData;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExportExcelByAjax
{
	public partial class Default : System.Web.UI.Page
	{
		private List<Person> GetPersons()
		{
			List<Person> persons = new List<Person>();
			for (int i = 0; i < 1000; i++)
			{
				persons.Add(new Person
				{
					FirstName = "Kevin" + (i + 1),
					LastName = "Ly",
					Birthday = new DateTime(1989, 9, 9),
					BirthPlace = "Ho Chi Minh city"
				});
			}
			return persons;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				grdView.DataSource = GetPersons();
				grdView.DataBind();
			}
			if (Request.QueryString["IsExportExcel"] != null)
			{
				bool isExportExcel;
				if (bool.TryParse(Request.QueryString["IsExportExcel"], out isExportExcel))
				{
					if (isExportExcel)
					{
						Thread.Sleep(10000);
						var workbook = new HSSFWorkbook();
						var sheet = workbook.CreateSheet("Persons");

						// Add header labels
						var rowIndex = 0;
						var row = sheet.CreateRow(rowIndex);
						row.CreateCell(0).SetCellValue("First Name");
						row.CreateCell(1).SetCellValue("Last Name");
						row.CreateCell(2).SetCellValue("Birthday");
						row.CreateCell(3).SetCellValue("BirthPlace");
						rowIndex++;

						// Add data rows
						foreach (var person in GetPersons())
						{
							row = sheet.CreateRow(rowIndex);
							row.CreateCell(0).SetCellValue(person.FirstName);
							row.CreateCell(1).SetCellValue(person.LastName);
							row.CreateCell(2).SetCellValue(person.Birthday.ToString("MM/dd/yyyy"));
							row.CreateCell(3).SetCellValue(person.BirthPlace);
							rowIndex++;
						}

						// Save the Excel spreadsheet to a MemoryStream and return it to the client
						using (var exportData = new MemoryStream())
						{
							Response.Cookies.Add(new HttpCookie("Downloaded", "True"));
							workbook.Write(exportData);
							string saveAsFileName = string.Format("PersonExport-{0:d}.xls", DateTime.Now).Replace("/", "-");
							Response.ContentType = "application/vnd.ms-excel";
							Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
							Response.Clear();
							Response.BinaryWrite(exportData.GetBuffer());
							Response.End();
						}
					}
				}
			}
		}

		protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			grdView.PageIndex = e.NewPageIndex;
			grdView.DataSource = GetPersons();
			grdView.DataBind();
		}
	}
}