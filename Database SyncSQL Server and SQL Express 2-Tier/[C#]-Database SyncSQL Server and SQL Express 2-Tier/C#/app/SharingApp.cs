// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Windows.Forms;



namespace SyncApplication
{
    static class OfflineApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SqlSharingForm());              
        }
    }
}