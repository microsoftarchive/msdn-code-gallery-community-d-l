/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

namespace PortInUse
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener httpListner = new HttpListener();
            httpListner.Prefixes.Add("http://*:8080/");
            httpListner.Start();

            Console.WriteLine("Port: 8080 status: " + (PortInUse(8080) ? "in use" : "not in use"));

            Console.ReadKey();

            httpListner.Close();
        }

        public static bool PortInUse(int port)
        {
            bool inUse = false;
            
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }

            return inUse;
        }
    }
}
