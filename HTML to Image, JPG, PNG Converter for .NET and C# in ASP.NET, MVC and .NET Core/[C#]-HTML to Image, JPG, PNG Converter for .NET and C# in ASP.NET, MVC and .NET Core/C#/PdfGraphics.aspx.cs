using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class PdfGraphics : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // create a page in document
            PdfPage page1 = document.AddPage();

            // create the true type fonts that can be used in document text
            System.Drawing.Font sysFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFont = document.CreateFont(sysFont);
            PdfFont pdfFontEmbed = document.CreateFont(sysFont, true);

            float crtYPos = 20;
            float crtXPos = 5;

            PdfLayoutInfo textLayoutInfo = null;
            PdfLayoutInfo graphicsLayoutInfo = null;

            #region Layout lines

            PdfText titleTextLines = new PdfText(crtXPos, crtYPos, "Lines:", pdfFontEmbed);
            titleTextLines.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextLines);

            // advance the Y position in the PDF page
            crtYPos = textLayoutInfo.LastPageRectangle.Bottom + 10;

            // layout a simple line
            PdfLine pdfLine = new PdfLine(new System.Drawing.PointF(crtXPos, crtYPos), new System.Drawing.PointF(crtXPos + 60, crtYPos));
            graphicsLayoutInfo = page1.Layout(pdfLine);

            // layout a thick line
            PdfLine pdfThickLine = new PdfLine(new System.Drawing.PointF(crtXPos + 70, crtYPos), new System.Drawing.PointF(crtXPos + 130, crtYPos));
            pdfThickLine.LineStyle.LineWidth = 3;
            graphicsLayoutInfo = page1.Layout(pdfThickLine);

            // layout a dotted colored line
            PdfLine pdfDottedLine = new PdfLine(new System.Drawing.PointF(crtXPos + 140, crtYPos), new System.Drawing.PointF(crtXPos + 200, crtYPos));
            pdfDottedLine.LineStyle.LineDashPattern = PdfLineDashPattern.Dot;
            pdfDottedLine.ForeColor = System.Drawing.Color.Green;
            graphicsLayoutInfo = page1.Layout(pdfDottedLine);

            // layout a dashed colored line
            PdfLine pdfDashedLine = new PdfLine(new System.Drawing.PointF(crtXPos + 210, crtYPos), new System.Drawing.PointF(crtXPos + 270, crtYPos));
            pdfDashedLine.LineStyle.LineDashPattern = PdfLineDashPattern.Dash;
            pdfDashedLine.ForeColor = System.Drawing.Color.Green;
            graphicsLayoutInfo = page1.Layout(pdfDashedLine);

            // layout a dash-dot-dot colored line
            PdfLine pdfDashDotDotLine = new PdfLine(new System.Drawing.PointF(crtXPos + 280, crtYPos), new System.Drawing.PointF(crtXPos + 340, crtYPos));
            pdfDashDotDotLine.LineStyle.LineDashPattern = PdfLineDashPattern.DashDotDot;
            pdfDashDotDotLine.ForeColor = System.Drawing.Color.Green;
            graphicsLayoutInfo = page1.Layout(pdfDashDotDotLine);

            // layout a thick line with rounded cap style
            PdfLine pdfRoundedLine = new PdfLine(new System.Drawing.PointF(crtXPos + 350, crtYPos), new System.Drawing.PointF(crtXPos + 410, crtYPos));
            pdfRoundedLine.LineStyle.LineWidth = 5;
            pdfRoundedLine.LineStyle.LineCapStyle = PdfLineCapStyle.RoundCap;
            pdfRoundedLine.ForeColor = System.Drawing.Color.Blue;
            graphicsLayoutInfo = page1.Layout(pdfRoundedLine);

            // advance the Y position in the PDF page
            crtYPos += 10;

            #endregion

            #region Layout circles

            PdfText titleTextCircles = new PdfText(crtXPos, crtYPos, "Circles:", pdfFontEmbed);
            titleTextCircles.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextCircles);

            // advance the Y position in the PDF page
            crtYPos = textLayoutInfo.LastPageRectangle.Bottom + 10;

            // draw a simple circle with solid line
            PdfCircle pdfCircle = new PdfCircle(new System.Drawing.PointF(crtXPos + 30, crtYPos + 30), 30);
            page1.Layout(pdfCircle);

            // draw a simple circle with dotted border line
            PdfCircle pdfDottedCircle = new PdfCircle(new System.Drawing.PointF(crtXPos + 100, crtYPos + 30), 30);
            pdfDottedCircle.ForeColor = System.Drawing.Color.Green;
            pdfDottedCircle.LineStyle.LineDashPattern = PdfLineDashPattern.Dot;
            graphicsLayoutInfo = page1.Layout(pdfDottedCircle);

            // draw a circle with colored border line and fill color
            PdfCircle pdfDisc = new PdfCircle(new System.Drawing.PointF(crtXPos + 170, crtYPos + 30), 30);
            pdfDisc.ForeColor = System.Drawing.Color.Navy;
            pdfDisc.BackColor = System.Drawing.Color.WhiteSmoke;
            graphicsLayoutInfo = page1.Layout(pdfDisc);

            // draw a circle with thick border line
            PdfCircle pdfThickBorderDisc = new PdfCircle(new System.Drawing.PointF(crtXPos + 240, crtYPos + 30), 30);
            pdfThickBorderDisc.LineStyle.LineWidth = 5;
            pdfThickBorderDisc.BackColor = System.Drawing.Color.LightSalmon;
            pdfThickBorderDisc.ForeColor = System.Drawing.Color.LightBlue;

            graphicsLayoutInfo = page1.Layout(pdfThickBorderDisc);

            crtYPos = graphicsLayoutInfo.LastPageRectangle.Bottom + 10;

            #endregion

            #region Layout ellipses and arcs

            PdfText titleTextEllipses = new PdfText(crtXPos, crtYPos, "Ellipses, arcs and slices:", pdfFontEmbed);
            titleTextEllipses.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextEllipses);

            // advance the Y position in the PDF page
            crtYPos = textLayoutInfo.LastPageRectangle.Bottom + 10;

            // draw a simple ellipse with solid line
            PdfEllipse pdfEllipse = new PdfEllipse(new System.Drawing.PointF(crtXPos + 50, crtYPos + 30), 50, 30);
            graphicsLayoutInfo = page1.Layout(pdfEllipse);

            // draw an ellipse with fill color and colored border line
            PdfEllipse pdfFilledEllipse = new PdfEllipse(new System.Drawing.PointF(crtXPos + 160, crtYPos + 30), 50, 30);
            pdfFilledEllipse.BackColor = System.Drawing.Color.WhiteSmoke;
            pdfFilledEllipse.ForeColor = System.Drawing.Color.Green;
            graphicsLayoutInfo = page1.Layout(pdfFilledEllipse);

            // draw an ellipse arc with colored border line
            PdfEllipseArc pdfEllipseArc1 = new PdfEllipseArc(new System.Drawing.RectangleF(crtXPos + 220, crtYPos, 100, 60), 0, 90);
            pdfEllipseArc1.ForeColor = System.Drawing.Color.OrangeRed;
            pdfEllipseArc1.LineStyle.LineWidth = 3;
            graphicsLayoutInfo = page1.Layout(pdfEllipseArc1);

            // draw an ellipse arc with fill color and colored border line
            PdfEllipseArc pdfEllipseArc2 = new PdfEllipseArc(new System.Drawing.RectangleF(crtXPos + 220, crtYPos, 100, 60), 90, 90);
            pdfEllipseArc2.ForeColor = System.Drawing.Color.Navy;
            graphicsLayoutInfo = page1.Layout(pdfEllipseArc2);

            // draw an ellipse arc with fill color and colored border line
            PdfEllipseArc pdfEllipseArc3 = new PdfEllipseArc(new System.Drawing.RectangleF(crtXPos + 220, crtYPos, 100, 60), 180, 90);
            pdfEllipseArc3.ForeColor = System.Drawing.Color.Green;
            pdfEllipseArc3.LineStyle.LineWidth = 3;
            graphicsLayoutInfo = page1.Layout(pdfEllipseArc3);

            // draw an ellipse arc with fill color and colored border line
            PdfEllipseArc pdfEllipseArc4 = new PdfEllipseArc(new System.Drawing.RectangleF(crtXPos + 220, crtYPos, 100, 60), 270, 90);
            pdfEllipseArc4.ForeColor = System.Drawing.Color.Yellow;
            graphicsLayoutInfo = page1.Layout(pdfEllipseArc4);


            // draw an ellipse slice 
            PdfEllipseSlice pdfEllipseSlice1 = new PdfEllipseSlice(new System.Drawing.RectangleF(crtXPos + 330, crtYPos, 100, 60), 0, 90);
            pdfEllipseSlice1.BackColor = System.Drawing.Color.Coral;
            graphicsLayoutInfo = page1.Layout(pdfEllipseSlice1);

            // draw an ellipse slice 
            PdfEllipseSlice pdfEllipseSlice2 = new PdfEllipseSlice(new System.Drawing.RectangleF(crtXPos + 330, crtYPos, 100, 60), 90, 90);
            pdfEllipseSlice2.BackColor = System.Drawing.Color.LightBlue;
            graphicsLayoutInfo = page1.Layout(pdfEllipseSlice2);

            // draw an ellipse slice 
            PdfEllipseSlice pdfEllipseSlice3 = new PdfEllipseSlice(new System.Drawing.RectangleF(crtXPos + 330, crtYPos, 100, 60), 180, 90);
            pdfEllipseSlice3.BackColor = System.Drawing.Color.LightGreen;
            graphicsLayoutInfo = page1.Layout(pdfEllipseSlice3);

            // draw an ellipse slice 
            PdfEllipseSlice pdfEllipseSlice4 = new PdfEllipseSlice(new System.Drawing.RectangleF(crtXPos + 330, crtYPos, 100, 60), 270, 90);
            pdfEllipseSlice4.BackColor = System.Drawing.Color.Yellow;
            graphicsLayoutInfo = page1.Layout(pdfEllipseSlice4);

            crtYPos = graphicsLayoutInfo.LastPageRectangle.Bottom + 10;

            #endregion

            #region Layout rectangles

            PdfText titleTextRectangles = new PdfText(crtXPos, crtYPos, "Rectangles:", pdfFontEmbed);
            titleTextRectangles.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextRectangles);

            // advance the Y position in the PDF page
            crtYPos = textLayoutInfo.LastPageRectangle.Bottom + 10;

            // draw a simple rectangle with solid line
            PdfRectangle pdfRectangle = new PdfRectangle(crtXPos, crtYPos, 100, 60);
            graphicsLayoutInfo = page1.Layout(pdfRectangle);

            // draw a rectangle with fill color and colored dotted border line
            PdfRectangle pdfFilledRectangle = new PdfRectangle(crtXPos + 110, crtYPos, 100, 60);
            pdfFilledRectangle.BackColor = System.Drawing.Color.WhiteSmoke;
            pdfFilledRectangle.ForeColor = System.Drawing.Color.Green;
            pdfFilledRectangle.LineStyle.LineDashPattern = PdfLineDashPattern.Dot;
            graphicsLayoutInfo = page1.Layout(pdfFilledRectangle);

            // draw a rectangle with fill color and without border line
            PdfRectangle pdfFilledNoBorderRectangle = new PdfRectangle(crtXPos + 220, crtYPos, 100, 60);
            pdfFilledNoBorderRectangle.BackColor = System.Drawing.Color.LightGreen;
            graphicsLayoutInfo = page1.Layout(pdfFilledNoBorderRectangle);

            // draw a rectangle filled with a thick border line and reounded corners
            PdfRectangle pdfThickBorderRectangle = new PdfRectangle(crtXPos + 330, crtYPos, 100, 60);
            pdfThickBorderRectangle.BackColor = System.Drawing.Color.LightSalmon;
            pdfThickBorderRectangle.ForeColor = System.Drawing.Color.LightBlue;
            pdfThickBorderRectangle.LineStyle.LineWidth = 5;
            pdfThickBorderRectangle.LineStyle.LineJoinStyle = PdfLineJoinStyle.RoundJoin;
            graphicsLayoutInfo = page1.Layout(pdfThickBorderRectangle);

            crtYPos = graphicsLayoutInfo.LastPageRectangle.Bottom + 10;

            #endregion

            #region Layout Bezier curves

            PdfText titleTextBezier = new PdfText(crtXPos, crtYPos, "Bezier curves and polygons:", pdfFontEmbed);
            titleTextBezier.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextBezier);

            // advance the Y position in the PDF page
            crtYPos = textLayoutInfo.LastPageRectangle.Bottom + 10;

            // the points controlling the Bezier curve
            System.Drawing.PointF pt1 = new System.Drawing.PointF(crtXPos, crtYPos + 50);
            System.Drawing.PointF pt2 = new System.Drawing.PointF(crtXPos + 50, crtYPos);
            System.Drawing.PointF pt3 = new System.Drawing.PointF(crtXPos + 100, crtYPos + 100);
            System.Drawing.PointF pt4 = new System.Drawing.PointF(crtXPos + 150, crtYPos + 50);

            // draw controlling points
            PdfCircle pt1Circle = new PdfCircle(pt1, 2);
            pt1Circle.BackColor = System.Drawing.Color.LightSalmon;
            page1.Layout(pt1Circle);
            PdfCircle pt2Circle = new PdfCircle(pt2, 2);
            pt2Circle.BackColor = System.Drawing.Color.LightSalmon;
            page1.Layout(pt2Circle);
            PdfCircle pt3Circle = new PdfCircle(pt3, 2);
            pt3Circle.BackColor = System.Drawing.Color.LightSalmon;
            page1.Layout(pt3Circle);
            PdfCircle pt4Circle = new PdfCircle(pt4, 2);
            pt4Circle.BackColor = System.Drawing.Color.LightSalmon;
            page1.Layout(pt4Circle);

            // draw the Bezier curve

            PdfBezierCurve bezierCurve = new PdfBezierCurve(pt1, pt2, pt3, pt4);
            bezierCurve.ForeColor = System.Drawing.Color.LightBlue;
            bezierCurve.LineStyle.LineWidth = 2;
            graphicsLayoutInfo = page1.Layout(bezierCurve);

            #endregion

            #region Layout a polygons

            // layout a polygon without fill color

            // the polygon points
            System.Drawing.PointF[] polyPoints = new System.Drawing.PointF[]{
                new System.Drawing.PointF(crtXPos + 200, crtYPos + 50),
                new System.Drawing.PointF(crtXPos + 250, crtYPos),
                new System.Drawing.PointF(crtXPos + 300, crtYPos + 50),
                new System.Drawing.PointF(crtXPos + 250, crtYPos + 100)
            };

            // draw polygon points
            foreach (System.Drawing.PointF polyPoint in polyPoints)
            {
                PdfCircle pointCircle = new PdfCircle(polyPoint, 2);
                pointCircle.BackColor = System.Drawing.Color.LightSalmon;
                page1.Layout(pointCircle);
            }

            // draw the polygon line
            PdfPolygon pdfPolygon = new PdfPolygon(polyPoints);
            pdfPolygon.ForeColor = System.Drawing.Color.LightBlue;
            pdfPolygon.LineStyle.LineWidth = 2;
            pdfPolygon.LineStyle.LineCapStyle = PdfLineCapStyle.ProjectingSquareCap;
            graphicsLayoutInfo = page1.Layout(pdfPolygon);

            // layout a polygon with fill color

            // the polygon points
            System.Drawing.PointF[] polyFillPoints = new System.Drawing.PointF[]{
                new System.Drawing.PointF(crtXPos + 330, crtYPos + 50),
                new System.Drawing.PointF(crtXPos + 380, crtYPos),
                new System.Drawing.PointF(crtXPos + 430, crtYPos + 50),
                new System.Drawing.PointF(crtXPos + 380, crtYPos + 100)
            };

            // draw a polygon with fill color and thick rounded border
            PdfPolygon pdfFillPolygon = new PdfPolygon(polyFillPoints);
            pdfFillPolygon.ForeColor = System.Drawing.Color.LightBlue;
            pdfFillPolygon.BackColor = System.Drawing.Color.LightSalmon;
            pdfFillPolygon.LineStyle.LineWidth = 5;
            pdfFillPolygon.LineStyle.LineCapStyle = PdfLineCapStyle.RoundCap;
            pdfFillPolygon.LineStyle.LineJoinStyle = PdfLineJoinStyle.RoundJoin;
            graphicsLayoutInfo = page1.Layout(pdfFillPolygon);

            #endregion

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=PdfGraphics.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                document.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.SelectNode("pdfGraphics");
            }
        }
    }
}