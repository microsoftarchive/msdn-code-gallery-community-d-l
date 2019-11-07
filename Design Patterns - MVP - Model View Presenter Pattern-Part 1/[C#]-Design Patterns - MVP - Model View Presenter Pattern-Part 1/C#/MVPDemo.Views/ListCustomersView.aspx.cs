using System;
using System.Collections.Generic;
using System.Web.UI;

using MVPDemo.Models;
using MVPDemo.Presenters;
using MVPDemo.Presenters.ViewInterfaces;

public partial class ListCustomersView : BasePage, IListCustomersView
{
    CustomerPresenter presenter;

    public void AttachPresenter(CustomerPresenter presenter)
    {
        this.presenter = presenter;
    }

    public string Message
    {
        set { lblMessage.Text = value; }
    }

    /// <summary>
    /// Provides a pass-through for the Customers to be bound to the GridView.  
    /// We do not want to expose the GridView directly so that the Presenters layer does not have a dependency 
    /// on System.Web nor has a dependency on an "implementation detail" of the view.
    /// </summary>
    public IList<CustomerModel> CustomersProperty
    {
        set
        {
            grdEmployees.DataSource = value;
            grdEmployees.DataBind();
        }
    }

    /// <summary>
    /// This hands control off to the presenter to raise the event that the user is requesting
    /// to add a new customer; alternatively, you could have the user control raise the event itself.  
    /// The downside is that, in some cases, the ASPX page may end up having to register for events with both the user control *and* the presenter.
    /// </summary>
    protected void btnAddCustomer_OnClick(object sender, EventArgs e)
    {
        presenter.AddCustomer();
    }

    //Base page overload method
    protected override void PageLoad() 
    {
        CustomerPresenter presenter = new CustomerPresenter(this, new CustomerModel());
        this.AttachPresenter(presenter);

        presenter.AddCustomerEvent += new EventHandler(HandleAddCustomerEvent);

        presenter.ListInitView(Request.QueryString["action"]);
    }

    private void HandleAddCustomerEvent(object sender, EventArgs e) 
    {
        // This redirect is fine since it's such a simple redirect, but be sure to check out 
        // PageMethods for redirection in your production application
        Response.Redirect("AddCustomerView.aspx");
    }
}
