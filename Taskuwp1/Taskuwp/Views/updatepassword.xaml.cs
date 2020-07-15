using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite.Net.Attributes;
using Taskuwp.Models;
using Google.Apis.Discovery;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class updatepassword : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public updatepassword()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
          "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }
        string param;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            param= e.Parameter as  string;
        }

        private async void upassword_Click(object sender, RoutedEventArgs e)
        {
            string userid,password;
            var checkuserid = conn.Table<Employeedetails>();
            userid = uid.Text;
            password = pwd.Password;
            int usid = Convert.ToInt32(userid);
            if (pwd.Password == reenterpwd.Password)

            {
             
              
 

                foreach (var details in checkuserid)

                {
                    if (param == details.Username && usid == details.userid)
                    {
                        conn.Execute("UPDATE Employeedetails SET Password = ? Where userid = ?", password, usid);
                        break;
                    }
                }
                MessageDialog sucessdialog = new MessageDialog("Password update successfully!");
                await sucessdialog.ShowAsync();
            }
            else
            {
                MessageDialog errdialog = new MessageDialog("password and conform password does not match!");
                await errdialog.ShowAsync();
            }
        }
    }
}
