
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
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Security;
using Taskuwp.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Taskuwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Forgotpassword : Page
    {
      
        public Forgotpassword()
        {
            this.InitializeComponent();
           
        }

        private readonly Random _random = new Random();
        private async void sendemail_Click(object sender, RoutedEventArgs e)
        {
            string tomail = emailid.Text;
            try
            {
               
              
                int loginstatus;
              loginstatus=ViewModels.Loginuser.checkvaliduser(tomail, " ");
                if (loginstatus == 1)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Anandan Lingusamy", "anandanlingu@gmail.com"));
                    message.To.Add(new MailboxAddress(" ", tomail));
                    message.Subject = "Password update";
                    int num = _random.Next(100000);
                    message.Body = new TextPart("plain")
                    {
                        Text = "Your Temporary userid is:" + num
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);


                        client.Authenticate("anandanhemavathi@gmail.com", "aruheemavathi");

                        client.Send(message);
                        client.Disconnect(true);

                    }
                    Employee emp = new Employee();


                    emp.empid = num;
                    emp.Emailid = tomail;


                    this.Frame.Navigate(typeof(updatepassword), emp);
                }

                if (loginstatus==0)
                {
                    MessageDialog userstatus = new MessageDialog("There is no user registered with the mailid");
                    await userstatus.ShowAsync();
                }

                
                 
            }
            catch
            {
                MessageDialog errdialog = new MessageDialog("There was a problem in sending email...please connect a internet");
                await errdialog.ShowAsync();

            }

        }
    }
}
