using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImgRecognitionEmGu
{
    public partial class Form1 : Form
    {
        // Source image, small portion of image to be found in bigger pictures
        const string _detailedImage = @"<INSERT HERE THE PATH OF THE IMAGE TO BE FOUND>";

        // Custom class to store image scores
        class WeightedImages
        {
            public string ImagePath { get; set; } = "";
            public long   Score { get; set; } = 0; 
        }

        // A List<> which contains processed images scores
        List<WeightedImages> imgList = new List<WeightedImages>();

        /// <summary>
        /// Process dirs/subdirs for every file contained
        /// </summary>
        /// <param name="mainFolder"></param>
        /// <param name="detailImage"></param>
        private void ProcessFolder(string mainFolder, string detailImage)
        {
            foreach (var file in System.IO.Directory.GetFiles(mainFolder))
                ProcessImage(file, detailImage);

            foreach (var dir in System.IO.Directory.GetDirectories(mainFolder))
                ProcessFolder(dir, detailImage);
        }

        /// <summary>
        /// Process single image: calculate score then add the occurence to imgList List<WeightedImage>
        /// </summary>
        /// <param name="completeImage"></param>
        /// <param name="detailImage"></param>
        private void ProcessImage(string completeImage, string detailImage)
        {
            if (completeImage == detailImage) return;

            try
            {
                long score;
                long matchTime;

                using (Mat modelImage = CvInvoke.Imread(detailImage, ImreadModes.Color))
                using (Mat observedImage = CvInvoke.Imread(completeImage, ImreadModes.Color))
                {
                    Mat homography;
                    VectorOfKeyPoint modelKeyPoints;
                    VectorOfKeyPoint observedKeyPoints;

                    using (var matches = new VectorOfVectorOfDMatch())
                    {
                        Mat mask;
                        DrawMatches.FindMatch(modelImage, observedImage, out matchTime, out modelKeyPoints, out observedKeyPoints, matches,
                           out mask, out homography, out score);
                    }

                    imgList.Add(new WeightedImages() { ImagePath = completeImage, Score = score });
                }
            } catch { }
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start elaboration, then bind sorted imgList to resultGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            ProcessFolder(@"<INSERT PATH OF IMAGES HERE>", _detailedImage);

            resultGrid.DataSource = imgList.OrderByDescending(x => x.Score).ToList();
            resultGrid.AutoResizeColumn(0);
        }

        /// <summary>
        /// Button used to show the result image in emImageViewer instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, System.EventArgs e)
        {
            string imgPath = resultGrid.CurrentRow.Cells[0].Value.ToString();

            long score;
            long matchTime;

            using (Mat modelImage = CvInvoke.Imread(_detailedImage, ImreadModes.Color))
            using (Mat observedImage = CvInvoke.Imread(imgPath, ImreadModes.Color))
            {
                var result = DrawMatches.Draw(modelImage, observedImage, out matchTime, out score);
                var iv = new emImageViewer(result, score);
                iv.Show();
            }
        }
    }
}
