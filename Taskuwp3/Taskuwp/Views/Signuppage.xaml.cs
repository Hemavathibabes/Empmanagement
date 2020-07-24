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
    public sealed partial class Signuppage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public Signuppage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
           "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Employeedetails>();
        }
        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Loginpage), null, new SuppressNavigationTransitionInfo());
        }

        private  async void signup_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != " "  &&  password.Password != " ")
            {
                if (password.Password == reenterpassword.Password)
                {

                    try

                    {
                        var insertquery = conn.Insert(new Employeedetails()
                        {
                           
                            Username = username.Text,
                            Password = password.Password
                        });
                        MessageDialog sucessdialog = new MessageDialog("Account created successfully!");
                        await sucessdialog.ShowAsync();
                    }
                    catch
                    {
                        MessageDialog namechangedialog = new MessageDialog("Username is already exist..try another one!!");
                        await namechangedialog.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog errordialog = new MessageDialog("Password and reenter password does not match..Try again!");
                    errordialog.Commands.Add(new UICommand("Ok", null));
                    await errordialog.ShowAsync();
                }
            }
            else
            {
                MessageDialog emptyfield = new MessageDialog("Please enter the above fields");
                await emptyfield.ShowAsync();
            }


        }
    }
}
