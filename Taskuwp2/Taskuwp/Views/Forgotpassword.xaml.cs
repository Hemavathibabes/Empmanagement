
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Google.Apis.Auth.OAuth2;
using SQLite.Net.Attributes;
using Taskuwp.Models;
using System.ServiceModel.Channels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Forgotpassword : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public Forgotpassword()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
           "db.People");
            conn = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        private async void sendemail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tomail = emailid.Text;
                bool ifuser = false;
               string id = "0";
                var getid= conn.Table<Employeedetails>();
                foreach(var msg in getid)
                {

                  if(tomail==msg.Username)
                    {
                        ifuser = true;
                        id = Convert.ToString(msg.userid);
                        break;
                       
                    }

                }
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Anandan Lingusamy", "anandanlingu@gmail.com"));
                message.To.Add(new MailboxAddress(" ", tomail));
                message.Subject = "Password update";

                message.Body = new TextPart("plain")
                {
                    Text = "Your userid is:" + id
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);


                    client.Authenticate("anandanhemavathi@gmail.com", "aruheemavathi");

                    client.Send(message);
                    client.Disconnect(true);

                }
                this.Frame.Navigate(typeof(updatepassword),tomail);

                if (ifuser==false)
                {
                    MessageDialog userstatus = new MessageDialog("There is no user registered with the mailid");
                    await userstatus.ShowAsync();
                }

                
                 
            }
            catch
            {
                MessageDialog errdialog = new MessageDialog("There was a problem in sending email...please create a new account");
                await errdialog.ShowAsync();

            }

        }
    }
}
