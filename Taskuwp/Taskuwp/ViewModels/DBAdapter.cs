using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using Taskuwp.Models;
using Taskuwp.Views;
namespace Taskuwp.ViewModels
{
   public class DBAdapter
    {
        protected static  string path;

        public static SQLite.Net.SQLiteConnection conn;
        public static void InitializeConnection()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Employeemanagement.db");
            conn = new SQLite.Net.SQLiteConnection(new
                  SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Employee>();

            conn.CreateTable<Teamdetails>();
        }
    }
}
