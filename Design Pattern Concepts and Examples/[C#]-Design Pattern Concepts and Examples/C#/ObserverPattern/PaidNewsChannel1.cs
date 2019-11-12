using System.Collections;
using System;
namespace com.tp.pattern.observer
{
    class PaidNewsChannel1:IPaidNewsChannels
    {
        News news;
        ArrayList myObservers = new ArrayList();

        public PaidNewsChannel1()
        {
            news = new News();
        }
        public void SubscribeMe(IChannelUsers user)
        {
            myObservers.Add(user);
        }

        public void UnSubscribeMe(IChannelUsers user)
        {
            myObservers.Remove(user);
        }


        public void NotifySubscribers()
        {
            news.NewsHeading = "Any News " + new Random().Next().ToString();
            news.NewsDetail = "This is a really very long detail of any news.";
            news.NewsDigest = "A short digest of news." ;
            foreach (Object obj in myObservers)
            {
                ((IChannelUsers)obj).notifyNews(news);
            }
        }
    }
}
