namespace HRApp.LoginUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Automation.Provider;
    using System.Windows.Controls;
    using System.Windows.Data;
    using HRApp.Web;
    using HRApp.Resources;

    public partial class RegistrationForm : StackPanel
    {
        private RegistrationData registrationData = new RegistrationData();
        private UserRegistrationContext userRegistrationContext = new UserRegistrationContext();
        private LoginRegistrationWindow parentWindow;

        public RegistrationForm()
        {
            InitializeComponent();

            this.userRegistrationContext.RegistrationDatas.Add(this.registrationData);
            this.registerForm.CurrentItem = this.registrationData;
            this.registerForm.AutoGeneratingField += this.RegisterForm_AutoGeneratingField;
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
        ///     Adds some additional behaviors to some of the DataForm's fields
        /// </summary>
        private void RegisterForm_AutoGeneratingField(object dataForm, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "Password")
            {
                PasswordBox passwordBox = (PasswordBox)e.Field.Content;

                passwordBox.PasswordChanged += (sender, eventArgs) =>
                {
                    // If the password is invalid, the entity property doesn't get updated.
                    // Thus, we keep a separate password copy (the ActualPassword property)
                    // that is guaranteed to match what the user typed
                    ((RegistrationData)this.registerForm.CurrentItem).ActualPassword = ((PasswordBox)sender).Password;
                };

                passwordBox.LostFocus += (sender, eventArgs) =>
                {
                    // Prevent this from having any effect after a submission
                    if (this.registrationData.EntityState == EntityState.Unmodified)
                    {
                        return;
                    }

                    // If there is something typed on the password confirmation box
                    // then we need to re-validate it
                    if (!String.IsNullOrEmpty(((PasswordBox)this.registerForm.Fields["PasswordConfirmation"].Content).Password))
                    {
                        this.registerForm.Fields["PasswordConfirmation"].Validate();
                    }
                };
            }
            else if (e.PropertyName == "Question")
            {
                // Create a ComboBox populated with security questions
                ComboBox comboBoxWithSecurityQuestions = RegistrationForm.CreateComboBoxWithSecurityQuestions();

                // Replace the control
                // Note: Since TextBox.Text treats empty text as string.Empty and ComboBox.SelectedItem
                // treats an empty selection as null, we need to use a converter on the binding
                e.Field.ReplaceTextBox(comboBoxWithSecurityQuestions, ComboBox.SelectedItemProperty, binding => binding.Converter = new TargetNullValueConverter());
            }
            else if (e.PropertyName == "UserName")
            {
                // Auto-fill FriendlyName if there is not already something in there
                TextBox userNameTextBox = (TextBox)e.Field.Content;

                userNameTextBox.LostFocus += (sender, eventArgs) =>
                {
                    // Prevent this from having any effect after a submission
                    if (this.registrationData.EntityState == EntityState.Unmodified)
                    {
                        return;
                    }

                    TextBox friendlyNameTextBox = (TextBox)this.registerForm.Fields["FriendlyName"].Content;

                    if (string.IsNullOrEmpty(friendlyNameTextBox.Text))
                    {
                        friendlyNameTextBox.Text = userNameTextBox.Text;
                    }
                };
            }
        }

        /// <returns>
        ///   Returns a <see cref="ComboBox" /> object whose <see cref="ComboBox.ItemsSource" /> property
        ///   is initialized with the resource strings defined in <see cref="SecurityQuestions" />
        /// </returns>
        private static ComboBox CreateComboBoxWithSecurityQuestions()
        {
            // Use reflection to grab all the localized security questions
            IEnumerable<string> availableQuestions = from propertyInfo in typeof(SecurityQuestions).GetProperties()
                                                     where propertyInfo.PropertyType.Equals(typeof(string))
                                                     select (string)propertyInfo.GetValue(null, null);

            // Create and initialize the ComboBox object
            ComboBox comboBox = new ComboBox();
            comboBox.ItemsSource = availableQuestions;
            return comboBox;
        }

        /// <summary>
        ///     If form is valid, submits userRegistrationContext information to the server
        /// </summary>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.registerForm.ValidateItem() && this.registerForm.CommitEdit())
            {
                SubmitOperation regOp = this.userRegistrationContext.SubmitChanges(this.RegistrationOperation_Completed, null);
                this.BindUIToOperation(regOp);
                this.parentWindow.AddPendingOperation(regOp);
            }
        }

        /// <summary>
        ///     Handles <see cref="SubmitOperation.Completed"/> for a userRegistrationContext
        ///     operation. If there was an error, an <see cref="ErrorWindow"/> is
        ///     displayed to the user. Otherwise, this triggers a <see cref="LoginOperation"/>
        ///     that will automatically log in the just registered user
        /// </summary>
        private void RegistrationOperation_Completed(SubmitOperation asyncResult)
        {
            if (asyncResult.HasError)
            {
                ErrorWindow.CreateNew(asyncResult.Error);
                asyncResult.MarkErrorAsHandled();
                this.registerForm.BeginEdit();
            }
            else
            {
                LoginOperation loginOperation = WebContext.Current.Authentication.Login(this.registrationData.ToLoginParameters(), this.LoginOperation_Completed, null);
                this.BindUIToOperation(loginOperation);
                this.parentWindow.AddPendingOperation(loginOperation);
            }
        }

        /// <summary>
        ///     Binds UI so that controls will look disabled and activity will be
        ///     displayed while operation is in progress. For simplicity Cancel button 
        ///     will be disabled during the operation even if it is cancellable
        /// </summary>
        /// <param name="operation"></param>
        private void BindUIToOperation(OperationBase operation)
        {
            Binding isActivityActiveBinding = operation.CreateOneWayBinding("IsComplete", new NotOperatorValueConverter());
            Binding isEnabledBinding = operation.CreateOneWayBinding("IsComplete");

            this.activity.SetBinding(Activity.IsActiveProperty, isActivityActiveBinding);
            this.registerForm.SetBinding(Control.IsEnabledProperty, isEnabledBinding);
            this.registerButton.SetBinding(Control.IsEnabledProperty, isEnabledBinding);
            this.registerCancel.SetBinding(Control.IsEnabledProperty, isEnabledBinding);
            this.backToLogin.SetBinding(Control.IsEnabledProperty, isEnabledBinding);
        }

        /// <summary>
        ///     Handles <see cref="LoginOperation.Completed"/> event for
        ///     the login operation that is sent right after a successful
        ///     userRegistrationContext. This will close the window. On the unexpected
        ///     event that this operation failed (the user was just added so
        ///     why wouldn't it be authenticated successfully) an 
        ///     <see cref="ErrorWindow"/> is created and will display the
        ///     error message.
        /// </summary>
        /// <param name="loginOperation"></param>
        private void LoginOperation_Completed(LoginOperation loginOperation)
        {
            this.parentWindow.Close();

            if (loginOperation.HasError)
            {
                ErrorWindow.CreateNew(string.Format(System.Globalization.CultureInfo.CurrentUICulture, ApplicationStrings.ErrorLoginAfterRegistrationFailed, loginOperation.Error.Message));
                loginOperation.MarkErrorAsHandled();
            }
            else if (loginOperation.LoginSuccess == false)
            {
                // ApplicationStrings.ErrorBadUserNameOrPassword is the correct error message as operation succeeded but login failed
                ErrorWindow.CreateNew(string.Format(System.Globalization.CultureInfo.CurrentUICulture, ApplicationStrings.ErrorLoginAfterRegistrationFailed, ApplicationStrings.ErrorBadUserNameOrPassword));
            }
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.NavigateToLogin();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Close();
        }
    }
}
