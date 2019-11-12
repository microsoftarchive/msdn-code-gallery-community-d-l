using System;
namespace com.tp.pattern.observer
{
    public class ObserverPattern:Pattern
    {
        public string DisplayName()
        {
            return "Observer Pattern";
        }

        public void ProblemStatement()
        {
            Console.WriteLine("We have a service whose value/property changes, but we are not sure when. Many other modules/apps/services provide their service on those values. In order to reflect correct value what we can do is to ask for latest updates after fixed/random interval (Pull) but chances are many of them will be worthless (since value has not yet changed). So what can we do?");
        }

        public void Help()
        {
            Console.WriteLine("\t");
            Console.WriteLine("IPaidNewsChannels.cs\tObservable interface.");
            Console.WriteLine("IChannelUsers.cs\tObservers interface.");
            Console.WriteLine();

            Console.WriteLine("News.cs\t\t\tObservable provide an update on news.");
            Console.WriteLine();

            Console.WriteLine("PaidNewsChannel1.cs\tThis is the observable implementation.");
            Console.WriteLine();

            Console.WriteLine("MobileUser.cs\t\tA mobile observer.");
            Console.WriteLine("TVUserBreakingNews.cs\tA Television observer.");
            Console.WriteLine("WebSiteDisplay.cs\tA website observer.");
            Console.WriteLine();

        }

        public void Process()
        {
            String sep = new String('*', 80);
            Console.WriteLine("Creating 1 news channel : PaidNewsChannel1");
            IPaidNewsChannels chan = new PaidNewsChannel1();
            Console.WriteLine("Creating Mobile User and subscribing it.");
            
            MobileUser m = new MobileUser();
            m.setNewsChannel(chan);

            Console.WriteLine("Press a key to notify users.");
            Console.ReadKey();
            Console.WriteLine("Notifying Users.");
            Console.Clear();
            Console.WriteLine(sep);
            chan.NotifySubscribers();
            Console.WriteLine(sep);
            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Adding TVUser and WebSiteUser");
            WebSiteDisplay web = new WebSiteDisplay();
            web.setNewsChannel(chan);
            TVUserBreakingNews tv = new TVUserBreakingNews();
            tv.setNewsChannel(chan);

            Console.WriteLine("Press a key to notify users.");
            Console.ReadKey();
            Console.WriteLine("Notifying Users.");
            Console.Clear();
            Console.WriteLine(sep);
            chan.NotifySubscribers();
            Console.WriteLine(sep);
            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Mobile and TV subscribers are bored of update so want to unsubscribe. So let us set its channel to null.");
            m.setNewsChannel(null);
            tv.setNewsChannel(null);

            Console.WriteLine("Press a key to notify users.");
            Console.ReadKey();
            Console.WriteLine("Notifying Users.");
            Console.Clear();
            Console.WriteLine(sep);
            chan.NotifySubscribers();
            Console.WriteLine(sep);
            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(Environment.NewLine + "You must have visited the code and figured out that it is behaving like a Push service where observers are sitting idle or performing some other tasks and gets notified by the observables as and when the update is available to observables.");
        }

        public void Implementation()
        {
            Console.WriteLine("We create Observable interface which provides the update and implement it. We provide observer interface for all those modules who want to receive updates. All the observers have an observable instance. They call register/deregister on observable to register/deregister themselves for updates. Observable adds all of the observables in some array/hashtable/list and calls notify as and when the updates are available." + Environment.NewLine + Environment.NewLine + "Again note that observable and observers can continue doing/behaving as they want and at the same time behave as observable and/or ovserver.");
        }
    }
}
