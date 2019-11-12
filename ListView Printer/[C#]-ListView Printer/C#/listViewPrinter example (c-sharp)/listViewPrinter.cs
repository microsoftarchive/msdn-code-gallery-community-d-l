using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace WindowsFormsApplication1
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class listViewPrinter
    {

        private ListView lv;
        private Point location;
        private Boolean border ;
        private Boolean hasGroups;
        private string title;
        private int titleHeight;

        private PrintDocument pd = new PrintDocument();

        public listViewPrinter(ListView lv, Point location, bool border, bool hasGroups, string title)
        {
	        this.lv = lv;
	        this.location = location;
	        this.border = border;
	        this.hasGroups = hasGroups;
	        this.title = title;
	        titleHeight = !string.IsNullOrEmpty(title) ? lv.FindForm().CreateGraphics().MeasureString(title, new Font(lv.Font.Name, 25)).ToSize().Height : 0;
            pd.BeginPrint += pd_BeginPrint;
            pd.PrintPage += pd_PrintPage;
        }

        public void print()
        {
            //pd.Print()
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        /// <summary>
        /// structure to hold printed page details
        /// </summary>
        /// <remarks></remarks>
        private struct pageDetails
        {
            public int columns;
            public int rows;
            public int startCol;
            public int startRow;
            public List<int> headerIndices;
        }
        /// <summary>
        /// dictionary to hold printed page details, with index key
        /// </summary>
        /// <remarks></remarks>

        private Dictionary<int, pageDetails> pages;
        int maxPagesWide;

        int maxPagesTall;

        ListViewItem[] items;

        /// <summary>
        /// the majority of this Sub is calculating printed page ranges
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void pd_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
	{
		//'this removes the printed page margins
		pd.OriginAtMargins = true;
        pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(location.X, location.X, location.Y, location.Y);

		pages = new Dictionary<int, pageDetails>();

        int maxWidth = Convert.ToInt32(pd.DefaultPageSettings.PrintableArea.Width) - (pd.DefaultPageSettings.Margins.Left + pd.DefaultPageSettings.Margins.Right + 40);
        int maxHeight = Convert.ToInt32(pd.DefaultPageSettings.PrintableArea.Height - (titleHeight + 12)) - (pd.DefaultPageSettings.Margins.Top + pd.DefaultPageSettings.Margins.Bottom + 40);

		int pageCounter = 0;
		pages.Add(pageCounter, new pageDetails { headerIndices = new List<int>() });

		int columnCounter = 0;

		int columnSum = 0;

		for (int c = 0; c <= lv.Columns.Count - 1; c++) {
			if (columnSum + lv.Columns[c].Width < maxWidth) {
                columnSum += lv.Columns[c].Width;
				columnCounter += 1;
			} else {
				pages[pageCounter] = new pageDetails {
					columns = columnCounter,
					rows = 0,
					startCol = pages[pageCounter].startCol,
					headerIndices = pages[pageCounter].headerIndices
				};
                columnSum = lv.Columns[c].Width;
				columnCounter = 1;
				pageCounter += 1;
				pages.Add(pageCounter, new pageDetails {
					startCol = c,
					headerIndices = new List<int>()
				});
			}
			if (c == lv.Columns.Count - 1) {
				if (pages[pageCounter].columns == 0) {
					pages[pageCounter] = new pageDetails {
						columns = columnCounter,
						rows = 0,
						startCol = pages[pageCounter].startCol,
						headerIndices = pages[pageCounter].headerIndices
					};
				}
			}
		}

		maxPagesWide = pages.Keys.Max() + 1;

		pageCounter = 0;

		int rowCounter = 0;
		int counter = 0;

		int itemHeight = lv.GetItemRect(0).Height;

		int rowSum = itemHeight;

        if (hasGroups)
        {
            for (int g = 0; g <= lv.Groups.Count - 1; g++)
            {
                rowSum += itemHeight + 6;
                pages[pageCounter].headerIndices.Add(counter);
                for (int r = 0; r <= lv.Groups[g].Items.Count - 1; r++)
                {
                    counter += 1;
                    if (rowSum + itemHeight < maxHeight)
                    {
                        rowSum += itemHeight;
                        rowCounter += 1;
                    }
                    else
                    {
                        pages[pageCounter] = new pageDetails
                        {
                            columns = pages[pageCounter].columns,
                            rows = rowCounter,
                            startCol = pages[pageCounter].startCol,
                            startRow = pages[pageCounter].startRow,
                            headerIndices = pages[pageCounter].headerIndices
                        };
                        for (int x = 1; x <= maxPagesWide - 1; x++)
                        {
                            pages[pageCounter + x] = new pageDetails
                            {
                                columns = pages[pageCounter + x].columns,
                                rows = rowCounter,
                                startCol = pages[pageCounter + x].startCol,
                                startRow = pages[pageCounter].startRow,
                                headerIndices = pages[pageCounter].headerIndices
                            };
                        }

                        pageCounter += maxPagesWide;
                        for (int x = 0; x <= maxPagesWide - 1; x++)
                        {
                            pages.Add(pageCounter + x, new pageDetails
                            {
                                columns = pages[x].columns,
                                rows = 0,
                                startCol = pages[x].startCol,
                                startRow = counter - 1,
                                headerIndices = new List<int>()
                            });
                        }

                        rowSum = itemHeight * 2 + itemHeight + 6;
                        rowCounter = 1;
                    }
                    if (counter == lv.Items.Count)
                    {
                        for (int x = 0; x <= maxPagesWide - 1; x++)
                        {
                            if (pages[pageCounter + x].rows == 0)
                            {
                                pages[pageCounter + x] = new pageDetails
                                {
                                    columns = pages[pageCounter + x].columns,
                                    rows = rowCounter,
                                    startCol = pages[pageCounter + x].startCol,
                                    startRow = pages[pageCounter + x].startRow,
                                    headerIndices = pages[pageCounter + x].headerIndices
                                };
                            }
                        }
                    }
                }
            }
        }
        else
        {
            for (int r = 0; r <= lv.Items.Count - 1; r++)
            {
                counter += 1;
                if (rowSum + itemHeight < maxHeight)
                {
                    rowSum += itemHeight;
                    rowCounter += 1;
                }
                else
                {
                    pages[pageCounter] = new pageDetails
                    {
                        columns = pages[pageCounter].columns,
                        rows = rowCounter,
                        startCol = pages[pageCounter].startCol,
                        startRow = pages[pageCounter].startRow
                    };
                    for (int x = 1; x <= maxPagesWide - 1; x++)
                    {
                        pages[pageCounter + x] = new pageDetails
                        {
                            columns = pages[pageCounter + x].columns,
                            rows = rowCounter,
                            startCol = pages[pageCounter + x].startCol,
                            startRow = pages[pageCounter].startRow
                        };
                    }

                    pageCounter += maxPagesWide;
                    for (int x = 0; x <= maxPagesWide - 1; x++)
                    {
                        pages.Add(pageCounter + x, new pageDetails
                        {
                            columns = pages[x].columns,
                            rows = 0,
                            startCol = pages[x].startCol,
                            startRow = counter - 1
                        });
                    }

                    rowSum = itemHeight * 2;
                    rowCounter = 1;
                }
                if (counter == lv.Items.Count)
                {
                    for (int x = 0; x <= maxPagesWide - 1; x++)
                    {
                        if (pages[pageCounter + x].rows == 0)
                        {
                            pages[pageCounter + x] = new pageDetails
                            {
                                columns = pages[pageCounter + x].columns,
                                rows = rowCounter,
                                startCol = pages[pageCounter + x].startCol,
                                startRow = pages[pageCounter + x].startRow
                            };
                        }
                    }
                }
            }

        }

		maxPagesTall = pages.Count / maxPagesWide;

        if (hasGroups)
        {
            items = new ListViewItem[] { };
            foreach (ListViewGroup g in lv.Groups)
            {
                items = items.Concat(g.Items.Cast<ListViewItem>().ToArray()).ToArray();
            }
        }
        else
        {
            items = lv.Items.Cast<ListViewItem>().ToArray();
        }

	}
        int startPage = 0;

        //int static_pd_PrintPage_startPage;
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Rectangle r2 = new Rectangle(location, new Size(lv.Columns.Cast<ColumnHeader>().Skip(pages[0].startCol).Take(pages[0].columns).Sum((ColumnHeader ch) => ch.Width), titleHeight));

            e.Graphics.DrawString(title, new Font(lv.Font.Name, 25), Brushes.Black, r2, sf);

            sf.Alignment = StringAlignment.Near;

            int startX = location.X;
            int startY = location.Y + titleHeight + 12;
            
            int itemHeight = lv.GetItemRect(0).Height;

            Point bottomRight;

            for (int p = startPage; p <= pages.Count - 1; p++)
            {
                startX = location.X;
                startY = location.Y + titleHeight + 12;

                Rectangle cell = default(Rectangle);

                for (int c = pages[p].startCol; c <= pages[p].startCol + pages[p].columns - 1; c++)
                {
                    cell = new Rectangle(startX, startY, lv.Columns[c].Width, itemHeight);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight), cell);
                    e.Graphics.DrawRectangle(Pens.Black, cell);
                    e.Graphics.DrawString(lv.Columns[c].Text, lv.Font, Brushes.Black, cell, sf);
                    startX += lv.Columns[c].Width;
                }

                startY += itemHeight;
                startX = location.X;

                for (int r = pages[p].startRow; r <= pages[p].startRow + pages[p].rows - 1; r++)
                {
                    startX = location.X;
                    if (hasGroups)
                    {
                        if (r == pages[p].startRow | pages[p].headerIndices.Contains(r))
                        {
                            cell = new Rectangle(startX + 20, startY + 6, lv.Columns.Cast<ColumnHeader>().Skip(pages[p].startCol).Take(pages[p].columns).Sum((ColumnHeader ch) => ch.Width), itemHeight);
                            e.Graphics.DrawString(items[r].Group.Header, new Font(lv.Font, FontStyle.Bold), Brushes.SteelBlue, cell, sf);
                            e.Graphics.DrawLine(new Pen(Color.SteelBlue, 2), startX + 20 + e.Graphics.MeasureString(items[r].Group.Header, new Font(lv.Font, FontStyle.Bold)).Width + 12, cell.Top + 3 + cell.Height / 2, cell.Right - 20, cell.Top + 3 + cell.Height / 2);
                            startY += itemHeight + 6;
                        }
                    }
                    for (int c = pages[p].startCol; c <= pages[p].startCol + pages[p].columns - 1; c++)
                    {
                        cell = new Rectangle(startX, startY, lv.Columns[c].Width, itemHeight);
                        e.Graphics.DrawString(items[r].SubItems[c].Text, lv.Font, Brushes.Black, cell, sf);
                        if(lv.GridLines){ 
                            e.Graphics.DrawRectangle(Pens.Black, cell);
                        }
                        startX += lv.Columns[c].Width;
                    }
                    startY += itemHeight;
                    if (r == pages[p].startRow + pages[p].rows - 1)
                    {
                        bottomRight = new Point(startX, startY);
                        if(border){
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(location, new Size(bottomRight.X - location.X, bottomRight.Y - location.Y)));
                        }
                    }
                
                }

                if (p != pages.Count - 1)
                {
                    startPage = p + 1;
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    startPage = 0;
                }

            }

        }
        //static bool InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
        //{
        //    if (flag.State == 0)
        //    {
        //        flag.State = 2;
        //        return true;
        //    }
        //    else if (flag.State == 2)
        //    {
        //        throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }

}
