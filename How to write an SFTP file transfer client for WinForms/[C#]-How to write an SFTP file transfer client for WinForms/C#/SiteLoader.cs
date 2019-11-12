using System;
using System.Collections.Generic;
using System.Xml;

namespace ClientSample
{
    struct SiteInfo
    {
        public string Address;
        public int Port;
        public string UserName;
        public string Password;
        public int Security;
        public string Description;
    }

    class SiteLoader
    {
        public static SiteInfo[] GetSites()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Sites.xml";

            List<SiteInfo> list = new List<SiteInfo>();
            XmlTextReader xmlReader = null;
            try
            {
                xmlReader = new XmlTextReader(fileName);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "sites")
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "add")
                            {
                                string address = null;
                                int port = 0;
                                string userName = null;
                                string password = null;
                                int security = 0;
                                string desc = null;

                                while (xmlReader.MoveToNextAttribute())
                                {
                                    if (xmlReader.Name == "address")
                                        address = xmlReader.Value;
                                    else if (xmlReader.Name == "port")
                                    {
                                        if (xmlReader.Value != string.Empty)
                                            port = int.Parse(xmlReader.Value);
                                        else
                                            port = 0;
                                    }
                                    else if (xmlReader.Name == "userName")
                                        userName = xmlReader.Value;
                                    else if (xmlReader.Name == "password")
                                        password = xmlReader.Value;
                                    else if (xmlReader.Name == "security")
                                        security = int.Parse(xmlReader.Value);
                                    else if (xmlReader.Name == "desc")
                                        desc = xmlReader.Value;
                                }

                                if (address != null)
                                {
                                    SiteInfo info = new SiteInfo();
                                    info.Address = address;
                                    info.Port = port;
                                    info.UserName = userName;
                                    info.Password = password;
                                    info.Security = security;
                                    info.Description = desc;

                                    list.Add(info);
                                }
                            }
                        }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                // Finished with XmlTextReader
                if (xmlReader != null)
                    xmlReader.Close();
            }

            return list.ToArray();
        }
    }
}