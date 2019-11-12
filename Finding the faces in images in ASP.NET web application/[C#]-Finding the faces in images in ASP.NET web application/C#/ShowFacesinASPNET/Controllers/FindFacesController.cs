using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowFacesinASPNET.Controllers
{
    public class FindFacesController : Controller
    {
        // GET: FindFaces
        public ActionResult Index()
        {
            if(Request.HttpMethod == "POST")
            {
                ViewBag.ImageProcessed = true;
                // Try to process the image.
                if(Request.Files.Count > 0)
                {
                    // There will be just one file.
                    var file = Request.Files[0];

                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(Server.MapPath("~/Images/" + fileName));

                    // Load the saved image, for native processing using Emgu CV.
                    var bitmap = new Bitmap(Server.MapPath("~/Images/" + fileName));

                    var faces = FaceDetector.DetectFaces(new Image<Bgr, byte>(bitmap).Mat);

                    // If faces where found.
                    if(faces.Count > 0)
                    {
                        ViewBag.FacesDetected = true;
                        ViewBag.FaceCount = faces.Count;

                        var positions = new List<Location>();
                        foreach (var face in faces)
                        {
                            // Add the positions.
                            positions.Add(new Location
                            {
                                X = face.X,
                                Y = face.Y,
                                Width = face.Width,
                                Height = face.Height
                            });
                        }

                        ViewBag.FacePositions = JsonConvert.SerializeObject(positions);
                    }

                    ViewBag.ImageUrl = fileName;
                }
            }
            return View();
        }
    }

    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class FaceDetector
    {
        public static List<Rectangle> DetectFaces(Mat image)
        {
            List<Rectangle> faces = new List<Rectangle>();
            var facesCascade = HttpContext.Current.Server.MapPath("~/haarcascade_frontalface_default.xml");
            using (CascadeClassifier face = new CascadeClassifier(facesCascade))
            {
                using (UMat ugray = new UMat())
                {
                    CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                    //normalizes brightness and increases contrast of the image
                    CvInvoke.EqualizeHist(ugray, ugray);

                    //Detect the faces  from the gray scale image and store the locations as rectangle
                    //The first dimensional is the channel
                    //The second dimension is the index of the rectangle in the specific channel
                    Rectangle[] facesDetected = face.DetectMultiScale(
                       ugray,
                       1.1,
                       10,
                       new Size(20, 20));

                    faces.AddRange(facesDetected);
                }
            }
            return faces;
        }
    }
}
