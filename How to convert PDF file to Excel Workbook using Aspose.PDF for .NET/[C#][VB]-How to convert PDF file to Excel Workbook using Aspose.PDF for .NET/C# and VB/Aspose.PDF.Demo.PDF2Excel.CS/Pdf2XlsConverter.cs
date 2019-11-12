using System.Data;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace Aspose.PDF.Demo.PDF2Excel.CS
{

    static class Pdf2XlsConverter
    {
        public static void SaveToExcel(string asposeFilePdf, string asposeFileXls, ExcelSaveOptions excelSaveOption)
        {
            var pdfDocument = new Document(filename: asposeFilePdf);
            pdfDocument.Save(asposeFileXls, excelSaveOption);
        }

        public static void AddInvoiceData(string asposeFilePdf)
        {
            var document = new Document();
            var pdfPage = document.Pages.Add();
            var table = new Table();
            table.ColumnWidths = "10 10 10 10 10";
            table.ColumnAdjustment = ColumnAdjustment.AutoFitToContent;
            table.DefaultCellPadding = new MarginInfo(5, 5, 5, 5);
            table.Border = new BorderInfo(BorderSide.All, 0.5F, Color.Black);
            table.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.2F, Color.Black);
            table.DefaultCellTextState = new TextState("TimesNewRoman", 10);
            var paymentFormat = new TextState("TimesNewRoman", 10) {HorizontalAlignment = HorizontalAlignment.Right};
            table.SetColumnTextState(2, paymentFormat);
            table.SetColumnTextState(4, paymentFormat);
            table.ImportDataTable(GenerateDataTable(), true, 0, 1, 5, 5);
            table.RepeatingRowsCount = 1;
            pdfPage.Paragraphs.Add(table);
            var streamOut = new FileStream(asposeFilePdf, FileMode.OpenOrCreate);
            document.Save(streamOut);
            streamOut.Close();
        }

        private static DataTable GenerateDataTable()
        {
            var dt = new DataTable("InovoiceItems");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Qunatity", typeof(int));
            dt.Columns.Add("Summa", typeof(float));
            var dr = dt.NewRow();
            for (var i = 1; i <= 5; i++)
            {
                dr[0] = i;
                dr[1] = "Sun Glasses Type " + i;
                dr[2] = 199.99;
                dr[3] = 1;
                dr[4] = 199.99;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
            return dt;
        }
    }  
}
