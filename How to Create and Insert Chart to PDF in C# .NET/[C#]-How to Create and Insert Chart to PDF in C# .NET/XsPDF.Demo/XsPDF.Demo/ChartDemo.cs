using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Charting;
using XsPDF.Drawing;
using XsPDF.Pdf;

namespace XsPDF.Demo
{
    class ChartDemo
    {
        public static void AddLineChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a line chart
            Chart chart = LineChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Draw chart into page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("Chart.pdf");
            Process.Start("Chart.pdf");
        }

        public static Chart LineChart()
        {
            // Set chart type to line
            Chart chart = new Chart(ChartType.Line);

            // Create first series with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 1";
            series.Add(new double[] { 1, 12, -6, 15, 11 });

            // Create second series with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 2";
            series.Add(new double[] { 22, 4, 12, 8, 12 });

            // Create third series with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 3";
            series.Add(new double[] { 12, 17, -3, 18, 1 });

            // Set X axes
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";
            //chart.XAxis.HasMajorGridlines = true;

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.Title.Caption = "Y-Axis";
            chart.YAxis.HasMajorGridlines = true;

            // Set plot area (chart diagram)
            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            // Set legend
            chart.Legend.Docking = DockingType.Bottom;
            chart.Legend.LineFormat.Visible = true;

            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("A", "B", "C", "D", "E", "F");

            return chart;
        }

        public static void AddPieChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d pie chart graph
            Chart chart = PieChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("PieChart.pdf");
            Process.Start("PieChart.pdf");
        }

        public static Chart PieChart()
        {
            // Set chart type to Pie2D
            Chart chart = new Chart(ChartType.Pie2D);

            // Add series data
            Series series = chart.SeriesCollection.AddSeries();
            series.Add(new double[] { 1, 5, 11, 3, 20 });

            // Add series legend
            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("Series 1", "Series 2", "Series 3", "Series 4", "Series 5");
            chart.Legend.Docking = DockingType.Right;

            // Set label display type
            chart.DataLabel.Type = DataLabelType.Percent;

            // Set label location
            chart.DataLabel.Position = DataLabelPosition.Center;

            return chart;
        }

        public static void AddBarChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d bar chart graph
            Chart chart = BarChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("BarChart.pdf");
            Process.Start("BarChart.pdf");
        }

        public static Chart BarChart()
        {
            // Set chart type to Bar2D
            Chart chart = new Chart(ChartType.Bar2D);

            // Add first series with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 1";
            series.Add(new double[] { 1, 5, -3, 20, 11 });

            // Add second series with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 2";
            series.Add(new double[] { 22, 4, 12, 8, 12 });

            // Add third series with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 3";
            series.Add(new double[] { 12, 14, 2, 18, 1 });

            // Add first fourth with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 4";
            series.Add(new double[] { 17, 13, 10, 9, 15 });

            // Set X axes
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            // Set plot area (chart diagram)
            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            // Set legend
            chart.Legend.Docking = DockingType.Right;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.InsideEnd;

            return chart;
        }

        public static void AddColumnChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d column chart graph
            Chart chart = ColumnChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("ColumnChart.pdf");
            Process.Start("ColumnChart.pdf");
        }

        public static Chart ColumnChart()
        {
            // Set chart type to Column2D
            Chart chart = new Chart(ChartType.Column2D);

            // Add first series of column chart with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 1";
            series.Add(new double[] { 1, 5, -3, 20, 11 });

            // Add second series of column chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 2";
            series.Add(new double[] { 22, 4, 12, 8, 12 });

            // Add third series of column chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 3";
            series.Add(new double[] { 12, 14, 2, 18, 1 });

            // Add fourth series of column chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 4";
            series.Add(new double[] { 17, 13, 10, 9, 15 });

            // Set X axes
            chart.XAxis.TickLabels.Format = "00";
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            // Set plot area (chart diagram)
            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            // Set legend
            chart.Legend.Docking = DockingType.Right;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

            return chart;
        }

        public static void AddStackedBarChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d stacked bar chart graph
            Chart chart = BarStackedChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("StactedBarChart.pdf");
            Process.Start("StactedBarChart.pdf");
        }

        public static Chart BarStackedChart()
        {
            // Set chart type to BarStacked2D
            Chart chart = new Chart(ChartType.BarStacked2D);

            // Add first series of stacked bar chart with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 1";
            series.Add(new double[] { 1, 5, -3, 20, 11 });

            // Add second series of stacked bar chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 2";
            series.Add(new double[] { 22, 4, 12, 8, 12 });

            // Add third series of stacked bar chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 3";
            series.Add(new double[] { 12, 14, 2, 18, 1 });

            // Add fourth series of stacked bar chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 4";
            series.Add(new double[] { 17, 13, 10, 9, 15 });

            // Set X axes
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            // Set plot area (chart diagram)
            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            // Set legend
            chart.Legend.Docking = DockingType.Right;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.Center;

            return chart;
        }

        public static void AddStackedColumnChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d stacked column chart graph
            Chart chart = ColumnStackedChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("StactedColumnChart.pdf");
            Process.Start("StactedColumnChart.pdf");
        }

        public static Chart ColumnStackedChart()
        {
            // Set chart type to ColumnStacked2D
            Chart chart = new Chart(ChartType.ColumnStacked2D);

            // Add first series of stacked column chart with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 1";
            series.Add(new double[] { 1, 5, -3, 20, 11 });

            // Add second series of stacked column chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 2";
            series.Add(new double[] { 22, 4, 12, 8, 12 });

            // Add third series of stacked column chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 3";
            series.Add(new double[] { 12, 14, 2, 18, 1 });

            // Add fourth series of stacked column chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 4";
            series.Add(new double[] { 17, 13, 10, 9, 15 });

            // Set X axes
            chart.XAxis.TickLabels.Format = "00";
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            // Set plot area (chart diagram)
            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            // Set legend
            chart.Legend.Docking = DockingType.Right;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.Center;

            return chart;
        }

        public static void AddAreaChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d area chart graph
            Chart chart = AreaChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("AreaChart.pdf");
            Process.Start("AreaChart.pdf");
        }

        public static Chart AreaChart()
        {
            // Set chart type to Area2D
            Chart chart = new Chart(ChartType.Area2D);

            // Add first series of area chart with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Add(new double[] { 31, 9, 15, 28, 13 });

            // Add second series of area chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Add(new double[] { 22, 7, 12, 21, 12 });

            // Add third series of area chart with name and data
            series = chart.SeriesCollection.AddSeries();
            series.Add(new double[] { 16, 5, 3, 20, 11 });

            // Set X axes
            chart.XAxis.TickLabels.Format = "00";
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            // Set plot area (chart diagram)
            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            // Set legend
            chart.Legend.Docking = DockingType.Top;

            return chart;
        }

        public static void AddExplodedPieChartToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d exploded pie chart graph
            Chart chart = PieExplodedChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("ExplodedPieChart.pdf");
            Process.Start("ExplodedPieChart.pdf");
        }

        public static Chart PieExplodedChart()
        {
            // Set chart type to Area2D
            Chart chart = new Chart(ChartType.PieExploded2D);

            // Add series of exploded pie chart with name and data
            Series series = chart.SeriesCollection.AddSeries();
            series.Add(new double[] { 1, 17, 45, 5, 3, 20, 11, 23, 8, 19, 34, 56, 23, 45 });

            // Set legend
            chart.Legend.Docking = DockingType.Left;

            chart.DataLabel.Type = DataLabelType.Percent;
            chart.DataLabel.Position = DataLabelPosition.Center;

            return chart;
        }

        public static void AddCombinedChartsToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d exploded pie chart graph
            Chart chart = CombinationChart();

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("CombinationChart.pdf");
            Process.Start("CombinationChart.pdf");
        }

        public static Chart CombinationChart()
        {
            Chart chart = new Chart();
            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Column2D;
            series.Add(new double[] { 1, 17, 45, 5, 3, 20, 11, 23, 8, 19 });
            series.HasDataLabel = true;

            series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Line;
            series.Add(new double[] { 41, 7, 5, 45, 13, 10, 21, 13, 18, 9 });

            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("A", "B", "C", "D", "E", "F", "G", "H", "I", "J");

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Color = XColors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            chart.Legend.Docking = DockingType.Left;
            chart.Legend.LineFormat.Visible = true;

            return chart;
        }

        public static void ChangePDFChartColor()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d column chart graph            
            Chart chart = new Chart(ChartType.Column2D);

            Series series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 1";
            series.Add(new double[] { 1, 5, 3, 20, 11 });
            // Set color for 1st series, all the column shapes 
            // in the 1st series will show the same color as 'Gold'
            series.FillFormat.Color = XColors.Gold;

            series = chart.SeriesCollection.AddSeries();
            series.Name = "Series 2";
            series.Add(new double[] { 22, 4, 12, 8, 12 });
            // set color for 2nd series, all the column shapes
            // in the 2nd series will displa the same color as 'Cyan'
            series.FillFormat.Color = XColors.Cyan;


            // Set X axes
            chart.XAxis.TickLabels.Format = "00";
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            // Set Y axes
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            // Set plot border color
            chart.PlotArea.LineFormat.Color = XColors.Black;
            chart.PlotArea.LineFormat.Visible = true;
            // Set plot background color
            chart.PlotArea.FillFormat.Color = XColors.White;

            // Set legend
            chart.Legend.Docking = DockingType.Right;
            chart.Legend.LineFormat.Color = XColors.Red;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("ColorChart.pdf");
            Process.Start("ColorChart.pdf");
        }

        public static void ChangePDFPieChartAndFrameColor()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Generate a 2d pie chart graph
            Chart chart = new Chart(ChartType.Pie2D);

            // Add series data
            Series series = chart.SeriesCollection.AddSeries();
            series.Add(new double[] { 5, 6, 3 });

            // Add series legend
            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("Series 1", "Series 2", "Series 3");
            chart.Legend.Docking = DockingType.Right;

            // Set fill color for series 1
            series.Elements[0].FillFormat.Color = XColors.Red;
            // Set fill color for series 2
            series.Elements[1].FillFormat.Color = XColors.Blue;
            // Set fill color for series 3
            series.Elements[2].FillFormat.Color = XColors.Yellow;

            // Set label display type
            chart.DataLabel.Type = DataLabelType.Percent;

            // Set label location
            chart.DataLabel.Position = DataLabelPosition.Center;

            // Create a chart frame, set chart location and size
            ChartFrame chartFrame = new ChartFrame();
            chartFrame.Location = new XPoint(30, 30);
            chartFrame.Size = new XSize(500, 600);
            // Set background color for frame
            chartFrame.BackgroudFormat = XBrushes.White;
            // Set border color for frame
            chartFrame.BorderFormat = XPens.Black;
            chartFrame.Add(chart);

            // Render chart symbols into pdf page
            XGraphics g = XGraphics.FromPdfPage(page);
            chartFrame.Draw(g);

            // Save and show the document           
            document.Save("PieColorChart.pdf");
            Process.Start("PieColorChart.pdf");
        }

    }
}
