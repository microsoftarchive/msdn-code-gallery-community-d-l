using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;

namespace CJG.ServerStub
{
    public class ScriptTypeFactory : IScriptTypeFactory
    {
        // Methods
        public ScriptTypeFactory()
        {
        }

        public IFromJson CreateObjectFromScriptType(string scriptType, ClientRuntimeContext context)
        {
            switch (scriptType)
            {
                case "SP.CJG":
                    return new Client.CJG(context, null);
            }

            return null;
        }

    }
}
