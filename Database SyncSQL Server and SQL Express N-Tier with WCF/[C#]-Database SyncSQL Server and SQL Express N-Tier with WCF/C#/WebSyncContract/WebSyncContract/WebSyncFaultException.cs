using System;
using System.Runtime.Serialization;

namespace WebSyncContract
{
    [DataContract]
    public class WebSyncFaultException 
    {
        public string message;
        public Exception innerException;

        public WebSyncFaultException(string message, Exception innerException) 
        {
            this.message = message;
            this.innerException = innerException;
        }

        [DataMember]
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        [DataMember]
        public Exception InnerException
        {
            get
            {
                return this.innerException;
            }

            set
            {
                this.innerException = value;
            }
        }
    }
}
