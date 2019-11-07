using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace ExtendedDataGridView
{

    public class Printer
	{

		List<Bitmap> portraitPages = new List<Bitmap>();
		List<Bitmap> landScapePages = new List<Bitmap>();

		List<Bitmap> Pages;
		private PrintDocument document = new PrintDocument();
			
		int pageIndex = 0;
		int copyIndex = 1;
		bool Collate;
		int Copies;
		bool Landscape;
		int FromPage;
		int ToPage;

        public Printer()
        {
            document.PrintPage += document_PrintPage;
        }

		//*
		//     * Creates a List of printed page images
		//     * both for use in the preview form and for printing
		//     
		public List<Bitmap> getPages(DataGridView mainTable, bool includeRowHeaders, bool includeColumnHeaders, bool includeHiddenColumns, bool portrait)
		{
			mainTable.EndEdit();

			List<Bitmap> pageImages = new List<Bitmap>();

			int startColumn = 0;
			int startRow = 0;
			int lastColumn = -1;
			int lastRow = -1;

			Font ulFont = new Font(mainTable.Font, mainTable.Font.Style | FontStyle.Underline);

			while (true) {
				//612, 792
				double sumX = (includeRowHeaders ? mainTable.RowHeadersWidth : 0);
				List<xC> xCoordinates = new List<xC>();

				for (int x = startColumn; x <= mainTable.ColumnCount - 1; x++) {
					if (!mainTable.Columns[x].Visible & !includeHiddenColumns) {
						xCoordinates.Add(new xC(0, 0));
						continue;
					}
					if ((sumX + mainTable.Columns[x].Width) < (portrait ? 765 : 1060)) {
						xCoordinates.Add(new xC(Convert.ToInt32(sumX), mainTable.Columns[x].Width));
						sumX += mainTable.Columns[x].Width;
						if (x == mainTable.ColumnCount - 1) {
							lastColumn = x;
						}
					} else {
						lastColumn = x - 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				double sumY = (includeColumnHeaders ? mainTable.ColumnHeadersHeight : 0);
				List<yC> yCoordinates = new List<yC>();

				for (int y = startRow; y <= mainTable.RowCount - 1; y++) {
					if ((sumY + mainTable.Rows[y].Height) < (portrait ? 1015 : 765)) {
						yCoordinates.Add(new yC(Convert.ToInt32(sumY), mainTable.Rows[y].Height));
						sumY += mainTable.Rows[y].Height;
						if (y == mainTable.RowCount - 1) {
							lastRow = y;
						}
					} else {
						lastRow = y - 1;
						break;
					}
				}

				Bitmap img = null;
				if (portrait) {
					img = new Bitmap(850, 1100);
				} else {
					img = new Bitmap(1100, 850);
				}
				Graphics g = Graphics.FromImage(img);

				g.Clear(Color.White);
				g.TranslateTransform(20, 20);

				// get metrics from the graphics
				//Dim metrics As SizeF = g2d.getFontMetrics(mainTable.getFont())
				//Dim height As Integer = metrics.getHeight()
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;

				SolidBrush brush = new SolidBrush(mainTable.ColumnHeadersDefaultCellStyle.BackColor);

				if (includeColumnHeaders) {
					for (int x = startColumn; x <= lastColumn; x++) {
						if (!mainTable.Columns[x].Visible & !includeHiddenColumns) {
							continue;
						}
						Rectangle r = new Rectangle(xCoordinates[x - startColumn].X, 0, xCoordinates[x - startColumn].Width, mainTable.ColumnHeadersHeight);
						g.FillRectangle(brush, r);
						g.DrawRectangle(Pens.DarkGray, r);

						bool b = false;
						if (mainTable.Columns[x].HeaderCell is checkAllHeaderCell || mainTable.Columns[x].HeaderCell is checkHideColumnHeaderCell) {
							if (mainTable.Columns[x].HeaderCell is checkAllHeaderCell) {
								checkAllHeaderCell hc = (checkAllHeaderCell)mainTable.Columns[x].HeaderCell;
								b = hc.isChecked;
							} else if (mainTable.Columns[x].HeaderCell is checkHideColumnHeaderCell) {
								checkHideColumnHeaderCell hc = (checkHideColumnHeaderCell)mainTable.Columns[x].HeaderCell;
								b = hc.isChecked;
							}
							Point l = new Point(r.Width - 18, 5);
							CheckBoxRenderer.DrawCheckBox(g, new Point(r.X + l.X, l.Y), b ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
						}

						r.Inflate(-2, -2);
						g.DrawString(mainTable.Columns[x].HeaderText, mainTable.Font, Brushes.Black, r, sf);
					}
				}

				if (includeRowHeaders) {
					for (int y = startRow - 1; y <= lastRow; y++) {
						if (y == startRow - 1) {
							Rectangle r = new Rectangle(0, 0, mainTable.RowHeadersWidth, mainTable.ColumnHeadersHeight);
							g.FillRectangle(brush, r);
							g.DrawRectangle(Pens.DarkGray, r);
						} else {
							Rectangle r = new Rectangle(0, yCoordinates[y - startRow].Y, mainTable.RowHeadersWidth, yCoordinates[y - startRow].Height);
							g.FillRectangle(brush, r);
							g.DrawRectangle(Pens.DarkGray, r);
							r.Inflate(-2, -2);
							object o = mainTable.Rows[y].HeaderCell.Value;
							g.DrawString(o != null ? o.ToString() : "", mainTable.Font, Brushes.Black, r, sf);
						}
					}
				}

				for (int x = startColumn; x <= lastColumn; x++) {
					if (!mainTable.Columns[x].Visible & !includeHiddenColumns) {
						continue;
					}
					for (int y = startRow; y <= lastRow; y++) {
						Rectangle r = new Rectangle(xCoordinates[x - startColumn].X, yCoordinates[y - startRow].Y, xCoordinates[x - startColumn].Width, yCoordinates[y - startRow].Height);
						Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width, r.Height);
						r2.Inflate(-2, -2);

						//DataGridViewButtonColumn
						//DataGridViewCheckBoxColumn
						//DataGridViewComboBoxColumn
						//DataGridViewImageColumn
						//DataGridViewLinkColumn
						//DataGridViewTextBoxColumn
						if (mainTable[x, y] is DataGridViewTextBoxCell) {
							if (!mainTable[x, y].Style.BackColor.Equals(Color.Empty)) {
								g.FillRectangle(new SolidBrush(mainTable[x, y].Style.BackColor), r);
							} else {
								if (!mainTable[x, y].OwningColumn.DefaultCellStyle.BackColor.Equals(Color.Empty)) {
									g.FillRectangle(new SolidBrush(mainTable[x, y].OwningColumn.DefaultCellStyle.BackColor), r);
								}
								if (!mainTable[x, y].OwningRow.DefaultCellStyle.BackColor.Equals(Color.Empty)) {
									g.FillRectangle(new SolidBrush(mainTable[x, y].OwningRow.DefaultCellStyle.BackColor), r);
								}
								if (!mainTable.AlternatingRowsDefaultCellStyle.BackColor.Equals(Color.Empty) && y % 2 == 1) {
									g.FillRectangle(new SolidBrush(mainTable.AlternatingRowsDefaultCellStyle.BackColor), r);
								}
							}

							string cellValue = "";
							if (mainTable[x, y].Value != null) {
								cellValue = mainTable[x, y].Value.ToString();
								g.DrawString(cellValue, mainTable.Font, Brushes.Black, r2, sf);
							}
						} else if (mainTable[x, y] is DataGridViewLinkCell) {
							if (!mainTable[x, y].Style.BackColor.Equals(Color.Empty)) {
								g.FillRectangle(new SolidBrush(mainTable[x, y].Style.BackColor), r);
							} else {
								if (!mainTable[x, y].OwningColumn.DefaultCellStyle.BackColor.Equals(Color.Empty)) {
									g.FillRectangle(new SolidBrush(mainTable[x, y].OwningColumn.DefaultCellStyle.BackColor), r);
								}
								if (!mainTable[x, y].OwningRow.DefaultCellStyle.BackColor.Equals(Color.Empty)) {
									g.FillRectangle(new SolidBrush(mainTable[x, y].OwningRow.DefaultCellStyle.BackColor), r);
								}
								if (!mainTable.AlternatingRowsDefaultCellStyle.BackColor.Equals(Color.Empty) && y % 2 == 1) {
									g.FillRectangle(new SolidBrush(mainTable.AlternatingRowsDefaultCellStyle.BackColor), r);
								}
							}

							string cellValue = "";
							if (mainTable[x, y].Value != null) {
								cellValue = mainTable[x, y].Value.ToString();
								Color c = ((DataGridViewLinkCell)mainTable[x, y]).LinkVisited ? Color.Purple : Color.Blue;
								g.DrawString(cellValue, ulFont, new SolidBrush(c), r2, sf);
							}
						} else if (mainTable[x, y] is DataGridViewComboBoxCell) {
							ComboBoxRenderer.DrawDropDownButton(g, new Rectangle(r.X + r.Width - 16, r.Top, 16, r.Height), System.Windows.Forms.VisualStyles.ComboBoxState.Normal);
							string cellValue = "";
							if (mainTable[x, y].Value != null) {
								cellValue = mainTable[x, y].Value.ToString();
								g.DrawString(cellValue, mainTable.Font, Brushes.Black, r2, sf);
							}
						} else if (mainTable[x, y] is DataGridViewCheckBoxCell) {
							if (!mainTable[x, y].Style.BackColor.Equals(Color.Empty)) {
								g.FillRectangle(new SolidBrush(mainTable[x, y].Style.BackColor), r);
							} else {
								if (!mainTable[x, y].OwningColumn.DefaultCellStyle.BackColor.Equals(Color.Empty)) {
									g.FillRectangle(new SolidBrush(mainTable[x, y].OwningColumn.DefaultCellStyle.BackColor), r);
								}
								if (!mainTable[x, y].OwningRow.DefaultCellStyle.BackColor.Equals(Color.Empty)) {
									g.FillRectangle(new SolidBrush(mainTable[x, y].OwningRow.DefaultCellStyle.BackColor), r);
								}
								if (!mainTable.AlternatingRowsDefaultCellStyle.BackColor.Equals(Color.Empty) && y % 2 == 1) {
									g.FillRectangle(new SolidBrush(mainTable.AlternatingRowsDefaultCellStyle.BackColor), r);
								}
							}

							bool b = false;
							if (bool.TryParse(mainTable[x, y].FormattedValue.ToString(), out b) && b) {
								CheckBoxRenderer.DrawCheckBox(g, new Point(r.Left + Convert.ToInt32((r.Width - 12) / 2), r.Top + Convert.ToInt32((r.Height - 12) / 2)), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
							} else {
								CheckBoxRenderer.DrawCheckBox(g, new Point(r.Left + Convert.ToInt32((r.Width - 12) / 2), r.Top + Convert.ToInt32((r.Height - 12) / 2)), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
							}
						} else if (mainTable[x, y] is DataGridViewButtonCell) {
							ButtonRenderer.DrawButton(g, r2, System.Windows.Forms.VisualStyles.PushButtonState.Normal);
							sf.Alignment = StringAlignment.Center;
							object o = mainTable[x, y].Value;
							if (o != null) {
								g.DrawString(o.ToString(), mainTable.Font, Brushes.Black, r2, sf);
							}
						} else if (mainTable[x, y] is DataGridViewImageCell) {
							if (y != mainTable.NewRowIndex) {
								if ((mainTable[x, y].Value != null)) {
									g.DrawImage((Bitmap)mainTable[x, y].FormattedValue, r);
								}
							}
						}
						g.DrawRectangle(Pens.DarkGray, r);
					}
				}

				String footer = "Page " + (pageImages.Count() + 1).ToString();
				int textWidth = TextRenderer.MeasureText(footer, mainTable.Font).Width;
				g.DrawString(footer, mainTable.Font, Brushes.Black, Convert.ToSingle((img.Width - textWidth) / 2) - 20, Convert.ToSingle(img.Height - 85));

				pageImages.Add(img);

				if (lastColumn < mainTable.ColumnCount - 1) {
					startColumn = lastColumn + 1;
				} else {
					if (lastRow < mainTable.RowCount - 1) {
						startColumn = 0;
						startRow = lastRow + 1;
					} else {
						break; // TODO: might not be correct. Was : Exit While
					}
				}
			}

			return pageImages;

		}

		public void startPrint(DataGridView mainTable, bool includeRowHeaders, bool includeColumnHeaders, bool includeHiddenColumns, bool preview)
		{
			portraitPages = getPages(mainTable, includeRowHeaders, includeColumnHeaders, includeHiddenColumns, true);
			landScapePages = getPages(mainTable, includeRowHeaders, includeColumnHeaders, includeHiddenColumns, false);

			document.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
			document.OriginAtMargins = true;

			altPrintDialog frm = new altPrintDialog(document, portraitPages.Count, landScapePages.Count);

			if (frm.ShowDialog() == DialogResult.OK) {
				Collate = document.PrinterSettings.Collate;
				Copies = document.PrinterSettings.Copies;
				Landscape = document.DefaultPageSettings.Landscape;
				FromPage = document.PrinterSettings.FromPage;
				ToPage = document.PrinterSettings.ToPage;
				document.PrinterSettings.PrintRange = PrintRange.SomePages;

				pageIndex = FromPage - 1;
				copyIndex = 1;
				if (Landscape) {
					Pages = landScapePages;
				} else {
					Pages = portraitPages;
				}
				//
				if (preview) {
					PrintPreviewDialog ppd = new PrintPreviewDialog();
					ppd.Document = document;
					ppd.WindowState = FormWindowState.Maximized;
					ppd.ShowDialog();
				} else {
					document.Print();
				}
			}

		}


		private void document_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(Pages[pageIndex], e.MarginBounds);

			if (!Collate) {
				copyIndex += 1;
				if (copyIndex > Copies) {
					pageIndex += 1;
					if (pageIndex < ToPage) {
						copyIndex = 1;
						e.HasMorePages = true;
					}
				} else {
					e.HasMorePages = true;
				}
			} else {
				pageIndex += 1;
				if (pageIndex == ToPage) {
					copyIndex += 1;
					pageIndex = FromPage - 1;
					if (copyIndex <= Copies) {
						e.HasMorePages = true;
					}
				} else {
					e.HasMorePages = true;
				}
			}

		}

	}
}
