using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using Spire.Presentation;
using Spire.Presentation.Charts;
using Spire.Presentation.Drawing;

namespace InsertChart
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //create PPT document
            Presentation presentation = new Presentation();

            //set background Image
            string ImageFile = "bg.png";
            RectangleF rect2 = new RectangleF(0, 0, presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height);
            presentation.Slides[0].Shapes.AppendEmbedImage(ShapeType.Rectangle, ImageFile, rect2);
            presentation.Slides[0].Shapes[0].Line.FillFormat.SolidFillColor.Color = Color.FloralWhite;

            //insert chart
            RectangleF rect = new RectangleF(presentation.SlideSize.Size.Width / 2 - 200, 100, 400, 400);
            IChart chart = presentation.Slides[0].Shapes.AppendChart(Spire.Presentation.Charts.ChartType.Cylinder3DClustered, rect);

            //add chart Title
            chart.ChartTitle.TextProperties.Text = "Report";
            chart.ChartTitle.TextProperties.IsCentered = true;
            chart.ChartTitle.Height = 30;
            chart.HasTitle = true;

            //load data from XML file to datatable
            DataTable dataTable = LoadData();

            //load data from datatable to chart
            InitChartData(chart, dataTable);
            chart.Series.SeriesLabel = chart.ChartData["B1", "D1"];
            chart.Categories.CategoryLabels = chart.ChartData["A2", "A7"];
            chart.Series[0].Values = chart.ChartData["B2", "B7"];
            chart.Series[0].Fill.FillType = FillFormatType.Solid;
            chart.Series[0].Fill.SolidColor.KnownColor = KnownColors.Brown;
            chart.Series[1].Values = chart.ChartData["C2", "C7"];
            chart.Series[1].Fill.FillType = FillFormatType.Solid;
            chart.Series[1].Fill.SolidColor.KnownColor = KnownColors.Green;
            chart.Series[2].Values = chart.ChartData["D2", "D7"];
            chart.Series[2].Fill.FillType = FillFormatType.Solid;
            chart.Series[2].Fill.SolidColor.KnownColor = KnownColors.Orange;

            //set the 3D rotation
            chart.RotationThreeD.XDegree = 10;
            chart.RotationThreeD.YDegree = 10;

            //save the document
            presentation.SaveToFile(@"..\..\chart.pptx", FileFormat.Pptx2010);

            System.Diagnostics.Process.Start(@"..\..\chart.pptx");
        }

        //function to load data from XML file to DataTable
        private static DataTable LoadData()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema("data-schema.xml");
            ds.ReadXml("data.xml");

            return ds.Tables[0];
        }

        //function to load data from DataTable to IChart
        private static void InitChartData(IChart chart, DataTable dataTable)
        {
            for (int c = 0; c < dataTable.Columns.Count; c++)
            {
                chart.ChartData[0, c].Text = dataTable.Columns[c].Caption;
            }

            for (int r = 0; r < dataTable.Rows.Count; r++)
            {
                object[] data = dataTable.Rows[r].ItemArray;
                for (int c = 0; c < data.Length; c++)
                {
                    chart.ChartData[r + 1, c].Value = data[c];
                }
            }
        }

    }
}
