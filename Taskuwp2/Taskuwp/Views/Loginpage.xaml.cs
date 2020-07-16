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
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Loginpage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public Loginpage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,"db.People");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }
        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Signuppage), null, new SuppressNavigationTransitionInfo());
        }

        private  async void login_Click(object sender, RoutedEventArgs e)
        {
           
           int loginstatus = 0;
            var checkquery = conn.Table<Employee>();
            foreach (var message in checkquery)
            {
                if (email.Text == message.Emailid)
                {
                    loginstatus = 1;
                    if (email.Text == message.Emailid && password.Password == message.password)
                    {
                       
                        loginstatus = 2;
                        break;
                    }
                }
               
            }
             if(loginstatus==1)
            {
                MessageDialog faillogin = new MessageDialog("Username and password does not match!");
                await faillogin.ShowAsync();

            }
            if (loginstatus==0)
            {
               MessageDialog failurelogin = new MessageDialog("You didn't created a account...!");
                await failurelogin.ShowAsync();
            }
            if (loginstatus == 2)
            {
                this.Frame.Navigate(typeof(Homepage), email.Text,new SuppressNavigationTransitionInfo());
            }
        }

        private void forgotpassword_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Forgotpassword), null, new SuppressNavigationTransitionInfo());
        }
    }
}
