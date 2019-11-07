using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using System.Text.RegularExpressions;
using System.Drawing.Imaging;


using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Drawing.Drawing2D;


/// <summary>
/// Author      : Shanu
/// Create date : 2015-12-01
/// Description :Student Register
/// Latest
/// Modifier    : 
/// Modify date : 


namespace DatagridViewCRUD
{
	public partial class Form1 : Form
	{
		#region Attribute
		// ReceptionSystemSrc.Helper.Webcamera.WebCam webcam;
		Boolean keypadOn = false;
		DataGridView Master_shanuDGV = new DataGridView();
		Button btn = new Button();
		Boolean Iscaptuered = false;
		Helper.BizClass bizObj = new Helper.BizClass();
		Helper.ShanuDGVHelper objshanudgvHelper = new Helper.ShanuDGVHelper();
		DataSet ds = new DataSet();
		PrivateFontCollection pfc = new PrivateFontCollection();

		int ival = 0;
		#endregion

		public Form1()
		{
			InitializeComponent();
		}

		

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{			

				MasterGrid_Initialize();
			}
			catch (Exception ex)
			{
			}
		}

		public void MasterGrid_Initialize()
		{

			Helper.ShanuDGVHelper.Layouts(Master_shanuDGV, Color.White, Color.White, Color.White, false, Color.SteelBlue, false, false, false, Color.White, 46, 60, "small");

			//Set Height,width and add panel to your selected control
			Helper.ShanuDGVHelper.Generategrid(Master_shanuDGV, pnlGrid, 1000, 600, 10, 10);

			// Color Image Column creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.imageEditColumn, "Edit", "Edit", "Edit", true, 60, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

			// Color Image Column creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.imageDelteColumn, "Delete", "Delete", "Delete", true, 60, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

			// Color Image Column creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.imageBoundcolumn, "StdImage", "Image", "Image", true, 60, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


			//// BoundColumn creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.BoundColumn, "StdNO", "StdNO", "StdNO", true, 80, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

			//// BoundColumn creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.BoundColumn, "StdName", "StdName", "StdName", true, 180, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


			//// BoundColumn creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.BoundColumn, "Email", "Email", "Email", true, 180, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


			//// BoundColumn creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.BoundColumn, "Phone", "Phone", "Phone", true, 180, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


			//// BoundColumn creation
			Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.BoundColumn, "Address", "Address", "Address", true, 180, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

			//// Color Image Column creation
			//Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.ImageColumn, "StaffID", "", "", true, 40, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);

			//// Color Image Column creation
			//Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.imageEditColumn, "Edit", "", "", true, 38, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);

			//// Color Image Column creation
			//Helper.ShanuDGVHelper.Templatecolumn(Master_shanuDGV, ShanuControlTypes.imageDelteColumn, "Delete", "", "", true, 38, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);


		
			bindData();
			//objshanudgvHelper.MasterDGVs_CellFormatting(Master_shanuDGV, Master_shanuDGV.Columns["IMG"].Index, ShanuEventTypes.cellContentClick, ShanuControlTypes.ImageColumn ds.Tables[0], "IMG");
			Master_shanuDGV.CellFormatting += new DataGridViewCellFormattingEventHandler(MasterDGVs_CellFormatting);


			Master_shanuDGV.SelectionChanged += new EventHandler(Master_shanuDGV_SelectionChanged);

			Master_shanuDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(Master_shanuDGV_CellContentClick);


			// Master_shanuDGV.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
		}
		private void Master_shanuDGV_SelectionChanged(Object sender, EventArgs e)
		{
			Master_shanuDGV.ClearSelection();
		}
		private void bindData()
		{
			try
			{
				// Bind data to DGV.
				SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
				sd.Add("@StudentName", txtName.Text.Trim());

				ds = bizObj.SelectList("USP_Student_Select", sd);
				Master_shanuDGV.DataSource = null;

				if (ds.Tables[0].Rows.Count > 0)
				{
					Master_shanuDGV.DataSource = ds.Tables[0];

				}
			}
			catch (Exception ex)
			{
			}
		}
		// Cell Content Click Event
		private void Master_shanuDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (Master_shanuDGV.Columns[e.ColumnIndex].Name == "Edit")
			{
				try
				{
					string studentID = ds.Tables[0].Rows[e.RowIndex]["StdNO"].ToString();
					frmSudentAdd obj = new frmSudentAdd(studentID);
					obj.ShowDialog();
					bindData();
				}
				catch (Exception ex)
				{
				}

			}
			else if (Master_shanuDGV.Columns[e.ColumnIndex].Name == "Delete")
			{
				try
				{
					string studentID = ds.Tables[0].Rows[e.RowIndex]["StdNO"].ToString();
					if (MessageBox.Show("Are You Sure to Delete Student Details ?", "Delete Student", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{

						SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
						
						sd.Add("@std_ID", studentID);

						DataSet ds1 = new DataSet();

						ds1 = bizObj.SelectList("USP_Student_Delete", sd);

						if (ds1.Tables[0].Rows.Count > 0)
						{
							string result = ds1.Tables[0].Rows[0][0].ToString();

							if (result == "Deleted")
							{
								MessageBox.Show("Student Deleted Successful, Thank You!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
								bindData();
							}
						}
					}
				}
				catch (Exception ex)
				{
				}

			}
		}
		#region Image Colukmn
		
		public static Image MakeCircleImage(Image img)
		{
			Bitmap bmp = new Bitmap(img.Width, img.Height);
			using (GraphicsPath gpImg = new GraphicsPath())
			{

				gpImg.AddEllipse(0, 0, img.Width, img.Height);
				using (Graphics grp = Graphics.FromImage(bmp))
				{
					grp.Clear(Color.White);
					grp.SetClip(gpImg);
					grp.DrawImage(img, Point.Empty);
				}
			}
			return bmp;
		}
		void MasterDGVs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				if (Master_shanuDGV.Columns[e.ColumnIndex].Name == "StdImage")
				{
					if (ds.Tables[0].Rows[e.RowIndex]["StdImage"] != "" && ds.Tables[0].Rows[e.RowIndex]["StdImage"] != DBNull.Value)
					{
						byte[] bits = new byte[0];
						bits = (byte[])ds.Tables[0].Rows[e.RowIndex]["StdImage"];
						MemoryStream ms = new MemoryStream(bits);
						System.Drawing.Image imgSave = System.Drawing.Image.FromStream(ms);
						e.Value = MakeCircleImage(imgSave);
						
					}
					else
					{
						System.Drawing.Image imgSave = (Image)DatagridViewCRUD.Properties.Resources.gridUserImage;
						e.Value = MakeCircleImage(imgSave); 
					}
				}


			}
			catch (Exception ex)
			{
			}
		}
		public Image byteArrayToImage(byte[] byteArrayIn)
		{
			using (MemoryStream mStream = new MemoryStream(byteArrayIn))
			{
				return Image.FromStream(mStream);
			}
		}

		#endregion
		private void btnSearch_Click(object sender, EventArgs e)
		{
			bindData();
		}

		private void btnStaffAdd_Click(object sender, EventArgs e)
		{
			frmSudentAdd obj = new frmSudentAdd("0");
			obj.ShowDialog();
			bindData();
		}
	}
}
