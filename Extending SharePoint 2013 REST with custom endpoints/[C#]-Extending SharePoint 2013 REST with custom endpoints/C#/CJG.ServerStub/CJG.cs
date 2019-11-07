using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;

namespace CJG.Client
{
    [ScriptType("SP.CJG", ServerTypeId = "{E1BB82E8-0D1E-4e52-B90C-684802AB4EF7}")]
    public class CJG : ClientObject
    {
        public CJG(ClientRuntimeContext context, ObjectPath objectPath)
            : base(context, objectPath)
        {
        }

        [Remote]
        public bool FirstName
        {
            get
            {
                base.CheckUninitializedProperty("FirstName");
                return (bool)base.ObjectData.Properties["FirstName"];
            }
            set
            {
                base.ObjectData.Properties["FirstName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "FirstName", value));
                }
            }
        }

    }
}

namespace CJG.ServerStub
{
    [ClientCallableType(Name="CJG", ServerTypeId="{E1BB82E8-0D1E-4e52-B90C-684802AB4EF7}", FactoryType=typeof(CJGObjectFactory))]
    public class CJG
    {
        public CJG()
        {

        }

        [ClientCallableProperty]
        public string FirstName { get; set; }

        [ClientCallableMethod]
        public int ReturnInt()
        {
            System.Random r = new Random();
            return r.Next();
        }

        [ClientCallable]
        public DateTime ReturnDate()
        {
            return DateTime.Now;
        }
    }
}
