using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCDemo5ViewBag
{
    public class ColorController : Controller
    {
        public ActionResult SelectColor() 
        {
            var _colors = new List<string> { "Red", "Green", "Blue", "Black", "White" };

            var viewModel = new ColorModel
            {
                NumberOfColors = _colors.Count,
                Colors = _colors
            };
            
            // Here we are using ViewBag to send data to view, we can it is similar to ViewState.
            // 'Starred' is our custom property, which can be accessible in View page.
            ViewBag.Starred = new List<string> { "Green", "White" };

            return View(viewModel);
        }
        public ActionResult DisplayColor(string SelectedColor)
        {
            ViewBag.SelectedColor = SelectedColor;
            return View(ViewBag);
        }
    }
}