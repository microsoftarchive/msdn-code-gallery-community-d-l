using System;
using System.Web;

using MVPDemo.Models;
using MVPDemo.Presenters.ViewInterfaces;
using System.Collections.Generic;

namespace MVPDemo.Presenters
{
    public class CustomerPresenter
    {
        private IAddCustomerView AddCustomerViewObject;
        private IEditCustomerView EditCustomerViewObject;
        private IListCustomersView ListCustomersViewObject;

        public CustomerModel CustomerModelObject;
        
        public CustomerPresenter(IAddCustomerView CustomerViewObject, CustomerModel CustomerModelObject)
        {
            
            if (CustomerViewObject == null)
            {
                throw new ArgumentNullException("CustomerViewObject may not be null");
            }
            if (CustomerModelObject == null)
            {
                throw new ArgumentNullException("CustomerModelObject may not be null");
            }

            this.AddCustomerViewObject = CustomerViewObject;
            this.CustomerModelObject = CustomerModelObject;
        }

        public CustomerPresenter(IEditCustomerView CustomerViewObject, CustomerModel CustomerModelObject)
        {
            if (CustomerViewObject == null)
            {
                throw new ArgumentNullException("CustomerViewObject may not be null");
            }
            if (CustomerModelObject == null)
            {
                throw new ArgumentNullException("CustomerModelObject may not be null");
            }

            this.EditCustomerViewObject = CustomerViewObject;
            this.CustomerModelObject = CustomerModelObject;
        }

        public CustomerPresenter(IListCustomersView ListCustomersViewObject, CustomerModel CustomerModelObject)
        {
            if (ListCustomersViewObject == null)
            {
                throw new ArgumentNullException("ListCustomersViewObject may not be null");
            }
            if (CustomerModelObject == null)
            {
                throw new ArgumentNullException("CustomerModelObject may not be null");
            }

            this.ListCustomersViewObject = ListCustomersViewObject;
            this.CustomerModelObject = CustomerModelObject;
        }
        
        /// <summary>
        /// Raised when the user wants to cancel adding a new customer.  
        /// The containing ASPX page should listen for this event.
        /// </summary>
        public EventHandler CancelAddEvent;

        /// <summary>
        /// Raised when the user wants to cancel editing a customer.  
        /// The containing ASPX page should listen for this event.
        /// </summary>
        public EventHandler CancelUpdateEvent;

        /// <summary>
        /// Raised when the user wants to add a new customer.  
        /// The containing ASPX page should listen for this event.
        /// </summary>
        public EventHandler AddCustomerEvent;

        /// <summary>
        /// Raised after the customer has been successfully added to the database.
        /// </summary>
        public EventHandler AddCustomerCompleteEvent;
        
        /// <summary>
        /// Raised after the customer has been successfully committed to the database.
        /// </summary>
        public EventHandler UpdateCustomerCompleteEvent;
        
        public void AddInitView()
        {
            AddCustomerViewObject.Message = "Use this form to add a new customer.";
        }
        
        public void EditInitView(string CustomerFirstName, bool isPostBack)
        {
            if (string.IsNullOrEmpty(CustomerFirstName))
            {
                throw new ArgumentNullException("Customer First Name may not be null or empty");
            }
            if (!isPostBack)
            {
                //EditCustomerViewObject.CustomerToUpdate = customerDao.GetById(customerId, false);
            }
        }

        public void ListInitView(string action)
        {
            DisplayMessageFor(action);

            List<CustomerModel> CustomerCollection = new List<CustomerModel>();
            object customerObject = HttpContext.Current.Session["CustomerModelObject"];
            if (customerObject != null)
            {
                CustomerCollection.Add((CustomerModel)customerObject);
                ListCustomersViewObject.CustomersProperty = CustomerCollection;
            }
            //ListCustomersViewObject.Customers.Add(new CustomerModel { FirstName = "Sai", LastName = "SriMahi" });
        }

        /// <summary>
        /// In this example solution, this is simply a pass-through method for the event to be raised.  
        /// In such a simple example, you may consider having the user control raise the event directly.  
        /// Conversely, there are times when other actions are taken before the event is raised.  
        /// In these situations, the presenter should definitely manage raising the event after the other actions have been taken.
        /// </summary>
        public void AddCustomer()
        {
            AddCustomerEvent(this, null);
        }

        /// <summary>
        /// Called by the view; this grabs the updated customer from the view and commits it to the DB.
        /// </summary>
        public void AddCustomer(bool isPageValid)
        {
            // Be sure to check isPageValid before anything else
            if (!isPageValid)
            {
                AddCustomerViewObject.Message = "There was a problem with your inputs.  Make sure you supplied everything and try again";
                return;
            }
            
            //Get the filled object from the Customer view.
            CustomerModelObject = AddCustomerViewObject.CustomerToAdd;
            HttpContext.Current.Session["CustomerModelObject"] = CustomerModelObject;


            // You could certainly pass in more than just null for the event args
            AddCustomerCompleteEvent(this, null);

            // By passing HTML tags from the presenter to the view, we've essentially bound the presenter to an HTML context.  
            // You may want to consider alternatives to keep the presentation layer web/windows agnostic.
            AddCustomerViewObject.Message = "<span style=\"color:red\">The Customer added to database successfully.";
        }
        
        /// <summary>
        /// Called by the view; this grabs the updated customer from the view and commits it to the DB.
        /// </summary>
        public void UpdateCustomer(bool isPageValid)
        {
            // Here's an example of taking into account if Page.IsValid.  Of course, if it fails, 
            // you'd want to send a message back to the view stating that there was a problem with the inputs.  
            // For an example of having the presenter send a message back to the view, see ListCustomersPresenter.
            if (isPageValid)
            {

                //Get the filled object from the Customer view.
                CustomerModelObject = EditCustomerViewObject.CustomerToUpdate;
                HttpContext.Current.Session["CustomerModelObject"] = CustomerModelObject;

                // You could certainly pass in more than just null for the event args
                UpdateCustomerCompleteEvent(this, null);
            }
        }
        
        /// <summary>
        /// In this example solution, this is simply a pass-through method for the event to be raised.  
        /// In such a simple example, you may consider having the user control raise the event directly.  
        /// Conversely, there are times when other actions are taken before the event is raised.  
        /// In these situations, the presenter should definitely manage raising the event after the other actions have been taken.
        /// </summary>
        public void CancelAdd()
        {
            CancelAddEvent(this, null);
        }

        /// <summary>
        /// In this example solution, this is simply a pass-through method for the event
        /// to be raised.  In such a simple example, you may consider having the user control raise
        /// the event directly.  Conversely, there are times when other actions are taken before
        /// the event is raised.  In these situations, the presenter should definitely manage 
        /// raising the event after the other actions have been taken.
        /// </summary>
        public void CancelUpdate()
        {
            CancelUpdateEvent(this, null);
        }       

        /// <summary>
        /// Reviews the supplied action and sets an appropriate message onto the view
        /// </summary>
        /// <param name="action">Alternatively, this could be provided as a enum value to make it 
        /// more strongly typed.</param>
        private void DisplayMessageFor(string action)
        {
            if (action == "updated")
            {
                ListCustomersViewObject.Message = "The customer was successfully updated.";
            }
            else if (action == "added")
            {
                ListCustomersViewObject.Message = "The customer was successfully added.";
            }
            else
            {
                ListCustomersViewObject.Message = "Click a customer's First Name to edit the customer.";
            }
        }
    }
}