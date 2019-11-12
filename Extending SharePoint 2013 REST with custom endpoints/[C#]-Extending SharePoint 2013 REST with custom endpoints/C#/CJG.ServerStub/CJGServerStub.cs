using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.ServerRuntime;

namespace CJG.ServerStub
{
    [ServerStub(typeof(CJG), TargetTypeId = "{E1BB82E8-0D1E-4e52-B90C-684802AB4EF7}")]
    public class CJGServerStub : Microsoft.SharePoint.Client.ServerStub
    {
        private Dictionary<string, MethodInformation> m_allMethods;
        private static Guid s_targetTypeId;
 

        static CJGServerStub()
        {
            s_targetTypeId = new Guid("{E1BB82E8-0D1E-4e52-B90C-684802AB4EF7}");

        }

        public CJGServerStub()
        {

        }

        protected override Type TargetType
        {
            get
            {
                return typeof(CJG);
            }
        }

        protected override Guid TargetTypeId
        {
            get
            {
                return s_targetTypeId;
            }
        }

 

        protected override string TargetTypeScriptClientFullName
        {
            get
            {
                return "SP.CJG";
            }
        }

        protected override object GetProperty(object target, string propName, ProxyContext proxyContext)
        {
            if (propName == null)
            {
                throw new ArgumentNullException("propName");
            }
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            CJG site = target as CJG;
            if (site == null)
            {
                throw new ArgumentNullException("target");
            }
            propName = base.GetMemberName(propName, proxyContext);

            switch (propName)
            {
                case "FirstName":
                    base.CheckBlockedGetProperty("FirstName", proxyContext);
                    return site.FirstName;                
            }

            return base.GetProperty(target, propName, proxyContext);
        }


        protected override object InvokeConstructor(XmlNodeList xmlargs, ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            base.CheckBlockedMethod(".ctor", proxyContext);
            return CJG_ConProxy(xmlargs, proxyContext);
        }

        protected override object InvokeConstructor(ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            base.CheckBlockedMethod(".ctor", proxyContext);
            return CJG_ConProxy(xmlargs, proxyContext);
        }

        private static CJG CJG_ConProxy(XmlNodeList xmlargs, ProxyContext proxyContext)
        {
            return new CJG();
        }


        private static CJG CJG_ConProxy(ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            return new CJG();
        }

        protected override object InvokeMethod(object target, string methodName, ClientValueCollection xmlargs, ProxyContext proxyContext, out bool isVoid)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            CJG me = target as CJG;
            if (me == null)
            {
                throw new ArgumentNullException("target");
            }
            methodName = base.GetMemberName(methodName, proxyContext);

            switch (methodName)
            {
                case "Empty":
                    isVoid = true;
                    //base.CheckBlockedMethod("Empty", proxyContext);
                    //UpdateClientObjectModelUseRemoteAPIsPermissionSetting_MethodProxy(site, xmlargs, proxyContext);
                    return null;
                case "ReturnInt":
                    isVoid = true;
                    //base.CheckBlockedMethod("ReturnInt", proxyContext);
                    return me.ReturnInt();
                case "ReturnDate":
                    isVoid = true;
                    //base.CheckBlockedMethod("ReturnDate", proxyContext);
                    return me.ReturnDate();
            }

            return base.InvokeMethod(target, methodName, xmlargs, proxyContext, out isVoid);
        }

        protected override IEnumerable<MethodInformation> GetMethods(ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }

            MethodInformation iteratorVariable1 = new MethodInformation
            {
                Name = "ReturnInt",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "ReturnInt",
                WildcardPath = false,
                ReturnType = typeof(int),
                ReturnODataType = ODataType.Primitive,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return iteratorVariable1;

            MethodInformation iteratorVariable2 = new MethodInformation
            {
                Name = "ReturnDate",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "ReturnDate",
                WildcardPath = false,
                ReturnType = typeof(DateTime),
                ReturnODataType = ODataType.Primitive,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return iteratorVariable2;

            MethodInformation iteratorVariable3 = new MethodInformation
            {
                Name = ".ctor",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.RESTful,
                OriginalName = ".ctor",
                WildcardPath = false,
                ReturnType = null,
                ReturnODataType = ODataType.Invalid,
                RESTfulExtensionMethod = false,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.None
            };          
            yield return iteratorVariable3;

        }

        protected override IEnumerable<PropertyInformation> GetProperties(ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }            

            PropertyInformation iteratorVariable1 = new PropertyInformation
            {
                Name = "FirstName",
                IsStatic = false,
                PropertyODataType = ODataType.Primitive,
                ExcludeFromDefaultRetrieval = false,
                PropertyType = typeof(string),
                ReadOnly = false,
                RequiredForHttpPutRequest = true,
                DefaultValue = false,
                OriginalName = "FirstName",
                RESTfulPropertyType = null,
                RequiredRight = ResourceRight.Default
            };

            yield return iteratorVariable1;

        }

        protected override ClientLibraryTargets ClientLibraryTargets
        {
            get
            {
                return ClientLibraryTargets.All;
            }
        }

    }
}
