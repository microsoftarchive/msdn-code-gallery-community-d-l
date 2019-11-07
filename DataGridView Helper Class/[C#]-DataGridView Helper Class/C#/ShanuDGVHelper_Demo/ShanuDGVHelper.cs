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
namespace ShanuDGVHelper_Demo
{

    class ShanuDGVHelper
    {
        #region Variables
        public DataGridView shanuDGVs = new DataGridView();
       List<int> listcolumnIndex;
        int DateColumnIndex=0;
        int ColorColumnIndex = 0;
        int ClickColumnIndex = 0;
       DateTimePicker shanuDateTimePicker;
       String EventFucntions;

       int imgColumnIndex = 0;
       DataTable objDGVBind = new DataTable();
       Boolean imgBindchk = false;

        # endregion

        //Set all the telerik Grid layout
        #region Layout

       public static void Layouts(DataGridView ShanuDGV, Color BackgroundColor, Color RowsBackColor, Color AlternatebackColor, Boolean AutoGenerateColumns, Color HeaderColor, Boolean HeaderVisual, Boolean RowHeadersVisible, Boolean AllowUserToAddRows, Color HeaderForeColor,int headerHeight)
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
            //header Visisble
            ShanuDGV.EnableHeadersVisualStyles = HeaderVisual;
            
            // Enable the row header
            ShanuDGV.RowHeadersVisible = RowHeadersVisible;

            // to Hide the Last Empty row here we use false.
            ShanuDGV.AllowUserToAddRows = AllowUserToAddRows;
        }
        #endregion

       //Add your grid to your selected Control and set height,width,position of your grid.
       #region Generategrid
       public static void Generategrid(DataGridView ShanuDGV, Control cntrlName, int width, int height, int xval, int yval)
        {
            ShanuDGV.Location = new Point(xval, yval);
            ShanuDGV.Size = new Size(width, height);
            //ShanuDGV.Dock = docktyope.
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
                   DataGridViewColumn col = new DataGridViewTextBoxColumn();
                       col.DataPropertyName = cntrlnames;
                       col.Name = cntrlnames;
                       col.HeaderText = Headertext;
                       col.ToolTipText = ToolTipText;
                       col.Visible = Visible;
                       col.Width = width;
                       col.SortMode = DataGridViewColumnSortMode.Automatic;
                       col.Resizable = Resizable;
                       col.DefaultCellStyle.Alignment = cellAlignment;
                       col.HeaderCell.Style.Alignment = headerAlignment;
                       if (CellTemplateBackColor.Name.ToString() != "Transparent")
                       {
                           col.CellTemplate.Style.BackColor = CellTemplateBackColor;
                       }
                       col.DefaultCellStyle.ForeColor = CellTemplateforeColor;     
                        ShanuDGV.Columns.Add(col);
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
                            dgvcombo.HeaderText = Headertext;
                            dgvcombo.ToolTipText = ToolTipText;
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
                    dgvButtons.HeaderText = Headertext;
                    dgvButtons.ToolTipText = ToolTipText;
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
                    dgvnestedBtn.Image = Image.FromFile("shanu.JPG");//global::ShanuDGVHelper_Demo.Properties.Resources.toggle;
                    dgvnestedBtn.HeaderText = Headertext;
                    dgvnestedBtn.ToolTipText = ToolTipText;
                    // dgvnestedBtn.DataPropertyName = cntrlnames;
                    dgvnestedBtn.Visible = Visible;
                    dgvnestedBtn.Width = width;
                    dgvnestedBtn.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvnestedBtn.Resizable = Resizable;
                    dgvnestedBtn.DefaultCellStyle.Alignment = cellAlignment;
                    dgvnestedBtn.HeaderCell.Style.Alignment = headerAlignment;
                    ShanuDGV.Columns.Add(dgvnestedBtn);
                    break;
            }
          



        }

        #endregion


        #region Image Column bind using Cellformatting
        public void datagridImageAddEvent(DataGridView ShanuDGV, int imgColIndex, DataTable objDGVBinds)
        {
            shanuDGVs = ShanuDGV;
            objDGVBind = objDGVBinds;
          imgColumnIndex=imgColIndex;

            shanuDGVs.CellFormatting +=new DataGridViewCellFormattingEventHandler(shanuDGVs_CellFormatting);
        }
        private void shanuDGVs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == imgColumnIndex)
            {
                if (imgBindchk == false)
                {
                    shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Image.FromFile(objDGVBind.Rows[e.RowIndex][imgColumnIndex].ToString());
                    if (e.RowIndex == objDGVBind.Rows.Count-1)
                    {
                        imgBindchk = true;
                    }
                }               
            }          
        }
        #endregion

        //Numeric Textbox event and check for key press event for accepting only numbers for the selected column
        #region Numeric Textbox Events 
        public  void NumeriTextboxEvents(DataGridView ShanuDGV,List<int> columnIndexs)
        {        

            shanuDGVs = ShanuDGV;
            listcolumnIndex=columnIndexs;

            ShanuDGV.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dShanuDGV_EditingControlShowing);
        }
        // grid Editing Control Showing
        private void dShanuDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);//This line of code resolved my issue
            if (listcolumnIndex.Contains(shanuDGVs.CurrentCell.ColumnIndex))
            {
                TextBox itemID = e.Control as TextBox;
                if (itemID != null)
                {
                    itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                }
            }
        }
        //Grid Kyey press event
        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        // Add an datTime Picker control to existing Textbox Column
        #region DateTimePicker control to textbox column
        public void DateTimePickerEvents(DataGridView ShanuDGV, int columnIndexs,ShanuEventTypes eventtype)
        {


            shanuDGVs = ShanuDGV;
            DateColumnIndex = columnIndexs;
            ShanuDGV.CellClick += new DataGridViewCellEventHandler(shanuDGVs_CellClick);
            //switch (eventtype)
            //{
            //    case ShanuEventTypes.CellClick:
            //        ShanuDGV.CellClick +=new DataGridViewCellEventHandler(shanuDGVs_CellClick);
            //        break;
            //    case ShanuEventTypes.cellContentClick:
            //          ShanuDGV.CellContentClick +=new DataGridViewCellEventHandler(shanuDGVs_CellContentClick);
            //        break;
            //}

            }


        // In this cell click event,DateTime Picker Control will be added to the selected column
        private void shanuDGVs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DateColumnIndex)
            {
                shanuDateTimePicker = new DateTimePicker();
                shanuDGVs.Controls.Add(shanuDateTimePicker);
                shanuDateTimePicker.Format = DateTimePickerFormat.Short;
                Rectangle dgvRectangle = shanuDGVs.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                shanuDateTimePicker.Size = new Size(dgvRectangle.Width, dgvRectangle.Height);
                shanuDateTimePicker.Location = new Point(dgvRectangle.X, dgvRectangle.Y);
               // shanuDateTimePicker.Visible = true;
            }

        }


        #endregion
        // Button Click evnet
        #region Button Click Event
        public void DGVClickEvents(DataGridView ShanuDGV, int columnIndexs, ShanuEventTypes eventtype)
        {


            shanuDGVs = ShanuDGV;
           ClickColumnIndex = columnIndexs;
           ShanuDGV.CellContentClick += new DataGridViewCellEventHandler(shanuDGVs_CellContentClick_Event);


        }
        private void shanuDGVs_CellContentClick_Event(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == ClickColumnIndex)
            {
                MessageBox.Show("Button Clicked " + shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
        #endregion
        // Button Click Event to show Color Dialog
        #region Button Click Event to show Color Dialog
        public void colorDialogEvents(DataGridView ShanuDGV, int columnIndexs, ShanuEventTypes eventtype)
        {
            shanuDGVs = ShanuDGV;
            ColorColumnIndex = columnIndexs;
          
                    ShanuDGV.CellContentClick += new DataGridViewCellEventHandler(shanuDGVs_CellContentClick);                  
        }
            
          private void shanuDGVs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.ColumnIndex == ColorColumnIndex)
                {
                    MessageBox.Show("Button Clicked " + shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    ColorDialog cd = new ColorDialog();
                    cd.ShowDialog();
                    shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = cd.Color;


                }

        }

        #endregion


    }
}
//Enam decalaration for DataGridView Column Type ex like Textbox Column ,Button Column
public enum ShanuControlTypes { BoundColumn, TextBox, ComboBox, CheckBox, DateTimepicker, Button, NumericTextBox, ColorDialog, ImageColumn }
public enum ShanuEventTypes { CellClick, cellContentClick, EditingControlShowing }
