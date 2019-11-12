using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;

namespace SqliteWin10
{
    class LocalDatabase
    {
        public static void CreateDatabase()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Contactdb.sqlite");

            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                conn.CreateTable<Contact>();
            }
        }
    }
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }

}
