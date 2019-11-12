/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageBlurFilter
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        
        public MainForm()
        {
            InitializeComponent();

            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.GaussianBlur3x3);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.GaussianBlur5x5);

            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean3x3);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean5x5);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean7x7);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Mean9x9);
            
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median3x3);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median5x5);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median7x7);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median9x9);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.Median11x11);

            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur5x5);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur5x5At135Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur5x5At45Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur7x7);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur7x7At135Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur7x7At45Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur9x9);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur9x9At135Degrees);
            cmbBlurFilter.Items.Add(ExtBitmap.BlurType.MotionBlur9x9At45Degrees);

            cmbBlurFilter.SelectedIndex = 0;
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = previewBitmap;

                ApplyFilter(true);
            }
        }

        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            ApplyFilter(false);

            if (resultBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                }
            }
        }

        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null || cmbBlurFilter.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                ExtBitmap.BlurType blurType =
                    ((ExtBitmap.BlurType)cmbBlurFilter.SelectedItem);

                bitmapResult = selectedSource.ImageBlurFilter(blurType);
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    picPreview.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = bitmapResult;
                }
            }
        }

        private void FilterValueChangedEventHandler(object sender, EventArgs e)
        {
            ApplyFilter(true);
        }
    }
}
