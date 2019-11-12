namespace HRApp.LoginUI
{
    using System;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using HRApp.Web.Resources;

    public partial class LoginForm : StackPanel
    {
        private LoginRegistrationWindow parentWindow;
        private LoginInfo loginInfo = new LoginInfo();
        private LoginOperation lastLoginOperation = null;

        public LoginForm()
        {
            InitializeComponent();

            this.loginForm.CurrentItem = this.loginInfo;
        }

        /// <remarks>
        ///     <see cref="LoginRegistrationWindow"/> will call this setter
        ///     during its initialization
        /// </remarks>
        public void SetParentWindow(LoginRegistrationWindow window)
        {
            this.parentWindow = window;
        }

        /// <summary>
        ///     Handles <see cref="DataForm.AutoGeneratingField"/>. Adds the necessary event listeners
        ///     so that the OK button will only be enabled when both username and password are filled
        /// </summary>
        private void LoginForm_OnAutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "UserName")
            {
                ((TextBox)e.Field.Content).TextChanged += EnableOrDisableOKButton;
            }
            else if (e.PropertyName == "Password")
            {
                ((PasswordBox)e.Field.Content).PasswordChanged += EnableOrDisableOKButton;
            }
        }

        /// <summary>
        ///     Enables the OK button if both username and password are not empty, disable it
        ///     otherwise
        /// </summary>
        private void EnableOrDisableOKButton(object sender, EventArgs e)
        {
            this.loginButton.IsEnabled = !(
                String.IsNullOrEmpty(((TextBox)this.loginForm.Fields["UserName"].Content).Text.Trim()) ||
                String.IsNullOrEmpty(((PasswordBox)this.loginForm.Fields["Password"].Content).Password)
        );
        }

        /// <summary>
        ///     Submits the <see cref="LoginOperation"/> to the server
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // If there was a validation error in a previously login attempt, clear it
            this.loginForm.ValidationSummary.Errors.Clear();

            if (this.loginForm.ValidateItem())
            {
                LoginOperation loginOperation = WebContext.Current.Authentication.Login(this.loginInfo.ToLoginParameters(), this.LoginOperation_Completed, null);

                this.BindUIToOperation(loginOperation);
                this.parentWindow.AddPendingOperation(loginOperation);
                this.lastLoginOperation = loginOperation;
            }
        }

        /// <summary>
        ///     Handles <see cref="LoginOperation.Completed"/> event. If operation
        ///     succeeds, it closes the window. If it has an error, we show an <see cref="ErrorWindow"/>
        ///     and mark the error as handled. If it was not canceled, succeded but login failed, 
        ///     it must have been because credentials were incorrect so we add a validation error 
        ///     to notify the user
        /// </summary>
        private void LoginOperation_Completed(LoginOperation loginOperation)
        {
            if (loginOperation.LoginSuccess)
            {
                this.parentWindow.Close();
            }
            else
            {
                if (loginOperation.HasError)
                {
                    ErrorWindow.CreateNew(loginOperation.Error);
                    loginOperation.MarkErrorAsHandled();
                }
                else if (!loginOperation.IsCanceled)
                {
                    this.loginForm.ValidationSummary.Errors.Add(new ValidationSummaryItem(ErrorResources.ErrorBadUserNameOrPassword));
                }

                this.loginForm.BeginEdit();
            }
        }

        /// <summary>
        ///     Binds UI so that controls will look disabled and activity control will
        ///     be displaying while operation is in progress, and cancel button will
        ///     be enabled only while the login operation can be cancelled
        /// </summary>
        private void BindUIToOperation(LoginOperation loginOperation)
        {
            Binding isEnabledBinding = loginOperation.CreateOneWayBinding("IsComplete");
            Binding isActivityActiveBinding = loginOperation.CreateOneWayBinding("IsComplete", new NotOperatorValueConverter());
            Binding isCancelEnabledBinding = loginOperation.CreateOneWayBinding("CanCancel");

            this.activity.SetBinding(Activity.IsActiveProperty, isActivityActiveBinding);
            this.loginButton.SetBinding(Control.IsEnabledProperty, isEnabledBinding);
            this.loginForm.SetBinding(Control.IsEnabledProperty, isEnabledBinding);
            this.registerNow.SetBinding(Control.IsEnabledProperty, isEnabledBinding);

            // The correct binding for the cancel button would be
            // IsEnabled = loginOperation.CanCancel || loginOperation.IsComplete
            //
            // However, this is a binding to two distinct properties which is
            // not supported, so we bind solely to CanCancel and remove the binding
            // once the operation is complete with a callback
            this.loginCancel.SetBinding(Control.IsEnabledProperty, isCancelEnabledBinding);
            loginOperation.Completed += this.ReEnableCancelButton;
        }

        /// <summary>
        ///     Removes the binding that the cancel button will have to <see cref="LoginOperation.CanCancel"/>
        ///     while an operation is in progress and makes it enabled again
        /// </summary>
        private void ReEnableCancelButton(object sender, EventArgs eventArgs)
        {
            this.loginCancel.IsEnabled = true;
        }

        private void RegisterNow_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.NavigateToRegistration();
        }

        /// <summary>
        ///     If a login operation is in progress and is cancellable, cancel it.
        ///     Otherwise, closes the window
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (this.lastLoginOperation != null && this.lastLoginOperation.CanCancel)
            {
                this.lastLoginOperation.Cancel();
            }
            else
            {
                this.parentWindow.Close();
            }
        }

        /// <summary>
        ///     Maps Esc to the cancel button and Enter to the
        ///     OK button
        /// </summary>
        private void LoginPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.CancelButton_Click(this.loginCancel, new EventArgs());
            }
            else if (e.Key == Key.Enter && this.loginButton.IsEnabled)
            {
                this.LoginButton_Click(this.loginButton, new EventArgs());
            }
        }
    }
}
