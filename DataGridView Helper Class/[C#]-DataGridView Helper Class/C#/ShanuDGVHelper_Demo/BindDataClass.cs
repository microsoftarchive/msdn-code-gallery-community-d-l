using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Author      : Shanu
/// Create date : 2014-11-11
/// Description : Shanu Bind List to Grid Class
/// Latest
/// Modifier    : Shanu
/// Modify date : 2014-11-11
/// </summary>
namespace ShanuDGVHelper_Demo
{
    class BindDataClass
    {
        public Boolean Chk { get; set; }  
         public string DGVBoundColumn { get; set; }
         public string DGVTXTColumn { get; set; }
         public int DGVNumericTXTColumn { get; set; }
         public DateTime DGVDateTimepicker { get; set; }
         public string DGVComboColumn { get; set; }
         public string DGVButtonColumn { get; set; }
         public string DGVColorDialogColumn { get; set; }
         public string DGVImgColumn { get; set; }

         public BindDataClass(Boolean chk, string dgvcolumn, string dgvtxtColumn, int dgvnumericTXTColumn, DateTime dgvdatetimepicker, string dgvcomboColumn, string dgvbuttonColumn, string dgvcolordialogcolumn, string dgvImgColumn)   
        {   
          Chk = chk;
          DGVBoundColumn = dgvcolumn;
          DGVTXTColumn = dgvtxtColumn;
          DGVNumericTXTColumn= dgvnumericTXTColumn;
          DGVDateTimepicker = dgvdatetimepicker;
          DGVComboColumn = dgvcomboColumn;
          DGVButtonColumn = dgvbuttonColumn;
          DGVColorDialogColumn = dgvcolordialogcolumn;
          DGVImgColumn = dgvImgColumn;
            
        }   

    }
}
