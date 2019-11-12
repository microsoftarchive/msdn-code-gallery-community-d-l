using System.Collections.Generic;

using MVPDemo.Models;

namespace MVPDemo.Presenters.ViewInterfaces
{
    /// <summary>
    /// There's not much rease to separate this from <see cref="IAddCustomerView" /> other than for making a more thorough example,
    /// as <see cref="CustomerPresenter "/> combined for Add/Edit/List.
    /// </summary>
    public interface IListCustomersView
    {
        string Message { set; }
        IList<CustomerModel> CustomersProperty { set; }
        void AttachPresenter(CustomerPresenter presenter);
    }
}