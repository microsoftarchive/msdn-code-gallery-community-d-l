using System;
using System.Windows.Forms;

// add PowerPoint namespace
using PPt = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;

namespace AutomationControlPPT
{
    // Automate control PowerPint Slides
    // Note here:Control operation is different in normal view with reading view, 
    // Reference information：http://msdn.microsoft.com/en-us/library/bb251394(v=office.12).aspx
    //http://support.microsoft.com/kb/316126 
    // http://www.codeproject.com/Questions/73414/Getting-Running-Instance-of-Powerpoint-in-C
    public partial class MainForm : Form
    {
        // Define PowerPoint Application object
        PPt.Application pptApplication;
        // Define Presentation object
        PPt.Presentation presentation;
        // Define Slide collection
        PPt.Slides slides;
        PPt.Slide slide;

        // Slide count
        int slidescount;
        // slide index
        int slideIndex;

        public MainForm()
        {
            InitializeComponent();

            // Set Control button disable
            this.btnFirst.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnPrev.Enabled = false;
            this.btnLast.Enabled = false;
        }

        /// <summary>
        /// Check whether PowerPoint is running 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // Get Running PowerPoint Application object
                pptApplication = Marshal.GetActiveObject("PowerPoint.Application") as PPt.Application;

                // Get PowerPoint application successfully, then set control button enable
                this.btnFirst.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnPrev.Enabled = true;
                this.btnLast.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Please Run PowerPoint Firstly", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            if (pptApplication != null)
            {
                // Get Presentation Object
                presentation = pptApplication.ActivePresentation;
                // Get Slide collection object
                slides = presentation.Slides;
                // Get Slide count
                slidescount = slides.Count;
                // Get current selected slide 
                try
                {
                    // Get selected slide object in normal view
                    slide = slides[pptApplication.ActiveWindow.Selection.SlideRange.SlideNumber];
                }
                catch
                {
                    // Get selected slide object in reading view
                    slide = pptApplication.SlideShowWindows[1].View.Slide;
                }
            }
        }

        // Transform to First Page
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                // Call Select method to select first slide in normal view
                slides[1].Select();
                slide = slides[1];
            }
            catch
            {
                // Transform to first page in reading view
                pptApplication.SlideShowWindows[1].View.First();
                slide = pptApplication.SlideShowWindows[1].View.Slide;
            }
        }

        // Transform to Last Page
        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                slides[slidescount].Select();
                slide = slides[slidescount];
            }
            catch
            {
                pptApplication.SlideShowWindows[1].View.Last();
                slide = pptApplication.SlideShowWindows[1].View.Slide;
            }
        }

        // Transform to next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            slideIndex = slide.SlideIndex + 1;
            if (slideIndex > slidescount)
            {
                MessageBox.Show("It is already last page");
            }
            else
            {
                try
                {
                    slide = slides[slideIndex];
                    slides[slideIndex].Select();
                }
                catch
                {
                    pptApplication.SlideShowWindows[1].View.Next();
                    slide = pptApplication.SlideShowWindows[1].View.Slide;
                }
            }
        }

        // Transform to Last page
        private void btnPrev_Click(object sender, EventArgs e)
        {
            slideIndex = slide.SlideIndex - 1;
            if (slideIndex >= 1)
            {
                try
                {
                    slide = slides[slideIndex];
                    slides[slideIndex].Select();
                }
                catch
                {
                    pptApplication.SlideShowWindows[1].View.Previous();
                    slide = pptApplication.SlideShowWindows[1].View.Slide;
                }
            }
            else
            {
                MessageBox.Show("It is already Fist Page");
            }
        }
    }
}
