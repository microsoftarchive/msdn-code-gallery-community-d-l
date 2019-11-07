using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LinqToTwitter;

namespace Facebook
{
    class Program
    {
        //TODO
        static void Main(string[] args)
        {
            Console.WriteLine("Section A: Initialise local variables");



            string accessToken = string.Empty;
            Console.WriteLine("Enter your access token");
            accessToken = Console.ReadLine();

            string accessTokenSecret = string.Empty;
            Console.WriteLine("Enter your access token Secret ");
            accessTokenSecret = Console.ReadLine();


            string consumerKey = string.Empty;
            Console.WriteLine("Enter your access consumer Key ");
            consumerKey = Console.ReadLine();

            string consumerSecret = string.Empty;
            Console.WriteLine("Enter your access token Secret");
            consumerSecret = Console.ReadLine();

            string twitterAcccountToDisplay = string.Empty;
            Console.WriteLine("Enter your access twitterAcccountToDisplay");
            twitterAcccountToDisplay = Console.ReadLine();

            string searchTweet = string.Empty;
            Console.WriteLine("Search for the tweet ");
            searchTweet = Console.ReadLine();

            int tweetCount;
            Console.WriteLine("Tweet Count");
            tweetCount = Convert.ToInt32(Console.ReadLine());

            // SECTION B: Setup Single User Authorisation
            Console.WriteLine("SECTION B: Setup Single User Authorisation");
            var authorizer = new SingleUserAuthorizer
            {

                CredentialStore = new InMemoryCredentialStore()
                {
                    ConsumerKey = consumerKey,
                    ConsumerSecret = consumerSecret,
                    OAuthToken = accessToken,
                    OAuthTokenSecret = accessTokenSecret,
                    ScreenName = twitterAcccountToDisplay,
                    UserID = 66370920
                }
            };

            // SECTION C: Generate the Twitter Context
            Console.WriteLine("SECTION C: Generate the Twitter Context");
            var twitterContext = new TwitterContext(authorizer);

            List<Search> statusTweets = new List<Search>();

            // SECTION D: Get Tweets for user
            Console.WriteLine("SECTION D: Get Tweets for user");
            try
            {
                statusTweets = (from tweet in twitterContext.Search
                                where tweet.Type == SearchType.Search && tweet.Query == searchTweet
                                && tweet.Count == tweetCount
                                select tweet).ToList();
            }
            catch (AggregateException e)
            {

                Console.WriteLine("AggregateException {0}", e.InnerExceptions[0]);

            }


            // SECTION E: Print Tweets
            Console.WriteLine("SECTION E: Print Tweets");
            PrintTweets(statusTweets);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the tweets.
        /// </summary>
        /// <param name="statusTweets">The status tweets.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void PrintTweets(List<Search> statusTweets)
        {
            foreach (var statusTweet in statusTweets)
            {

                statusTweet.Statuses.ForEach(tweet =>
                   Console.WriteLine(
                       "User: {0}, Tweet: {1} \n",
                       tweet.User.ScreenNameResponse,
                       tweet.Text));

                Thread.Sleep(1000);
            }
        }
    }
}
