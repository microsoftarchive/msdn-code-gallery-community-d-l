using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo4ModelViewController
{
    public class ColorController : Controller
    {
        public ActionResult SelectColor() // View File name also same 
        {
            // Create list of genres
            var _colors = new List<string> { "Red", "Green", "Blue", "Black", "White" };

            // Create your view model
            var viewModel = new ColorModel
            {
                NumberOfColors = _colors.Count,
                Colors = _colors
            };

            return View(viewModel);
        }
    }
}
