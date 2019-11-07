using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PhpMyAdminConnection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //The Windows.Web.Http.HttpClient class provides the main class for 
        // sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
        private HttpClient httpClient;
        private HttpResponseMessage response;

        // This is the url that will checked by the php file
        private String phpAddress = "http://localhost/login.php?";

        // This is the complete url that must be checked and verified by the php file
        // private String phpAddress = "http://localhost/login.php?login=user&pwd=user";
        public MainPage()
        {
            this.InitializeComponent();

            httpClient = new HttpClient();

            // Add a user-agent header
            var headers = httpClient.DefaultRequestHeaders;

            // HttpProductInfoHeaderValueCollection is a collection of 
            // HttpProductInfoHeaderValue items used for the user-agent header

            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            phpAddress = "http://localhost/login.php?login=" + tbLogin.Text + "&pwd=" + tbPwd.Text;
            response = new HttpResponseMessage();

            // if 'phpAddress' value changed the new URI must be tested --------------------------------
            // if the new 'phpAddress' doesn't work, 'phpStatus' informs the user about the incorrect input.


            Uri resourceUri;
            if (!Uri.TryCreate(phpAddress.Trim(), UriKind.Absolute, out resourceUri))
            {
                phpStatus.Text = "Invalid URI, please re-enter a valid URI";
                return;
            }
            if (resourceUri.Scheme != "http" && resourceUri.Scheme != "https")
            {
                phpStatus.Text = "Only 'http' and 'https' schemes supported. Please re-enter URI";
                return;
            }
            // ---------- end of test---------------------------------------------------------------------

            string responseText;
            phpStatus.Text = "Waiting for response ...";

            try
            {
                response = await httpClient.GetAsync(resourceUri);

                response.EnsureSuccessStatusCode();

                responseText = await response.Content.ReadAsStringAsync();


            }
            catch (Exception ex)
            {
                // Need to convert int HResult to hex string
                phpStatus.Text = "Error = " + ex.HResult.ToString("X") +
                    "  Message: " + ex.Message;
                responseText = "";
            }
            phpStatus.Text = response.StatusCode + " " + response.ReasonPhrase;

            // now 'responseText' contains the response as a verified text.
            // next 'responseText' is displayed 


            phpStatus.Text = responseText.ToString();
        }
    }
}
