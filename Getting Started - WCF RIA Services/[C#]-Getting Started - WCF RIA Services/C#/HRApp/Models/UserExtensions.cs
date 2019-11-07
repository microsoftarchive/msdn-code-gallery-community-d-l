namespace HRApp.Web
{
    using System;
    using System.ComponentModel;

    public partial class User
    {
        #region Make DisplayName Bindable
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            base.OnPropertyChanged(e);

            if (e.PropertyName == "Name" || e.PropertyName == "FriendlyName")
            {
                this.RaisePropertyChanged("DisplayName");
            }
        }
        #endregion
    }
}
