using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Presentation;

namespace ProcessTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Spire.License.LicenseProvider.SetLicenseKey("PUILu36Ih+JDtwEAr15df+E9OHwWC9pL54zFDJvFvQaW0gyLhw7Ynog/D53EWfx4AqgfkWxQxO8XR6vHzNtTnzemNPKTf4OMd/FVxzKPnIvOjuG0c1G5v1ZtlAZb5Uv1bwM9Ar+RjvXfQnylsQJwub+b9BZwnvNzOdWqDf8lqs6YcLDC5i3ObVJ24LVWpJI+Pxl0Mrg3ccRsSH7JraWEbvCfReHJyi5JJDG2KFxLH0cyx2TiRf4Sduan6+F3ZrjgPM5A2oCYfnDbHBLFv0oX9/oRKepuLb/PuASMMySZrjxoLMdCEEqc/mFB+BW0FzLKfgNIael5geTryiN5AGWEnB5K03Dsgo+o1k++02w1WQi4qD9n28rBQMvLrCyqreqacsRlUR2CjDgR1+Wor+ZG5GNVCoXYlY3MOY1oKbuAHy3VqgAeAwAdaHmHYrwXI/x4l+tIfnJWjiePqRa41je6KE2fDC4gboDMJlq1dk5Bdyzpe1HHe2IsZffg4eUvEfIPQTIIRtQdS4ynsUAirIBSGZGOD18vW/v1HJAUCkt/Dddxp+csS14i/OmUG4JddryhLRufFVkFk9wpQfiPjNXm/CI9eq22igO5I2Z3MNvAFV5EKvtJ9xy3eV4+w/1iZRtOU9OQYv7dSKXsfFflAVxjgDM0JjVQphsqHbarbs88LAO02P4G1wB36evbA8n/HAQTJvFtb6XpiI1mA9/XNnWS72rzVD69MBSZWelJWXvb6dnHI0CTdPVGpKDyZnI9fmpmvq+Yc7fjtC+P1rGtpLls3FiHR16s0fidh9uFJquJe0DXlFVR5Nk9oh5fMOpov9Bsy3G9UM3VpMS//UNx1LENKqz9lx7niE26gIM907h0ihSFiMgq8uU9s1+y44mNE2lNMD9ykQG5mK0WP8BzU2aoX9/T45ERldOSXm+dn6dTtHngaNfN7LgdXtcQYW0/2hLz3xJli9x7PL5R/iFTUufW0KgGMQOu4OBi/j8lTFROcR/lGI3rjhg5IWWy6cO+mGAXiJKdmtXWeWTdCfpu//RyBZtiGqFu1Z0m7bQzrFVGTB9MLuWJqVXM5UekXbEGK7ksxadKjx9cSwZapRHAh2gJp7eMvk160AAl3AleXyLC0f8fBSyzQFnvioAxwsATdbjxThZk/Pt1Zu/uOG1Dnul8wm90I9DYpcOaWW6okYEHQf37GmnkOYW2VVDOw/7YXw2nxTri1JrNlqw8E+9XXx779IzZcsX0XU71E7qqHWxP5JfRlSm4f2d+oS3alGhvduH7Y/PF08a8hhBSnznDziJeoYVjd+ZwT2uZ46ZGqcri2e10/x9OfjSoYDQn2JFG72dJLwmh/so0jkcjroDdWTLWqKZp5uTU3Xd0IoRCWyw7/k5cIBrV5qMaiNwtQWptH8KaeBbdqoxZqHWJdIjO+JMAIKTTAA8ZOHA1lEOkxjMYZnJtSVqxCGC+2fagkaANoZAv");

            //create Presentation instance and load file
            Presentation presentation = new Presentation();
            presentation.LoadFromFile(@"..\..\table.pptx");

            ITable table = null;

            //A: traversal in table
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is ITable)
                {
                    table = (ITable)shape;

                    //traverse through the cells of table
                    foreach (TableRow row in table.TableRows)
                    {
                        foreach (Cell cell in row)
                        {
                            //print the data in cell
                            Console.Write("{0,15}", cell.TextFrame.Text);
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();

            //B: remove row and column
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is ITable)
                {
                    table = (ITable)shape;

                    //remove the second row
                    table.TableRows.RemoveAt(1,false);

                    //remove the second column
                    table.ColumnsList.RemoveAt(1,false);

                }
            }
            presentation.SaveToFile(@"../../result_remove.pptx",FileFormat.Pptx2010);

            //C: remove all tables in PowerPoint document

            //get the tables in PowerPoint document
            List<IShape> shape_tems = new List<IShape>();
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is ITable)
                {
                    //add new table to table list
                    shape_tems.Add(shape);
                }
            }

            //remove all tables
            foreach (IShape shape in shape_tems)
            {
                presentation.Slides[0].Shapes.Remove(shape);
            }

            //save the document
            presentation.SaveToFile(@"..\..\result_all.pptx", FileFormat.Pptx2010);
        }
    }
}
