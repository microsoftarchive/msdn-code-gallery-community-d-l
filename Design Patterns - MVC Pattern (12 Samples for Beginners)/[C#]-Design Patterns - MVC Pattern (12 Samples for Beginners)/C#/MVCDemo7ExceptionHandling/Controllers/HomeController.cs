using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Caching;

namespace MVCDemo7ExceptionHandling
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome!";
            Session["SampleSessionObject"] = "Hello Sai, this is from MVC Session";
            //Cache["SampleCacheObject"] = "Hello Sai, this is from MVC Cache";
            TempData["TempDataObject"] = "Hello Sai, this is from TempData";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
        [HandleError]
        public ActionResult ThrowException()
        {
            throw new ApplicationException();
        }

        [HandleError(View = "CustomErrorView", ExceptionType = typeof(NotImplementedException))]
        public ActionResult ThrowNotImplemented()
        {
            throw new NotImplementedException();
        }

        //string errorMessage = "<div class=\"validation-summary-errors\">The following errors occurred:<ul>";

        //        foreach (var key in ModelState.Keys) 
        //        {
        //            var error = ModelState[key].Errors.FirstOrDefault();
        //            if (error != null) 
        //            {
        //                errorMessage += "<li class=\"field-validation-error\">" + error.ErrorMessage + "</li>";
        //            }
        //        }
        //        errorMessage += "</ul>";

        //protected override bool OnError(string actionName, System.Reflection.MethodInfo methodInfo, Exception exception)
        //{

            //WriteLog(Settings.LogErrorFile, exception.ToString());

            // Output a nice error page
            //if (exception.HttpContext.IsCustomErrorEnabled)
            //{
            //    exception.ExceptionHandled = true;
            //    this.View("Error").ExecuteResult(this.ControllerContext);
            //}

            //var model = new HandleErrorInfo(context.Exception, controllerName, actionName);
            //var result = new ViewResult
            //{
            //    ViewName = view,
            //    MasterName = master,
            //    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            //    TempData = context.Controller.TempData
            //};
            //context.Result = result;

            //// Configure the response object 
            //context.ExceptionHandled = true;
            //context.HttpContext.Response.Clear();
            //context.HttpContext.Response.StatusCode = 500;
            //context.HttpContext.Response.TrySkipIisCustomErrors = true;


            //RenderView("Error", exception.InnerException);
            //return false;
        //}
    }
}

/*
 MVC2.0 New Features:
1. Templated Helpers: 
Templated helpers let you automatically associate HTML elements for edit and display with data types. For example, when data of type System.DateTime is displayed in a view, a date-picker UI element can be automatically rendered. This is similar to how field templates work in ASP.NET Dynamic Data. For more information, see Using Templated Helpers to Display Data on the MSDN Web site.
 
2. Areas: 
Areas let you organize a large project into multiple smaller sections in order to manage the complexity of a large Web application. Each section (“area”) typically represents a separate section of a large Web site and is used to group related sets of controllers and views. For more information, see Walkthrough: Organizing an ASP.NET MVC Application by Areas on the MSDN Web site. 
To create a new area, in Solution Explorer, right-click the project, click Add, and then click Area. This displays a dialog box that prompts you for the area name. After you enter the area name, Visual Studio adds a new area to the project.
 Areas
    Admin
       Controllers
       Models
       Views
    Iniala Claims
       Controllers
       Models
       Views
3. Support for Asynchronous Controllers :
ASP.NET MVC 2 now allows controllers to process requests asynchronously. This can lead to performance gains by allowing servers which frequently call blocking operations (like network requests) to call non-blocking counterparts instead.
4. Support for DefaultValueAttribute in Action-Method Parameters :

The System.ComponentModel.DefaultValueAttribute class allows a default value to be supplied for the argument parameter to an action method. For example, assume that the following default route is defined:
 {controller}/{action}/{id} 
Also assume that the following controller and action method is defined:
public class ArticleController 
{ 
  public ActionResult View(int id, [DefaultValue(1)]int page) 
  { 
  } 
} 
Any of the following request URLs will invoke the View action method that is defined in the preceding example.
•/Article/View/123
•/Article/View/123?page=1 (Effectively the same as the previous request) 
•/Article/View/123?page=2

5. Support for Binding Binary Data with Model Binders: 
There are two new overloads of the Html.Hidden helper that encode binary values as base-64-encoded strings:
public static string Hidden(this HtmlHelper htmlHelper, string name, Binary value);  
public static string Hidden(this HtmlHelper htmlHelper, string name, byte[] value); 

6. Support for DataAnnotations Attributes: 
ASP.NET MVC 2 supports using the RangeAttribute, RequiredAttribute, StringLengthAttribute, and RegexAttribute validation attributes (defined in the System.ComponentModel.DataAnnotations namespace) when you bind to a model in order to provide input validation

 * using System.ComponentModel.DataAnnotations;
namespace MvcTmpHlprs {

    [MetadataType(typeof(ProductMD))]
    public partial class Product {
        public class ProductMD {
            public object SellStartDate { get; set; }
            [UIHint("rbDate")]
            public object SellEndDate { get; set; }
            [DataType(DataType.Date)]
            public object DiscontinuedDate { get; set; }
            [ScaffoldColumn(false)]
            public object ModifiedDate { get; set; }
            [ScaffoldColumn(false)]
            public object rowguid { get; set; }
            [ScaffoldColumn(false)]
            public object ThumbnailPhotoFileName { get; set; }
        }
    }
}


7. Model-Validator Providers: 
The model-validation provider class represents an abstraction that provides validation logic for the model. ASP.NET MVC includes a default provider based on validation attributes that are included in the System.ComponentModel.DataAnnotations namespace

8. Client-Side Validation: 
The model-validator provider class exposes validation metadata to the browser in the form of JSON-serialized data that can be consumed by a client-side validation library. ASP.NET MVC 2 includes a client validation library and adapter that supports the DataAnnotations namespace validation attributes noted earlier.

9. New RequireHttpsAttribute Action Filter: 
ASP.NET MVC 2 includes a new RequireHttpsAttribute class that can be applied to action methods and controllers. By default, the filter redirects a non-SSL (HTTP) request to the SSL-enabled (HTTPS) equivalent.
 
10. Overriding the HTTP Method Verb 
When you build a Web site by using the REST architectural style, HTTP verbs are used to determine which action to perform for a resource. REST requires that applications support the full range of common HTTP verbs, including GET, PUT, POST, and DELETE. 
ASP.NET MVC 2 includes new attributes that you can apply to action methods and that feature compact syntax. These attributes enable ASP.NET MVC to select an action method based on the HTTP verb. In the following example, a POST request will call the first action method and a PUT request will call the second action method.

[HttpPost] 
public ActionResult Edit(int id) 
 
[HttpPut] 
public ActionResult Edit(int id, Tag tag) 
In earlier versions of ASP.NET MVC, these action methods required more verbose syntax, as shown in the following example:
[AcceptVerbs(HttpVerbs.Post)]  
        public ActionResult Edit(int id)  
 
        [AcceptVerbs(HttpVerbs.Put)]  
        public ActionResult Edit(int id, Tag tag)  
       

Because browsers support only the GET and POST HTTP verbs, it is not possible to post to an action that requires a different verb. Thus it is not possible to natively support all RESTful requests.
 
However, to support RESTful requests during POST operations, ASP.NET MVC 2 introduces a new HttpMethodOverride HTML helper method. This method renders a hidden input element that causes the form to effectively emulate any HTTP method. For example, by using the HttpMethodOverride HTML helper method, you can have a form submission appear be a PUT or DELETE request. The behavior of HttpMethodOverride affects the following attributes:
 •HttpPostAttribute
 •HttpPutAttribute
 •HttpGetAttribute
 •HttpDeleteAttribute
 •AcceptVerbsAttribute

11. New HiddenInputAttribute Class for Templated Helpers:
 
You can apply the new HiddenInputAttribute attribute to a model property to indicate whether a hidden input element should be rendered when displaying the model in an editor template. (The attribute sets an implicit UIHint value of HiddenInput). The attribute’s DisplayValue property lets you specify whether the value is displayed in editor and display modes. When DisplayValue is set to false, nothing is displayed, not even the HTML markup that normally surrounds a field. The default value for DisplayValue is true.
You might use HiddenInputAttribute attribute in the following scenarios:
 •When a view lets users edit the ID of an object and it is necessary to display the value as well as to provide a hidden input element that contains the old ID so that it can be passed back to the controller. 
•When a view lets users edit a binary property that should never be displayed, such as a timestamp property. In that case, the value and surrounding HTML markup (such as the label and value) are not displayed. 

The following example shows how to use the HiddenInputAttribute class.
public class ProductViewModel { 
    [HiddenInput] // equivalent to [HiddenInput(DisplayValue=true)] 
    public int Id { get; set; } 
 
    public string Name { get; set; } 
 
    [HiddenInput(DisplayValue=false)] 
    public byte[] TimeStamp { get; set; } 
} 

12. Html.ValidationSummary Helper Method Can Display Model-Level Errors:

Instead of always displaying all validation errors, the Html.ValidationSummary helper method has a new option to display only model-level errors. This enables model-level errors to be displayed in the validation summary and field-specific errors to be displayed next to each field. 

13. T4 Templates in Visual Studio Generate Code that is Specific to the Target Version of the .NET Framework:

A new property is available to T4 files from the ASP.NET MVC T4 host that specifies the version of the .NET Framework that is used by the application. This enables T4 templates to generate code and markup that is specific to a version of the .NET Framework. In Visual Studio 2008, the value is always .NET 3.5. In Visual Studio 2010, the value is either .NET 3.5 or .NET 4.
 
14. API Improvements:
 
This section describes changes to existing ASP.NET MVC types and members.
Added a protected virtual CreateActionInvoker method in the Controller class. This method is invoked by the ActionInvoker property of Controller and allows for lazy instantiation of the invoker if no invoker is already set. 
MVC3:

MVC4:
HTML5, tablet, and mobile

 * */