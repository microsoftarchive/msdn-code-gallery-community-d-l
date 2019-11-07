using System;
namespace com.tp.pattern.observer
{
    class WebSiteDisplay : IChannelUsers
    {
        IPaidNewsChannels chan;
        public void setNewsChannel(IPaidNewsChannels someNewsChannel)
        {
            if (chan != null)
                this.chan.UnSubscribeMe(this);
            this.chan = someNewsChannel;
            if (chan != null)
                this.chan.SubscribeMe(this);
        }

        public void notifyNews(News news)
        {
            DisplayOnWebsite(news);
        }
        private void DisplayOnWebsite(News news)
        {
            Console.WriteLine("^^^^^     WebSite     ^^^^^");
            Console.WriteLine(news.NewsHeading + Environment.NewLine + Environment.NewLine + news.NewsDetail + Environment.NewLine + new string('_', 80));
        }
    }
}