using System;
namespace com.tp.pattern.observer
{
    class MobileUser:IChannelUsers
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
            DisplayOnMobile(news);
        }
        private void DisplayOnMobile(News news)
        {
            Console.WriteLine("^^^^^     Mobile     ^^^^^");
            Console.WriteLine(news.NewsHeading+Environment.NewLine+news.NewsDigest+Environment.NewLine+(new string('=',30)));
        }
    }
}
