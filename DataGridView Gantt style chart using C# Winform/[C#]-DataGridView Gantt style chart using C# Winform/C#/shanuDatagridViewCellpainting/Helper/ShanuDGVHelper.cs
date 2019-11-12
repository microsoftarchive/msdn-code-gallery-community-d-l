using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

/// <summary>
/// Author      : Shanu
/// Create date : 2014-11-11
/// Description : ShanuDGVHelper
/// Latest
/// Modifier    : Shanu
/// Modify date : 2014-11-11
/// </summary>

namespace shanuDatagridViewCellpainting.Helper
{
	class ShanuDGVHelper
	{
	 #region Variables
        public DataGridView MasterDGVs = new DataGridView();
        public DataGridView DetailDGVs = new DataGridView();
        List<int> listcolumnIndex;
        static String ImageName = "toggle.png";
        String FilterColumnName = "";
        DataTable DetailgridDT;
        int gridColumnIndex = 0;
       

        DateTimePicker shanuDateTimePicker = new DateTimePicker();
        DataGridView shanuNestedDGV = new DataGridView();
        String EventFucntions;
		#endregion

		//Set all the telerik Grid layout
		#region Layout

		public static void Layouts(DataGridView ShanuDGV, Color BackgroundColor, Color RowsBackColor, Color RowSelectionBackColor, Boolean rowSelection, Color AlternatebackColor, Boolean AutoGenerateColumns, Color HeaderColor, Boolean HeaderVisual, Boolean RowHeadersVisible, Boolean AllowUserToAddRows, Color HeaderForeColor, int headerHeight, int rowheight, string fontBig)
		{
			//Grid Back ground Color
			ShanuDGV.BackgroundColor = BackgroundColor;

			//Grid Back Color
			ShanuDGV.RowsDefaultCellStyle.BackColor = RowsBackColor;

			//GridColumnStylesCollection Alternate Rows Backcolr
			ShanuDGV.AlternatingRowsDefaultCellStyle.BackColor = AlternatebackColor;

			// Auto generated here set to tru or false.
			ShanuDGV.AutoGenerateColumns = AutoGenerateColumns;
			//  ShanuDGV.DefaultCellStyle.Font = new Font("Verdana", 10.25f, FontStyle.Regular);
			// ShanuDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

			//Column Header back Color
			ShanuDGV.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;
			ShanuDGV.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
			ShanuDGV.ColumnHeadersHeight = headerHeight;
			if (fontBig == "big")
			{
				ShanuDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			}
			else
			{
				ShanuDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			}


			//header Visisble
			ShanuDGV.EnableHeadersVisualStyles = HeaderVisual;

			// Enable the row header
			ShanuDGV.RowHeadersVisible = RowHeadersVisible;
			ShanuDGV.RowTemplate.Height = rowheight;
			if (fontBig == "big")
			{
				ShanuDGV.DefaultCellStyle.Font = new Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			}
			else
			{
				ShanuDGV.DefaultCellStyle.Font = new Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			}

			//ShanuDGV.DefaultCellStyle.SelectionBackColor = Color.Transparent;
			//ShanuDGV.DefaultCellStyle.SelectionForeColor = Color.LightBlue;
			//ShanuDGV.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
			// to Hide the Last Empty row here we use false.
			
			ShanuDGV.AllowUserToAddRows = AllowUserToAddRows;
			if (rowSelection == true)
			{
				ShanuDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;			
            }
			ShanuDGV.DefaultCellStyle.SelectionBackColor = RowSelectionBackColor;
			////Padding newPadding = new Padding(0, 1, 0, 1);
			////ShanuDGV.RowTemplate.DefaultCellStyle.Padding = newPadding;

			////// Set the selection background color to transparent so  
			////// the cell won't paint over the custom selection background. 
			////ShanuDGV.RowTemplate.DefaultCellStyle.SelectionBackColor =
			////    Color.Transparent;

			ShanuDGV.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //to Disbale the Column and Row 
            ShanuDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            ShanuDGV.AllowUserToResizeRows = false;
            ShanuDGV.AllowUserToResizeColumns = true;
            ShanuDGV.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			ShanuDGV.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
		}
        #endregion

        //Add your grid to your selected Control and set height,width,position of your grid.
        #region Variables
        public static void Generategrid(DataGridView ShanuDGV, Control cntrlName, int width, int height, int xval, int yval)
        {
            ShanuDGV.Location = new Point(xval, yval);
            ShanuDGV.Size = new Size(width, height);
            ShanuDGV.Dock = DockStyle.Fill;
            ShanuDGV.BorderStyle = BorderStyle.Fixed3D;
            cntrlName.Controls.Add(ShanuDGV);
        }
        #endregion

        //Template Column In this column we can add Textbox,Lable,Check Box,Dropdown box and etc
        #region Templatecolumn
        public static void Templatecolumn(DataGridView ShanuDGV, ShanuControlTypes ShanuControlTypes, String cntrlnames, String Headertext, String ToolTipText, Boolean Visible, int width, DataGridViewTriState Resizable, DataGridViewContentAlignment cellAlignment, DataGridViewContentAlignment headerAlignment, Color CellTemplateBackColor, DataTable dtsource, String DisplayMember, String ValueMember, Color CellTemplateforeColor)
        {
            switch (ShanuControlTypes)
            {
                case ShanuControlTypes.CheckBox:
                    DataGridViewCheckBoxColumn dgvChk = new DataGridViewCheckBoxColumn();
                    dgvChk.ValueType = typeof(bool);
                    dgvChk.Name = cntrlnames;
					                    dgvChk.HeaderText = Headertext;
                    dgvChk.ToolTipText = ToolTipText;
                    dgvChk.Visible = Visible;
                    dgvChk.Width = width;
                    dgvChk.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvChk.Resizable = Resizable;
                    dgvChk.DefaultCellStyle.Alignment = cellAlignment;
                    dgvChk.HeaderCell.Style.Alignment = headerAlignment;
                    if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    {
                        dgvChk.CellTemplate.Style.BackColor = CellTemplateBackColor;
                    }
                    dgvChk.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    ShanuDGV.Columns.Add(dgvChk);
                    break;
                case ShanuControlTypes.BoundColumn:
                    DataGridViewColumn dgvbound = new DataGridViewTextBoxColumn();
                    dgvbound.DataPropertyName = cntrlnames;
                    dgvbound.Name = cntrlnames;
                    dgvbound.HeaderText = Headertext;
                    dgvbound.ToolTipText = ToolTipText;
                    dgvbound.Visible = Visible;
                    dgvbound.Width = width;
                    dgvbound.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvbound.Resizable = Resizable;
                    dgvbound.DefaultCellStyle.Alignment = cellAlignment;
                    dgvbound.HeaderCell.Style.Alignment = headerAlignment;
                    dgvbound.ReadOnly = true;
                    if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    {
                        dgvbound.CellTemplate.Style.BackColor = CellTemplateBackColor;
                    }
                    dgvbound.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    ShanuDGV.Columns.Add(dgvbound);
                    break;
                case ShanuControlTypes.TextBox:
                    DataGridViewTextBoxColumn dgvText = new DataGridViewTextBoxColumn();
                    dgvText.ValueType = typeof(decimal);
                    dgvText.DataPropertyName = cntrlnames;
                    dgvText.Name = cntrlnames;
                    dgvText.HeaderText = Headertext;
                    dgvText.ToolTipText = ToolTipText;
                    dgvText.Visible = Visible;
                    dgvText.Width = width;
                    dgvText.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvText.Resizable = Resizable;
                    dgvText.DefaultCellStyle.Alignment = cellAlignment;
                    dgvText.HeaderCell.Style.Alignment = headerAlignment;
                    if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    {
                        dgvText.CellTemplate.Style.BackColor = CellTemplateBackColor;
                    }
                    dgvText.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    ShanuDGV.Columns.Add(dgvText);
                    break;
                case ShanuControlTypes.ComboBox:
                    DataGridViewComboBoxColumn dgvcombo = new DataGridViewComboBoxColumn();
                    dgvcombo.ValueType = typeof(decimal);
                    dgvcombo.Name = cntrlnames;
                    dgvcombo.DataSource = dtsource;
                    dgvcombo.DisplayMember = DisplayMember;
                    dgvcombo.ValueMember = ValueMember;
                    dgvcombo.Visible = Visible;
                    dgvcombo.Width = width;
                    dgvcombo.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvcombo.Resizable = Resizable;
                    dgvcombo.DefaultCellStyle.Alignment = cellAlignment;
                    dgvcombo.HeaderCell.Style.Alignment = headerAlignment;
                    if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    {
                        dgvcombo.CellTemplate.Style.BackColor = CellTemplateBackColor;

                    }
                    dgvcombo.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    ShanuDGV.Columns.Add(dgvcombo);
                    break;

                case ShanuControlTypes.Button:
                    DataGridViewButtonColumn dgvButtons = new DataGridViewButtonColumn();
                    dgvButtons.Name = cntrlnames;
                    dgvButtons.FlatStyle = FlatStyle.Popup;
                    dgvButtons.DataPropertyName = cntrlnames;
                    dgvButtons.Visible = Visible;
                    dgvButtons.Width = width;
                    dgvButtons.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvButtons.Resizable = Resizable;
                    dgvButtons.DefaultCellStyle.Alignment = cellAlignment;
                    dgvButtons.HeaderCell.Style.Alignment = headerAlignment;
                    if (CellTemplateBackColor.Name.ToString() != "Transparent")
                    {
                        dgvButtons.CellTemplate.Style.BackColor = CellTemplateBackColor;
                    }
                    dgvButtons.DefaultCellStyle.ForeColor = CellTemplateforeColor;
                    ShanuDGV.Columns.Add(dgvButtons);
                    break;
                case ShanuControlTypes.ImageColumn:
                    DataGridViewImageColumn dgvnestedBtn = new DataGridViewImageColumn();
                    dgvnestedBtn.Name = cntrlnames;
                 
                  
                    dgvnestedBtn.Image = global::shanuDatagridViewCellpainting.Properties.Resources.detailClickImg;
                    // dgvnestedBtn.DataPropertyName = cntrlnames;
                    dgvnestedBtn.Visible = Visible;
                    dgvnestedBtn.Width = width;
                    dgvnestedBtn.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvnestedBtn.Resizable = Resizable;
                    dgvnestedBtn.DefaultCellStyle.Alignment = cellAlignment;
                    dgvnestedBtn.HeaderCell.Style.Alignment = headerAlignment;
                    dgvnestedBtn.HeaderText = Headertext;
                    ShanuDGV.Columns.Add(dgvnestedBtn);
                    break;
                case ShanuControlTypes.imageBoundcolumn:
                    DataGridViewImageColumn dgvnestedBtn1 = new DataGridViewImageColumn();
                    dgvnestedBtn1.Name = cntrlnames;

                    dgvnestedBtn1.DefaultCellStyle.BackColor = Color.White;
                 
                    dgvnestedBtn1.Image = global::shanuDatagridViewCellpainting.Properties.Resources.images;
                    // dgvnestedBtn.DataPropertyName = cntrlnames;
                    dgvnestedBtn1.Visible = Visible;
                    dgvnestedBtn1.Width = width;
                   
                    dgvnestedBtn1.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dgvnestedBtn1.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvnestedBtn1.HeaderText = Headertext;
                    dgvnestedBtn1.Resizable = Resizable;
                    dgvnestedBtn1.DefaultCellStyle.Alignment = cellAlignment;
                    dgvnestedBtn1.HeaderCell.Style.Alignment = headerAlignment;
                    dgvnestedBtn1.DefaultCellStyle.BackColor = Color.White;
                    dgvnestedBtn1.DefaultCellStyle.Padding = new Padding(4);

                    ShanuDGV.Columns.Add(dgvnestedBtn1);
                    break;
                case ShanuControlTypes.imageEditColumn:
                    DataGridViewImageColumn dgvnestedBtn2 = new DataGridViewImageColumn();
                    dgvnestedBtn2.Name = cntrlnames;


                    dgvnestedBtn2.Image = global::shanuDatagridViewCellpainting.Properties.Resources.E_icon_edit;
                    
                    // dgvnestedBtn.DataPropertyName = cntrlnames;
                    dgvnestedBtn2.Visible = Visible;
                    dgvnestedBtn2.Width = width;
                    dgvnestedBtn2.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvnestedBtn2.Resizable = Resizable;
                    dgvnestedBtn2.DefaultCellStyle.Alignment = cellAlignment;
                    dgvnestedBtn2.HeaderCell.Style.Alignment = headerAlignment;
                    dgvnestedBtn2.HeaderText = Headertext;
                    ShanuDGV.Columns.Add(dgvnestedBtn2);
                    break;
                case ShanuControlTypes.imageDelteColumn:
                    DataGridViewImageColumn dgvnestedBtn3 = new DataGridViewImageColumn();
                    dgvnestedBtn3.Name = cntrlnames;


                    dgvnestedBtn3.Image = global::shanuDatagridViewCellpainting.Properties.Resources.D_icon_delete;
                    // dgvnestedBtn.DataPropertyName = cntrlnames;
                    dgvnestedBtn3.Visible = Visible;
                    dgvnestedBtn3.Width = width;
                    dgvnestedBtn3.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvnestedBtn3.Resizable = Resizable;
                    dgvnestedBtn3.DefaultCellStyle.Alignment = cellAlignment;
                    dgvnestedBtn3.HeaderCell.Style.Alignment = headerAlignment;
                    dgvnestedBtn3.HeaderText = Headertext;
                    ShanuDGV.Columns.Add(dgvnestedBtn3);
                    break;
            }
        }

        #endregion
      
        // Image Colukmn Click evnet
        #region Image Colukmn Click Event
        public void DGVMasterGridClickEvents(DataGridView ShanuMasterDGV, DataGridView ShanuDetailDGV, int columnIndexs, ShanuEventTypes eventtype, ShanuControlTypes types,DataTable DetailTable,String FilterColumn)
        {
            MasterDGVs = ShanuMasterDGV;
            DetailDGVs = ShanuDetailDGV;
            gridColumnIndex = columnIndexs;
            DetailgridDT = DetailTable;
            FilterColumnName = FilterColumn;
           
            MasterDGVs.CellContentClick += new DataGridViewCellEventHandler(masterDGVs_CellContentClick_Event);


        }
        private void masterDGVs_CellContentClick_Event(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewImageColumn cols = (DataGridViewImageColumn)MasterDGVs.Columns[0];
         
           // cols.Image = Image.FromFile(ImageName);
            MasterDGVs.Rows[e.RowIndex].Cells[0].Value = Image.FromFile("expand.png");

             if (e.ColumnIndex == gridColumnIndex)
             {
                
            
                 if (ImageName == "expand.png")
                 {
                     DetailDGVs.Visible = true;
                     ImageName = "toggle.png";
                     // cols.Image = Image.FromFile(ImageName);
                     MasterDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Image.FromFile(ImageName);


                     String Filterexpression = MasterDGVs.Rows[e.RowIndex].Cells[FilterColumnName].Value.ToString();

                     DataView detailView = new DataView(DetailgridDT);
                     detailView.RowFilter = FilterColumnName + " = '" + Filterexpression + "'";
                     if (detailView.Count <= 0)
                     {
                         MessageBox.Show("No Details Found");
                     }

                     MasterDGVs.Controls.Add(DetailDGVs);


                     Rectangle dgvRectangle = MasterDGVs.GetCellDisplayRectangle(1, e.RowIndex, true);
                     DetailDGVs.Size = new Size(MasterDGVs.Width - 200, 200);
                     DetailDGVs.Location = new Point(dgvRectangle.X, dgvRectangle.Y + 20);


                    
                     DetailDGVs.DataSource = detailView;


                 }
                 else
                 {
                     ImageName = "expand.png";
                     //  cols.Image = Image.FromFile(ImageName);
                     MasterDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Image.FromFile(ImageName);
                     DetailDGVs.Visible = false;
                 }                 
             }
             else
             {
                 DetailDGVs.Visible = false;
                 
             }
        }
        #endregion

        public void DGVDetailGridClickEvents(DataGridView ShanuDetailDGV)
        {
          
            DetailDGVs = ShanuDetailDGV;

            DetailDGVs.CellContentClick += new DataGridViewCellEventHandler(detailDGVs_CellContentClick_Event);


        }
          private void detailDGVs_CellContentClick_Event(object sender, DataGridViewCellEventArgs e)
          {
              MessageBox.Show("Detail grid Clicked : You clicked on " + DetailDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
          }

    }
}
//Enam decalaration for DataGridView Column Type ex like Textbox Column ,Button Column
public enum ShanuControlTypes { BoundColumn, TextBox, ComboBox, CheckBox, DateTimepicker, Button, NumericTextBox, ColorDialog, ImageColumn ,imageBoundcolumn,imageEditColumn,imageDelteColumn}
public enum ShanuEventTypes { CellClick, cellContentClick, EditingControlShowing }