using System;
namespace com.tp.pattern.observer
{
    class TVUserBreakingNews : IChannelUsers
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
            DisplayOnTVAsBreakingNews(news);
        }
        private void DisplayOnTVAsBreakingNews(News news)
        {
            Console.WriteLine("^^^^^     TV     ^^^^^");
            Console.WriteLine("Breaking News : " + news.NewsHeading + Environment.NewLine + new String('+', 50));
        }
    }
}