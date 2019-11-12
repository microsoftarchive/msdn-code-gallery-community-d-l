using System;
using System.Web.UI;

using MVPDemo.Models;
using MVPDemo.Presenters;
using MVPDemo.Presenters.ViewInterfaces;

public partial class EditCustomerView : BasePage, IEditCustomerView
{
    private CustomerPresenter presenter;

    /// <summary>
    /// Provides a means for setting/retrieving the <see cref="Customer" /> to be updated.
    /// Arguably, you could just pass primitives back and forth instead of having the view
    /// be bound to the domain layer...but passing primitives could become quite painful very quickly.  
    /// IMO, the benefits of brevity outweigh the "disadvantages" of  being dependent on the domain layer.
    /// </summary>
    public CustomerModel CustomerToUpdate
    {
        get
        {
            // In Entity Framework scenarion pass Customer ID and fetch the associated record and map the data to same object.
            //CustomerModel CustomerModelObject = new CustomerModel(CustID);

            CustomerModel CustomerModelObject = new CustomerModel();
            CustomerModelObject.FirstName = txtFirstName.Text;
            CustomerModelObject.LastName = txtLastName.Text;

            return CustomerModelObject;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("CustomerToUpdate may not be null");
            }

            txtFirstName.Text = value.FirstName;
            txtLastName.Text = value.LastName;
        }
    }

    public void AttachPresenter(CustomerPresenter presenter)
    {
        this.presenter = presenter;
    }

    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        // Instead of having the presenter grab the updated customer via the CustomerToUpdate's getter,
        // you could also pass the updated Customer directly to the UpdateCustomer method.  
        // I prefer the consistency of using the getter/setter pair.
        presenter.UpdateCustomer(Page.IsValid);
    }

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        presenter.CancelUpdate();
    }
    
    protected override void PageLoad()
    {
        CustomerPresenter presenter = new CustomerPresenter(this, new CustomerModel());
        this.AttachPresenter(presenter);

        presenter.UpdateCustomerCompleteEvent += new EventHandler(HandleUpdateCustomerCompleteEvent);
        presenter.CancelUpdateEvent += new EventHandler(HandleCancelUpdateEvent);

        presenter.EditInitView(Request.QueryString["CustomerFirstName"], IsPostBack);
    }

    private void HandleUpdateCustomerCompleteEvent(object sender, EventArgs e)
    {
        Response.Redirect("ListCustomersView.aspx?action=updated");
    }

    private void HandleCancelUpdateEvent(object sender, EventArgs e)
    {
        Response.Redirect("ListCustomersView.aspx");
    }
}
