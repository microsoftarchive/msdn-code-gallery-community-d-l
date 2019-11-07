using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shanuDatagridViewCellpainting.Helper.Biz;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

/// <summary>
/// Author      : Shanu
/// Create date : 2015-09-09
/// Description :DatagridView Cell painting 
/// Latest
/// Modifier    : 
/// Modify date : 


namespace shanuDatagridViewCellpainting
{
	public partial class shanuDatagridViewPaint : Form
	{
		#region Attribute
		DataGridView Master_shanuDGV = new DataGridView();
		DataSet ds = new DataSet();
		String ProjectType = "1"; 
		#endregion
		#region Form Load
		public shanuDatagridViewPaint()
		{
			InitializeComponent();
		}
		private void shanuDatagridViewPaint_Load(object sender, EventArgs e)
		{

			MasterGrid_Initialize();
			bindData();
		}
		#endregion


		#region Functions
		// to generate Master Datagridview with your coding
		public void MasterGrid_Initialize()
		{

			//First generate the grid Layout Design
			Helper.ShanuDGVHelper.Layouts(Master_shanuDGV, Color.White, Color.WhiteSmoke, Color.WhiteSmoke, false, Color.WhiteSmoke, true, Color.FromArgb(112, 128, 144), false, false, false, Color.White, 40, 20, "small");

			//Set Height,width and add panel to your selected control
			Helper.ShanuDGVHelper.Generategrid(Master_shanuDGV, pnlGrid, 1000, 600, 10, 10);

			Master_shanuDGV.CellFormatting += new DataGridViewCellFormattingEventHandler(MasterDGVs_CellFormatting);
		
		}

	

	
	
		
		void MasterDGVs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				
					ProjectType = ds.Tables[0].Rows[e.RowIndex]["PrpjectType"].ToString(); //e.Value.ToString();
              

				if (e.ColumnIndex > 2)
				{
					Color color1= Color.FromArgb(116, 176, 30);//Green
					Color color2 = Color.FromArgb(0, 76, 153); //Blue

					if (e.Value.ToString() == "0")
					{
						e.Value = "";
					}
					if(ProjectType=="1")
					{
						color1 = Color.FromArgb(116, 176, 30);//Green
						color2 = Color.FromArgb(0, 76, 153); //Blue
					}
					else if (ProjectType == "2")
					{
						color1 = Color.FromArgb(218, 165, 32);//golden rod
						color2 = Color.FromArgb(255, 215, 0); //GOLD 
					}
					else if (ProjectType == "3")
					{
						color1 = Color.FromArgb(147, 112, 219);//medium purple
						color2 = Color.FromArgb(255, 105, 180); //hot pink
					}


					switch (e.Value.ToString())
					{
						case "-1":
							e.CellStyle.BackColor = Color.FromArgb(255, 69, 0);  // Orange
							e.CellStyle.SelectionBackColor = Color.FromArgb(255, 69, 0); // Orange
							e.CellStyle.ForeColor = Color.White;
							e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
							e.Value = "END";
							break;

						case "2":
							e.CellStyle.BackColor = color1;
                            e.CellStyle.SelectionBackColor = color1;

							e.Value = "";
							break;
						case "1":
							e.CellStyle.BackColor = color2;
                            e.CellStyle.SelectionBackColor = color2;
                            e.Value = "";
							break;

					}
					

				}
			}
			catch (Exception ex)
			{ }
		}

	
		private void bindData()
		{
			try
			{
				// Bind data to DGV.
				SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
				sd.Add("@projectId", txtProjectID.Text.Trim());

				
				ds = new ShanuProjectScheduleBizClass().SelectList(sd);
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


		#endregion

		#region Events

		#endregion

		private void btnSearch_Click(object sender, EventArgs e)
		{
			bindData();
		}

		
	}
}
