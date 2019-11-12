using System;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
public abstract class BasePage : Page
{
    /// <summary>
    /// Page_Load of the Page Controller pattern.
    /// See http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpatterns/html/ImpPageController.asp
    /// </summary>
    private void Page_Load(object sender, EventArgs e)
    {
        // If using PageMethods, uncomment the following line...
        // PageMethodsEngine.InvokeMethod(this, true);
        PageLoad();
    }
    protected abstract void PageLoad();
}
