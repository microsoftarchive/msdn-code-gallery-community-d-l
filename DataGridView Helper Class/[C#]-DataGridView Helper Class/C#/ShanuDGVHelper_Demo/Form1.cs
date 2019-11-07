using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/// Author      : Shanu
/// Create date : 2014-11-11
/// Description : ShanuDGVHelper
/// Latest
/// Modifier    : Shanu
/// Modify date : 2014-11-11
/// </summary>
namespace ShanuDGVHelper_Demo
{
    public partial class Form1 : Form
    {
        #region Variables
    DataGridView shanuDGV = new DataGridView();
  
   List<int> lstNumericTextBoxColumns;
   ShanuDGVHelper objshanudgvHelper = new ShanuDGVHelper();
   public int ColumnIndex;
   DataTable dtName = new DataTable();

   DataTable dtSource = new DataTable();
    # endregion

   #region Form Load
   public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // To bind the data to List 
            BindData();

            // to generate DGV with your coding
            generatedgvColumns();
        }
   # endregion


        #region Methods

        public void BindData()
        {
           

            dtSource.Columns.Add("Chk",typeof(bool));
            dtSource.Columns.Add("DGVBoundColumn",typeof(String));
            dtSource.Columns.Add("DGVTXTColumn", typeof(String));
            dtSource.Columns.Add("DGVNumericTXTColumn" ,typeof(int));
            dtSource.Columns.Add("DGVDateTimepicker", typeof(DateTime));
            dtSource.Columns.Add("DGVComboColumn", typeof(String));
            dtSource.Columns.Add("DGVButtonColumn", typeof(String));
            dtSource.Columns.Add("DGVColorDialogColumn", typeof(String));
            dtSource.Columns.Add("DGVImgColumn", typeof(String));
            try
            {

                dtSource.Rows.Add(false, "item 1", "Shanu", 11, DateTime.Now, "SHANU", "Button1", "red", "shanu.JPG");
                dtSource.Rows.Add(true, "item 2", "Afraz", 5, DateTime.Now.AddDays(-565), "Afraz", "Button2", "Green", "shanu.JPG");
                dtSource.Rows.Add(false, "item 3", "Afreen", 8, DateTime.Now.AddDays(-12), "Afreen", "Button3", "Pink", "green.png");
                dtSource.Rows.Add(false, "item 4", "Shanu", 1, DateTime.Now.AddMonths(-12), "SHANU", "Button4", "yellow", "yellow.png");
                dtSource.Rows.Add(true, "item 5", "Afraz", 17, DateTime.Now.AddDays(-565), "Afraz", "Button5", "black", "shanu.JPG");
                dtSource.Rows.Add(false, "item 6", "Afreen", 121, DateTime.Now.AddDays(-63), "Afreen", "Button6", "gray", "green.png");
                dtSource.Rows.Add(false, "item 7", "Shanu", 0, DateTime.Now, "SHANU", "Button7", "red", "yellow.png");
                dtSource.Rows.Add(false, "item 8", "Afreen", 0, DateTime.Now.AddDays(-53), "Afreen", "Button8", "Pink", "shanu.JPG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // For combo Box bind 

            dtName.Columns.Add("Name");
            dtName.Columns.Add("Value");

            dtName.Rows.Add("Shanu", "Shanu");
            dtName.Rows.Add("Afraz", "Afraz");
            dtName.Rows.Add("Afreen", "Afreen");
            
        }

        // to generate DGV with your coding
        public void generatedgvColumns()
        {

            //First generate the grid Layout Design
            ShanuDGVHelper.Layouts(shanuDGV, Color.LightSteelBlue, Color.AliceBlue, Color.LightSkyBlue, false, Color.SteelBlue, false, false, false,Color.White,40);

            //Set Height,width and add panel to your selected control
            ShanuDGVHelper.Generategrid(shanuDGV, pnlShanuGrid, 1000, 600, 10, 10);
          
            // CheckboxColumn creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.CheckBox, "Chk", "CHKCOL", "Check Box Column", true, 60, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.BoundColumn, "DGVBoundColumn", "BOUNDCOL", "Bound  Column", true, 120, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // TextboxColumn creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.TextBox, "DGVTXTColumn", "TXTCOL", "textBox  Column", true, 130, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, Color.White, null, "", "", Color.Black);

            // NumerictextColumn creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.TextBox, "DGVNumericTXTColumn", "NO.COL", "textBox  Column", true, 60, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, Color.MistyRose, null, "", "", Color.Black);

            // BoundColumn creation which will be used as Datetime picker
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.BoundColumn, "DGVDateTimepicker", "DATECOL", "For Datetime  Column", true, 160, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, Color.Transparent, null, "", "", Color.Black);

            // ComboBox Column creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.ComboBox, "DGVComboColumn", "COMBOCOL", "Combo  Column", true, 160, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, dtName, "Name", "Value", Color.Black);


            // Button Column creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.Button, "DGVButtonColumn", "BUTTONCOL", "Button  Column", true, 120, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);

            // Color Dialog Column creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.Button, "DGVColorDialogColumn", "COLORPICKER", "Button  Column", true, 120, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);

            // Image Column creation
            ShanuDGVHelper.Templatecolumn(shanuDGV, ShanuControlTypes.ImageColumn, "DGVImgColumn", "IMGCOL", "IMG Column", true, 80, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);


            // Numeric Textbox Setting and add the Numeric Textbox column index to list
            lstNumericTextBoxColumns = new List<int>();
            lstNumericTextBoxColumns.Add(shanuDGV.Columns["DGVNumericTXTColumn"].Index);          
         
            //Numeric textbox events to allow only numeric is that column
            objshanudgvHelper.NumeriTextboxEvents(shanuDGV, lstNumericTextBoxColumns);

            //Image Column bind image 
            objshanudgvHelper.datagridImageAddEvent(shanuDGV, shanuDGV.Columns["DGVImgColumn"].Index, dtSource);

           
            // Datetime Picker Bind to an existing textbox Column
            objshanudgvHelper.DateTimePickerEvents(shanuDGV, shanuDGV.Columns["DGVDateTimepicker"].Index, ShanuEventTypes.CellClick);

            // Add Color Dialog to Button Column
            objshanudgvHelper.colorDialogEvents(shanuDGV, shanuDGV.Columns["DGVColorDialogColumn"].Index, ShanuEventTypes.cellContentClick);

            // DGV button Click Event
            objshanudgvHelper.DGVClickEvents(shanuDGV, shanuDGV.Columns["DGVButtonColumn"].Index, ShanuEventTypes.cellContentClick);
       

            // Bind data to DGV.
            shanuDGV.DataSource = dtSource;



        }
        # endregion
    }
}
