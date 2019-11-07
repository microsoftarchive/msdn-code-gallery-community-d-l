using MVPDemo.Models;

namespace MVPDemo.Presenters.ViewInterfaces
{
    /// <summary>
    /// There's not much rease to separate this from <see cref="IEditCustomerView" /> other than for making a more thorough example,
    /// as <see cref="CustomerPresenter "/> combined for Add/Edit/List.
    /// </summary>
    public interface IAddCustomerView
    {
        string Message { set; }
        void AttachPresenter(CustomerPresenter presenter);

        /// <summary>
        /// No need to have a setter since we're only interested in getting the new 
        /// <see cref="Customer" /> to be added.
        /// </summary>
        CustomerModel CustomerToAdd { get; }
    }
}