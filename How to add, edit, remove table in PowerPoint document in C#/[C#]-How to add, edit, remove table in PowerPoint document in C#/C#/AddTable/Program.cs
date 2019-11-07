using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Spire.Presentation;

namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            Spire.License.LicenseProvider.SetLicenseKey("PUILu36Ih+JDtwEAr15df+E9OHwWC9pL54zFDJvFvQaW0gyLhw7Ynog/D53EWfx4AqgfkWxQxO8XR6vHzNtTnzemNPKTf4OMd/FVxzKPnIvOjuG0c1G5v1ZtlAZb5Uv1bwM9Ar+RjvXfQnylsQJwub+b9BZwnvNzOdWqDf8lqs6YcLDC5i3ObVJ24LVWpJI+Pxl0Mrg3ccRsSH7JraWEbvCfReHJyi5JJDG2KFxLH0cyx2TiRf4Sduan6+F3ZrjgPM5A2oCYfnDbHBLFv0oX9/oRKepuLb/PuASMMySZrjxoLMdCEEqc/mFB+BW0FzLKfgNIael5geTryiN5AGWEnB5K03Dsgo+o1k++02w1WQi4qD9n28rBQMvLrCyqreqacsRlUR2CjDgR1+Wor+ZG5GNVCoXYlY3MOY1oKbuAHy3VqgAeAwAdaHmHYrwXI/x4l+tIfnJWjiePqRa41je6KE2fDC4gboDMJlq1dk5Bdyzpe1HHe2IsZffg4eUvEfIPQTIIRtQdS4ynsUAirIBSGZGOD18vW/v1HJAUCkt/Dddxp+csS14i/OmUG4JddryhLRufFVkFk9wpQfiPjNXm/CI9eq22igO5I2Z3MNvAFV5EKvtJ9xy3eV4+w/1iZRtOU9OQYv7dSKXsfFflAVxjgDM0JjVQphsqHbarbs88LAO02P4G1wB36evbA8n/HAQTJvFtb6XpiI1mA9/XNnWS72rzVD69MBSZWelJWXvb6dnHI0CTdPVGpKDyZnI9fmpmvq+Yc7fjtC+P1rGtpLls3FiHR16s0fidh9uFJquJe0DXlFVR5Nk9oh5fMOpov9Bsy3G9UM3VpMS//UNx1LENKqz9lx7niE26gIM907h0ihSFiMgq8uU9s1+y44mNE2lNMD9ykQG5mK0WP8BzU2aoX9/T45ERldOSXm+dn6dTtHngaNfN7LgdXtcQYW0/2hLz3xJli9x7PL5R/iFTUufW0KgGMQOu4OBi/j8lTFROcR/lGI3rjhg5IWWy6cO+mGAXiJKdmtXWeWTdCfpu//RyBZtiGqFu1Z0m7bQzrFVGTB9MLuWJqVXM5UekXbEGK7ksxadKjx9cSwZapRHAh2gJp7eMvk160AAl3AleXyLC0f8fBSyzQFnvioAxwsATdbjxThZk/Pt1Zu/uOG1Dnul8wm90I9DYpcOaWW6okYEHQf37GmnkOYW2VVDOw/7YXw2nxTri1JrNlqw8E+9XXx779IzZcsX0XU71E7qqHWxP5JfRlSm4f2d+oS3alGhvduH7Y/PF08a8hhBSnznDziJeoYVjd+ZwT2uZ46ZGqcri2e10/x9OfjSoYDQn2JFG72dJLwmh/so0jkcjroDdWTLWqKZp5uTU3Xd0IoRCWyw7/k5cIBrV5qMaiNwtQWptH8KaeBbdqoxZqHWJdIjO+JMAIKTTAA8ZOHA1lEOkxjMYZnJtSVqxCGC+2fagkaANoZAv");

            //create PPT document
            Presentation presentation = new Presentation();

            //set background Image
            string ImageFile = @"..\..\bg.png";
            RectangleF rect = new RectangleF(0, 0, presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height);
            presentation.Slides[0].Shapes.AppendEmbedImage(ShapeType.Rectangle, ImageFile, rect);
            presentation.Slides[0].Shapes[0].Line.FillFormat.SolidFillColor.Color = Color.FloralWhite;

            //add new table to PPT
            Double[] widths = new double[] { 100, 100, 150, 100, 100 };
            Double[] heights = new double[] { 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15 };

            ITable table = presentation.Slides[0].Shapes.AppendTable(presentation.SlideSize.Size.Width / 2 - 275, 90, widths, heights);

            String[,] dataStr = new String[,]{
            {"Name",	"Capital",	"Continent",	"Area",	"Population"},
            {"Venezuela",	"Caracas",	"South America",	"912047",	"19700000"},
            {"Bolivia",	"La Paz",	"South America",	"1098575",	"7300000"},
            {"Brazil",	"Brasilia",	"South America",	"8511196",	"150400000"},
            {"Canada",	"Ottawa",	"North America",	"9976147",	"26500000"},
            {"Chile",	"Santiago",	"South America",	"756943",	"13200000"},
            {"Colombia",	"Bagota",	"South America",	"1138907",	"33000000"},
            {"Cuba",	"Havana",	"North America",	"114524",	"10600000"},
            {"Ecuador",	"Quito",	"South America",	"455502",	"10600000"},
            {"Paraguay",	"Asuncion","South America", "406576",	"4660000"},
            {"Peru",	"Lima",	"South America",	"1285215",	"21600000"},
            {"Jamaica",	"Kingston",	"North America",	"11424",	"2500000"},
            {"Mexico",	"Mexico City",	"North America",	"1967180",	"88600000"}
            };

            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 5; j++)
                {
                    //fill the table with data
                    table[j, i].TextFrame.Text = dataStr[i, j];

                    //set the Font
                    table[j, i].TextFrame.Paragraphs[0].TextRanges[0].LatinFont = new TextFont("Arial Narrow");
                }

            //set the alignment of the first row to Center
            for (int i = 0; i < 5; i++)
            {
                table[i, 0].TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Center;
            }

            //set the style of table
            table.StylePreset = TableStylePreset.LightStyle1Accent1;

            //save the document
            presentation.SaveToFile(@"..\..\table.pptx", FileFormat.Pptx2010);
            System.Diagnostics.Process.Start(@"..\..\table.pptx");
        }
    }
}
