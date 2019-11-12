//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.Dynamic;
using System.Windows.Forms;
using NorthwindMapping;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // For this sample to work, you need an active database server or SqlExpress.
            // Here is a connection to the Data sample project that ships with Microsoft Visual Studio 2008.
            string dbPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\..\Data\NORTHWND.MDF"));
            string sqlServerInstance = @".\SQLEXPRESS";
            string connString = "AttachDBFileName='" + dbPath + "';Server='" + sqlServerInstance + "';user instance=true;Integrated Security=SSPI;Connection Timeout=60";
            
            // Here is an alternate connect string that you can modify for your own purposes.
            // string connString = "server=test;database=northwind;user id=test;password=test";

            Northwind db = new Northwind(connString); 
            db.Log = Console.Out;

            var query =
                db.Customers.Where("City == @0 and Orders.Count >= @1", "London", 10).
                OrderBy("CompanyName").
                Select("New(CompanyName as Name, Phone)");

            Console.WriteLine(query);
            Console.ReadLine();
        }
    }
}
