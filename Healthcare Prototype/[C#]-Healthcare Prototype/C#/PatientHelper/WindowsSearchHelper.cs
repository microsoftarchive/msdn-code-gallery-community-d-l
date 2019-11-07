using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Threading;
using System.Threading;
using System.Data.OleDb;
using IdentityMine.Avalon.Controls;

namespace PatientHelper
{
    public class WindowsSearchHelper
    {
        private string connectionString;
        private Dispatcher uiDispatcher;
        private Thread workerThread;
        private string queryText;
        private string query;

        public string QueryText
        {
            get { return queryText; }
            set { queryText = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        #region EventHandlers
        public delegate void WindowsSearchCompleteEventHandler(object sender);

        public event WindowsSearchCompleteEventHandler WindowsSearchCompleteEvent;
        protected object OnWindowsSearchCompleteEvent(object o)
        {
            if (WindowsSearchCompleteEvent != null)
                WindowsSearchCompleteEvent(o);
            return null;
        }

        #endregion

        void ExecuteWindowsSearchQuery()
        {
            string tempString = queryText;
            int index = tempString.IndexOf('#');
            string queryWithParam = tempString.Remove(index, 1);
            if(query.Contains("") )
                tempString = queryWithParam.Insert(index, "\""+query+"\"");
            else
                tempString = queryWithParam.Insert(index, query);

            SearchXPSItemCollection list = new SearchXPSItemCollection();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    OleDbCommand cmd = new OleDbCommand(tempString, connection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        int numColumns = reader.FieldCount;

                        object[] values = new object[numColumns];

                        while (reader.Read())
                        {
                            reader.GetValues(values);
                            string[] rowTextValues = GetRowTextValues(values);
                            
                            SearchXPSItem searchXPSItem = new SearchXPSItem();
                            searchXPSItem.Name = rowTextValues[0];
                            searchXPSItem.Path = rowTextValues[1];
                            list.Add(searchXPSItem);
                        }
                    }
                }
            }
            catch { }
          
            if (uiDispatcher != null)
                uiDispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback(OnWindowsSearchCompleteEvent), (object)list);
        }

        // Process a row from the query results, and combine any multi-valued columns
        string[] GetRowTextValues(object[] QueryResultValues)
        {
            string[] textValues = new string[QueryResultValues.Length];
            for (int i = 0; i < QueryResultValues.Length; i++)
            {
                if (!QueryResultValues[i].GetType().IsArray)
                {
                    textValues[i] = QueryResultValues[i].ToString();
                }
                else
                {
                    int count = 0;
                    string colValue = "";

                    foreach (object o in QueryResultValues[i] as Array)
                    {
                        if (count++ > 0)
                        {
                            colValue += ";";
                        }
                        colValue += o.ToString();
                    }
                }
            }

            return (textValues);
        }

        public void ExecuteWindowsSearch(string text)
        {
            query = text;
            // track the dispatcher because we need to get back to the UI thread
            uiDispatcher = Dispatcher.CurrentDispatcher;

            // Start worker thread to access internet, get search result
            workerThread = new Thread(new ThreadStart(ExecuteWindowsSearchQuery));
            workerThread.Priority = ThreadPriority.Normal ;
            workerThread.Start();

        }

    }
}
