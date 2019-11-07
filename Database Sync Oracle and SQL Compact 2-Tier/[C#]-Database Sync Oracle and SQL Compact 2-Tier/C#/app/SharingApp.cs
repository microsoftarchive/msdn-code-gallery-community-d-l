// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;


namespace SyncApplication
{
    static class OfflineApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("usage: SyncApplication.exe OracleConnectionString");
                return;
            }
            
            string oracleConnectionString = args[0];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CESharingForm(oracleConnectionString));              
        }
    }
}