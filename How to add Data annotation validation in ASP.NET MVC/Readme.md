# How to add Data annotation validation in ASP.NET MVC
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
## Topics
- Data annotation validation
## Updated
- 08/07/2015
## Description

<h1>Introduction</h1>
<p>Hi,</p>
<p>i added a new project about How to add Data Annotation validation in Asp.net MVC&nbsp;</p>
<p><em><a title="How to add Data annotation validation in ASP.NET MVC" href="http://csharpcode.org/how-to-add-data-annotation-validation-in-mvc/">http://csharpcode.org/how-to-add-data-annotation-validation-in-mvc/</a></em></p>
<p>&nbsp;</p>
<p>First of all You need to know which namespace or Reference is for DataAnnotation validation in MVC :</p>
<p><strong>using System.ComponentModel.DataAnnotations;</strong></p>
<p>This namespace is already Built-in .NET Framework</p>
<p>Here are some Validation Attributes :</p>
<p><em><strong>Required, Range, StringLength, RegularExpression, DataType, EmailAddress, Currency, MinLength, MaxLength etc.</strong></em></p>
<p><strong>Required :</strong></p>
<p>You can use this attribute as</p>
<pre>[Required]</pre>
<pre>[Required(ErrorMessage = &quot;Your Message for Required Field&quot;)]</pre>
<p><strong>Range :</strong></p>
<p>You can use this attribute as</p>
<pre>[Range(1,10 , ErrorMessage = &quot;value must be between 1 to 10&quot;)]</pre>
<p><strong>StringLength :</strong></p>
<p>You can use this attribute as</p>
<pre>[StringLength(5)]</pre>
<p><strong>RegularExpression :</strong></p>
<p>You can use this attribute as</p>
<pre>[RegularExpression(@&quot;^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$&quot;, ErrorMessage = &quot;Entered Contact No format is not valid.&quot;)]</pre>
<p><strong>DataType :</strong></p>
<p>You can use this attribute as</p>
<pre>[DataType(DataType.EmailAddress, ErrorMessage = &quot;Error message.&quot;)]</pre>
<p><strong>Now take a look at an Example</strong></p>
<p><strong>Example :</strong></p>
<pre>public class Profile
{
 [Key]
 public int Id { get; set; }
 
 [Required(ErrorMessage = &quot;First Name is Required&quot;)]
 [Display(Name = &quot;FirstName&quot;)]
 public string FirstName { get; set; }
 
 [Required(ErrorMessage = &quot;Email ID is Required&quot;)]
 [DataType(DataType.EmailAddress, ErrorMessage = &quot;Email ID is not valid.&quot;)]
 [Display(Name = &quot;Email Id&quot;)]
 public string EmailId { get; set; }
 
 [Required(ErrorMessage = &quot;Contact No is Required&quot;)]
 [Display(Name = &quot;Contact No&quot;)]
 [RegularExpression(@&quot;^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$&quot;, ErrorMessage = &quot;Entered Contact No format is not valid.&quot;)]
 public string ContactNo { get; set; }
 
 [StringLength(5)]
 [Required(ErrorMessage = &quot;Rating is Required&quot;)]
 public string Rating { get; set; }
 
 [Required(ErrorMessage = &quot;Age is Required&quot;)]
 [Range(1, 100, ErrorMessage = &quot;Age must be between $1 and $100&quot;)]
 public decimal Age { get; set; }
}
</pre>
<p>Now model Profile is created so now how to use it for validation purpose.</p>
<p><strong>Controller page :</strong></p>
<pre>[HttpPost]
public ActionResult Create(Profile model)
{
 // and if You want to remove validation for field Id then
 if (ModelState.Keys.Contains(&quot;Id&quot;))
 {
 ModelState[&quot;Id&quot;].Errors.Clear();
 }
 if (ModelState.IsValid) //this condition is for validation checking on server side
 {
 dbContext.Profile.Add(model);
 dbContext.SaveChanges();
 return RedirectToAction(&quot;ProfileList&quot;);
 }
 return View(model);
}
</pre>
<p>Next, in view you can do client-side Validation using JS of jquery&nbsp;which are &ldquo;jquery.validate.min.js&rdquo; and &ldquo;jquery.validate.unobtrusive.min.js&rdquo;<br>
so add this jQuery in Header (&lt;/head&gt;) tag and write this code</p>
<pre>@model Mvc.Models.Profile
@{
   ViewBag.Title = &quot;Create&quot;;
}
@using (Html.BeginForm())
{
   @Html.ValidationSummary(true)
   &lt;fieldset&gt;
        &lt;legend&gt;Movie&lt;/legend&gt;
             &lt;div class=&quot;editor-label&quot;&gt;
                  @Html.LabelFor(model =&gt; model.FirstName)
             &lt;/div&gt;
             &lt;div class=&quot;editor-field&quot;&gt;
                  @Html.EditorFor(model =&gt; model.FirstName)
                  @Html.ValidationMessageFor(model =&gt; model.FirstName)
             &lt;/div&gt;
             &lt;div class=&quot;editor-label&quot;&gt;
                  @Html.LabelFor(model =&gt; model.EmailId)
             &lt;/div&gt;
             &lt;div class=&quot;editor-field&quot;&gt;
                  @Html.EditorFor(model =&gt; model.EmailId)
                  @Html.ValidationMessageFor(model =&gt; model.EmailId)
             &lt;/div&gt;
             &lt;div class=&quot;editor-label&quot;&gt;
                  @Html.LabelFor(model =&gt; model.ContactNo)
             &lt;/div&gt;
             &lt;div class=&quot;editor-field&quot;&gt;
                  @Html.EditorFor(model =&gt; model.ContactNo)
                  @Html.ValidationMessageFor(model =&gt; model.ContactNo)
             &lt;/div&gt;
             &lt;div class=&quot;editor-label&quot;&gt;
                  @Html.LabelFor(model =&gt; model.Rating)
             &lt;/div&gt;
             &lt;div class=&quot;editor-field&quot;&gt;
                  @Html.EditorFor(model =&gt; model.Rating)
                  @Html.ValidationMessageFor(model =&gt; model.Rating)
            &lt;/div&gt;
            &lt;div class=&quot;editor-label&quot;&gt;
                  @Html.LabelFor(model =&gt; model.Age)
            &lt;/div&gt;
            &lt;div class=&quot;editor-field&quot;&gt;
                  @Html.EditorFor(model =&gt; model.Age)
                  @Html.ValidationMessageFor(model =&gt; model.Age)
            &lt;/div&gt;
     &lt;p&gt;
           &lt;input type=&quot;submit&quot; value=&quot;Submit&quot; class=&quot;btn btn-success&quot; /&gt;
     &lt;/p&gt;
 &lt;/fieldset&gt;
}
</pre>
<p>Now, your coding is done Test your code .</p>
<p><em><br>
</em></p>
