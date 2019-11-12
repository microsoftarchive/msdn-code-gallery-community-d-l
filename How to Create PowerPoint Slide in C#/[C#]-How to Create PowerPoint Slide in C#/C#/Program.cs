using System.Drawing;
using Spire.Presentation;
using Spire.Presentation.Drawing;
using Spire.Presentation.Drawing.Transition;

using System.IO;

namespace CreateSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation ppt = new Presentation();
            ISlide slide = ppt.Slides[0];
            SizeF pptSize=ppt.SlideSize.Size;

            //Set background
            string bgFile = "bg.jpg";
            RectangleF bgRect = new RectangleF(new PointF(0, 0), pptSize);
            slide.Shapes.AppendEmbedImage(ShapeType.Rectangle, bgFile, bgRect);

            //Add title
            RectangleF titleRect = new RectangleF(pptSize.Width / 2 - 200, 10, 400, 50);
            IAutoShape titleShape = slide.Shapes.AppendShape(ShapeType.Rectangle, titleRect);
            titleShape.Fill.FillType = FillFormatType.None;
            titleShape.ShapeStyle.LineColor.Color = Color.Empty;
            TextParagraph titlePara = titleShape.TextFrame.Paragraphs[0];
            titlePara.Text = "Microsoft PowerPoint";
            titlePara.FirstTextRange.FontHeight = 36;
            titlePara.FirstTextRange.Fill.FillType = FillFormatType.Solid;
            titlePara.FirstTextRange.Fill.SolidColor.Color = Color.Black;
            titlePara.Alignment = TextAlignmentType.Center;

            //Insert Image
            string logoFile = "logo.png";
            RectangleF logoRect = new RectangleF(pptSize.Width / 2 - 40, 60, 80, 80);
            IEmbedImage image = slide.Shapes.AppendEmbedImage(ShapeType.Rectangle, logoFile, logoRect);
            image.Line.FillType = FillFormatType.None;

            //Insert Table and apply built-in table style
            double[] widths={160, 320};
            double[] heights={15, 15, 15, 15, 15, 15, 15};
            ITable table = slide.Shapes.AppendTable(pptSize.Width / 2 - 240, 150, widths, heights);
            string[,] data = new string[,] 
            {
                {"Developer(s)", "Microsoft"},
                {"Stable Release", "2013/10,2,2012; 2 years ago"},
                {"Written In", "C++"},
                {"Operation System", "Microsoft Windows"},
                {"Type", "Presentation Program"},
                {"License", "Trialware"},
                {"Website", "http://office.microsoft.com/powerpoint"}
            };
            for(int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    table[j, i].TextFrame.Text = data[i, j];
                }
            }
            table.StylePreset = TableStylePreset.LightStyle3Accent5;

            //Add hyperlink
            ClickHyperlink hyperlink = new ClickHyperlink("http://office.microsoft.com/powerpoint");
            table[1, 6].TextFrame.TextRange.ClickAction = hyperlink;

            //Add content
            RectangleF textRect = new RectangleF(pptSize.Width / 2 - 240, 365, 480, 130);
            IAutoShape textShape = slide.Shapes.AppendShape(ShapeType.Rectangle, textRect);
            //Content format
            string text = File.ReadAllText("description.txt");
            textShape.AppendTextFrame(text);
      
            TextParagraph contentPara = textShape.TextFrame.Paragraphs[0];
            contentPara.FirstTextRange.Fill.FillType = FillFormatType.Solid;
            contentPara.FirstTextRange.Fill.SolidColor.Color = Color.Black;
            contentPara.Alignment = TextAlignmentType.Left;
            //Shape format
            textShape.ShapeStyle.LineColor.Color = Color.Empty;
            textShape.Fill.FillType = FillFormatType.Gradient;
            textShape.Fill.Gradient.GradientStops.Append(0, Color.LightBlue);
            textShape.Fill.Gradient.GradientStops.Append(1, Color.LightGreen);
            //Set footer
            ppt.SetDateTimeVisible(true);
            ppt.SetSlideNoVisible(true);

            //Set transition of slide
            slide.SlideShowTransition.Type = TransitionType.Cover;

            //Save the file
            ppt.SaveToFile("result.pptx", FileFormat.Pptx2010);     
        }
    }
}
