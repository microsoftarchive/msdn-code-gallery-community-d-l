using System;
using System.Web.UI;

using MVPDemo.Models;
using MVPDemo.Presenters;
using MVPDemo.Presenters.ViewInterfaces;

public partial class AddCustomerView : BasePage, IAddCustomerView
{
    private CustomerPresenter presenter;

    public string Message 
    {
        set 
        {             
            lblMessage.Text = value; 
        }
    }

    public void AttachPresenter(CustomerPresenter presenter) 
    {
        this.presenter = presenter;
    }

    public CustomerModel CustomerToAdd 
    {
        get 
        {
            CustomerModel customer = new CustomerModel();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            return customer;
        }
    }

    protected void btnAdd_OnClick(object sender, EventArgs e) 
    {
        presenter.AddCustomer(Page.IsValid);
    }

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        presenter.CancelAdd();
    }

    //Base page overload method
    protected override void PageLoad() 
    {
        // DaoFactory is inherited from BasePage
        CustomerModel CustomerModelObject = new CustomerModel();

        CustomerPresenter presenter = new CustomerPresenter(this, CustomerModelObject);
        this.AttachPresenter(presenter);

        presenter.AddCustomerCompleteEvent += new EventHandler(HandleAddCustomerCompleteEvent);
        presenter.CancelAddEvent += new EventHandler(HandleCancelAddEvent);

        presenter.AddInitView();
    }
    
    private void HandleAddCustomerCompleteEvent(object sender, EventArgs e) 
    {
        Response.Redirect("ListCustomersView.aspx?action=added");
    }

    private void HandleCancelAddEvent(object sender, EventArgs e) 
    {
        Response.Redirect("ListCustomersView.aspx");
    }
}