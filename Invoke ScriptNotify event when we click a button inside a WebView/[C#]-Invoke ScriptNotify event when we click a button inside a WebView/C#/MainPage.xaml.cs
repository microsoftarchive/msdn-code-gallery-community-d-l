using System;
using Windows.UI.Xaml.Controls;

namespace WebViewSample.ButtonClick
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Webs the view_ on navigation completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="WebViewNavigationCompletedEventArgs"/> instance containing the event data.</param>
        private async void WebView_OnNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            await WebView.InvokeScriptAsync("eval", new[]
            {
                "var signButton=document.getElementById(\"MyButton\");" +
                "if (signButton.addEventListener) {" +
                    "signButton.addEventListener(\"click\", MyButtonClicked, false);" +
                "} else {" +
                    "signButton.attachEvent('onclick', MyButtonClicked);" +
                "}  " +
                "function MyButtonClicked(){" +
                    " window.external.notify('%%' + location.href);"+
                 "}"
            });
        }

        /// <summary>
        /// Handles the OnScriptNotify event of the WebView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NotifyEventArgs"/> instance containing the event data.</param>
        private void WebView_OnScriptNotify(object sender, NotifyEventArgs e)
        {
            var url = e.Value;
        }
    }
}
