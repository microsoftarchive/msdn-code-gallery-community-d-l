using System;
using System.Threading;

namespace UnhandledExceptionHandler.Model
{
    // Because this class is derived from MarshalByRefObject, a proxy  
    // to a MarshalByRefType object can be returned across an AppDomain  
    // boundary. 
    public class SecondAppDomainObject : MarshalByRefObject
    {
        Timer timer;

        //  Call this method via a proxy. 
        public void StartProcessingStuff()
        {
            timer = new Timer(tick, null, 1000, 1000);
        }

        void tick(object state)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite); // Stop timer
            throw new Exception("New AppDomain Unhandled Exception!!", new ArgumentOutOfRangeException());
        }
    }

}
