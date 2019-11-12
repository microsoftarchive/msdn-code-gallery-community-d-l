using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OAuthLinkedIn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string _consumerKey = "consumer key";
        string _consumerSecretKey = "consumer secret key";
        string _linkedInRequestTokenUrl = "https://api.linkedin.com/uas/oauth/requestToken";
        string _linkedInAccessTokenUrl = "https://api.linkedin.com/uas/oauth/accessToken";

        string _requestPeopleUrl = "http://api.linkedin.com/v1/people/~";
        string _requestConnectionsUrl = "http://api.linkedin.com/v1/people/~/connections";
        string _requestPositionsUrl = "http://api.linkedin.com/v1/people/~:(positions)";

        OAuthUtil oAuthUtil = new OAuthUtil();

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            consumerKey.Text = _consumerKey;
            consumerSecretKey.Text = _consumerSecretKey;
        }

        private async void getRequestToken_Click_1(object sender, RoutedEventArgs e)
        {
            string nonce = oAuthUtil.GetNonce();
            string timeStamp = oAuthUtil.GetTimeStamp();

            string sigBaseStringParams = "oauth_consumer_key=" + consumerKey.Text;

            sigBaseStringParams += "&" + "oauth_nonce=" + nonce;
            sigBaseStringParams += "&" + "oauth_signature_method=" + "HMAC-SHA1";
            sigBaseStringParams += "&" + "oauth_timestamp=" + timeStamp;
            sigBaseStringParams += "&" + "oauth_version=1.0";
            string sigBaseString = "POST&";
            sigBaseString += Uri.EscapeDataString(_linkedInRequestTokenUrl) + "&" + Uri.EscapeDataString(sigBaseStringParams);

            string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text);

            var responseText = await oAuthUtil.PostData(_linkedInRequestTokenUrl, sigBaseStringParams + "&oauth_signature=" + Uri.EscapeDataString(signature));

            if (!string.IsNullOrEmpty(responseText))
            {
                string oauth_token = null;
                string oauth_token_secret = null;
                string oauth_authorize_url = null;
                string[] keyValPairs = responseText.Split('&');

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            oauth_token = splits[1];
                            break;
                        case "oauth_token_secret":
                            oauth_token_secret = splits[1];
                            break;
                        case "xoauth_request_auth_url":
                            oauth_authorize_url = splits[1];
                            break;
                    }
                }

                requestToken.Text = oauth_token;
                requestTokenSecretKey.Text = oauth_token_secret;
                oAuthAuthorizeLink.Content = Uri.UnescapeDataString(oauth_authorize_url + "?oauth_token=" + oauth_token);
            }
        }

        private async void getAccessToken_Click_1(object sender, RoutedEventArgs e)
        {
            string nonce = oAuthUtil.GetNonce();
            string timeStamp = oAuthUtil.GetTimeStamp();

            string sigBaseStringParams = "oauth_consumer_key=" + consumerKey.Text;
            sigBaseStringParams += "&" + "oauth_nonce=" + nonce;
            sigBaseStringParams += "&" + "oauth_signature_method=" + "HMAC-SHA1";
            sigBaseStringParams += "&" + "oauth_timestamp=" + timeStamp;
            sigBaseStringParams += "&" + "oauth_token=" + requestToken.Text;
            sigBaseStringParams += "&" + "oauth_verifier=" + oAuthVerifier.Text;
            sigBaseStringParams += "&" + "oauth_version=1.0";
            string sigBaseString = "POST&";
            sigBaseString += Uri.EscapeDataString(_linkedInAccessTokenUrl) + "&" + Uri.EscapeDataString(sigBaseStringParams);

            // LinkedIn requires both consumer secret and request token secret
            string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text, requestTokenSecretKey.Text);

            var responseText = await oAuthUtil.PostData(_linkedInAccessTokenUrl, sigBaseStringParams + "&oauth_signature=" + Uri.EscapeDataString(signature));

            if (!string.IsNullOrEmpty(responseText))
            {
                string oauth_token = null;
                string oauth_token_secret = null;
                string[] keyValPairs = responseText.Split('&');

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            oauth_token = splits[1];
                            break;
                        case "oauth_token_secret":
                            oauth_token_secret = splits[1];
                            break;
                    }
                }

                accessToken.Text = oauth_token;
                accessTokenSecretKey.Text = oauth_token_secret;
            }
        }

        private void oAuthAuthorizeLink_Click_1(object sender, RoutedEventArgs e)
        {
            WebViewHost.Visibility = Windows.UI.Xaml.Visibility.Visible;
            WebViewHost.Navigate(new Uri(oAuthAuthorizeLink.Content.ToString()));
        }

        private async void requestUserProfile_Click_1(object sender, RoutedEventArgs e)
        {
            requestLinkedInApi(_requestPeopleUrl);
        }

        private void requestConnections_Click_1(object sender, RoutedEventArgs e)
        {
            requestLinkedInApi(_requestConnectionsUrl);
        }

        private void requestPositions_Click_1(object sender, RoutedEventArgs e)
        {
            requestLinkedInApi(_requestPositionsUrl);
        }

        private async void requestLinkedInApi(string url)
        {
            string nonce = oAuthUtil.GetNonce();
            string timeStamp = oAuthUtil.GetTimeStamp();

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.MaxResponseContentBufferSize = int.MaxValue;
                httpClient.DefaultRequestHeaders.ExpectContinue = false;
                HttpRequestMessage requestMsg = new HttpRequestMessage();
                requestMsg.Method = new HttpMethod("GET");
                requestMsg.RequestUri = new Uri(url, UriKind.Absolute);

                string sigBaseStringParams = "oauth_consumer_key=" + consumerKey.Text;
                sigBaseStringParams += "&" + "oauth_nonce=" + nonce;
                sigBaseStringParams += "&" + "oauth_signature_method=" + "HMAC-SHA1";
                sigBaseStringParams += "&" + "oauth_timestamp=" + timeStamp;
                sigBaseStringParams += "&" + "oauth_token=" + accessToken.Text;
                sigBaseStringParams += "&" + "oauth_verifier=" + oAuthVerifier.Text;
                sigBaseStringParams += "&" + "oauth_version=1.0";
                string sigBaseString = "GET&";
                sigBaseString += Uri.EscapeDataString(url) + "&" + Uri.EscapeDataString(sigBaseStringParams);

                // LinkedIn requires both consumer secret and request token secret
                string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text, accessTokenSecretKey.Text);

                string data = "realm=\"http://api.linkedin.com/\", oauth_consumer_key=\"" + consumerKey.Text
                              +
                              "\", oauth_token=\"" + accessToken.Text +
                              "\", oauth_verifier=\"" + oAuthVerifier.Text +
                              "\", oauth_nonce=\"" + nonce +
                              "\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"" + timeStamp +
                              "\", oauth_version=\"1.0\", oauth_signature=\"" + Uri.EscapeDataString(signature) + "\"";
                requestMsg.Headers.Authorization = new AuthenticationHeaderValue("OAuth", data);
                var response = await httpClient.SendAsync(requestMsg);
                var text = await response.Content.ReadAsStringAsync();
                WebViewHost.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                LinkedInResponse.Visibility = Windows.UI.Xaml.Visibility.Visible;
                LinkedInResponse.Text = text;
            }
            catch (Exception Err)
            {
                throw;
            }
        }
    }
}
