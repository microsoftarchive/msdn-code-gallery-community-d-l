namespace HRApp
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.Windows;
    using System.Windows.Controls;
    using HRApp.Resources;

    public partial class App : Application
    {
        private Activity progressIndicator;

        public App()
        {
            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // This will enable you to bind controls in XAML files to WebContext.Current
            // properties
            this.Resources.Add("WebContext", WebContext.Current);

            // This will automatically authenticate a user when using windows authentication
            // or when the user chose "Keep me signed in" on a previous login attempt
            WebContext.Current.Authentication.LoadUser(this.Application_UserLoaded, null);

            // Show some UI to the user while LoadUser is in progress
            this.InitializeRootVisual();
        }

        /// <summary>
        ///     Invoked when the <see cref="LoadUserOperation"/> completes. Use this
        ///     event handler to switch from the "loading UI" you created in
        ///     <see cref="InitializeRootVisual"/> to the "application UI"
        /// </summary>
        private void Application_UserLoaded(LoadUserOperation operation)
        {
            this.progressIndicator.IsActive = false;
        }

        /// <summary>
        ///     Initializes the <see cref="Application.RootVisual"/> property. The
        ///     initial UI will be displayed before the LoadUser operation has completed
        ///     (The LoadUser operation will cause user to be logged automatically if
        ///     using windows authentication or if the user had selected the "keep
        ///     me signed in" option on a previous login).
        /// </summary>
        protected virtual void InitializeRootVisual()
        {
            this.progressIndicator = new Activity();
            this.progressIndicator.Content = new MainPage();
            //this.progressIndicator.IsActive = true;
            this.progressIndicator.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            this.progressIndicator.VerticalContentAlignment = VerticalAlignment.Stretch;

            // Let the user now we're trying to authenticate him
            this.progressIndicator.ActiveContent = ApplicationStrings.ActivityLoadingUser;

            this.RootVisual = this.progressIndicator;
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // a ChildWindow control.
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                ErrorWindow.CreateNew(e.ExceptionObject);
            }
        }
    }
}