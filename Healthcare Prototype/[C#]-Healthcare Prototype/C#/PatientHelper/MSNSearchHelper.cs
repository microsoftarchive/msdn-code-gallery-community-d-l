using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel ;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using IdentityMine.Avalon.Controls;
using PatientHelper.MSNSearch;

namespace PatientHelper
{
    public class MSNSearchHelper 
    {
        private MSNSearchService s;
        private string msnAppID;

        public string MsnAppID
        {
            get { return msnAppID; }
            set { msnAppID = value; }
        }

        private Dispatcher uiDispatcher;
        private Thread workerThread;
        private string queryText;

        public MSNSearchHelper()
        {
            // Create a new MSNSearchService object. MSNSearchService is the top-level
            // proxy class for accessing the service. MSNSearchService has one synchronous method:
            // Search, which takes a single SearchRequest object as an argument.
            // Asynchronous search methods, such as BeginSearch and EndSearch, may also be
            // available, depending on the SOAP toolkit used to generate the proxies.
            s = new MSNSearchService();

        }

        #region EventHandlers

        public delegate void MSNSearchCompleteEventHandler(object sender);

        public event MSNSearchCompleteEventHandler MSNSearchCompleteEvent;
        protected object OnMSNSearchCompleteEvent(object o)
        {
            if (MSNSearchCompleteEvent != null)
                MSNSearchCompleteEvent(o);
            return null; 
        }

        #endregion

   
        private void ExecuteMSNSearchQuery()
        {
            //THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
            //ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED
            //TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
            //PARTICULAR PURPOSE.
            //
            //Copyright (C) 2005  Microsoft Corporation.  All rights reserved.

            // Create a new SearchRequest object that represents the search request. Each SearchRequest can
            // contain multiple SourceRequest objects; however, each SearchRequest can contain
            // only one SourceRequest of each type. (More on this later.)
            SearchRequest searchRequest = new SearchRequest();
            
            int arraySize = 3;

            // Each SourceRequest can be configured to return one or more result fields:
            // CacheUrl, Description, DisplayUrl, SearchTags, Title, Url, and All.
            // Fields can be combined using the bitwise OR operator (|); 
            // All returns all available fields in the enumeration.
            // Note that some SourceRequest objects cannot return all of the fields
            // described. For example, a SourceRequest of type Spelling returns one spelling
            // suggestion in the Title field, so the returned data is the same when the
            // ResultFields property is set to ResultFieldMask.All or ResultFieldMask.Title.
            SourceRequest[] sr = new SourceRequest[arraySize];

            // The first SourceRequest is a Web source request. This can be a request for Web or
            // Web-Local results, depending on whether the Location object is set. When the user clicks
            // Near Me, the sample application applies the Location information to the search and
            // returns Web-Local results (results that consider Location as a relevance factor) and
            // PhoneBook results.
            sr[0] = new SourceRequest();
            sr[0].Source = SourceType.Web;

            // For this SourceRequest, we can return all fields...
            sr[0].ResultFields = ResultFieldMask.All;

            // Or just specific fields, such as SearchTags.
            // sr[0].ResultFields = ResultFieldMask.SearchTags;

            // To return a subset of all fields, combine the result fields using the bitwise
            // OR operator (|). The following example returns the Title and URL fields only:
            // sr[0].ResultFields = ResultFieldMask.Title | ResultFieldMask.Url;

            // Check for the number of results to return per page. If this value is not set,
            // the service returns the default number of results, which is ten per page.
            sr[0].Count = 10;

            // Check for an offset value. The default offset is zero, meaning that results are
            // returned from the MSN Search Engine with the highest-ranking result displayed first.
            // The Offset property is most commonly used in conjunction with the Count
            // property, above, for paging through long lists of results.
            sr[0].Offset = 0;

            //// The second SourceRequest is a spelling source request. Spelling returns only one
            //// result per call, in the Title field.
            //sr[1] = new SourceRequest();
            //sr[1].Source = SourceType.Spelling;
            //sr[1].ResultFields = ResultFieldMask.Title;
            //// Set the Count to 1 and the Offset to 0 for SourceType.Spelling; Spelling returns
            //// only one result per request (Count = 1) at offset zero (Offset = 0).
            //sr[1].Count = 1;
            //sr[1].Offset = 0;

            //// The third SourceRequest is a PhoneBook source request. PhoneBook results include
            //// a title, description, URL, phone number, address object, and location object.
            //// Although the DisplayUrl field can be returned, the URL it contains is not significant.
            //sr[2] = new SourceRequest();
            //sr[2].Source = SourceType.PhoneBook;

            //// In this sample, we will return the Title, Description, and Url fields, as well as
            //// the PhoneBook-specific return fields Phone, Address, and Location.
            //sr[2].ResultFields = ResultFieldMask.Title | ResultFieldMask.Url;
            ////   if (txtNumResults.Text != String.Empty)
            //sr[2].Count = 10;// Int32.Parse(txtNumResults.Text);
            ////    if (txtOffset.Text != String.Empty)
            //sr[2].Offset = 0;// Int32.Parse(txtOffset.Text);

            // The Query field of the SearchRequest object is the text of the query submitted to the
            // MSN Search Engine. The query can contain any valid query text supported by the 
            // MSN Search Engine, including advanced query syntax. 
            searchRequest.Query = queryText;

            // The Requests field of the SearchRequest object is the array of SourceRequest objects
            // for this search.
            searchRequest.Requests = sr;

            // Check the user selection for SafeSearchOptions.
            // If no setting is specified, the default setting of Moderate is applied to this SearchRequest.            
            searchRequest.SafeSearch = SafeSearchOptions.Off;
            // searchRequest.SafeSearch = SafeSearchOptions.Strict;
            // searchRequest.SafeSearch = SafeSearchOptions.Moderate;

            // Enter the Application ID, in double quotation marks, supplied by the 
            // Developer Provisioning System as the value of the AppID on the SearchRequest.
            searchRequest.AppID = msnAppID;

            // Determine whether the user chose to enable query word marking. Query word
            // marking returns specific characters before and after each word or group of words
            // used in the SearchRequest.Query field.
            searchRequest.Flags = SearchFlags.None;

            // Determine the user's CultureInfo selection.
            // The following code gets the CultureInfo value from the combo box.
            // The combo box collection contains all values recognized by the MSN Search Engine.
            // You can also set the CultureInfo to a specific value in the code, as shown in the
            // following example:
            searchRequest.CultureInfo = "en-US";

            // To return PhoneBook results in addition to Web results, the user must set the Location.
            // The following code sets the Latitude and Longitude fields of the Location
            // object and the Radius of the search.
            // If invalid Location data is specified, the MSN Search Engine will attempt to
            // return search results based on the information provided. Note that zero results
            // may return  if the Location data does not map to a valid geographic location.
            // The value of Radius also affects the search results; a small value for Radius may
            // return fewer results than expected.
            // The sample application user interface does not validate user input.
            //if (nearMe)
            //{
            //    double latitude = Double.Parse(txtLatitude.Text);
            //    double longitude = Double.Parse(txtLongitude.Text);
            //    double radius = Double.Parse(txtRadius.Text);
            //    searchRequest.Location = new Location();
            //    searchRequest.Location.Latitude = latitude;
            //    searchRequest.Location.Longitude = longitude;
            //    searchRequest.Location.Radius = radius;
            //}

            // Once the SearchRequest has been configured and all of the SourceRequest
            // objects have been configured and added to the SearchRequest, the
            // application can process the request.

            //  s.SearchCompleted += new SearchCompletedEventHandler(s_SearchCompleted);
            // Execute the search request and return the search response by
            // setting the SearchResponse to MSNSearchService.Search(SearchRequest).
            SearchResponse searchResponse = s.Search(searchRequest);
            SearchMSNItemCollection list = new SearchMSNItemCollection();

            // Check the SearchResponse to determine whether it contains a spelling suggestion.
            // The spelling suggestion is returned in the Title field of the Spelling SourceResponse.
            // If the SearchResponse does not contain a Spelling SourceResponse, there is no
            // spelling suggestion and the application passes the SearchResponse to the printResults method.
            // If a Spelling SourceResponse is returned, the application displays a MessageBox that asks
            // the user to choose whether to ignore the spelling suggestion or accept the spelling
            // suggestion and re-execute the query with the updated query string.
            // To test for the presence of the Spelling SourceResponse, check the Total field for
            // the SearchResponse.Response for the Spelling SourceType.


            foreach (SourceResponse sourceResponse in searchResponse.Responses)
            {
                // The requested result fields for each SourceRequest are returned in the 
                // Results field of the respective SourceResponse.
                Result[] sourceResults = sourceResponse.Results;

                // Using foreach, loop through the results returned in each SourceResponse.
                foreach (Result sourceResult in sourceResults)
                {
                    SearchMSNItem searchMSNItem = new SearchMSNItem();
                    searchMSNItem.Name = sourceResult.Title;
                    searchMSNItem.Path = sourceResult.Url;
                    list.Add(searchMSNItem);
                }
            }

            if (uiDispatcher != null)
                uiDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(OnMSNSearchCompleteEvent), (object)list);
        }

        public void ExecuteMSNSearch(string text)
        {
            queryText = text;
            // track the dispatcher because we need to get back to the UI thread
            uiDispatcher = Dispatcher.CurrentDispatcher;

            // Start worker thread to access internet, get search result
            workerThread = new Thread(new ThreadStart(ExecuteMSNSearchQuery));
            workerThread.Priority = ThreadPriority.Normal;
            workerThread.Start();

        }

    }
}
