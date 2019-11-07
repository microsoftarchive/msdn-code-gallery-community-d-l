using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.ServerRuntime;

namespace CJG.ServerStub
{
    [ClientCallableObjectFactory(ServerTypeId="740c6a0b-85e2-48a0-a494-e0f1759d4aa8")]
    public class CJGObjectFactory: ClientCallableObjectFactory
    {
        public override object GetObjectById(string objectId)
        {
            return new CJG();
        }
    }
}
