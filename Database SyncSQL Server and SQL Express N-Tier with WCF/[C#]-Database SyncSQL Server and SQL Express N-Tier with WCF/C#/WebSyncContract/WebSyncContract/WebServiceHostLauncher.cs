using System;
using System.Collections.Generic;

using System.Text;
using System.ServiceModel;

namespace WebSyncContract
{
    public class WebServiceHostLauncher
    {
        public static void Main(String[] args)
        {
            try
            {
                ServiceHost sqlHost = new ServiceHost(typeof(SqlWebSyncService));
                sqlHost.Open();

                Console.WriteLine("Press <ENTER> to terminate the service host");
                Console.ReadLine();

                sqlHost.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in opening servicehost. " + e);
                Console.ReadLine();
            }
        }
    }
}
